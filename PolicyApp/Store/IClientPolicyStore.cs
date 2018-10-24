using PolicyApp.Models;
using System;

namespace PolicyApp.Store
{
	public interface IClientPolicyStore
	{
		void DeleteClientPolicy(Guid P_Id);
		void DeletePolicyFromClient(ClientPolicy clientPolicy);
		ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy);
	}
}