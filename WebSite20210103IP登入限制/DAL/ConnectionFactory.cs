using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace WebSite20210103IP登入限制.DAL
{

 internal class ConnectionFactory
    {

        public static DbConnection GetOpenConnection()
        {
            //string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string connstr = @"server=192.168.1.200;uid=sa;pwd=321456852;database=dbweb;";
            var connection = new  System.Data.SqlClient.SqlConnection(connstr); 
            connection.Open(); 
            return connection;

        }

    }


   
}
