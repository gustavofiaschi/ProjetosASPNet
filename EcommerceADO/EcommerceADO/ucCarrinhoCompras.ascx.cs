using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace EcommerceADO
{
    public partial class ucCarrinhoCompras : System.Web.UI.UserControl
    {
        public List<Produto> ListaProdutos
        {
            get
            {
                if (Session["ListaProdutos"] != null)
                    return (List<Produto>)Session["ListaProdutos"];
                else
                    return new List<Produto>();
            }
            set
            {
                Session["ListaProdutos"] = value;
            }
        }

        /// <summary>
        /// Adiciona produto ao carrinho
        /// </summary>
        /// <param name="produto">objeto produto</param>
        public void AddProduto(Produto produto)
        {
            if (produto != null)
            {
                List<Produto> lista = this.ListaProdutos;

                if (lista.Where(p => p.Id == produto.Id).Count() > 0)
                {
                    lista.Where(p => p.Id == produto.Id).FirstOrDefault().Quantidade += 1;
                }
                else
                {
                    lista.Add(produto);
                }

                this.ListaProdutos = lista;
            }
        }

        /// <summary>
        /// Remove produtos do carrinho
        /// </summary>
        /// <param name="idProduto">id do produto</param>
        public void RemProduto(int idProduto)
        {
            if (idProduto > 0)
                this.ListaProdutos.RemoveAll(p => p.Id == idProduto);
        }

        /// <summary>
        /// Remove produtos do carrinho
        /// </summary>
        /// <param name="produto">objeto produto</param>
        public void RemProduto(Produto produto)
        {
            if (produto != null)
                this.ListaProdutos.Remove(produto);
        }

        public void AtualizaCarrinho()
        {
            int qtdProdutos = this.ListaProdutos.Count;
            lblCountLista.Text = qtdProdutos.ToString();

            if (qtdProdutos == 0)
                Image1.ImageUrl = "Imagens/CarEmpty.jpg";
            else
                Image1.ImageUrl = "Imagens/CarFull.jpg";
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizaCarrinho();
        }
    }
}