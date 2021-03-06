using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace EvidencijaTransporta.Web.Extesnions
{
	public static class HtmlHelperExtension
	{
		public static void ActionLink<TController>(this HtmlHelper html, string linkText, Expression<Action<TController>> expression, params object[] methodArguments)
			where TController : Controller
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (methodArguments == null) throw new ArgumentNullException(nameof(methodArguments));

			MethodInfo methodInfo = GetMethodInfo(expression);

			string controllerName = typeof(TController).Name.RemoveSuffix("Controller");

			RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
			MatchArgumentsWithMethodParameters(methodInfo, (key, value) => routeValueDictionary.Add(key, value), methodArguments);

			html.ActionLink(linkText, methodInfo.Name, controllerName, routeValueDictionary);

		}

		private static MethodInfo GetMethodInfo<T>(Expression<T> expression)
		{
			if (!(expression.Body is MethodCallExpression body))
				throw new ArgumentException("Expression has to specify an existing method on the type T.", nameof(expression));

			return body.Method;
		}

		private static void MatchArgumentsWithMethodParameters(MethodInfo methodInfo, Action<string, object> action, params object[] methodArguments)
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != methodArguments.Length)
			{
				throw new ArgumentException("Number of provided arguments doesn't match with number of method parameters.", nameof(methodArguments));
			}

			IEnumerator parametersEnumerator = parameters.GetEnumerator();
			IEnumerator argumentsEnumerator = methodArguments.GetEnumerator();

			while (parametersEnumerator.MoveNext() && argumentsEnumerator.MoveNext())
			{
				action(((ParameterInfo)parametersEnumerator.Current).Name, argumentsEnumerator.Current);
			}
		}
	}
}