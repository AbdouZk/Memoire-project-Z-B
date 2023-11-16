using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Module module = new Module();
        Enseignant enseignant = new Enseignant();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId >= 3)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }



                if (Request.QueryString["do"] != null){
                    if (Request.QueryString["do"].Equals("add-edit")  && Request.QueryString["opt"] != null)
                    {

                        if (Request.QueryString["opt"].Equals("add"))
                        {
                            btnAddModule.Visible = true;

                        } else if (Request.QueryString["opt"].Equals("edit"))
                        {
                            if (libModule.Value.Equals("")) libModule.Value = module.getModule(int.Parse(Request.QueryString["idModule"])).libelle;

                            btnSaveModule.Visible = true;

                        } else
                        {
                            Response.Redirect("404-page.aspx");
                        }
                    }

                   


                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idModule"] != null)
                    {

                        ModToDrop.Text = module.getModule(int.Parse(Request.QueryString["idModules"])).libelle;
                        ModToDrop.Visible = true;



                    }
                    else
                    {
                        ModToDrop.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("404-page.aspx");
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            try
            {
                string libMod = libModule.Value;
                int idmod = module.getLastModuleId() + 1;


                module.addModule(new Module(idmod, libMod));

               
                msgModule.Text = "Bien Ajouter";
                libModule.Value = "";
                msgModule.Visible = true;




            }
            catch (Exception ex)
            {
                msgModule.Text = "Echèc d'ajouter";
                msgModule.Visible = true;
            }
        }

        protected void btnDropModule_Click(object sender, EventArgs e)
        {
            try
            {
                int idmod = int.Parse(Request.QueryString["idModule"]);

              
                // delete Module 
                module.deleteModule(module.getModule(idmod));

                Response.Redirect("GestionModules.aspx?id=" + Session["id"] + "&do=AllModules");

            }
            catch (Exception ex)
            {
                msgModule.Text = "On peut pas supprimer cet Module, Il apartient à des sections ";
            }
        }

        protected void btnSaveModule_Click(object sender, EventArgs e)
        {
            try
            {
                string libMod = libModule.Value;
                int idmod = int.Parse(Request.QueryString["idModule"]);
                Module mod = new Module(idmod, libMod);

                module.EditModule(mod,idmod);
                msgModule.Text = "Bien Modifier";
                msgModule.Visible = true;


            }
            catch (Exception ex)
            {
                msgModule.Text = "Echèc De Modifier";
                msgModule.Visible = true;
            }

        }

        
    }
}