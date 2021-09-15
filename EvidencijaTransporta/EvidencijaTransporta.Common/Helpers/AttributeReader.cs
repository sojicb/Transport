using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.Common.Helpers
{
	public class AttributeReader
	{
		/// <summary>
		/// Method that returns the class Attribute from any given class.
		/// </summary>
		/// <typeparam name="TType">Class that has the attribute</typeparam>
		/// <typeparam name="TAttribute">Attributes name</typeparam>
		/// <returns>Returns the custom attribute from the given class and attribute name</returns>
		public static TAttribute GetClassAttribute<TType, TAttribute>()
			where TAttribute : Attribute
		{
			return (TAttribute)Attribute.GetCustomAttribute(typeof(TType), typeof(TAttribute));
		}
	}
}
