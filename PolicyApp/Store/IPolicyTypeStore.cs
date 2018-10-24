using System.Collections.Generic;
using PolicyApp.Models;
using System;

namespace PolicyApp.Store
{
	public interface IPolicyTypeStore
	{
		IEnumerable<PolicyType> FindAllTypes();
		PolicyType FindTypeById(Guid T_Id);
	}
}