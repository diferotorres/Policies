using System.Collections.Generic;
using PolicyApp.Models;

namespace PolicyApp.Store
{
	public interface IClientStore
	{
		IEnumerable<Client> GetAllClients();
	}
}