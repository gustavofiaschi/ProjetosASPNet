using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PedidoDataAccess : Conexao
    {
        public int CriarPedido(int pessoaId, List<Model.Produto> listaProdutos)
        {
            this.Connect();
            SqlTransaction transacao = this.Connection.BeginTransaction("CriaPedido");

            try
            {
                int idPedido = 0;

                SqlCommand cmdInserirPedido = new SqlCommand("Insert into Pedido(Data, PessoaId) values (getdate(), @PessoaId);Select cast(scope_identity() as int)", this.Connection, transacao);
                cmdInserirPedido.Parameters.AddWithValue("@PessoaId", pessoaId);
                idPedido = (int)cmdInserirPedido.ExecuteScalar();
                                
                //Chama camada PedidoProduto
                foreach (var produto in listaProdutos)
                {
                    new PedidoProdutoDataAccess().InserirPedidoProduto(idPedido, produto.Id, this.Connection, transacao);
                }

                transacao.Commit();
                this.Connection.Close();
                return idPedido;
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw ex;
            }
        }


    }
}
