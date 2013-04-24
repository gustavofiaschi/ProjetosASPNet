using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace EcommerceADO
{
    public partial class ucLogin : System.Web.UI.UserControl
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
            AtualizarLogin();
        }

        public void AtualizarLogin()
        {
            if (this.UsuarioLogado != null)
            {
                lblUsuario.Text = UsuarioLogado.Login;
                lkbLogin.Visible = false;
                lkbSair.Visible = true;
            }
            else
            {
                lblUsuario.Text = "Convidado";
                lkbLogin.Visible = true;
                lkbSair.Visible = false;
            }
        }

        protected void lkbLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void lkbSair_Click(object sender, EventArgs e)
        {
            this.UsuarioLogado = null;
            this.AtualizarLogin();
        }
    }
}