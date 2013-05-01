using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PedidoProdutoDataAccess : Conexao
    {
        public void InserirPedidoProduto(int idPedido, int idProduto, decimal quantidade, SqlConnection conexao = null, SqlTransaction transacao = null)
        {
            if (conexao == null)
                conexao = this.Connection;

            SqlCommand cmdInserirPedido = new SqlCommand("Insert into PedidoProduto(Pedidos_Id, Produtos_Id, Quantidade) values (@idPedido, @idProduto, @Quantidade)", conexao, transacao);
            cmdInserirPedido.Parameters.AddWithValue("@idPedido", idPedido);
            cmdInserirPedido.Parameters.AddWithValue("@idProduto", idProduto);
            cmdInserirPedido.Parameters.AddWithValue("@Quantidade", quantidade);
            cmdInserirPedido.ExecuteNonQuery();
        }
    }
}
