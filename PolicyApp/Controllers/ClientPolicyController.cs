using PolicyApp.Models;
using PolicyApp.Repository;
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
		public void Delete([FromBody] ClientPolicy clientPolicy)
		{
			_clientPolicyRepository.DeletePolicyFromClient(clientPolicy);
		}
		private readonly IClientPolicyRepository _clientPolicyRepository = new ClientPolicyRepository();
    }
}
