using System;
using System.Collections.Generic;
using PolicyApp.Models;

namespace PolicyApp.Repository
{
	public interface IPolicyTypeRepository
	{
		IEnumerable<PolicyType> FindAllTypes();
		PolicyType FindTypeById(Guid T_Id);
	}
}