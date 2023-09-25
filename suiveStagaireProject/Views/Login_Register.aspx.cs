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
           User u = new User();
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
                string use = usernameLog.Text;
                string pass = passwordLog.Text;


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
                    errorLog.Text = "User don't existe !";
                    errorLog.Visible = true;
                    errors.Visible = false;

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            ScryptEncoder encoder = new ScryptEncoder();
            try
            {
                string use = usernameReg.Text;
                string pass = passReg.Text; 
                string passConf = confPassReg.Text;
                int groupId = int.Parse(DropDownGroupId.SelectedValue);

             

                if (use.Equals("") || pass.Equals("")) {
                    // error1 
                    errors.Text = "username ou password invalid";
                    errors.Visible = true;
                    errorLog.Visible = false;


                }
                else if (!pass.Equals(passConf))
                {
                    // error2 
                    errors.Text = "c'est pas le meme password";
                    errors.Visible = true;
                    errorLog.Visible = false;


                }
                else 
                {
                    pass = encoder.Encode(pass);
                    User us = new User(use, pass,groupId);
                    u.registerUser(us);

                    successEg.Text = "You have been register sucsessfuly";
                    successEg.Visible = true;
                    errorLog.Visible = false;


                }



            }
            catch (Exception ex)
            {

            }
        }
    }
}