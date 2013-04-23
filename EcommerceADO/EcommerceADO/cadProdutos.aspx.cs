using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Model;
using System.IO;
using Common;

namespace EcommerceADO
{
    public partial class cadProdutos : System.Web.UI.Page
    {
        public int idProduto
        {
            get { return (int)ViewState["idProduto"]; }
            set { ViewState["idProduto"] = value; }
        }

        public string FotoProduto
        {
            get { return (string)ViewState["FotoProduto"]; }
            set { ViewState["FotoProduto"] = value; }
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
                ProdutoBusiness business = new ProdutoBusiness();
                ddlCategoria.DataSource = business.RetornaCategorias();
                ddlCategoria.DataTextField = "Value";
                ddlCategoria.DataValueField = "Key";
                ddlCategoria.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    this.idProduto = int.Parse(Request.QueryString["id"]);
                    CarregaCampos();
                }
                else
                {
                    this.idProduto = 0;
                    this.FotoProduto = string.Empty;
                }
            }
        }

        private void CarregaCampos()
        {
            if (this.idProduto > 0)
            {
                ProdutoBusiness business = new ProdutoBusiness();
                Produto produto = business.RetornaProduto(this.idProduto);

                if (produto != null)
                {
                    this.idProduto = produto.Id;
                    this.FotoProduto = produto.Foto;
                    txtNome.Text = produto.Nome;
                    txtDescricao.Text = produto.Descricao;
                    txtPreco.Text = produto.Preco.ToString();
                    txtQtdEstoque.Text = produto.QtdEstoque.ToString();
                    ddlCategoria.SelectedValue = ((short)produto.Categoria).ToString();
                }
            }
            else
            {
                this.idProduto = 0;
                this.FotoProduto = "";
                txtNome.Text = "";
                txtDescricao.Text = "";
                txtPreco.Text = "";
                txtQtdEstoque.Text = "";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Produto produto = new Produto();
                    produto.Nome = txtNome.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.Preco = Decimal.Parse(txtPreco.Text);
                    produto.QtdEstoque = int.Parse(txtQtdEstoque.Text);
                    produto.Foto = this.FotoProduto;
                    produto.Id = this.idProduto;
                    produto.Categoria = (ProdutoCategorias) Enum.Parse(typeof(ProdutoCategorias), ddlCategoria.SelectedValue);

                    if (FileUpload1.HasFile)
                    {
                        string nomeArquivo = FileUpload1.FileName;
                        string caminhoArquivo = Path.Combine(MapPath("~/Imagens/Produtos"), nomeArquivo);
                        FileUpload1.SaveAs(caminhoArquivo);

                        produto.Foto = nomeArquivo;
                    }

                    new ProdutoBusiness().Salvar(produto);

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
    }
}