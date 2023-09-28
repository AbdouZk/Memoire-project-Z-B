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

                if (Request.QueryString["do"].Equals("addSec") )
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

                    if (DropDownEnsAdd.Items.Count == 0)
                    {
                        DropDownEnsAdd.DataSource = ens.getEnseignantsNames();
                        DropDownEnsAdd.DataValueField = "idEns";
                        DropDownEnsAdd.DataTextField = "nameEns";

                        DropDownEnsAdd.DataBind();
                    }
                    if (DropDownModules.Items.Count == 0)
                    {
                        DropDownModules.DataSource = module.getModulesNames();
                        DropDownModules.DataValueField = "idMod";
                        DropDownModules.DataTextField = "libMod";

                        DropDownModules.DataBind();
                    }


                }

                if (Request.QueryString["do"].Equals("editSec") && Request.QueryString["idSec"] != null)
                {
                    CatalogeSection cat = new CatalogeSection();
                    Section sec = new Section();
                    Enseignant ens = new Enseignant();
                    sec = sec.getSection(int.Parse(Request.QueryString["idSec"]));

                    

                    if (DropDownFormationEdit.Items.Count == 0)
                    {
                        // Fill all formations
                        DropDownFormationEdit.DataSource = cat.getListeCatalogeSec();
                        DropDownFormationEdit.DataTextField = "codeSpe";
                        DropDownFormationEdit.DataValueField = "idCataloge";
                        DropDownFormationEdit.DataBind();

                        // Fill all Enseignats names
                        DropDowntuteurSecEdit.DataSource = ens.getEnseignantsNames();
                        DropDowntuteurSecEdit.DataValueField = "nameEns";
                        DropDowntuteurSecEdit.DataTextField = "nameEns";
                        DropDowntuteurSecEdit.DataBind();


                        DropDownFormationEdit.SelectedValue = sec.idCat.ToString();
                        numSectionEdit.Text = sec.numSection.ToString();
                        //DropDownListSemestreEdit.SelectedValue = sec.semestre.ToString();
                        modeOrgEdit.Text = sec.modeOrgaForm;
                        RadioButtonmodeGesEdit.SelectedValue = sec.modeGestionForm.ToString();

                        string debut = sec.dateOuv.ToString("yyyy-MM-dd");
                        string fin = sec.dateFin.Value.ToString("yyyy-MM-dd");

                        debutForEdit.Value = debut;
                        finForEdit.Value = fin;
                        DropDowntuteurSecEdit.SelectedValue = sec.tuteurSection;
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

        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            try 
            {
                int idCataloge =int.Parse( DropDownFormationAdd.SelectedValue);
                int numSection = int.Parse(numSectionAdd.Text);
                char semestre = char.Parse(DropDownListSemestreAdd.SelectedValue);
                if (semestre == '0') { semestre = '1'; }
                string modeOrg = modeOrgAdd.Text;
                char modeGes = char.Parse(RadioButtonmodeGesAdd.SelectedValue);
                string debut = debutForAdd.Value ;
                string fin = finForAdd.Value;
                string tuteur = DropDowntuteurSecAdd.SelectedValue;

                Section sec = new Section(DateTime.Parse(debut), DateTime.Parse(fin), numSection,tuteur,modeGes,modeOrg,idCataloge);
                
                
                
                section.addSection(sec);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Ajouter</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>"+ex.Message+" </div><br/>";

            }
        }

        protected void btnEditSection_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idSec"]);

                int idCataloge = int.Parse(DropDownFormationEdit.SelectedValue);
                int numSection = int.Parse(numSectionEdit.Text);
                char semestre = char.Parse(DropDownListSemestreEdit.SelectedValue);
                string modeOrg = modeOrgEdit.Text;
                char modeGes = char.Parse(RadioButtonmodeGesEdit.SelectedValue);
                string debut = debutForEdit.Value.ToString();
                string fin = finForEdit.Value.ToString();
                string tuteur = DropDowntuteurSecEdit.SelectedValue;

                Section sec = new Section(DateTime.Parse(debut), DateTime.Parse(fin), numSection, tuteur, modeGes, modeOrg, idCataloge);

                section.editSection(sec,id);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Modifer</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc du Modification </div><br/>";

            }
        }

        protected void btnDropSection_Click(object sender, EventArgs e)
        {
            try
            {

                Section sec = section.getSection(int.Parse(Request.QueryString["idSec"]));
                section.deleteSection(sec);
                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAffecEnsSec_Click(object sender, EventArgs e)
        {
            try {
                string idEns = DropDownEnsAdd.SelectedValue;
                string nameEns = DropDownEnsAdd.SelectedItem.Text;
                

                List<ListItem> allEns = new List<ListItem>();

            
                foreach (ListItem item in listEnseignants.Items)
                {
                    
                    allEns.Add(item);
                }              


                if (allEns.Count == 0)
                {
                    listEnseignants.Items.Add("#" + idEns + " " + nameEns);
                    listEnseignants.DataBind();
                }
                else
                {
                    bool find = false;
                    foreach (ListItem item in allEns)
                    {
                        if (item.Value.Equals("#" + idEns + " " + nameEns))
                        {
                            find = true;
                            break;
                            
                        }
                       

                    }
                    if (!find)
                    {
                        listEnseignants.Items.Add("#" + idEns + " " + nameEns);
                        listEnseignants.DataBind();
                    }
                }
                
                
            } catch (Exception ex) 
            {
            }

        }

        protected void btnAffecModSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (!confMod.Value.Equals("") && !noteEl.Value.Equals(""))
                {
                    string idMod = DropDownModules.SelectedValue;
                    string libMod = DropDownModules.SelectedItem.Text;
                    string nEli = noteEl.Value;
                    string cof = confMod.Value;


                    List<ListItem> allMod = new List<ListItem>();


                    foreach (ListItem item in listBoxModules.Items)
                    {

                        allMod.Add(item);
                    }


                    if (allMod.Count == 0)
                    {
                        listBoxModules.Items.Add("#" + idMod + " " + libMod + " Coenf:" + cof + " Note Eli:" + nEli);
                        listBoxModules.DataBind();
                    }
                    else
                    {
                        bool find = false;
                        foreach (ListItem item in allMod)
                        {
                            if (item.Value=="#" + idMod + " " + libMod + " Coenf:" + cof + " Note Eli:" + nEli)
                            {
                                find = true;
                                break;

                            }

                        }
                        if (!find)
                        {
                            listBoxModules.Items.Add("#" + idMod + " " + libMod + " Coenf:" + cof + " Note Eli:" + nEli);
                            listBoxModules.DataBind();
                        }
                    }

                }

               

            }
            catch (Exception ex)
            {
            }
        }
    }
}