using PolicyApp.Models;
using PolicyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PolicyApp.Controllers
{	
	
	public class PolicyController : ApiController
    {
		
		public IEnumerable<Policy> Get()
		{
			var policies = _policyRepository.GetAllPolicies();
			return policies;
		}

		
		public int Get(int policyId)
		{
			//var policy = _policyRepository.GetPolicyById(policyId);
			return 5;
		}

		private readonly IPolicyRepository _policyRepository = new PolicyRepository();
	}
}
