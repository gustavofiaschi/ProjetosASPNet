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
        public int IdUsuario
        {
            get { return (int)ViewState["IdUsuario"]; }
            set { ViewState["IdUsuario"] = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            SiteMaster master = (SiteMaster)this.Master;
            master.ChangedTheme += new SiteMaster.OnChangedTheme(master_ChangedTheme);
            //master.ChangedTheme += teste;
            //master.ChangedTheme += teste2;

            this.Theme = master.TemaSelecionado;
        }

        void master_ChangedTheme(string IdTema)
        {
            Server.Transfer(Request.FilePath);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioBusiness business = new UsuarioBusiness();
                ddlStatus.DataSource = business.RetornaStatus();
                ddlStatus.DataTextField = "Value";
                ddlStatus.DataValueField = "Key";
                ddlStatus.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    this.IdUsuario = int.Parse(Request.QueryString["id"]);
                    CarregaCampos();
                }
                else
                {
                    this.IdUsuario = 0;                    
                }
            }
        }

        private void CarregaCampos()
        {
            if (this.IdUsuario > 0)
            {
                UsuarioBusiness business = new UsuarioBusiness();
                Usuario usuario = business.RetornaUsuario(this.IdUsuario);

                if (usuario != null)
                {
                    this.IdUsuario = usuario.Id;
                    txtLogin.Text = usuario.Login;
                    txtSenha.Text = usuario.Senha;
                    ddlPessoa.SelectedValue = usuario.PessoaId.ToString();
                    ddlStatus.SelectedValue = usuario.Status.ToString();
                }
            }
            else
            {
                this.IdUsuario = 0;
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;
                ddlPessoa.SelectedIndex = -1;
                ddlStatus.SelectedIndex = -1;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioBusiness business = new UsuarioBusiness();
            Usuario usuario = new Usuario();

            usuario.Id = this.IdUsuario;
            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            usuario.PessoaId = int.Parse(ddlPessoa.SelectedValue);
            usuario.Status = (StatusUsuario)Enum.Parse(typeof(StatusUsuario), ddlStatus.SelectedValue);

            business.Salvar(usuario);

            lblMsg.Text = "Cadastro realizado com sucesso.";
        }
    }
}