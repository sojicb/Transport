using EvidencijaTransporta.Common.HelperModel;
using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EvidencijaTransporta.DataAccess.Models
{
	public abstract class RequestModel<TModel> 
	{
		public string GetClassAttribute()
		{
			DataBaseProcedureNameAttribute attribute = (DataBaseProcedureNameAttribute)Attribute
				.GetCustomAttribute(typeof(TModel), typeof(DataBaseProcedureNameAttribute));

			return attribute.ProcedureName;
		}

		public List<ParameterModel> GetParameters<TType>(TType istance)
		{
			List<ParameterModel> parameters = new List<ParameterModel>();

			foreach (PropertyInfo property in istance.GetType().GetProperties())
			{
				DataBaseRequestParameterNameAttribute attribute = (DataBaseRequestParameterNameAttribute)property.GetCustomAttribute(typeof(DataBaseRequestParameterNameAttribute), false);

				parameters.Add(new ParameterModel
				{
					ParameterName = attribute.AttributeName,
					DbType = attribute.AttributeType,
					Value = property.GetValue(istance)
				});
			}
			return parameters;
		}
	}
}
