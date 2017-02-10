using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Disposables;

namespace UserApp.Helpers
{
    public static class NotifyPropertyChangeHelpers
    {
        public static IDisposable AddPropertyChangeHandler<T>(this T obj, Action<T> action, params Expression<Func<T, object>>[] properties)
            where T : INotifyPropertyChanged
        {
            return AddPropertyChangeHandler(obj, () => action(obj), properties);
        }

        public static IDisposable AddPropertyChangeHandler<T>(this T obj, Action action, params Expression<Func<T, object>>[] properties)
            where T : INotifyPropertyChanged
        {
            var propertyNames = properties.Select(GetPropertyName);
            PropertyChangedEventHandler handler = (s, e) =>
            {
                if (propertyNames.Contains(e.PropertyName))
                {
                    action();
                }
            };

            obj.PropertyChanged += handler;

            return Disposable.Create(() => obj.PropertyChanged -= handler);
        }

        public static string GetPropertyName<T>(Expression<Func<T,object>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }
}
