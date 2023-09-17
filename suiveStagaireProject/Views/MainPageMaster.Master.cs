using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace suiveStagaireProject
{
    public partial class MainPageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login_Register.aspx");
            }

            lblYear.Text = DateTime.Now.Year.ToString()+" - "+ (int.Parse(DateTime.Now.Year.ToString())+1);
           
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session["id"] = null; Session["username"] = null; Session["trustId"] = null;Session["groupId"] = null;
            Response.Redirect("Login_Register.aspx");
        }

        protected void btnCRUDcomptes_Click(object sender, EventArgs e)
        {
            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString() != "1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=add");
            }
            

        }

        protected void btnListeComp_Click(object sender, EventArgs e)
        {

            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString()!="1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                 Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=All");
            }
           
        }

        protected void btnActDis_Click(object sender, EventArgs e)
        {
            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString() != "1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=All");
            }
           
        }

        protected void btnCRUDcat_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=All");
        }
    }
}