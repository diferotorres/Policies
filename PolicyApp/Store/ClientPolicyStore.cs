using Dapper;
using PolicyApp.Models;
using System;
using System.Linq;

namespace PolicyApp.Store
{
	public class ClientPolicyStore : IClientPolicyStore
	{
		public void DeleteClientPolicy(Guid P_Id)
		{
			const string sql = @"DELETE FROM dbo.TClientPolicy
								WHERE P_Id=@P_Id";
			using (var dbConnection = DbFactory.Create())
			{
				dbConnection.Query<ClientPolicy>(sql, new { P_Id });
			}
		}
		public void DeletePolicyFromClient(ClientPolicy clientPolicy)
		{
			const string sql = @"DELETE FROM dbo.TClientPolicy
								WHERE P_Id=@P_ID AND C_Id = @C_ID";
			var queryParams = new
			{
				clientPolicy.P_ID,
				clientPolicy.C_ID
			};
			using (var dbConnection = DbFactory.Create())
			{
				dbConnection.Query<ClientPolicy>(sql, queryParams);
			}
		}
		public ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy)
		{
			const string sql = @"INSERT INTO dbo.TClientPolicy (P_ID,C_ID,PC_StartDate)
								VALUES(@P_ID,@C_ID,@PC_StartDate)";
			var queryParams = new {
				clientPolicy.P_ID,
				clientPolicy.C_ID,
				clientPolicy.PC_StartDate
			};
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<ClientPolicy>(sql, queryParams).FirstOrDefault();
			}
		}
	}
}