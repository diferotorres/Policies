using Dapper;
using PolicyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Store
{

	public class PolicyStore : IPolicyStore
	{
		public IEnumerable<Policy> GetAllPolicies()
		{
			const string sql = @"SELECT P_Id
							  ,P_Name
							  ,P_Description
							  ,P_TypeID
							  ,P_StartDate
							  ,P_Price
							  ,P_Period_Months
							  ,P_RiskType
							FROM dbo.Tpolicy";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, new{}).ToList();
			}
		}
		public Policy GetPolicyById(Guid P_Id)
		{
			const string sql = @"SELECT P_Id
							  ,P_Name
							  ,P_Description
							  ,P_TypeID
							  ,P_StartDate
							  ,P_Price
							  ,P_Period_Months
							  ,P_RiskType
							FROM dbo.Tpolicy WHERE P_Id = @P_Id";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, new {P_Id }).FirstOrDefault();
			}
		}

		public Policy CreatePolicy(Policy policy)
		{
			const string sql = @" DECLARE @resultSet table(P_Id UNIQUEIDENTIFIER);

								INSERT INTO dbo.Tpolicy
								   (P_Name,P_Description,P_TypeID,P_StartDate,P_Price,P_Period_Months,P_RiskType)
								OUTPUT inserted.P_Id INTO @resultSet
								VALUES(@P_Name,@P_Description,@P_TypeID,@P_StartDate,@P_Price,@P_Period_Months,@P_RiskType)
								
								SELECT P_Id,P_Name,P_Description,P_TypeID,P_StartDate,P_Price,P_Period_Months,P_RiskType
								FROM dbo.Tpolicy WHERE P_Id IN (SELECT P_Id FROM @resultSet)";
			var queryParams = new {
				policy.P_Name,
				policy.P_Description,
				policy.P_TypeID,
				policy.P_StartDate,
				policy.P_Price,
				policy.P_PeriodMonths,
				policy.P_RiskType
			};
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, queryParams).FirstOrDefault();
			}
		}
	}
}