
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles & Evaluates  the expression that is passed in and return the value underlying value from the expression
        /// </summary>
        /// <typeparam name="T">Return type of the function that this expressins contains</typeparam>
        /// <param name="lambda">the expression itself</param>
        /// <returns></returns>
        public static T GetPropertyValueOfExpression<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }


        /// <summary>
        /// This function reflects through the underlying property that this expression wraps 
        /// and set the value of the property to the value passed in
        /// </summary>
        /// <typeparam name="T">The actual type of the underlying propety value of the expression</typeparam>
        /// <param name="lambda">the expression itself</param>
        /// <param name="value">the value that needs to be set to the propety that this expression wraps up</param>
        public static void SetPropertyValueOfExpression<T>(this Expression<Func<T>> lambda,T value)
        {
            //The process of extracting the actual property from the Expression

            //Converts a Lambda expression to Property
            var expression = (lambda as LambdaExpression).Body as MemberExpression; //Member Expression is an expression that is used to express a  field or Property (Eg:LoginIsRunning)

            //Nw we need to set the property value to the value passed in .
            //For that we need the property info of the property

            var propertyInfo = (PropertyInfo)expression.Member;

            //Get the class in which the property is defined
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);
        }

    }
}
