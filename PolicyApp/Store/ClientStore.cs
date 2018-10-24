using Dapper;
using PolicyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Store
{
	public class ClientStore : IClientStore
	{
		public IEnumerable<Client> GetAllClients()
		{
			const string sql = @"SELECT C_Id
							  ,C_Name
							  ,C_Identity
						  FROM dbo.TClient";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Client>(sql, new { }).ToList();
			}
		}
	}
			
}