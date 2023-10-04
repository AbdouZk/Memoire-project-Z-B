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
        Ens_Sec ens_sec = new Ens_Sec();
        Sec_Mod_Sem sec_mod_sem = new Sec_Mod_Sem();


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

                if (Request.QueryString["do"].Equals("addCat") )
                {
                   
                   

                    if (dropDownBrachees.Items.Count==0) {
                        dropDownBrachees.DataSource = branche.getListeBranchees();
                        dropDownBrachees.DataTextField = "libileBrache";
                        dropDownBrachees.DataValueField = "idBrache";

                        dropDownBrachees.DataBind();
                    }
                    
                }

                if (Request.QueryString["do"].Equals("editCat") && Request.QueryString["idCat"] != null)
                {

                    CatalogeSection cat = new CatalogeSection();
                    cat = cat.getCatalogeSec(int.Parse(Request.QueryString["idCat"]));

                    if (DropDownBracheeEditCat.Items.Count == 0)
                    {
                        DropDownBracheeEditCat.DataSource = branche.getListeBranchees();
                        DropDownBracheeEditCat.DataTextField = "libileBrache";
                        DropDownBracheeEditCat.DataValueField = "idBrache";
                        DropDownBracheeEditCat.DataBind();
                    }
                    if (editCatcodeSpe.Text.Equals(""))
                    {
                        DropDownBracheeEditCat.SelectedValue = cat.brancheId.ToString();
                        editCatcodeSpe.Text = cat.codeSpe;
                        editCatintitulCat.Text = cat.intituleSpe;
                        dropDownFilierEditCat.SelectedValue = cat.fileresExigees;
                        if (cat.niveauFormation == 4) { radioEditCat.SelectedValue = "4"; } else { radioEditCat.SelectedValue = "5"; }
                    }

                    errorsEdit.Visible = false;
                }
                else
                {
                    errorsEdit.Text = "Cataloge Introuvable !";
                    errorsEdit.Visible = true;
                }

                if (Request.QueryString["do"].Equals("deleteCat") && Request.QueryString["idCat"] != null)
                {

                    CatToDrop.Text = cataloge.getCatalogeCode(int.Parse(Request.QueryString["idCat"]));
                    CatToDrop.Visible = true;



                }
                else
                {
                    CatToDrop.Visible = false;
                }

                if (Request.QueryString["do"].Equals("add-editSec") )
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


                    if (Request.QueryString["idSec"] != null && Request.QueryString["idSem"] != null)
                    {
                        if (numSectionAdd.Text.Equals(""))
                        {
                            int idSec = int.Parse(Request.QueryString["idSec"]);

                            DropDownFormationAdd.SelectedValue = section.getSection(idSec).idCat.ToString();
                            numSectionAdd.Text = section.getSection(idSec).numSection.ToString();
                            DropDownListSemestreAdd.SelectedValue = Request.QueryString["idSem"];
                            modeOrgAdd.Text = section.getSection(idSec).modeOrgaForm;
                            RadioButtonmodeGesAdd.SelectedValue = section.getSection(idSec).modeGestionForm.ToString();
                            string deb = section.getSection(idSec).dateOuv.ToString("yyyy-MM-dd");
                            string f = section.getSection(idSec).dateFin.Value.ToString("yyyy-MM-dd");

                            debutForAdd.Value = deb;
                            finForAdd.Value = f;
                            DropDowntuteurSecAdd.SelectedValue = section.getSection(idSec).tuteurSection;

                            btnSuivantSec.Visible = false;
                            btnSuivantSecEdit.Visible = true;
                            btnAnnulerSectionAdd.Visible = false;
                            btnAnnulerSectionEdit.Visible = true;
                            btnFicheOuvertureSec.Visible = true;
                            btnListeStagSec.Visible = true;
                        }

                    }
                    



                }

               
                

                if (Request.QueryString["do"].Equals("aORrMod") && Request.QueryString["idSec"] != null && Request.QueryString["idSem"] != null)
                {

                    if (listBoxModAff.Items.Count == 0)
                    {
                        listBoxModAff.DataSource = module.getModulesNames();
                        listBoxModAff.DataValueField = "idMod";
                        listBoxModAff.DataTextField = "libMod";

                        listBoxModAff.DataBind();
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }

        

        protected void btnSaveEditCat_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idCat"]);
                int branchId = int.Parse(DropDownBracheeEditCat.SelectedValue);
                string codSec = editCatcodeSpe.Text;
                string intitul = editCatintitulCat.Text;
                string FilierExigess = dropDownFilierEditCat.SelectedValue;
                int niveau = int.Parse(radioEditCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec, intitul, FilierExigess, niveau);
                cataloge.updateCatlogSec(cat,id);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Editer</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div><br/>";
            }

        }

        protected void btnDropCtaloge_Click(object sender, EventArgs e)
        {
            try{ 

                CatalogeSection cat = cataloge.getCatalogeSec(int.Parse(Request.QueryString["idCat"]));
                cataloge.deleteCatalogeSec(cat);
                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllCat");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterCat_Click(object sender, EventArgs e)
        {
            try
            {

                int branchId =int.Parse( dropDownBrachees.SelectedValue );
                string codSec = codeSpe.Text;
                string intitul = intitulCat.Text;
                string FilierExigess = dropDownFilierExigess.SelectedValue;
                int niveau =int.Parse( radioNivCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec,intitul, FilierExigess, niveau);
                cataloge.addCatalogeSec(cat);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Ajouter</div>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div>";
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
                    int idSec = int.Parse(Request.QueryString["idSec"]);
                    ens_sec.deleteSec_Ens_SemBySection(idSec);
                    sec_mod_sem.deleteSec_Mod_SemBySection(idSec);

                    section.deleteSection(section.getSection(idSec));

                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnsearchEns_Click(object sender, EventArgs e)
        {
            try
            {
                if (!searchEns.Value.Equals(""))
                {

                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORr" + "&idSec=" + Request.QueryString["idSec"] + "&idSem=" + Request.QueryString["idSem"]+ "&searchEns=" + searchEns.Value);

                }
                else
                {

                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORr"+"&idSec=" +Request.QueryString["idSec"]+"&idSem=" + Request.QueryString["idSem"]);
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
                int idSec = section.getLastId() + 1;
                int idCataloge = int.Parse(DropDownFormationAdd.SelectedValue);
                int numSection = int.Parse(numSectionAdd.Text);
                char semestre = char.Parse(DropDownListSemestreAdd.SelectedValue);
                if (semestre == '0') { semestre = '1'; }
                string modeOrg = modeOrgAdd.Text;
                char modeGes = char.Parse(RadioButtonmodeGesAdd.SelectedValue);
                string debut = debutForAdd.Value;
                string fin = finForAdd.Value;
                string tuteur = DropDowntuteurSecAdd.SelectedValue;


                if (section.countSecById(idSec) !=0)
                {             
                    section.deleteSection(section.getSection(idSec));
                }

                Section sec = new Section(idSec, DateTime.Parse(debut), DateTime.Parse(fin), numSection, tuteur, modeGes, modeOrg,semestre, idCataloge);
                section.addSection(sec);

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORr" + "&idSec=" + idSec + "&idSem=" + semestre);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echec de continuer </div><br/>";

            }
        }

        protected void btnSuivantEns_Click(object sender, EventArgs e)
        {
            try
            {
                int idSec =int.Parse( Request.QueryString["idSec"]);
                int semestre = int.Parse(Request.QueryString["idSem"]);

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORrMod" + "&idSec=" + idSec + "&idSem=" + semestre);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Erreur De Saisir </div><br/>";

            }
        }

        protected void btnAnnulerEns_Click(object sender, EventArgs e)
        {
            try
            {
                int idSec = int.Parse(Request.QueryString["idSec"]);
                int semestre = int.Parse(Request.QueryString["idSem"]);

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=add-editSec" + "&idSec=" + idSec + "&idSem=" + semestre);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Erreur De Saisir </div><br/>";

            }
        }

        protected void btnSuivantMod_Click(object sender, EventArgs e)
        {
            try
            {
               

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc d'Ajouter </div><br/>";

            }
        }

        protected void btnAnnulerMod_Click(object sender, EventArgs e)
        {
            try
            {
                int idSec = int.Parse(Request.QueryString["idSec"]);
                int semestre = int.Parse(Request.QueryString["idSem"]);

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORr" + "&idSec=" + idSec + "&idSem=" + semestre);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Erreur De Saisir </div><br/>";

            }
        }

        protected void btnAffMod_Click(object sender, EventArgs e)
        {
            try
            {
                if ( Request.QueryString["idSem"] != null && Request.QueryString["idSec"] != null)
                {
                    int idMod = int.Parse(listBoxModAff.SelectedValue);
                    int idSem = int.Parse(Request.QueryString["idSem"]);
                    int idSec = int.Parse(Request.QueryString["idSec"]);
                    int noteEli = int.Parse(noteEl.Value);
                    int coenf = int.Parse(coef.Value);

                    if (sec_mod_sem.countSecModSemByAll(idSec, idSem, idMod) == 0)
                    {
                        sec_mod_sem.addSec_Mod_Sem(new Sec_Mod_Sem(idSec, idMod, idSem, noteEli, coenf));
                    }

                    string currentUrl = Request.Url.ToString();

                    string newUrl = currentUrl.Replace($"do={ Request.QueryString["do"]}", $"do={"aORrMod"}");

                    // Redirect to the updated URL
                    Response.Redirect(newUrl);
                }
                else { Response.Redirect("404-page.aspx"); }

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<span class='alert alert-danger'> Echèc d'affectation Echec d'affectation <span>";
            }
        }

        protected void btnRetMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idSem"] != null && Request.QueryString["idSec"] != null)
                {
                    int idMod = int.Parse(listBoxModAff.SelectedValue);
                    int idSem = int.Parse(Request.QueryString["idSem"]);
                    int idSec = int.Parse(Request.QueryString["idSec"]);


                    if (sec_mod_sem.countSecModSemByAll(idSec, idSem, idMod) != 0)
                    {
                        sec_mod_sem.deleteSec_Mod_Sem(sec_mod_sem.getEns_SecByAll(idSec, idSem, idMod));
                    }

                    string currentUrl = Request.Url.ToString();

                    string newUrl = currentUrl.Replace($"do={ Request.QueryString["do"]}", $"do={"aORrMod"}");

                    // Redirect to the updated URL
                    Response.Redirect(newUrl);
                }
                else { Response.Redirect("404-page.aspx"); }

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<span class='alert alert-danger'> Echèc de reterait <span>";
            }
        }

        protected void btnAnnulerSectionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idSec"] == null )
                {
                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

                }
                else
                {
                    int idSec =int.Parse( Request.QueryString["idSec"]);
                    ens_sec.deleteSec_Ens_SemBySection(idSec);
                    sec_mod_sem.deleteSec_Mod_SemBySection(idSec);
                    
                    section.deleteSection(section.getSection(idSec));

                    Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

                }



            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'> Echèc de Annuler </div><br/>";

            }
        }

        protected void btnSuivantSecEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int idSec =int.Parse( Request.QueryString["idSec"]);
                int idCataloge = int.Parse(DropDownFormationAdd.SelectedValue);
                int numSection = int.Parse(numSectionAdd.Text);
                char semestre = char.Parse(DropDownListSemestreAdd.SelectedValue);
                if (semestre == '0') { semestre = '1'; }
                string modeOrg = modeOrgAdd.Text;
                char modeGes = char.Parse(RadioButtonmodeGesAdd.SelectedValue);
                string debut = debutForAdd.Value;
                string fin = finForAdd.Value;
                string tuteur = DropDowntuteurSecAdd.SelectedValue;


                
                    Section sec = new Section(idSec, DateTime.Parse(debut), DateTime.Parse(fin), numSection, tuteur, modeGes, modeOrg,semestre, idCataloge);
                    section.editSection(sec,idSec);
                

                

                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=aORr" + "&idSec=" + idSec + "&idSem=" + semestre);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echec de continuer </div><br/>";

            }
        }

        protected void btnAnnulerSectionEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

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
    }
}