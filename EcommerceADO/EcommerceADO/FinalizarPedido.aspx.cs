using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Business;

namespace EcommerceADO
{
    public partial class FinalizarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucCarrinhoCompras carrinho = (ucCarrinhoCompras)this.Master.FindControl("ucCarrinhoCompras1");
                Repeater1.DataSource = carrinho.ListaProdutos;
                Repeater1.DataBind();
                AtualizarValorTotal();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        public void AtualizarValorTotal()
        {
            decimal precoTotal = 0M;

            foreach (var item in Repeater1.Items)
            {
                RepeaterItem rptItem = (RepeaterItem)item;
                Label lblPreco = (Label)rptItem.FindControl("lblPreco");
                TextBox txtQtd = (TextBox)rptItem.FindControl("txtQuantidade");

                decimal preco = decimal.Parse(lblPreco.Text);
                int qtd = int.Parse(txtQtd.Text);

                precoTotal += (preco * qtd);
            }

            lblTotal.Text = string.Format("{0:c}", precoTotal);
            lblValorTotal.Text = string.Format("{0:c}", precoTotal);
        }
        
        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            this.AtualizarValorTotal();
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            modalFinalizarPedido.Hide();

            List<Produto> listaProdutos = new List<Produto>();
            foreach (var item in Repeater1.Items)
            {
                RepeaterItem rptItem = (RepeaterItem)item;
                Label lblPreco = (Label)rptItem.FindControl("lblPreco");
                TextBox txtQtd = (TextBox)rptItem.FindControl("txtQuantidade");
                HiddenField hdfId = (HiddenField)rptItem.FindControl("hdfIdProduto");

                int id = int.Parse(hdfId.Value);
                int qtd = int.Parse(txtQtd.Text);

                Produto produto = new Produto();
                produto.Id = id;
                produto.Quantidade = qtd;

                listaProdutos.Add(produto);
            }

            if (Session["UsuarioLogado"] != null)
            {
                try
                {
                    Usuario usuarioLogado = (Usuario)Session["UsuarioLogado"];
                    PedidoBusiness business = new PedidoBusiness();
                    int numPedido = business.CriarPedido(usuarioLogado, listaProdutos);

                    lblMsg.Text = string.Format("Pedido Nº {0} criado com sucesso", numPedido);
                }
                catch (Exception ex)
                {
                    lblMsg.Text = string.Format("Erro: {0}", ex.Message);
                }
            }
            else
            {
                lblMsg.Text = "Realize o login para finalizar o pedido!";
            }
        }
    }
}