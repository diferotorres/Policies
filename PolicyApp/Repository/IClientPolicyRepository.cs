using PolicyApp.Models;
using System;

namespace PolicyApp.Repository
{
	public interface IClientPolicyRepository
	{
		void DeleteClientPolicy(Guid P_Id);
		void DeletePolicyFromClient(ClientPolicy clientPolicy);
		ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy);
	}
}