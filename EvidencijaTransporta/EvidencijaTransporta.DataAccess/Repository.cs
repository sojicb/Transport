using EvidencijaTransporta.DataAccess.Models;
using EvidencijaTransporta.Common.HelperModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;

namespace EvidencijaTransporta.DataAccess
{
	public class Repository : IDisposable
	{
		//private readonly string _connectionString = ConfigurationManager.ConnectionStrings["IP_PK2020Usluge3"].ConnectionString;
		private readonly string _connectionString = "Data Source=.;Initial Catalog=IP_PK2020Usluge3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public virtual List<TResponse> GetListStoredProcedure<TResponse, TRequest>(TRequest request)
			where TResponse : IResponseModel, new()
			where TRequest : RequestModel<TRequest>, new()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = request.GetClassAttribute();
					command.CommandType = CommandType.StoredProcedure;

					List<TResponse> response = new List<TResponse>();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response.Add((TResponse)new TResponse().MapToObject(reader));
						}
					}
					return response;
				}
			}
		}

		public virtual List<TResponse> GetListStoredProcedureWithParameters<TResponse, TRequest>(TRequest request)
			where TResponse : IResponseModel, new()
			where TRequest : RequestModel<TRequest>, new()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = request.GetClassAttribute();
					command.CommandType = CommandType.StoredProcedure;

					foreach (ParameterModel parameter in request.GetParameters(request))
					{
						command.Parameters.Add(parameter.ParameterName, parameter.DbType);
						command.Parameters[parameter.ParameterName].Value = parameter.Value;
					}

					List<TResponse> response = new List<TResponse>();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response.Add((TResponse)new TResponse().MapToObject(reader));
						}
					}
					return response;
				}
			}
		}

		public virtual TResponse ExecuteProcedureWithParameters<TRequest, TResponse>(TRequest request)
			where TResponse : IResponseModel, new()
			where TRequest : RequestModel<TRequest>, new()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = request.GetClassAttribute();
					command.CommandType = CommandType.StoredProcedure;

					foreach(ParameterModel parameter in request.GetParameters(request))
					{
						command.Parameters.Add(parameter.ParameterName, parameter.DbType);
						command.Parameters[parameter.ParameterName].Value = parameter.Value;
					}

					TResponse response = new TResponse();

					using(SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response.MapToObject(reader);
						}
					}

					return response;
				}
			}
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
