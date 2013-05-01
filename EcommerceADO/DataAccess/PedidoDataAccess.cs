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

            decimal precoTotal = 0M;

            foreach (var produto in listaProdutos)
            {
                precoTotal += produto.Quantidade * produto.Preco;
            }

            try
            {
                int idPedido = 0;

                SqlCommand cmdInserirPedido = new SqlCommand("Insert into Pedido(Data, PessoaId, PrecoTotal) values (getdate(), @PessoaId, @PrecoTotal);Select cast(scope_identity() as int)", this.Connection, transacao);
                cmdInserirPedido.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmdInserirPedido.Parameters.AddWithValue("@PrecoTotal", precoTotal);
                idPedido = (int)cmdInserirPedido.ExecuteScalar();
                                
                //Chama camada PedidoProduto
                foreach (var produto in listaProdutos)
                {
                    new PedidoProdutoDataAccess().InserirPedidoProduto(idPedido, produto.Id, produto.Quantidade, this.Connection, transacao);
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
