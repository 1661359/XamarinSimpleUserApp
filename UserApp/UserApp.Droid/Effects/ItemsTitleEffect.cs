using Android.Graphics;
using Android.Widget;
using UserApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ResolutionGroupName("UserApp")]
[assembly:ExportEffect(typeof(ItemsTitleEffect), "ItemsTitleEffect")]
namespace UserApp.Droid.Effects
{
    public class ItemsTitleEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textView = Control as TextView;
            if (textView != null)
            {
                textView.SetTextColor(new Android.Graphics.Color(35, 35, 35));
                textView.SetTypeface(null, TypefaceStyle.Bold);
                
                textView.SetTextAppearance(Resource.Style.Base_TextAppearance_AppCompat_Large);
            }
           
        }

        protected override void OnDetached()
        {
            
        }
    }
}