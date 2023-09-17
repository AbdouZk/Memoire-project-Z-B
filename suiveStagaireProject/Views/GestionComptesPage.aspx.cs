using Scrypt;
using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString() != "1")
                {
                    Response.Redirect("HomePage.aspx?id="+Session["id"]);
                }


                if (Request.QueryString["do"].Equals("edit") && Request.QueryString["id"] != null)
                {
                    User us = new User();
                    us = user.getUser(int.Parse(Request.QueryString["id"]));

                    if (usernameEditUser.Text.Equals("")) {
                        usernameEditUser.Text = us.username;
                        DropDownGroupIdEditUser.SelectedValue = us.groupID.ToString();
                        DropDownTrustIdEditUser.SelectedValue = us.trustID.ToString();
                    }
                }
                else
                {
                    errorsEdit.Text = "User Introuvable !";
                    errorsEdit.Visible = true;
                }


                if (Request.QueryString["do"].Equals("delete") && Request.QueryString["id"] != null)
                {
                    User us = new User();
                    us = user.getUser(int.Parse(Request.QueryString["id"]));


                    userToDrop.Text = us.username;
                    userToDrop.Visible = true;



                }
                else
                {
                    userToDrop.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionComptesPage.aspx?id="+Session["id"]+"&do=add");

        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=edit");
        }

        protected void btnDropUser_Click(object sender, EventArgs e)
        {
            try
            {
                int id =int.Parse( Request.QueryString["id"]);
                user.deleteUser(user.getUser(id));
                Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterUser_Click(object sender, EventArgs e)
        {
            try
            {
                ScryptEncoder encode = new ScryptEncoder();
                string use = usernameAddUser.Text;
                string pass = passAddUser.Text;
                string confPass = confPassAddUser.Text;
                int groupId = 0;
                int trustId = 0; 
                if (DropDownGroupId.SelectedValue.Equals("-1")) { groupId = 0; } else { groupId = int.Parse(DropDownGroupId.SelectedValue); }
                if (DropDownTrustId.SelectedValue.Equals("-1")) { trustId = 0; } else { trustId = int.Parse(DropDownTrustId.SelectedValue); }



                if (use.Equals("") || pass.Equals(""))
                {
                    // error1 
                    errors.Text = "username ou password invalid";
                    errors.Visible = true;
                    seccuss.Visible = false;


                }
                else if (!pass.Equals(confPass))
                {
                    // error2 
                    errors.Text = "c'est pas le meme password";
                    errors.Visible = true;
                    seccuss.Visible = false;


                }
                else
                {
                    pass = encode.Encode(pass);
                    User us = new User(use, pass, groupId,trustId,DateTime.Now);
                    user.addUser(us);

                    seccuss.Text = "Bien Ajouter";
                    errors.Visible = false;
                    seccuss.Visible = true;

                }


            }
            catch(Exception ex)
            {

            }
        }

        protected void saveEditUser_Click(object sender, EventArgs e)
        {
            try {
                ScryptEncoder encode = new ScryptEncoder();

                int id = int.Parse(Request.QueryString["id"]);
                string use = usernameEditUser.Text;
                string pass = passwordEditUser.Text;
                string confPass = confPasswordEditUser.Text;
                int groupId = 0;
                int trustId = 0;
                if (DropDownGroupIdEditUser.SelectedValue.Equals("-1")) { groupId = 0; } else { groupId = int.Parse(DropDownGroupIdEditUser.SelectedValue); }
                if (DropDownTrustIdEditUser.SelectedValue.Equals("-1")) { trustId = 0; } else { trustId = int.Parse(DropDownTrustIdEditUser.SelectedValue); }


                if (use.Equals("") || pass.Equals(""))
                {
                    // error1 
                    errorsEdit.Text = "username ou password invalid";
                    errorsEdit.Visible = true;
                    successEdit.Visible = false;

                }
                else if (!pass.Equals(confPass))
                {
                    // error2 
                    errorsEdit.Text = "c'est pas le meme password";
                    errorsEdit.Visible = true;
                    successEdit.Visible = false;


                }
                else
                {
                    pass = encode.Encode(pass);
                    User us = new User(use, pass, groupId, trustId);
                    user.updateUser(us,id);

                    successEdit.Text = "Bien Modifier";
                    errorsEdit.Visible = false;
                    successEdit.Visible = true;

                }


            }
            catch(Exception ex)
            {

            }
        }

        protected void btnCancelDropUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=");
        }
    }
}