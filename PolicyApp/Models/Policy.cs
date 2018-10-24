using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicyApp.Models
{
	public class Policy
	{
		public Guid P_Id { get; set; }
		public string P_Name { get; set; }
		public string P_Description { get; set; }
		public Guid P_TypeID { get; set; }
		public DateTime P_StartDate { get; set; }
		public double P_Price { get; set; }
		public short P_Period_Months { get; set; }
		public int P_RiskType { get; set; }
		public string C_Name { get; set; }
		public string C_Identity { get; set; }
		public string PolicyType { get; set; }
		public RiskCategory RiskType
		{
			get => (RiskCategory)this.P_RiskType;
			set => this.P_RiskType = (int)value;
		}
		
	}
}