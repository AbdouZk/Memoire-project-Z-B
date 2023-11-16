using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm11 : System.Web.UI.Page
    {

        Employeur employeur  = new Employeur();
        

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


                if (Request.QueryString["do"].Equals("add-edit") && Request.QueryString["opt"] != null)
                {

                    if (Request.QueryString["opt"].Equals("add"))
                    {
                        if (nomEmp.Text=="")
                        {
                            dropDownStatusEmp.SelectedValue = "Active";
                        }
                        
                        btnAjouterEmp.Visible = true;


                    }
                    else if (Request.QueryString["opt"].Equals("edit") && Request.QueryString["idEmp"] != null)
                    {

                        if (nomEmp.Text.Equals(""))
                        {
                            Employeur listeEmp = new Employeur();
                            listeEmp = employeur.GetEmployeur(int.Parse(Request.QueryString["idEmp"]));

                            nomEmp.Text = listeEmp.Name;

                            adresseEmp.Text = listeEmp.Adresse;

                            if (listeEmp.status!="Active    ") {
                                dropDownStatusEmp.SelectedIndex = 1;
                            } 
                            
                            

                        }

                        btnSaveEmp.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("404-page.aspx");
                    }
                }



                if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idEmp"] == null)
                {


                    Response.Redirect("404-page.aspx");


                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterEmp_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nomEmp.Text;
                string adresse = adresseEmp.Text;
                string status = dropDownStatusEmp.SelectedValue;

                employeur.addEmployeur(new Employeur(name,adresse,status));
                msgEmp.Text = "Bien ajouter";
            }
            catch (Exception ex)
            {
                msgEmp.Text = "Echec d'ajouter";
            }
        }

        protected void btnSaveEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int id =int.Parse( Request.QueryString["idEmp"] );
                string name = nomEmp.Text;
                string adresse = adresseEmp.Text;
                string status = dropDownStatusEmp.SelectedValue;

                employeur.editEmployeur(new Employeur(name, adresse, status),id);
                msgEmp.Text = "Bien modifier";
            }
            catch (Exception ex)
            {
                msgEmp.Text = "Echec de modifier";
            }
        }

        protected void btnDropEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idEmp"]);
                

                employeur.deleteEmployeur(employeur.GetEmployeur(id));
                Response.Redirect("GestionEmployeurs.aspx?id="+Session["id"]+"&do=AllEmp");
            }
            catch (Exception ex)
            {
                msgEmp.Text = "Echec de supprimer";
            }

        }

        protected void btnsearchEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!searchEmp.Value.Equals(""))
                {
                    Response.Redirect("GestionEmployeurs.aspx?id=" + Session["id"] + "&do=AllEmp&searchEmp=" + searchEmp.Value);
                }
                else
                {
                    Response.Redirect("GestionEmployeurs.aspx?id=" + Session["id"] + "&do=AllEmp");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}