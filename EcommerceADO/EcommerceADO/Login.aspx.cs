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
    public partial class Login : System.Web.UI.Page
    {
        public Usuario UsuarioLogado
        {
            get
            {
                if (Session["UsuarioLogado"] != null)
                    return (Usuario)Session["UsuarioLogado"];
                else
                    return null;
            }
            set { Session["UsuarioLogado"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioLogado = new UsuarioBusiness().RealizarLogin(txtLogin.Text, txtSenha.Text);

                if (usuarioLogado != null)
                {
                    this.UsuarioLogado = usuarioLogado;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMsg.Text = "Usuário ou senha incorretos";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}