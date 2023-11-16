using suiveStagaireProject.Models;
using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Section section = new Section();
        PersonnelInfo personnelInfo = new PersonnelInfo();
        DetailsStagiaire detailsStagiaire = new DetailsStagiaire();
        Stagiaire stagiaire = new Stagiaire();
        Employeur employeur = new Employeur();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {



                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId >= 4)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"] != null)
                {
                    if (Request.QueryString["do"].Equals("add-edit") && Request.QueryString["opt"] != null)
                    {

                        if (Request.QueryString["opt"].Equals("add"))
                        {
                            if (DropDownListcodeSecadd.Items.Count == 0)
                            {
                                DropDownListcodeSecadd.DataSource = section.getAllSection();
                                DropDownListcodeSecadd.DataValueField = "codeSection";
                                DropDownListcodeSecadd.DataTextField = "codeSection";
                                DropDownListcodeSecadd.DataBind();
                            }
                            if (DropDownListEmp.Items.Count == 0)
                            {
                                DropDownListEmp.DataSource = employeur.GetEmployeurs();
                                DropDownListEmp.DataValueField = "idEpoloyeur";
                                DropDownListEmp.DataTextField = "name";
                                DropDownListEmp.DataBind();
                            }

                            btnAjouterStgAdd.Visible = true;
                        }
                        else
                        if (Request.QueryString["opt"].Equals("edit") && Request.QueryString["idStg"] != null)
                        {
                            Stagiaire stag = new Stagiaire();


                            stag = stagiaire.getStagiaire(int.Parse(Request.QueryString["idStg"]));

                            if (DropDownListcodeSecadd.Items.Count == 0)
                            {
                                DropDownListcodeSecadd.DataSource = section.getAllSection();
                                DropDownListcodeSecadd.DataValueField = "codeSection";
                                DropDownListcodeSecadd.DataTextField = "codeSection";
                                DropDownListcodeSecadd.DataBind();

                               
                                DropDownListEmp.DataSource = employeur.GetEmployeurs();
                                DropDownListEmp.DataValueField = "idEpoloyeur";
                                DropDownListEmp.DataTextField = "name";
                                DropDownListEmp.DataBind();
                                

                                numInscAdd.Text = stag.numInsc; numInscAdd.Enabled = false;
                                nomAdd.Text = stag.PersonnelInfo.nom;nomAddAr.Text = stag.PersonnelInfo.nomAr;
                                prenomAdd.Text = stag.PersonnelInfo.prenom; prenomAddAr.Text = stag.PersonnelInfo.prenomAr;
                                RadioButtonListSex.SelectedValue = stag.PersonnelInfo.sexe;
                                string dateNai = stag.PersonnelInfo.dateNai.Value.ToString("yyyy-MM-dd");
                                dateNaiAdd.Value = dateNai;
                                lieuNaisAdd.Text = stag.PersonnelInfo.lieuNai; lieuNaisAddAr.Text = stag.PersonnelInfo.lieuNaiAr;
                                natAdd.Text = stag.DetailsStagiaire.nat;
                                DropDownListSitFamAdd.SelectedValue = stag.DetailsStagiaire.sitFam; telPerAdd.Value = stag.PersonnelInfo.telephone; emailAdd.Value = stag.PersonnelInfo.email;
                                DropDownListSangAdd.SelectedValue = stag.DetailsStagiaire.sang; ppereadd.Value = stag.DetailsStagiaire.prenomPere; nmereadd.Value = stag.DetailsStagiaire.nomMere; pmereadd.Value = stag.DetailsStagiaire.prenomMere;
                                profPereadd.Value = stag.DetailsStagiaire.profPere; profMereadd.Value = stag.DetailsStagiaire.profMere; 
                                adresseadd.Value = stag.PersonnelInfo.adresse; adresseaddAr.Value = stag.PersonnelInfo.adresseAr;
                                telTuteuradd.Value = stag.DetailsStagiaire.telTuteur;
                                dropDownSitFamAdd.SelectedValue = stag.DetailsStagiaire.sitFam;
                                DropDownListSitFamAdd.SelectedValue = stag.DetailsStagiaire.sitFamParents; derEtabFreadd.Value = stag.DetailsStagiaire.derEtabFre; dropDownNivScolaireAdd.SelectedValue = stag.DetailsStagiaire.nivScolaire;
                                FileUploadImgAdd.Enabled = false;
                                RadioButtonListsitMed.SelectedValue = stag.DetailsStagiaire.sitMedical.ToString();
                                DropDownListcodeSecadd.SelectedValue = stag.idSection;

                                if (stag.employeurId!=null)
                                {
                                    DropDownListEmp.SelectedValue = stag.employeurId.ToString();
                                    rORaStag.Checked = true;
                                    DropDownListEmp.Enabled = true;
                                }

                                btnsaveEditStg.Visible = true;
                            }
                        }

                    }
                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idStg"] != null)
                    {

                        StgToDrop.Text = stagiaire.getStagiaire(int.Parse(Request.QueryString["idStg"])).PersonnelInfo.nom ;
                        StgToDrop.Text = StgToDrop.Text+" " + stagiaire.getStagiaire(int.Parse(Request.QueryString["idStg"])).PersonnelInfo.prenom ;
                        StgToDrop.Visible = true;



                    }
                    else
                    {
                        StgToDrop.Visible = false;
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


        protected void btnAjouterStgAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupération des données 
                string numInsc = numInscAdd.Text.Trim(), nom = nomAdd.Text.Trim(), nomAr = nomAddAr.Text.Trim(), prenom = prenomAdd.Text.Trim(), prenomAr = prenomAddAr.Text.Trim(), status = "Admis",
                    sexe = RadioButtonListSex.SelectedValue, lieuNais = lieuNaisAdd.Text.Trim(), lieuNaisAr = lieuNaisAddAr.Text.Trim(), nat = "",
                    sitFam = dropDownSitFamAdd.SelectedValue, telephone = telPerAdd.Value.Trim(), email = emailAdd.Value.Trim(),
                    sang = DropDownListSangAdd.SelectedValue, pPere = ppereadd.Value.Trim(), nMere = nmereadd.Value.Trim(), pMere = pmereadd.Value.Trim(),
                    proPere = profPereadd.Value.Trim(), proMere = profMereadd.Value.Trim(), adress = adresseadd.Value.Trim(), adressAr = adresseaddAr.Value.Trim(), telTuteur = telTuteuradd.Value.Trim(),
                    sitFamP = DropDownListSitFamAdd.SelectedValue, derEtaFre = derEtabFreadd.Value.Trim(), nivSco = dropDownNivScolaireAdd.SelectedValue,
                    codeSec = DropDownListcodeSecadd.SelectedValue,

                    img = FileUploadImgAdd.FileName;
                if (img.Equals("") && sexe.Equals("Homme")) { img = "photoProfile.png"; }
                if (img.Equals("") && sexe.Equals("Femme")) { img = "photoProfileWoman.png"; }
                FileUploadImgAdd.SaveAs(Server.MapPath("~/Layout/images/Stagiaires/") + Path.GetFileName(img));

                int sitMed = int.Parse(RadioButtonListsitMed.SelectedValue),
                    idPersonne = 0, idDetails = 0, id = 0;
                int? idEmp = null;

                idDetails = detailsStagiaire.getLastId() + 1;
                idPersonne = personnelInfo.getLastId() + 1;
                id = stagiaire.getLastId() + 1;


                DateTime dateNai = DateTime.Parse(dateNaiAdd.Value);

                

                if (radioGroupNat.SelectedValue.Equals("Etrangere"))
                {
                    nat = natAdd.Text.Trim();
                }
                else
                {
                    nat = radioGroupNat.SelectedValue;
                }

                numInsc = numInsc + DateTime.Now.Year.ToString().ElementAt(2) + DateTime.Now.Year.ToString().ElementAt(3) + section.getSection(codeSec).modeGestionForm;


                //Add Personne part

                PersonnelInfo per = new PersonnelInfo(idPersonne, nom, nomAr, prenom, prenomAr, dateNai, lieuNais, lieuNaisAr, sexe, adress, adressAr, email, telephone);
                personnelInfo.addPersonnelInfo(per);

                //add Details Stagiaire

                DetailsStagiaire ds = new DetailsStagiaire(idDetails, sang, sitMed, pPere, nMere, pMere, telTuteur, nat, derEtaFre, nivSco, sitFam, proPere, proMere, sitFamP);
                detailsStagiaire.addDetailStagiaire(ds);


                //add Stagiaire
                if (rORaStag.Checked)
                {
                    idEmp = int.Parse(DropDownListEmp.SelectedValue);
                    Stagiaire stg = new Stagiaire(id, numInsc, img, status, codeSec, idPersonne, idDetails, idEmp);
                    stagiaire.addStagiaireA(stg);
                }
                else
                {
                    Stagiaire stg = new Stagiaire(id, numInsc, img, status, codeSec, idPersonne, idDetails);
                    stagiaire.addStagiaireR(stg);
                }





                Response.Redirect(Request.Url.AbsoluteUri);
               

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc d'ajouter </div><br/>";

            }
        }

        protected void saveEditStg_Click(object sender, EventArgs e)
        {

            try
            {
                // Recupération des données 
                string numInsc = numInscAdd.Text.Trim(), nom = nomAdd.Text.Trim(), nomAr = nomAddAr.Text.Trim(), prenom = prenomAdd.Text.Trim(), prenomAr = prenomAddAr.Text.Trim(), status = "Admis",
                    sexe = RadioButtonListSex.SelectedValue, lieuNais = lieuNaisAdd.Text.Trim(), lieuNaisAr = lieuNaisAddAr.Text.Trim(), nat = "",
                    sitFam = dropDownSitFamAdd.SelectedValue, telephone = telPerAdd.Value.Trim(), email = emailAdd.Value.Trim(),
                    sang = DropDownListSangAdd.SelectedValue, pPere = ppereadd.Value.Trim(), nMere = nmereadd.Value.Trim(), pMere = pmereadd.Value.Trim(),
                    proPere = profPereadd.Value.Trim(), proMere = profMereadd.Value.Trim(), adress = adresseadd.Value.Trim(), adressAr = adresseaddAr.Value.Trim(), telTuteur = telTuteuradd.Value.Trim(),
                    sitFamP = DropDownListSitFamAdd.SelectedValue, derEtaFre = derEtabFreadd.Value.Trim(), nivSco = dropDownNivScolaireAdd.SelectedValue,
                    codeSec = DropDownListcodeSecadd.SelectedValue,

                    img = FileUploadImgAdd.FileName;
                FileUploadImgAdd.SaveAs(Server.MapPath("~/Layout/images/Stagiaires/") + Path.GetFileName(FileUploadImgAdd.FileName));

                int sitMed = int.Parse(RadioButtonListsitMed.SelectedValue),
                    idPersonne = 0, idDetails = 0, id = 0;
                int? idEmp = null;

               
                id = int.Parse(Request.QueryString["idStg"]);
                idDetails =(int) stagiaire.getStagiaire(id).detailsInfoId ;
                idPersonne = (int)stagiaire.getStagiaire(id).personnelInfoId;

                DateTime dateNai = DateTime.Parse(dateNaiAdd.Value);

                if (radioGroupNat.SelectedValue.Equals("Etrangere"))
                {
                    nat = natAdd.Text.Trim();
                }
                else
                {
                    nat = radioGroupNat.SelectedValue;
                }

                numInsc = numInsc + DateTime.Now.Year.ToString().ElementAt(2) + DateTime.Now.Year.ToString().ElementAt(3) + section.getSection(codeSec).modeGestionForm;


                //Add Personne part

               
                PersonnelInfo per = new PersonnelInfo(idPersonne, nom, nomAr, prenom, prenomAr, dateNai, lieuNais, lieuNaisAr, sexe, adress, adressAr, email, telephone);              
                personnelInfo.editPersonnelInfoStg(per,idPersonne);

                //add Details Stagiaire

                DetailsStagiaire ds = new DetailsStagiaire(idDetails, sang, sitMed, pPere, nMere, pMere, telTuteur, nat, derEtaFre, nivSco, sitFam, proPere, proMere, sitFamP);
                
                detailsStagiaire.editDetailStagiaire(ds,idDetails);


                //add Stagiaire
                if (rORaStag.Checked)
                {
                    idEmp = int.Parse(DropDownListEmp.SelectedValue);
                    Stagiaire stg = new Stagiaire(id, numInsc, img, status, codeSec, idPersonne, idDetails, idEmp);
                    stagiaire.editStagiaireA(stg,id);
                }
                else
                {
                    Stagiaire stg = new Stagiaire(id, numInsc, img, status, codeSec, idPersonne, idDetails);
                    stagiaire.editStagiaireR(stg,id);
                }





                Response.Redirect(Request.Url.AbsoluteUri);


            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc de modifier "+ex.Message+"</div><br/>";

            }
        }

        protected void btnDropStagiaire_Click(object sender, EventArgs e)
        {
            try {

                int idstg =int.Parse( Request.QueryString["idStg"]  );

                Stagiaire s = stagiaire.getStagiaire(idstg);
                stagiaire.deleteStagiaire(s);
                detailsStagiaire.deleteDetailStagiaire(detailsStagiaire.getDetailsStagiaire((int)s.detailsInfoId));
                personnelInfo.deletePersonnelInfo(personnelInfo.getPersonnelInfo((int)s.personnelInfoId));

                

                Response.Redirect("GestionStagiaires.aspx?id=" + Session["id"] + "&do=AllStg");

            } catch (Exception ex)
            {

            }
        }

      

        protected void btnsearchStg_Click(object sender, EventArgs e)
        {
            try
            {
                if (!searchStg.Value.Equals("")) {
                    Response.Redirect("GestionStagiaires.aspx?id=" + Session["id"] + "&do=AllStg&searchStg=" + searchStg.Value);
                }
                else
                {
                    Response.Redirect("GestionStagiaires.aspx?id=" + Session["id"] + "&do=AllStg");
                }
            }
            catch (Exception ex)
            {

            }
        }

      

       
    }
}