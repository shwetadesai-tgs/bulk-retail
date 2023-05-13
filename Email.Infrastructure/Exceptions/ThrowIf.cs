using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Email.Infrastructure.Exceptions
{
    public static class ThrowIf
    {
        public static void IsPropertyNull<T>(Expression<Func<T>> expression) where T : class
        {
            if (expression.Compile().Invoke() == null)
            {
                throw new RequiredPropertyNullException(GetName(expression));
            }
        }

        public static void IsArgumentNull<T>(Expression<Func<T>> expression) where T : class
        {
            if (expression.Compile().Invoke() == null)
            {
                throw new ArgumentNullException(GetName(expression));
            }
        }

        private static string GetName<T>(Expression<Func<T>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}
