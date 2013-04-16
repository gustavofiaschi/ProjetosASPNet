using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace EcommerceADO
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                if (e.CommandArgument != null)
                {
                    int indice = int.Parse(e.CommandArgument.ToString());
                    int id = int.Parse(GridView1.DataKeys[indice].Value.ToString());
                    //string url = string.Format("cadPessoas.aspx?id={0}&param2={1}", id, indice);
                    string url = string.Format("cadUsuarios.aspx?id={0}", id);
                    Response.Redirect(url);
                }
            }
            else if (e.CommandName.Equals("Delete"))
            {
                if(e.CommandArgument != null)
                {
                    int indice = int.Parse(e.CommandArgument.ToString());
                    int id = int.Parse(GridView1.DataKeys[indice].Value.ToString());

                    new UsuarioBusiness().Excluir(id);

                    Response.Redirect(Request.FilePath);
                }
            }
        }
    }
}