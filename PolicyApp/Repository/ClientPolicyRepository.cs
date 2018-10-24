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
		private readonly IClientPolicyStore _clientPolicyStore;
	}
}