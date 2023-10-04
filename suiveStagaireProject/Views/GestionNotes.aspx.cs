using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Section section = new Section();
            Module module = new Module();
            Stagiaire stagiaire = new Stagiaire();
            Enseignant enseignant = new Enseignant();
            Sec_Mod_Sem sec_mod_sem = new Sec_Mod_Sem();
            Ens_Sec ens_sec = new Ens_Sec();

            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || (groupId ==2 || groupId ==3) )
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

               
                    if (Session["groupId"].ToString() == "4") {

                    int idEns = enseignant.getEnseignatByUserId(int.Parse(Session["id"].ToString())).idEnseiginant;
                    if (dropdownSections.Items.Count == 0)
                    {
                        dropdownSections.DataSource = ens_sec.getSectionByEns(idEns);
                        dropdownSections.DataTextField = "codeSec";
                        dropdownSections.DataValueField = "idSec";
                        dropdownSections.DataBind();
                    }
                    if (Request.QueryString["idSec"] != null && Request.QueryString["idSem"] !=null)
                    {
                        if (dropdownModules.Items.Count == 0)
                        {
                            dropdownModules.DataSource = sec_mod_sem.getModuleByEns(int.Parse(Request.QueryString["idSec"]), int.Parse(Request.QueryString["idSem"]), idEns);
                            dropdownModules.DataTextField = "libMod";
                            dropdownModules.DataValueField = "idMod";
                            dropdownModules.DataBind();
                        }
                    }

                    

                    }
                    else
                    {
                        if (dropdownSections.Items.Count == 0)
                        {
                            dropdownSections.DataSource = section.viewSections();
                            dropdownSections.DataTextField = "codeSec";
                            dropdownSections.DataValueField = "idSec";
                            dropdownSections.DataBind();
                        }

                        if (Request.QueryString["idSec"]!= null && Request.QueryString["idSem"] != null)
                        {
                        if (dropdownModules.Items.Count == 0)
                        {
                            dropdownModules.DataSource = sec_mod_sem.getModuleByEns(int.Parse(Request.QueryString["idSec"]), int.Parse(Request.QueryString["idSem"]));
                            dropdownModules.DataTextField = "libMod";
                            dropdownModules.DataValueField = "idMod";
                            dropdownModules.DataBind();
                        }
                            
                        }
                       
                    }
                 
                

                if (Request.QueryString["do"] != null)
                {


                    if (Request.QueryString["do"].Equals("show") && Request.QueryString["idSec"] != null && Request.QueryString["idMod"] != null && Request.QueryString["idSem"] != null)
                    {
                        int idSec = int.Parse( Request.QueryString["idSec"]);

                        if (listStgs.Items.Count == 0)
                        {
                            listStgs.DataSource = stagiaire.getStagiaires(idSec);
                            listStgs.DataTextField = "nom";
                            listStgs.DataValueField = "idStg";
                            listStgs.DataBind();
                        }

                    }

                    else
                    if (Request.QueryString["do"].Equals("edit") && Request.QueryString["id"] != null)
                    {


                    }
                    else

                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["id"] != null)
                    {

                        //CatToDrop.Text = cataloge.getCatalogeCode(int.Parse(Request.QueryString["idCat"]));
                        //CatToDrop.Visible = true;



                    }
                }
                else
                {
                    //CatToDrop.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }

        }


        protected void btnSuivantSec_Click(object sender, EventArgs e)
        {
            try
            {
                int idSec = int.Parse(dropdownSections.SelectedValue);
                int idSem = int.Parse(DropDownSemestre.SelectedValue);

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseMod&idSec=" + idSec + "&idSem=" + idSem );

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSuivantMod_Click(object sender, EventArgs e)
        {
            try
            {
                int idSem = int.Parse(Request.QueryString["idSem"]);
                int idSec = int.Parse(Request.QueryString["idSec"]);
                int idMod = int.Parse(dropdownModules.SelectedValue);

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&idSec=" + idSec + "&idSem="+ idSem +"&idMod="+idMod);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnIsererNote_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}