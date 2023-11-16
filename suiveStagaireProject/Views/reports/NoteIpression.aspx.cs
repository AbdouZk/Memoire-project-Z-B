using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views.reports
{
    public partial class WebForm7 : System.Web.UI.Page
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


                if (Session["trustId"].ToString().Equals("0") || (groupId == 2 || groupId == 3))
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}