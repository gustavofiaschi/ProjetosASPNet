using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceADO
{
    public partial class ListaPessoas : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            SiteMaster master = (SiteMaster)this.Master;
            string temaSelecionado = master.TemaSelecionado;
            this.Theme = temaSelecionado;
            master.ChangedTheme += new SiteMaster.OnChangedTheme(master_ChangedTheme);
        }

        void master_ChangedTheme(string IdTema)
        {
            Server.Transfer(Request.FilePath);
            
        }

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
                    int id = 0;//int.Parse(GridView1.DataKeys[indice].Value.ToString());
                    //string url = string.Format("cadPessoas.aspx?id={0}&param2={1}", id, indice);
                    string url = string.Format("cadPessoas.aspx?id={0}", id);
                    Response.Redirect(url);
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                if (e.CommandArgument != null)
                {
                    int id = int.Parse(e.CommandArgument.ToString());                   
                    string url = string.Format("cadPessoas.aspx?id={0}", id);
                    Response.Redirect(url);
                }
            }
        }

        protected void Repeater1_PreRender(object sender, EventArgs e)
        {
            if (Repeater1.DataSource != null)
            {
            }
        }

        protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue == null)
            {

            }
        }
                
    }
}