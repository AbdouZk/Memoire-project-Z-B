using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        Seance seance = new Seance();
        Section section = new Section();
        Module module = new Module();
        Enseignant enseignant = new Enseignant();
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
                    if (Request.QueryString["do"].Equals("add-edit") && Request.QueryString["opt"] != null)
                    {

                        if (Request.QueryString["opt"].Equals("add"))
                        {

                            if (dropDownMod.Items.Count == 0)
                            {
                                dropDownMod.DataSource = module.getModules();
                                dropDownMod.DataTextField = "libelle";
                                dropDownMod.DataValueField = "idModule";
                                dropDownMod.DataBind();

                                dropDownSec.DataSource = section.getAllSection();
                                dropDownSec.DataValueField = "codeSection";
                                dropDownSec.DataTextField = "codeSection";
                                dropDownSec.DataBind();

                                dropDownProf.DataSource = enseignant.getEnseignantsNames();
                                dropDownProf.DataValueField = "idEns";
                                dropDownProf.DataTextField = "nameEns";
                                dropDownProf.DataBind();

                            }

                            btnAddSeance.Visible = true;

                        }
                        else if (Request.QueryString["opt"].Equals("edit"))
                        {
                            string idS = (Request.QueryString["idSeance"]);

                            if (dropDownMod.Items.Count == 0)
                            {
                                dropDownMod.DataSource = module.getModules();
                                dropDownMod.DataTextField = "libelle";
                                dropDownMod.DataValueField = "idModule";
                                dropDownMod.DataBind();

                                dropDownSec.DataSource = section.getAllSection();
                                dropDownSec.DataValueField = "codeSection";
                                dropDownSec.DataTextField = "codeSection";
                                dropDownSec.DataBind();

                                dropDownProf.DataSource = enseignant.getEnseignantsNames();
                                dropDownProf.DataValueField = "idEns";
                                dropDownProf.DataTextField = "nameEns";
                                dropDownProf.DataBind();

                            }

                            dropDownMod.SelectedValue = seance.GetSreance(idS).idMod.ToString();
                            dropDownSec.SelectedValue = seance.GetSreance(idS).idSec;
                            dropDownProf.SelectedValue = seance.GetSreance(idS).idEns.ToString();
                            volumeH.Value = seance.VH.ToString();
                            btnSaveSeance.Visible = true;

                        }
                        else
                        {
                            Response.Redirect("404-page.aspx");
                        }
                    }

                    


                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idSeance"] != null)
                    {
                        Seance s = seance.GetSreance((Request.QueryString["idSeance"]));
                        SeanceToDrop.Text = s.Module.libelle+"("+s.typeSeance+")"+" de la section "+s.Section.codeSection;
                        SeanceToDrop.Visible = true;



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

        protected void btnAddSeance_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idMod =int.Parse( dropDownMod.SelectedValue );
                int idProf =int.Parse( dropDownProf.SelectedValue );
                int? VH =int.Parse( volumeH.Value );
                if (VH == null) { VH = 0; }
                string idSec =dropDownSec.SelectedValue ;
                string typeseance = DropDownTypeSeance.SelectedValue;

                string idSeance =idMod+"_"+idSec+"/"+typeseance ; 
                Seance s = new Seance(idSeance, typeseance, VH, idSec, idProf, idMod);

                seance.addSeabce(s);

                msgSeance.Text = "Bien Ajouter";
                msgSeance.Visible = true;


            }
            catch (Exception ex)
            {
                msgSeance.Text = "Echèc D'ajouter";
                msgSeance.Visible = true;
            }
        }

        protected void btnSaveSeance_Click(object sender, EventArgs e)
        {
            try
            {
             
                int idMod = int.Parse(dropDownMod.SelectedValue);
                int idProf = int.Parse(dropDownProf.SelectedValue);
                int? VH = int.Parse(volumeH.Value);
                if (VH == null) { VH = 0; }
                string idSec = dropDownSec.SelectedValue ;
                string typeseance = DropDownTypeSeance.SelectedValue;

                string idSeance = Request.QueryString["idSeance"];
                Seance s = new Seance(idSeance, typeseance, VH, idSec, idProf, idMod);

               

                seance.editSeance(s, idSeance);

                msgSeance.Text = "Bien Modifier";
                msgSeance.Visible = true;


            }
            catch (Exception ex)
            {
                msgSeance.Text = "Echèc De modifier";
                msgSeance.Visible = true;
            }
        }

        protected void btnDropSeance_Click(object sender, EventArgs e)
        {
            try
            {
                string idSeance=(Request.QueryString["idSeance"]);
               
                seance.deleteSeance(seance.GetSreance(idSeance));

                Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=AllSeances");


            }
            catch (Exception ex)
            {
                msgSeance.Text = "Echèc De modifier";
                msgSeance.Visible = true;
            }
        }

     

        protected void btnsearchSeance_Click(object sender, EventArgs e)
        {

            try
            {
                string by = dropDownBy.SelectedValue;
                string search = searchSeance.Value;

                if (search.Equals(""))
                {
                    Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=AllSeances");
                }
                else
                {
                    Response.Redirect("GestionSeances.aspx?id="+Session["id"]+"&do=AllSeances&searchSeance="+search+"&By="+by);
                }


            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnCreationExm_Click(object sender, EventArgs e)
        {
            try
            {
                string idSeance = Request.QueryString["idSeance"];
                int idExm = exam.getLastExmId() + 1;
                int noteE = int.Parse(noteEli.Value);
                int coeff = int.Parse(coef.Value);
                

                exam.addExama(new Exam(idExm ,idSeance,noteE,coeff));
          

                Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=AllSeances");
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}