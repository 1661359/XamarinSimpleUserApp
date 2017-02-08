
# IronKit.Validation component

Component provides convinient way to setup validation on Xamarin applications build in according to MVVM pattern with XAML views.

It provides a set of interfaces to validate model, and several attached properties to bind it with your views.

## Usage exaple

Let's imagine we have login page splitted into xaml page(or view) and view-model class:

```cs
public class LoginViewModel : INotifyPropertyChanged
{
	// ..
	public string UserName
	{
		get { return userName; }
		set
		{
			userName = value;
			OnPropertyChanged();
		}
	}

	public string Password
	{
		get { return password; }
		set
		{
			password = value;
			OnPropertyChanged();
		}
	}
	// ..
}
```

Login form in xaml looks like:

```xml
<Label>Login</Label>
<Entry Text="{Binding UserName}"
        Placeholder="Login"
        Style="{StaticResource EntryStyle}"/>
      
<Label>Password</Label>
<Entry Text="{Binding Password}"
        Placeholder="Password"
        Style="{StaticResource EntryStyle}"/>
      
<Button Text="Login" Clicked="Button_OnClicked" />
```

We need few things to add validation to this form.
Firstly, you need to add validation rules on view-model class.


To do so we can use validation attributes from DataAnnotations.
Also we need to implement interface `IValidatable<TViewModel>`
which contains single property describing validation rules:

```cs
public class LoginViewModel : INotifyPropertyChanged, IValidatable<LoginViewModel>
{
	// ..
	public LoginViewModel()
	{
		ValidationInfo = new ValidationInfo<LoginViewModel>(this);
	}

	public ValidationInfo<LoginViewModel> ValidationInfo { get; }

	[Required]
	[MinLength(3)]
	public string UserName
	{
		get { return userName; }
		set
		{
			userName = value;
			OnPropertyChanged();
		}
	}

	[Required]
	[MinLength(6)]
	public string Password
	{
		get { return password; }
		set
		{
			password = value;
			OnPropertyChanged();
		}
	}
	// ..

}
```

Now we already can perform validation from code:

```cs
	public void Login()
	{
		if (this.IsValid())
		{
			// Auth logic here.
		}
	}
```

or

```cs
	public void Login()
	{
		var invalidProperties = this.GetInvalidProperties();
		if (invalidProperties.Any())
		{
			// Auth logic here.
		}
		else
		{
			// Show errors
		}
	}
```

Next step is to somehow highlight invalid fields on UI. To do so we need to specify
when validation should occur and style elements to indicate invalid state.

Well, to define when validation should occur we need to setup `ValidateOn`
attached property (defined in `IronKit.Validation.Validation` class).

```xml
<Label>Login</Label>
<Entry validation:Validation.ValidateOn="LostFocus"
       Text="{Binding UserName}"
       Placeholder="Login"
       Style="{StaticResource EntryStyle}"/>
      
<Label>Password</Label>
<Entry validation:Validation.ValidateOn="LostFocus"
       Text="{Binding Password}"
       Placeholder="Password"
       Style="{StaticResource EntryStyle}"/>
```

Next step is to highlight invalid state. This can be achieved using `IsValid` attached
property (defined on the same class). This property is of `IronKit.Validation.ValidationState` enum type.
Initially it has value `Unknown` after first validation it becomes either `Valid` or `Invalid`.

We can use triggers to react on this property change:

```xml
<Style TargetType="Entry" x:Key="ValidatableEntry">
  <Style.Triggers>
    <Trigger TargetType="Entry" Property="validation:Validation.ValidationState" Value="Invalid">
      <Setter Property="PlaceholderColor" Value="Red" />
      <Setter Property="TextColor" Value="Red" />
    </Trigger>
    <Trigger TargetType="Entry" Property="validation:Validation.ValidationState" Value="Unknown">
      <Setter Property="PlaceholderColor" Value="Default" />
      <Setter Property="TextColor" Value="Default" />
    </Trigger>
  </Style.Triggers>
</Style>
```

## UI Elements Support

Validation can be set on element of any type. Basically it only should know about bindable
property which is validation target. I.e. `Text` property on `Entry`, or `Date` property on `DatePicker`.
This property can be set via `ValidationProperty` attached property.
There set of predefined values which are used when `ValidationProperty` isn't set.
When you want to add validation on element other then `Entry`, `Editor`, `DatePicker`, `TimePicker`
or it's subclasses, you have to speficify `ValidationProperty` value.

I don't have any suitable custom control how, but for example we can explicitly define property for `Entry`:

```xml
<Entry validation:Validation.ValidateOn="LostFocus"
       validation:Validation.ValidationProperty="{x:Static Entry.TextProperty}"
       Text="{Binding UserName}"
       Placeholder="Login"
       Style="{StaticResource EntryStyle}"/>
```

## Custom Validators
If you need custom validation rules, you have three options:
1. Implement own attribute inherited from `ValidationAttribute` and then apply it to property.

```cs
public class EmailAttribute : ValidationAttribute
{
    public EmailAttribute()
        : base(() => "Email is incorrect.")
    {
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }
        string input = value as string;
        if (ValidationHelpers.IsValidEmail(input))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new List<string> { validationContext.MemberName});
    }
}
```

2. Add custom validation func directly to `ValidationHelper` in your view-model.

```cs
public LoginViewModel()
{
    ValidationInfo = new ValidationInfo<LoginViewModel>(this);
    ValidationInfo.AddValidator(t => !string.IsNullOrWhiteSpace(t.UserName) && emailRegex.IsMatch(t.UserName), nameof(UserName));
}
```

3. Implement custom `IValidator<TViewModel>` and add it directly to `ValidationHelper`.

```cs
public class EmailValidator : IValidator<LoginViewModel>
{
    public IEnumerable<string> GetInvalidProperties(LoginViewModel target)
    {
        return IsValidEmail(target.UserName) ? new string[0] : new[] {nameof(target.UserName)};
    }

    public event EventHandler<ValidationOccurredEventArgs> ValidationOccurred;

    protected virtual void OnValidationOccurred(ValidationOccurredEventArgs e)
    {
        ValidationOccurred?.Invoke(this, e);
    }
}
// ..
public LoginViewModel()
{
    ValidationInfo = new ValidationInfo<LoginViewModel>(this);
    ValidationInfo.AddValidator(new EmailValidator());
}
```

## Background

The main problem solved by this component is correct separation of responsibility:
validation from view-model should be populated to controls bound to it.
When we have marked control as validatable we need to know on which property on the
view-model it is bound.
To achieve this target we have used a bit of black magic i.e. reflection to extract
some internal data of the Binding:
  1. `_properties` private field of the `BindableObject`,
  2. `BindablePropertyContext` nested class in `BindableObject`
  3. `Binding` and `Property` fields of `BindablePropertyContext`.

This functionality incapsulated into `BindingUtils` class and used by single method
`GetBinding(this BindableObject, BindableProperty)` which returns `Binding` object
set on specified object for speficied property.