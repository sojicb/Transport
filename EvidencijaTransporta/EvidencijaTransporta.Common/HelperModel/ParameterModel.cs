using System.Data;

namespace EvidencijaTransporta.Common.HelperModel
{
	public class ParameterModel
	{
		public string ParameterName { get; set; }
		public SqlDbType DbType { get; set; }
		public object Value { get; set; }
	}
}
