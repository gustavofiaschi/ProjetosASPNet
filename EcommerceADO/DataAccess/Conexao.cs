using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Conexao
    {
        private SqlConnection connection;
        public SqlConnection Connection
        {
            get { return this.connection; }
        }

        public Conexao()
        {
            this.connection = new SqlConnection(@"Data Source=.\sqlexpress2;Initial Catalog=Ecommerce2;Integrated Security=True");            
        }

        public void Connect()
        {
            if (this.connection != null)
            {
                this.connection.Open();
            }
        }

        public void Disconnect()
        {
            if (this.connection != null)
                this.connection.Close();
        }
    }
}
