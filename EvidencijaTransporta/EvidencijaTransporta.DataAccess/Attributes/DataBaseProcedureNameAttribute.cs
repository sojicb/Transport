using System;

namespace EvidencijaTransporta.DataAccess.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class DataBaseProcedureNameAttribute : Attribute
	{
		public DataBaseProcedureNameAttribute(string procedureName)
		{
			ProcedureName = procedureName;
		}

		public string ProcedureName { get; set; }
	}
}
