using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Models
{
	public class ClientPolicy
	{
		public Guid P_ID { get; set; }
		public Guid C_ID { get; set; }
		public DateTime PC_StartDate { get; set; }
	}
}