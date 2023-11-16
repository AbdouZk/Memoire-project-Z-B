using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Scrypt;

namespace suiveStagaireProject.Views
{
    public partial class Login_Register : System.Web.UI.Page
    {
           User u = new User(); ScryptEncoder encoder = new ScryptEncoder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }


            lblYear.Text = DateTime.Now.Year.ToString() + " - " + (int.Parse(DateTime.Now.Year.ToString()) + 1);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            try
            {
                string use = usernameLogin.Value;
                string pass = passwordLogin.Value;


                if (encoder.Compare(pass, u.getUserLog(use).password))
                {
                  
                    Session["id"] = u.getUserLog(use).id;
                    Session["username"] = use;
                    Session["trustId"] = u.getUserLog(use).trustID;
                    Session["groupId"] = u.getUserLog(use).groupID;

                    Response.Redirect("HomePage.aspx?id=" + u.getUserLog(use).id);
                    
                }
                else
                {
                    errorLog.Text = "Utilisateur n'existe pas !";
                    errorLog.Visible = true;
                    

                }

            }
            catch (Exception ex)
            {
                errorLog.Text = "Utilisateur n'existe pas !";
                errorLog.Visible = true;

            }
        }

       
    }
}