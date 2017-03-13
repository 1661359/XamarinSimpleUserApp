using System.Linq;
using System.Threading.Tasks;
using Android.Widget;
using Java.Lang;
using UserApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(FlashingEffect), "FlashingEffect")]
namespace UserApp.Droid.Effects
{
    public class FlashingEffect : PlatformEffect
    {
        private bool isFlashing;
        private TextView textView;
        private int defaultTextColor;
        private Color newColor;

        protected override void OnAttached()
        {
            textView = Control as TextView;
            if (textView != null)
            {
                defaultTextColor = textView.CurrentTextColor;
                newColor =
                ((Common.Effects.FlashingEffect)
                    Element.Effects.First(x => x is Common.Effects.FlashingEffect)).Color;
                isFlashing = true;
                Task.Factory.StartNew(Flashing);
            }
        }

        private void Flashing()
        {
            while (isFlashing)
            {
                Device.BeginInvokeOnMainThread(SetTextColor);
                Thread.Sleep(1500);
            }
        }

        private void SetTextColor()
        {
            textView.SetTextColor(textView.CurrentTextColor == defaultTextColor
                ? newColor.ToAndroid()
                : new Android.Graphics.Color(defaultTextColor));
        }


        protected override void OnDetached()
        {
            isFlashing = false;    
        }
    }
}