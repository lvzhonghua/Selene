using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical.Utils
{
    public static class PropertyExpression
    {
        /// <summary>
        /// get property name from expression.
        /// eg: m => m.Name will return Name.
        /// </summary>
        public static string GetPropertyName<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
            {
                if (propertyExpression.Body is UnaryExpression)
                {
                    body = ((propertyExpression.Body as UnaryExpression).Operand as MemberExpression);
                }
            }
            if (body == null)
            {
                throw new ArgumentException("propertyExpression");
            }

            return body.Member.Name;
        }

        /// <summary>
        /// get property full name from expression.
        /// eg: m => m.User.Name will return User.Name.
        /// </summary>
        public static string GetPropertyFullName<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyExpression)
        {
            ParameterExpression modelParameterExpression = null;
            return GetPropertyFullName(propertyExpression, out modelParameterExpression);
        }

        /// <summary>
        /// get service method
        /// </summary>
        public static MethodInfo GetMethod<TService, TRequest, TResponse>(Expression<Func<TService, Func<TRequest, TResponse>>> method)
        {
            return ((((method.Body as UnaryExpression).Operand as MethodCallExpression).Arguments.Last() as ConstantExpression).Value as MethodInfo);
        }

        #region private methods

        public static string GetPropertyFullName<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyExpression,
            out ParameterExpression modelParameterExpression)
        {
            modelParameterExpression = null;
            MemberExpression modelMemberExpression = null;
            BinaryExpression modelBinaryExpression = null;
            UnaryExpression modelUnaryExpression = null;
            MethodCallExpression modelMethodCallExpression = null;
            Stack<string> propertyNameStack = new Stack<string>();

            if (propertyExpression.Body is ParameterExpression)
            {
                propertyNameStack.Push(propertyExpression.Body.ToString());
            }
            else if (propertyExpression.Body is MemberExpression)
            {
                modelMemberExpression = propertyExpression.Body as MemberExpression;
                Loop(modelMemberExpression, propertyNameStack, out modelParameterExpression);
            }
            else if (propertyExpression.Body is BinaryExpression)
            {
                modelBinaryExpression = propertyExpression.Body as BinaryExpression;
                propertyNameStack.Push(CalculateBinaryExpression(ref modelBinaryExpression));
                modelMemberExpression = modelBinaryExpression.Left as MemberExpression;
                Loop(modelMemberExpression, propertyNameStack, out modelParameterExpression);
            }
            else if (propertyExpression.Body is UnaryExpression)
            {
                modelUnaryExpression = propertyExpression.Body as UnaryExpression;
                modelMemberExpression = modelUnaryExpression.Operand as MemberExpression;
                Loop(modelMemberExpression, propertyNameStack, out modelParameterExpression);
            }
            else if (propertyExpression.Body is MethodCallExpression)
            {
                modelMethodCallExpression = propertyExpression.Body as MethodCallExpression;
                modelMemberExpression = modelMethodCallExpression.Object as MemberExpression;
                propertyNameStack.Push(CalculateMethodCallExpression(modelMethodCallExpression));
                Loop(modelMemberExpression, propertyNameStack, out modelParameterExpression);
            }
            else
            {
                throw new NotSupportedException(string.Format("not support for {0}", propertyExpression.ToString()));
            }

            var propertyName = propertyNameStack.Pop();
            while (propertyNameStack.Count > 0)
            {
                var segment = propertyNameStack.Pop();
                var hasPoint = segment.IndexOf("[") < 0;
                propertyName = string.Format("{0}{1}{2}", propertyName, hasPoint ? "." : "", segment);
            }

            return propertyName;
        }

        private static void Loop(
            MemberExpression modelMemberExpression,
            Stack<string> propertyNameStack,
            out ParameterExpression modelParameterExpression)
        {
            modelParameterExpression = null;
            MethodCallExpression modelMethodCallExpression = null;
            BinaryExpression modelBinaryExpression = null;

            do
            {
                if (modelMemberExpression.Expression is ParameterExpression)
                {
                    propertyNameStack.Push(modelMemberExpression.Member.Name);
                    modelParameterExpression = modelMemberExpression.Expression as ParameterExpression;
                }
                else if (modelMemberExpression.Expression is MemberExpression)
                {
                    propertyNameStack.Push(modelMemberExpression.Member.Name);
                    modelMemberExpression = modelMemberExpression.Expression as MemberExpression;
                }
                else if (modelMemberExpression.Expression is BinaryExpression)
                {
                    propertyNameStack.Push(modelMemberExpression.Member.Name);
                    modelBinaryExpression = modelMemberExpression.Expression as BinaryExpression;
                    propertyNameStack.Push(CalculateBinaryExpression(ref modelBinaryExpression));
                    modelMemberExpression = modelBinaryExpression.Left as MemberExpression;
                }
                else if (modelMemberExpression.Expression is MethodCallExpression)
                {
                    propertyNameStack.Push(modelMemberExpression.Member.Name);
                    modelMethodCallExpression = modelMemberExpression.Expression as MethodCallExpression;
                    propertyNameStack.Push(CalculateMethodCallExpression(modelMethodCallExpression));
                    modelMemberExpression = modelMethodCallExpression.Object as MemberExpression;
                }
                else
                {
                    throw new NotSupportedException(string.Format("not support"));
                }
            }
            while (modelParameterExpression == null);
        }

        private static string CalculateMethodCallExpression(MethodCallExpression modelMethodCallExpression)
        {
            string argument = string.Empty;
            string arguments = string.Empty;
            string typeName = modelMethodCallExpression.Type.Name;
            for (int index = 0; index < modelMethodCallExpression.Arguments.Count; index++)
            {
                var value = Expression.Lambda(modelMethodCallExpression.Arguments[index]).Compile().DynamicInvoke();
                if ((value is Int16) || (value is Int32) ||
                    (value is Int64) || (value is Enum) || (value is string))
                {
                    argument = value.ToString();
                }
                else
                {
                    throw new NotSupportedException(string.Format("not support"));
                }

                if (typeName.EndsWith("[]") || typeName.EndsWith("List`1"))
                {
                    arguments = string.Format("[{0}]", argument);
                }
                else
                {
                    arguments += ((arguments.Length == 0) ? "[" : ",");
                    arguments += argument;
                    if ((index + 1) == modelMethodCallExpression.Arguments.Count)
                    {
                        arguments += "]";
                    }
                }
            }

            return arguments;
        }

        private static string CalculateBinaryExpression(ref BinaryExpression modelBinaryExpression)
        {
            // at first calculating right expression
            string arguments = string.Format("[{0}]", Expression.Lambda(modelBinaryExpression.Right).Compile().DynamicInvoke().ToString());

            // and then turning to left expression loop
            do
            {
                modelBinaryExpression = modelBinaryExpression.Left as BinaryExpression;
                if (modelBinaryExpression != null)
                {
                    arguments += string.Format("[{0}]", Expression.Lambda(modelBinaryExpression.Right).Compile().DynamicInvoke().ToString());
                }
            }
            while ((modelBinaryExpression != null) && (modelBinaryExpression.Left is BinaryExpression));

            return arguments;
        }

        #endregion
    }
}
