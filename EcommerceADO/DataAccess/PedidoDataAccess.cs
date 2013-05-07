using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using EntityDataAccess;

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

                SqlCommand cmdInserirPedido = new SqlCommand("Insert into Pedido(Data, PessoaId, PrecoTotal) values (@Data, @PessoaId, @PrecoTotal);Select cast(scope_identity() as int)", this.Connection, transacao);
                cmdInserirPedido.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmdInserirPedido.Parameters.AddWithValue("@PrecoTotal", precoTotal);
                cmdInserirPedido.Parameters.AddWithValue("@Data", DateTime.Now.Date);
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

        public int CriarPedidoEntity(int pessoaId, List<Model.Produto> listaProdutos)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                EPedido pedido = new EPedido();
                pedido.PessoaId = pessoaId;
                pedido.Data = DateTime.Now.Date;
                pedido.PrecoTotal = listaProdutos.Sum(lp => lp.Quantidade * lp.Preco);
                
                this.EntityContext.Pedido.AddObject(pedido);
                this.EntityContext.SaveChanges();

                foreach (var produto in listaProdutos)
                {
                    EPedidoProduto pedProd = new EPedidoProduto();
                    pedProd.Produtos_Id = produto.Id;
                    pedProd.Pedidos_Id = pedido.Id;
                    pedProd.Quantidade = produto.Quantidade;
                    this.EntityContext.PedidoProduto.AddObject(pedProd);
                }
                this.EntityContext.SaveChanges();

                transaction.Complete();

                return pedido.Id;
            }
        }
    }
}
