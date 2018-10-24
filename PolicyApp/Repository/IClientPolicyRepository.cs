using System;

namespace PolicyApp.Repository
{
	public interface IClientPolicyRepository
	{
		void DeleteClientPolicy(Guid P_Id);
	}
}