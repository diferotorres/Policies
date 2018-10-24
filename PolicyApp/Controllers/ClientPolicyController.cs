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
    public class ClientPolicyController : ApiController
    {
		public ClientPolicy Post([FromBody] ClientPolicy clientPolicy)
		{
			var newClientPolicy = _clientPolicyRepository.CreateClientPolicy(clientPolicy);
			return newClientPolicy;
		}
		private readonly IClientPolicyRepository _clientPolicyRepository = new ClientPolicyRepository();
    }
}
