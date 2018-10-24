using System;

namespace PolicyApp.Store
{
	public interface IClientPolicyStore
	{
		void DeleteClientPolicy(Guid P_Id);
	}
}