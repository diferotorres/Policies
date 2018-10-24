using Dapper;
using PolicyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyApp.Store
{

	public class PolicyStore : IPolicyStore
	{
		public IEnumerable<Policy> GetAllPolicies()
		{
			const string sql = @"SELECT po.P_Id
								,po.P_Name
								,po.P_Description
								,po.P_TypeID
								,po.P_StartDate
								,po.P_Price
								,po.P_Period_Months
								,po.P_RiskType
								,cl.C_Name 
								,cl.C_Identity	
							FROM dbo.Tpolicy po 
							INNER JOIN dbo.TClientPolicy cp on po.P_Id = cp.P_ID 
							INNER JOIN dbo.TClient cl on cl.C_Id = cp.C_ID";
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, new{}).ToList();
			}
		}
		public Policy GetPolicyById(Guid P_Id)
		{
			const string sql = @"SELECT po.P_Id
								,po.P_Name
								,po.P_Description
								,po.P_TypeID
								,po.P_StartDate
								,po.P_Price
								,po.P_Period_Months
								,po.P_RiskType
								,cl.C_Name 
								,cl.C_Identity	
							FROM dbo.Tpolicy po 
							INNER JOIN dbo.TClientPolicy cp on po.P_Id = cp.P_ID 
							INNER JOIN dbo.TClient cl on cl.C_Id = cp.C_ID WHERE po.P_Id = @P_Id";
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
				policy.P_Period_Months,
				policy.P_RiskType
			};
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, queryParams).FirstOrDefault();
			}
		}

		public Policy UpdatePolicy(Policy policy)
		{
			const string sql = @"UPDATE dbo.Tpolicy
								   SET 
									  P_Name = @P_Name
									  ,P_Description = @P_Description
									  ,P_TypeID = @P_TypeID
									  ,P_StartDate = @P_StartDate
									  ,P_Price = @P_Price
									  ,P_Period_Months = @P_Period_Months
									  ,P_RiskType = @P_RiskType
								 WHERE P_Id = @P_Id

								SELECT P_Id,P_Name,P_Description,P_TypeID,P_StartDate,P_Price,P_Period_Months,P_RiskType
								FROM dbo.Tpolicy WHERE P_Id = @P_Id";
			var queryParams = new
			{
				policy.P_Id,
				policy.P_Name,
				policy.P_Description,
				policy.P_TypeID,
				policy.P_StartDate,
				policy.P_Price,
				policy.P_Period_Months,
				policy.P_RiskType
			};
			using (var dbConnection = DbFactory.Create())
			{
				return dbConnection.Query<Policy>(sql, queryParams).FirstOrDefault();
			}
		}
		public void DeletePolicy(Guid P_Id)
		{
			const string sql = @"DELETE FROM dbo.Tpolicy
								WHERE P_Id=@P_Id";
			using (var dbConnection = DbFactory.Create())
			{
				dbConnection.Query<Policy>(sql, new { P_Id });
			}
		}
	}
}