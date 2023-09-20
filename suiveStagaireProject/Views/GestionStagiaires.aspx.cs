using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId >= 4)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"].Equals("add") && Request.QueryString["id"] != null)
                {


                }
                else
                {

                }


                if (Request.QueryString["do"].Equals("edit") && Request.QueryString["id"] != null)
                {


                }
                else
                {
                    //errorsEdit.Text = "User Introuvable !";
                    // errorsEdit.Visible = true;
                }


                if (Request.QueryString["do"].Equals("delete") && Request.QueryString["id"] != null)
                {

                    //CatToDrop.Text = cataloge.getCatalogeCode(int.Parse(Request.QueryString["idCat"]));
                    //CatToDrop.Visible = true;



                }
                else
                {
                    //CatToDrop.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}