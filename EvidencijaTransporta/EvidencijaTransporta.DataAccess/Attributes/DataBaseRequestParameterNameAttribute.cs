using System;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
	public class DataBaseRequestParameterNameAttribute : Attribute
	{
		public DataBaseRequestParameterNameAttribute(string attributeName, SqlDbType attributeType)
		{
			AttributeName = attributeName;
			AttributeType = attributeType;
		}

		public string AttributeName { get; set; }
		public SqlDbType AttributeType { get; set; }
	}
}
