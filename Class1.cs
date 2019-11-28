using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Decompression
{
    public class DatabaseUser
    {
        public string DoWork(string pUserName, string pPassword)
        {
            string connectionString = $"Data Source={serverName};" + $"Initial catalog={catalogName};";
            var securePassword = new SecureString();

            foreach (var character in pPassword)
            {
                securePassword.AppendChar(character);
            }
            securePassword.MakeReadOnly();
            return "";
        }
        private string serverName;
        private string catalogName;
        public DatabaseUser(string pServerName, string pCatalogName )
        {
            serverName = pServerName;
            catalogName = pCatalogName;
        }



        public bool SqlCredentialLogin(string pUserName, string pPassword)
        {
            string connectionString = $"Data source={serverName};" +
           $"Initial catalog={catalogName};";

            var securePassword = new SecureString();

            foreach (var character in pPassword)
            {
                securePassword.AppendChar(character);
            }
            securePassword.MakeReadOnly();

            var credentials = new SqlCredential(pUserName, securePassword);
            using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
            {
                try
                {
                    cn.Credential = credentials;
                    cn.Open();
                    return true;
                }
                catch (Exception e)
                {
                    return true;
                }

            }



        }
    }
}
