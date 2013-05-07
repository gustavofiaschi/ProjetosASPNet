using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using EntityDataAccess;
using System.Data.EntityClient;

namespace DataAccess
{
    public class Conexao
    {
        private SqlConnection connection;
        public SqlConnection Connection
        {
            get { return this.connection; }
        }

        public EcommerceADOEntities1 EntityContext { get; set; }

        public Conexao()
        {
            this.connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=EcommerceADO;Integrated Security=True");

            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
            builder.Metadata = "res://*/EntityEcommerce.csdl|res://*/EntityEcommerce.ssdl|res://*/EntityEcommerce.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = this.Connection.ConnectionString;

            EntityConnection Entityconexao = new EntityConnection(builder.ToString());
            this.EntityContext = new EcommerceADOEntities1(Entityconexao);
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
