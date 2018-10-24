using PolicyApp.Models;
using PolicyApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Repository
{
	public class PolicyTypeRepository : IPolicyTypeRepository
	{
		public PolicyTypeRepository(IPolicyTypeStore policyTypeStore = null)
		{
			_policyTypeStore = policyTypeStore ?? new PolicyTypeStore();
		}
		public IEnumerable<PolicyType> FindAllTypes()
		{
			var policyTypes = _policyTypeStore.FindAllTypes();
			return policyTypes;
		}
		public PolicyType FindTypeById(Guid T_Id)
		{
			var policyType = _policyTypeStore.FindTypeById(T_Id);
			return policyType;
		}
		private readonly IPolicyTypeStore _policyTypeStore;
		
	}
}