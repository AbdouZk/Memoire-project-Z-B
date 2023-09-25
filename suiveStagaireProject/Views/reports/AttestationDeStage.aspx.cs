using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views.reports
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["id"] == null)
                {
                    Response.Redirect("../Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId >= 4)
                {
                    Response.Redirect("../HomePage.aspx?id=" + Session["id"]);
                }

                if (!Request.QueryString["do"].Equals("impression") || Request.QueryString["idStg"] == null)
                {
                    Response.Redirect("../GestionStagiaires.aspx?id=" + Session["id"]+"do=AllStg");

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}