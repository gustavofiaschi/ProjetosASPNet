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
    public partial class cadPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = txtNome.Text;
                pessoa.DataNascimento = DateTime.Parse(txtDataNasc.Text);
                pessoa.CPF = txtCPF.Text;

                new PessoaBusiness().Salvar(pessoa);

                lblMsg.Text = "Cadastro Realizado com Sucesso!";
            /*}
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }*/
        }
    }
}