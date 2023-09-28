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
        Examen examen = new Examen();
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

                    if (Request.QueryString["do"].Equals("affectation"))
                    {
                        if (dropDownEnseignants.Items.Count==0)
                        {
                            dropDownEnseignants.DataSource = enseignant.getEnseignantsNames();
                            dropDownEnseignants.DataTextField = "nameEns";
                            dropDownEnseignants.DataValueField = "idEns";
                            dropDownEnseignants.DataBind();

                            dropDownModules.DataSource = module.getModules();
                            dropDownModules.DataValueField = "idModule";
                            dropDownModules.DataTextField = "libelle";
                            dropDownModules.DataBind();

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

                    examen.addExamen(new Examen("E1", (int)idmod));
                    examen.addExamen(new Examen("E2", (int)idmod));
                    examen.addExamen(new Examen("S", (int)idmod));
                    examen.addExamen(new Examen("Ratt", (int)idmod));

                    msgModule.Text = "Bien Ajouter";
                    libModule.Value = "";
                    msgModule.Visible = true;
                
            
                

                
            }
            catch (Exception ex)
            {
                msgModule.Text = "Echèc d'jouter";
                msgModule.Visible = true;
            }
        }

        protected void btnDropModule_Click(object sender, EventArgs e)
        {
            try
            {
                int idmod =int.Parse(Request.QueryString["idModule"]);

                // delete All Exemen's Module
                examen.DeleteExamen(idmod);
                examen.DeleteExamen(idmod);
                examen.DeleteExamen(idmod);
                examen.DeleteExamen(idmod);

                // delete item from table between Module and Enseignant
                Ens_Mod em = new Ens_Mod();
                em.deleteEM(idmod);

                // delete item from table between Module and Section and Semestre


                // delete Module 
                module.deleteModule(module.getModule(idmod));

                Response.Redirect("GestionModules.aspx?id="+Session["id"]+"&do=AllModules");

            }
            catch (Exception ex)
            {
                
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

        protected void btnAffecterModule_Click(object sender, EventArgs e)
        {
            try
            {
                int idEns =int.Parse( dropDownEnseignants.SelectedValue);
                int idmod = int.Parse(dropDownModules.SelectedValue);
                Ens_Mod em = new Ens_Mod();
                em.AddEns_Mod(new Ens_Mod(idEns, idmod));
               
                msgModule.Text = "Bien Affecté";
                msgModule.Visible = true;


            }
            catch (Exception ex)
            {
                msgModule.Text = "Echèc D'Affectation";
                msgModule.Visible = true;
            }

        }
    }
}