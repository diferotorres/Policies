using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PolicyApp
{
	internal static class DbFactory
	{
		static DbFactory()
		{
			SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
		}

		public static IDbConnection Create()
		{
			string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			return new SqlConnection(conn);
		}
	}
}