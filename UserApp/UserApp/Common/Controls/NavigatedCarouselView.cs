using System.Collections;
using Xamarin.Forms;

namespace UserApp.Common.Controls
{
    public class NavigatedCarouselView : AbsoluteLayout
    {
        private readonly CarouselView carouselView;
        private readonly Image navigateLeft;
        private readonly Image navigateRight;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IList),
                typeof(NavigatedCarouselView),
                null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((NavigatedCarouselView)bindableObject).ItemsSourceChanged();
                }
            );

        public static readonly BindableProperty ItemTemplateProperty =
           BindableProperty.Create
           (
               nameof(ItemTemplate),
               typeof(DataTemplate),
               typeof(NavigatedCarouselView),
               propertyChanged: (bindable, value, newValue) =>
               {
                   ((NavigatedCarouselView)bindable).ItemTemplateChanged();
               }
           );

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }



        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }
            set
            {
                SetValue(ItemTemplateProperty, value);
            }
        }

        public NavigatedCarouselView()
        {
            carouselView = new CarouselView();
            navigateLeft = new Image();
            navigateRight = new Image();
            navigateLeft.Source = new FileImageSource() { File = "back.png" };
            navigateRight.Source = new FileImageSource() { File = "next.png" };

            navigateLeft.Margin = new Thickness(5, 0, 0, 0);
            navigateLeft.Opacity = 0.5;
            SetLayoutBounds(navigateLeft, new Rectangle(1, 0, .1, 1));
            SetLayoutFlags(navigateLeft, AbsoluteLayoutFlags.SizeProportional);

            navigateRight.Margin = new Thickness(0, 0, 5, 0);
            navigateRight.Opacity = 0.5;
            SetLayoutBounds(navigateRight, new Rectangle(1, 0, .1, 1));
            SetLayoutFlags(navigateRight, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.SizeProportional);

            SetLayoutBounds(carouselView, new Rectangle(0, 0, 1, 1));
            SetLayoutFlags(carouselView, AbsoluteLayoutFlags.SizeProportional);

            HorizontalOptions = LayoutOptions.FillAndExpand;

            Children.Add(carouselView);
            Children.Add(navigateLeft);
            Children.Add(navigateRight);

            carouselView.ItemSelected += CarouselView_ItemSelected;
        }

        private void CarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SetNavigationButtonsVisibility(e.SelectedItem);
        }

        private void SetNavigationButtonsVisibility(object item)
        {
            if (ItemsSource == null || ItemsSource.Count < 2)
            {
                navigateRight.IsVisible = false;
                navigateLeft.IsVisible = false;
                return;
            }

            navigateRight.IsVisible = item != ItemsSource[ItemsSource.Count - 1];
            navigateLeft.IsVisible = item != ItemsSource[0];
        }

        private void ItemsSourceChanged()
        {
            carouselView.ItemsSource = ItemsSource;
        }

        private void ItemTemplateChanged()
        {
            carouselView.ItemTemplate = ItemTemplate;
        }

    }
}