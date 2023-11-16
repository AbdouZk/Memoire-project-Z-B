using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        Exam exam = new Exam();
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
                    if (Request.QueryString["do"].Equals("edit") && Request.QueryString["idExm"] != null)
                    {
                        int idMod = int.Parse(Request.QueryString["idMod"]);
                        string codeSec = Request.QueryString["codeSec"];
                        examaInfo.Text= exam.GetExma(idMod, codeSec).Seance.Module.libelle + " dans la section " + exam.GetExma(idMod, codeSec).Seance.Section.codeSection;
                        noteEli.Value = exam.GetExma(idMod, codeSec).noteEli.ToString();
                        coef.Value = exam.GetExma(idMod, codeSec).coef.ToString();

                    }



                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idExm"] != null)
                    {

                        int idMod = int.Parse(Request.QueryString["idMod"]);
                        string codeSec = Request.QueryString["codeSec"];

                        ExmToDrop.Text = exam.GetExma(idMod, codeSec).Seance.Module.libelle+" dans la section "+ exam.GetExma(idMod, codeSec).Seance.Section.codeSection;
                        ExmToDrop.Visible = true;



                    }
                    else
                    {
                        ExmToDrop.Visible = false;
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

        protected void btnsearchExm_Click(object sender, EventArgs e)
        {
            try
            {
                string by = dropDownBy.SelectedValue;
                string search = searchExm.Value;

                if (search.Equals(""))
                {
                    Response.Redirect("GestionExamens.aspx?id=" + Session["id"] + "&do=AllExamens");
                }
                else
                {
                    Response.Redirect("GestionExamens.aspx?id=" + Session["id"] + "&do=AllExamens&searchExm=" + search + "&By=" + by);
                }


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDropExm_Click(object sender, EventArgs e)
        {
            try
            {
                string codeSection = Request.QueryString["codeSec"];
                int idMod =int.Parse( Request.QueryString["idMod"] );

                exam.deleteExama(idMod,codeSection);
                
                
                Response.Redirect("GestionExamens.aspx?id=" + Session["id"] + "&do=AllExamens");
 

            }
            catch (Exception ex)
            {
                msgModule.Text = "On peut pas supprimer cet examen, Il a des notes ";
            }
        }

        protected void btnSaveExm_Click(object sender, EventArgs e)
        {
            try
            {
                int idExm =int.Parse( Request.QueryString["idExm"]);              
                int nEli = int.Parse(noteEli.Value);
                int coe = int.Parse(coef.Value);

                exam.editExama(new Exam(idExm,"",nEli,coe),idExm);


                msgModule.Text = "Bien Modifier";


            }
            catch (Exception ex)
            {
                msgModule.Text = "On peut pas supprimer cet examen, Il a des notes ";
            }

        }
    }
}