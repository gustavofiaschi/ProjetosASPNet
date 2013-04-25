using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Model;

namespace EcommerceADO
{
    public partial class ListaProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucLogin uc = (ucLogin)this.Master.FindControl("ucLogin1");
                uc.UsuarioLogado.Login = "TESTE";

                ProdutoBusiness business = new ProdutoBusiness();
                ddlCategorias.DataSource = business.RetornaCategorias();
                ddlCategorias.DataTextField = "Value";
                ddlCategorias.DataValueField = "Key";
                ddlCategorias.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ucCarrinhoCompras carrinho = (ucCarrinhoCompras)this.Master.FindControl("ucCarrinhoCompras1");

            int id = int.Parse(e.CommandArgument.ToString()); 

            switch (e.CommandName.ToString())
            {
                case "Comprar":
                    //Adicionar ao carrinho de comprar e redirecionar a pagina de Finalizar Compra
                    Produto produtoCompra = new ProdutoBusiness().RetornaProduto(id);
                    carrinho.AddProduto(produtoCompra);
                    carrinho.AtualizaCarrinho();
                    Response.Redirect("FinalizarPedido.aspx");
                    break;
                case "AddCarrinho":
                    // Adicionar ao Carrinho de Compras
                    Produto produtoCarrinho = new ProdutoBusiness().RetornaProduto(id);
                    carrinho.AddProduto(produtoCarrinho);
                    carrinho.AtualizaCarrinho();
                    break;
                case "Edit":                                       
                    string url = string.Format("cadProdutos.aspx?id={0}", id);
                    Response.Redirect(url);
                    break;
                default:
                    break;
            }
        }
    }
}