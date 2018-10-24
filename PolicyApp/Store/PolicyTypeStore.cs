using Dapper;
using PolicyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Store
{
	public class PolicyTypeStore : IPolicyTypeStore
	{
		public IEnumerable<PolicyType> FindAllTypes()
		{
			const string sql = @"SELECT T_Id,T_Name,T_Percent FROM dbo.TType";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<PolicyType>(sql, new { }).ToList();
			}
		}
		public PolicyType FindTypeById(Guid T_Id)
		{
			const string sql = @"SELECT T_Id,T_Name,T_Percent FROM dbo.TType WHERE T_Id=@T_Id";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<PolicyType>(sql, new { T_Id }).FirstOrDefault();
			}
		}
	}
}