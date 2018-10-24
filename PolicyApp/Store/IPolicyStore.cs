using System.Collections.Generic;
using PolicyApp.Models;
using System;

namespace PolicyApp.Store
{
	public interface IPolicyStore
	{
		IEnumerable<Policy> GetAllPolicies();
		Policy GetPolicyById(Guid P_Id);
		Policy CreatePolicy(Policy policy);
		Policy UpdatePolicy(Policy policy);
		void DeletePolicy(Guid P_Id);
	}
}