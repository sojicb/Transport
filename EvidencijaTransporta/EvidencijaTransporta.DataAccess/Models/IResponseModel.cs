using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models
{
	public interface IResponseModel
	{
		int Id { get; set; }
		IResponseModel MapToObject(SqlDataReader reader);
	}
}
