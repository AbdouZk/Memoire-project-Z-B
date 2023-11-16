using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Branchee branche = new Branchee();
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

                if (Request.QueryString["do"] != null)
                {

                    if (Request.QueryString["do"].Equals("add-edit"))
                    {
                        if (Request.QueryString["opt"] != null)
                        {
                            if (Request.QueryString["opt"].Equals("add"))
                            {
                                btnAddBranche.Visible = true;

                            }
                            else if (Request.QueryString["opt"].Equals("edit"))
                            {
                                if (libBranche.Value.Equals("")) { libBranche.Value = branche.getListeBranchee(int.Parse(Request.QueryString["idBranche"])).libileBrache; 
                                                                   libBrancheAr.Value = branche.getListeBranchee(int.Parse(Request.QueryString["idBranche"])).LibileBracheAr; }

                                btnSaveBranche.Visible = true;

                            }
                        }
                        else
                        {
                            Response.Redirect("404-page.aspx");
                        }
                    }




                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idBranche"] != null)
                    {

                        BraToDrop.Text = branche.getListeBranchee(int.Parse(Request.QueryString["idBranche"])).libileBrache;
                        BraToDrop.Visible = true;

                    }
                    else
                    {
                        BraToDrop.Visible = false;
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

        protected void btnDropBranche_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idBranche"]);
                branche.deleteBranche(branche.getListeBranchee(id));
                Response.Redirect("GestionBranches.aspx?id=" + Session["id"] + "&do=AllBranches");

            }
            catch (Exception ex)
            {
                toAlert.Text = "<div class='alert alert-danger'>Echec de supprimer</div>";
            }
        }

        protected void btnAddBranche_Click(object sender, EventArgs e)
        {
            try
            {
                string lib = libBranche.Value;
                string libAr = libBrancheAr.Value;

                branche.addBranche(new Branchee(lib,libAr));
                toAlert.Text = "<div class='alert alert-success'>Bien Ajouter</div>";
            }
            catch (Exception ex)
            {
                toAlert.Text = "<div class='alert alert-danger'>Echec d'ajouter</div>";
                toAlert.Visible = true;
            }
        }

        protected void btnSaveBranche_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idBranche"]);
                string lib = libBranche.Value;
                string libAr = libBrancheAr.Value;

                branche.editBranche(new Branchee(lib, libAr),id);
                toAlert.Text = "<div class='alert alert-success'>Bien Modifier</div>";
                toAlert.Visible = true;


            }
            catch (Exception ex)
            {
                toAlert.Text = "<div class='alert alert-danger'>Echec de Modification</div>";
            }
        }
    }


}