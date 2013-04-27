using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PedidoDataAccess : Conexao
    {
        public int CriarPedido(int p, List<Model.Produto> listaProdutos)
        {
            int idPedido = 0;

            this.Connect();
            SqlTransaction transacao = this.Connection.BeginTransaction("CriaPedido");

            SqlCommand cmdInserirPedido = new SqlCommand("Insert into (Data) values (getdate())", this.Connection, transacao);            
            SqlDataReader retorno = cmdInserirPedido.ExecuteReader();

            idPedido = int.Parse(retorno["identity"].ToString());
            return idPedido;
        }

        
    }
}
