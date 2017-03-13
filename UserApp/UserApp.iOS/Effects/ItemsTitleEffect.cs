using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace UserApp.iOS.Effects
{
    public class ItemsTitleEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textview = Control as UILabel;
            if (textview != null)
            {
                textview.TextColor = UIColor.FromRGB(54, 54, 54);
                textview.Font = UIFont.BoldSystemFontOfSize((nfloat)17.0);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}