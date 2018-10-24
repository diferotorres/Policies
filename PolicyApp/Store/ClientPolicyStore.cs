using Dapper;
using PolicyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
	}
}