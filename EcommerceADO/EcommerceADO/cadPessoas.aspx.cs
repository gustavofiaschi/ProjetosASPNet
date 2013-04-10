using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Business;
using System.IO;
using System.Configuration;

namespace EcommerceADO
{
    public partial class cadPessoas : System.Web.UI.Page
    {
        public int IdPessoa
        {
            get { return (int)ViewState["IdPessoa"]; }
            set { ViewState["IdPessoa"] = value; }
        }

        public string nomeFoto
        {
            get { return (string)ViewState["nomeFoto"]; }
            set { ViewState["nomeFoto"] = value; }
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

        void teste(string x)
        {
            Response.Write("Metodo 2 <\br>");
        }

        void teste2(string x)
        {
            Response.Write("Metodo 3 <\br>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Forma de acesso as configurações da aplicação web
            //string configuracao = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            //Recuperação da QueryString [id]
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    this.IdPessoa = int.Parse(Request.QueryString["id"]);
                    CarregaCampos();
                }
                else
                {
                    this.IdPessoa = 0;
                    this.nomeFoto = string.Empty;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.Nome = txtNome.Text;
                    pessoa.DataNascimento = DateTime.Parse(txtDataNasc.Text);
                    pessoa.CPF = txtCPF.Text;
                    pessoa.NomeFoto = this.nomeFoto;
                    pessoa.Id = this.IdPessoa;

                    if (uploadFoto.HasFile)
                    {
                        string nomeArquivo = uploadFoto.FileName;
                        string caminhoArquivo = Path.Combine(MapPath("~/Imagens/Fotos"), nomeArquivo);
                        uploadFoto.SaveAs(caminhoArquivo);

                        pessoa.NomeFoto = nomeArquivo;
                    }

                    new PessoaBusiness().Salvar(pessoa);

                    lblMsg.Text = "Operação Realizada com Sucesso!";
                }
                else
                {
                    lblMsg.Text = "A Página não está valida!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void cvDataNascimento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dataNasc = Convert.ToDateTime(txtDataNasc.Text);

            if ((DateTime.Now.Year - dataNasc.Year) < 18)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            Page.Validate();
        }

        private void CarregaCampos()
        {
            if (this.IdPessoa > 0)
            {
                PessoaBusiness business = new PessoaBusiness();
                Pessoa pessoa = business.RetornaPessoa(this.IdPessoa);

                if (pessoa != null)
                {
                    this.IdPessoa = pessoa.Id;
                    this.nomeFoto = pessoa.NomeFoto;
                    txtCPF.Text = pessoa.CPF;
                    txtNome.Text = pessoa.Nome;
                    txtDataNasc.Text = pessoa.DataNascimento.ToShortDateString();
                }
            }
            else
            {
                this.IdPessoa = 0;
                this.nomeFoto = "";
                txtCPF.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtDataNasc.Text = string.Empty;
            }
        }
    }
}