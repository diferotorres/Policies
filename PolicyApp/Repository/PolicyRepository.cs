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
		public PolicyRepository(IPolicyStore policyStore = null, IClientPolicyRepository clientPolicyRepository = null)
		{
			_policyStore = policyStore ?? new PolicyStore();
			_clientPolicyRepository = clientPolicyRepository ?? new ClientPolicyRepository();
		}

		public IEnumerable<Policy> GetAllPolicies()
		{
			return _policyStore.GetAllPolicies();
		}
		public Policy GetPolicyById(Guid P_Id)
		{
			return _policyStore.GetPolicyById(P_Id);
		}
		public Policy CreatePolicy(Policy policy)
		{
			return _policyStore.CreatePolicy(policy);
		}
		public Policy UpdatePolicy(Policy policy)
		{
			return _policyStore.UpdatePolicy(policy);
		}
		public void DeletePolicy(Guid P_Id)
		{
			_clientPolicyRepository.DeleteClientPolicy(P_Id);
			_policyStore.DeletePolicy(P_Id);
		}
		private readonly IPolicyStore _policyStore;
		private readonly IClientPolicyRepository _clientPolicyRepository;
	}
}