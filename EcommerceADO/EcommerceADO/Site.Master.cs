using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace EcommerceADO
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public delegate void OnChangedTheme(string IdTema);
        public event OnChangedTheme ChangedTheme;

        public string TemaSelecionado
        {
            get 
            {
                if (Session["TemaSelecionado"] != null)
                    return (string)Session["TemaSelecionado"];
                else
                    return "Padrao";
            }
            set { Session["TemaSelecionado"] = value; }
        }

                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTema.DataSource = Tema.RetornaTemas();
                ddlTema.SelectedValue = this.TemaSelecionado;
                ddlTema.DataBind();
            }
        }

        protected void ddlTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TemaSelecionado = ddlTema.SelectedValue;

            if (ChangedTheme != null)
                ChangedTheme(ddlTema.SelectedValue);            
        }
    }
}
