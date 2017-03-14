using System;
using System.Linq;
using Xamarin.Forms;

namespace UserApp.Common.Effects
{
    public static class EffectProperties
    {
        public static readonly BindableProperty EffectsProperty = BindableProperty.Create("Effects",
            typeof(Type[]), typeof(EffectProperties), new Type[0], propertyChanged: OnEffectsChanged);


        public static void SetEffects(BindableObject view, Type[] effects)
        {
            view.SetValue(EffectsProperty, effects);
        }

        public static Type[] GetEffects(BindableObject view)
        {
            return (Type[])view.GetValue(EffectsProperty);
        }

        private static void OnEffectsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            var oldEffects = (Type[])oldValue;
            var newEffects = (Type[])newValue;

            foreach (var oldEffect in oldEffects.Where(x => !newEffects.Contains(x)))
            {
                RemoveEffect(view, oldEffect);
            }

            foreach (var newEffect in newEffects.Where(x => !view.Effects.Select(y => y.GetType()).Contains(x)))
            {
                AddEffect(view, newEffect);
            }
        }

        private static void RemoveEffect(View view, Type effectType)
        {
            var effectToRemove = view.Effects.FirstOrDefault(e => e.GetType() == effectType);
            if (effectToRemove != null)
            {
                view.Effects.Remove(effectToRemove);
            }
        }

        private static void AddEffect(View view, Type effectType)
        {
            var effect = (Effect)Activator.CreateInstance(effectType);
            view.Effects.Add(effect);
        }
    }
}