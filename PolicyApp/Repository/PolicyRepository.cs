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
		public PolicyRepository(IPolicyStore policyStore = null,
			IClientPolicyRepository clientPolicyRepository = null,
			IPolicyTypeRepository policyTypeRepository = null)
		{
			_policyStore = policyStore ?? new PolicyStore();
			_clientPolicyRepository = clientPolicyRepository ?? new ClientPolicyRepository();
			_policyTypeRepository = policyTypeRepository ?? new PolicyTypeRepository();
		}

		public IEnumerable<Policy> GetAllPolicies()
		{
			var policies = _policyStore.GetAllPolicies();
			foreach (var item in policies)
			{
				var policyType = _policyTypeRepository.FindTypeById(item.P_TypeID);
				item.PolicyType = policyType.T_Name;
			}
			return policies;
		}
		public Policy GetPolicyById(Guid P_Id)
		{
			var policy = _policyStore.GetPolicyById(P_Id);
			var policyType = _policyTypeRepository.FindTypeById(policy.P_TypeID);
			policy.PolicyType = policyType.T_Name;
			return policy;
		}
		public Policy CreatePolicy(Policy policy)
		{
			var policyType = _policyTypeRepository.FindTypeById(policy.P_TypeID);
			if (policyType.T_Percent > 50 && policy.P_RiskType == (int)RiskCategory.alto)
				throw new HttpRequestValidationException("No es posible cubrir más del 50% cuando el riesgo es alto");
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
		private readonly IPolicyTypeRepository _policyTypeRepository;
	}
}