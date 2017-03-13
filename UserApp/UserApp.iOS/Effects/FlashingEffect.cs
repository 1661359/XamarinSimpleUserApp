using UserApp.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(FlashingEffect), "FlashingEffect")]
namespace UserApp.iOS.Effects
{
    public class FlashingEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            
        }

        protected override void OnDetached()
        {

        }
    }