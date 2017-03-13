using Xamarin.Forms;

namespace UserApp.Common.Effects
{
    public class FlashingEffect : RoutingEffect
    {
        public Color Color
        {
            get;
            set;
        }

        public FlashingEffect() : base("UserApp.FlashingEffect")
        {
            
        }
    }
}