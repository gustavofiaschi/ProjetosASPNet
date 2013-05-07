using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using Common;

namespace DataAccess
{
    public class ProdutoDataAccess : Conexao
    {
        public ProdutoDataAccess()
            : base()
        {

        }

        public void Salvar(Produto produto)
        {
            SqlCommand cmd = new SqlCommand("Insert into Produto (Nome, Descricao, Preco, QtdEstoque, CategoriaId, Foto) values (@Nome, @Descricao, @Preco, @QtdEstoque, @Categoria, @Foto)", this.Connection);

            cmd.Parameters.AddWithValue("@Nome", produto.Nome);
            cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
            cmd.Parameters.AddWithValue("@Categoria", (short)produto.Categoria);
            cmd.Parameters.AddWithValue("@Foto", produto.Foto);

            this.Connect();
            int linhas = cmd.ExecuteNonQuery();
            this.Disconnect();
        }

        public List<Produto> RetornaProdutos(ProdutoCategorias categoria = ProdutoCategorias.Todos)
        {
            string command = categoria == ProdutoCategorias.Todos ? "Select * From Produto" : "Select * from Produto where CategoriaId = @Categoria";

            SqlCommand cmd = new SqlCommand(command, this.Connection);

            if (categoria != ProdutoCategorias.Todos)
                cmd.Parameters.AddWithValue("@Categoria", (short)categoria);

            this.Connect();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Produto> listaProdutos = new List<Produto>();

            while (dr.Read())
            {
                Produto produto = new Produto();
                produto.Nome = dr["Nome"].ToString();
                produto.Descricao = dr["Descricao"].ToString();
                produto.Preco = Convert.ToDecimal(dr["Preco"]);
                produto.Id = int.Parse(dr["Id"].ToString());
                produto.Foto = dr["Foto"] == null ? string.Empty : dr["Foto"].ToString();
                produto.QtdEstoque = int.Parse(dr["QtdEstoque"].ToString());
                produto.Categoria = (ProdutoCategorias)Enum.Parse(typeof(ProdutoCategorias), dr["CategoriaId"].ToString());

                listaProdutos.Add(produto);
            }

            return listaProdutos;
        }

        public void Atualizar(Produto produto)
        {
            SqlCommand cmd = new SqlCommand("Update Produto set Nome = @Nome, Descricao = @Descricao, Preco = @Preco, QtdEstoque = @QtdEstoque, CategoriaId = @CategoriaId, Foto = @Foto where Id = @Id", this.Connection);
            cmd.Parameters.AddWithValue("@Id", produto.Id);
            cmd.Parameters.AddWithValue("@Nome", produto.Nome);
            cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@QtdEstoque", produto.QtdEstoque);
            cmd.Parameters.AddWithValue("@CategoriaId", (short)produto.Categoria);
            cmd.Parameters.AddWithValue("@Foto", produto.Foto);

            this.Connect();
            cmd.ExecuteNonQuery();
            this.Disconnect();
        }

        public Produto RetornaProduto(int idProduto)
        {
            string command = "Select * from Produto where Id = @Id";

            SqlCommand cmd = new SqlCommand(command, this.Connection);
            cmd.Parameters.AddWithValue("@Id", (short)idProduto);

            this.Connect();
            SqlDataReader dr = cmd.ExecuteReader();

            Produto produto = new Produto();
            while (dr.Read())
            {
                produto.Nome = dr["Nome"].ToString();
                produto.Descricao = dr["Descricao"].ToString();
                produto.Preco = Convert.ToDecimal(dr["Preco"]);
                produto.Id = int.Parse(dr["Id"].ToString());
                produto.Foto = dr["Foto"] == null ? string.Empty : dr["Foto"].ToString();
                produto.QtdEstoque = int.Parse(dr["QtdEstoque"].ToString());
                produto.Categoria = (ProdutoCategorias)Enum.Parse(typeof(ProdutoCategorias), dr["CategoriaId"].ToString());
            }

            return produto;
        }

        /// <summary>
        /// Retorna os produtos, quantidades vendidas e valor total das vendas.
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public List<ProdutoRentabilidade> RetornaProdutosQuantidades(DateTime dataInicial, DateTime dataFinal)
        {
            List<ProdutoRentabilidade> listaProdutos = new List<ProdutoRentabilidade>();

            //Filtra os pedidos pela data
            foreach (var pedido in this.EntityContext.Pedido.Where(p => p.Data >= dataInicial.Date && p.Data <= dataFinal.Date).ToList())
            {                               
                foreach (var pedProd in pedido.PedidoProduto)
                {
                    if (listaProdutos.Where(lp => lp.Produto.Id == pedProd.Produtos_Id).Count() == 0)
                    {
                        //Adiciona um novo produto
                        ProdutoRentabilidade produtoRent = new ProdutoRentabilidade();
                        produtoRent.QtdVendida = pedProd.Quantidade == null ? 0 : pedProd.Quantidade.Value;
                        produtoRent.Produto = pedProd.Produto.ToProduto();
                        produtoRent.ValorTotal = pedProd.Produto.Preco * produtoRent.QtdVendida;
                        listaProdutos.Add(produtoRent);
                    }
                    else
                    {
                        //Acessa diretamente as propriedades para incrementa-las
                        listaProdutos.Where(lp => lp.Produto.Id == pedProd.Produtos_Id).FirstOrDefault().QtdVendida += pedProd.Quantidade == null ? 0 : pedProd.Quantidade.Value;
                        listaProdutos.Where(lp => lp.Produto.Id == pedProd.Produtos_Id).FirstOrDefault().ValorTotal += pedProd.Produto.Preco * pedProd.Quantidade == null ? 0 : pedProd.Quantidade.Value;
                    }
                }
            }

            return listaProdutos;
        }

        /// <summary>
        /// Retorna os produtos mais rentaveis nos ultimos 6 meses
        /// </summary>
        /// <returns></returns>
        public List<ProdutoRentabilidade> RetornaProdutosMaisRentaveis()
        {
            //6 meses antes
            DateTime dataInicial = DateTime.Now.AddMonths(-6).Date;
            return this.RetornaProdutosQuantidades(dataInicial, DateTime.Now.Date).Take(3).ToList();
        }
    }
}
