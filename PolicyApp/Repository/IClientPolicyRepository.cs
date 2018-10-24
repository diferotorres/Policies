using PolicyApp.Models;
using System;

namespace PolicyApp.Repository
{
	public interface IClientPolicyRepository
	{
		void DeleteClientPolicy(Guid P_Id);
		ClientPolicy CreateClientPolicy(ClientPolicy clientPolicy);
	}
}