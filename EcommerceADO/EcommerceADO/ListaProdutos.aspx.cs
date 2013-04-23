﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace EcommerceADO
{
    public partial class ListaProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProdutoBusiness business = new ProdutoBusiness();
                ddlCategorias.DataSource = business.RetornaCategorias();
                ddlCategorias.DataTextField = "Value";
                ddlCategorias.DataValueField = "Key";
                ddlCategorias.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "Comprar":
                    //TODO: Adicionar ao carrinho de comprar e redirecionar a pagina de Finalizar Compra
                    break;
                case "AddCarrinho":
                    //TODO: Adicionar ao Carrinho de Compras
                    break;
                case "Edit":
                    int id = int.Parse(e.CommandArgument.ToString());                    
                    string url = string.Format("cadProdutos.aspx?id={0}", id);
                    Response.Redirect(url);
                    break;
                default:
                    break;
            }
        }
    }
}