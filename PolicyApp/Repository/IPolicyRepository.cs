using System.Collections.Generic;
using PolicyApp.Models;
using System;

namespace PolicyApp.Repository
{
	public interface IPolicyRepository
	{
		IEnumerable<Policy> GetAllPolicies();
		Policy GetPolicyById(Guid P_Id);
	}
}