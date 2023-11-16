using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Section section = new Section();
        CatalogeSection cataloge = new CatalogeSection();
        Branchee branche = new Branchee();
        Module module = new Module();
     


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId =int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId>=3)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"]==null)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }





                if (Request.QueryString["do"].Equals("add-editSec"))
                {

                  
                    Enseignant ens = new Enseignant();

                    if (DropDownFormationAdd.Items.Count == 0)
                    {
                        DropDownFormationAdd.DataSource = cataloge.getListeCatalogeSec();
                        DropDownFormationAdd.DataTextField = "codeSpe";
                        DropDownFormationAdd.DataValueField = "idCataloge";

                        DropDownFormationAdd.DataBind();
                    }

                    if (DropDowntuteurSecAdd.Items.Count == 0)
                    {
                        DropDowntuteurSecAdd.DataSource = ens.getEnseignantsNames();
                        DropDowntuteurSecAdd.DataValueField = "nameEns";
                        DropDowntuteurSecAdd.DataTextField = "nameEns";

                        DropDowntuteurSecAdd.DataBind();


                    }
                        if (Request.QueryString["opt"] != null)
                        {

                            if (Request.QueryString["opt"].Equals("edit"))
                            {
                                {
                                    if (numSectionAdd.Text.Equals(""))
                                    {
                                        string idSec = Request.QueryString["idSec"];

                                        DropDownFormationAdd.SelectedValue = section.getSection(idSec).idCat.ToString();
                                        numSectionAdd.Text = section.getSection(idSec).codeSection.ElementAt(section.getSection(idSec).codeSection.Length - 1).ToString();
                                        RadioButtonmodeGesAdd.SelectedValue = section.getSection(idSec).modeGestionForm.ToString();
                                        string deb = section.getSection(idSec).dateOuv.ToString("yyyy-MM-dd");
                                        string f = section.getSection(idSec).dateFin.ToString("yyyy-MM-dd");

                                        debutForAdd.Value = deb;
                                        finForAdd.Value = f;
                                        DropDowntuteurSecAdd.SelectedValue = section.getSection(idSec).tuteurSection;

                                        btnAddSec.Visible = false;
                                        btnSaveSec.Visible = true;
                                        btnFicheOuvertureSec.Visible = true;
                                        btnListeStagSec.Visible = true;
                                    }

                                }
                            }
                        }




                }
                

            }
            catch (Exception ex)
            {

            }
        }

    
     

        protected void btnDropSection_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["idSec"] == null)
                {
                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

                }
                else
                {
                    string idSec = (Request.QueryString["idSec"]);
                

                    section.deleteSection(section.getSection(idSec));

                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

                }
            }
            catch (Exception ex)
            {

            }
        }

      



        protected void btnFicheOuvertureSec_Click(object sender, EventArgs e)
        {
            try {
                
                Response.Redirect("reports/ProcesVerbalSection.aspx?id="+Session["id"]+"&do=impression&idSec="+Request.QueryString["idSec"]);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnListeStagSec_Click(object sender, EventArgs e)
        {

            try
            {

                Response.Redirect("reports/ListeStagiairesIncorpores.aspx?id=" + Session["id"] + "&do=impression&idSec=" + Request.QueryString["idSec"]);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddSec_Click(object sender, EventArgs e)
        {
            try
            {
                string codeSec = DropDownFormationAdd.SelectedItem.ToString();
                int idCataloge = int.Parse(DropDownFormationAdd.SelectedValue);
                string numSection = numSectionAdd.Text;
                //char semestre = char.Parse(DropDownListSemestreAdd.SelectedValue);
               // if (semestre == '0') { semestre = '1'; }        
                char modeGes = char.Parse(RadioButtonmodeGesAdd.SelectedValue);
                string debut = debutForAdd.Value;
                string fin = finForAdd.Value;
                string tuteur = DropDowntuteurSecAdd.SelectedValue;


                Section sec = new Section(codeSec+numSection, DateTime.Parse(debut), DateTime.Parse(fin), tuteur, modeGes, 1, idCataloge);
                section.addSection(sec);



            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echec d'ajouter </div><br/>";

            }

        }

        protected void btnSaveSec_Click(object sender, EventArgs e)
        {
            try
            {
                string codeSec = DropDownFormationAdd.SelectedItem.ToString();
                int idCataloge = int.Parse(DropDownFormationAdd.SelectedValue);
                string numSection = numSectionAdd.Text;
                //char semestre = char.Parse(DropDownListSemestreAdd.SelectedValue);
                // if (semestre == '0') { semestre = '1'; }        
                char modeGes = char.Parse(RadioButtonmodeGesAdd.SelectedValue);
                string debut = debutForAdd.Value;
                string fin = finForAdd.Value;
                string tuteur = DropDowntuteurSecAdd.SelectedValue;


                Section sec = new Section(codeSec + numSection, DateTime.Parse(debut), DateTime.Parse(fin), tuteur, modeGes, 2, idCataloge);
                section.editSection(sec, codeSec + numSection);



            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echec de Modifier </div><br/>";

            }

        }
    }
}