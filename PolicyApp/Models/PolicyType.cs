using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Models
{
	public class PolicyType
	{
		public Guid T_Id { get; set; }
		public string T_Name { get; set; }
		public int T_Percent { get; set; }
	}
}