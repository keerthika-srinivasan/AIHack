using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEngine.Repository
{
    public class BaseRepository
    {
        public BaseRepository()
        {

            con = new SqlConnection(ConnectionString);
        }
        protected SqlConnection con { get; set; }

        private static string ConnectionString
        {
            get
            {
                var t = Convert.ToString(ConfigurationManager.AppSettings["ConnectionString"]);
                return string.IsNullOrEmpty(t)
                    ? @"Data Source=IP-AC1FBF31\SITECORESQL;Initial Catalog=FraudDetector;Integrated Security=true;"
                    : t;
            }
        }
    }
}