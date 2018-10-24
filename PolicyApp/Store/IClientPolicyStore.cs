using PolicyApp.Models;
using System;

namespace PolicyApp.Store
{
	public interface IClientPolicyStore
	{
		void DeleteClientPolicy(Guid P_Id);
		ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy);
	}
}