using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Model;
using Common;

namespace EcommerceADO
{
    public partial class cadUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioBusiness business = new UsuarioBusiness();
                ddlStatus.DataSource = business.RetornaStatus();
                ddlStatus.DataTextField = "Value";
                ddlStatus.DataValueField = "Key";
                ddlStatus.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioBusiness business = new UsuarioBusiness();
            Usuario usuario = new Usuario();

            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            usuario.PessoaId = int.Parse(ddlPessoa.SelectedValue);
            usuario.Status = (StatusUsuario)Enum.Parse(typeof(StatusUsuario), ddlStatus.SelectedValue);

            business.Salvar(usuario);

            lblMsg.Text = "Cadastro realizado com sucesso.";
        }
    }
}