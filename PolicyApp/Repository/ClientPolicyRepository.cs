using PolicyApp.Models;
using PolicyApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Repository
{
	public class ClientPolicyRepository : IClientPolicyRepository
	{
		public ClientPolicyRepository(IClientPolicyStore clientPolicyStore=null)
		{
			_clientPolicyStore = clientPolicyStore ?? new ClientPolicyStore();
		}
		public void DeleteClientPolicy(Guid P_Id)
		{
			_clientPolicyStore.DeleteClientPolicy(P_Id);
		}
		public ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy)
		{
			var newClientPolicy = _clientPolicyStore.CreateClientPolicy(clientPolicy);
			return newClientPolicy;
		}
		private readonly IClientPolicyStore _clientPolicyStore;
	}
}