using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Models
{
	public class Client
	{
		public Guid C_Id { get; set; }
		public string C_Name { get; set; }
		public string C_Identity { get; set; }
	}
}