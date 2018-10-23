using PolicyApp.Models;
using PolicyApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Repository
{
	public class PolicyRepository : IPolicyRepository
	{
		public PolicyRepository(IPolicyStore policyStore=null)
		{
			_policyStore = policyStore ?? new PolicyStore();
		}

		public IEnumerable<Policy> GetAllPolicies()
		{
			return _policyStore.GetAllPolicies(); 
		}
		public Policy GetPolicyById(Guid P_Id)
		{
			return _policyStore.GetPolicyById(P_Id);
		}
		private readonly IPolicyStore _policyStore;
	}
}