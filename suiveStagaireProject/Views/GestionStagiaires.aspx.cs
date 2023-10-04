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
                                DropDownListcodeSecadd.DataSource = section.viewSections();
                                DropDownListcodeSecadd.DataValueField = "idSec";
                                DropDownListcodeSecadd.DataTextField = "codeSec";
                                DropDownListcodeSecadd.DataBind();
                            }
                            btnAjouterStgAdd.Visible = true;
                        }
                        else
                        if (Request.QueryString["opt"].Equals("edit") && Request.QueryString["idStg"] != null)
                        {
                            Stagiaire stag = new Stagiaire();
                            detailsStagiaire detStag = new detailsStagiaire();

                            detStag = stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"]));

                            if (DropDownListcodeSecadd.Items.Count == 0)
                            {
                                DropDownListcodeSecadd.DataSource = section.viewSections();
                                DropDownListcodeSecadd.DataValueField = "idSec";
                                DropDownListcodeSecadd.DataTextField = "codeSec";
                                DropDownListcodeSecadd.DataBind();



                                numInscAdd.Text = detStag.NumInsc; nomAdd.Text = detStag.Nom; prenomAdd.Text = detStag.Prenom;
                                RadioButtonListSex.SelectedValue = detStag.Sexe;
                                string dateNai = detStag.DateNai.ToString("yyyy-MM-dd");
                                dateNaiAdd.Value = dateNai;
                                lieuNaisAdd.Text = detStag.LieuNai; natAdd.Text = detStag.Nat;
                                DropDownListSitFamAdd.SelectedValue = detStag.SitFam; telPerAdd.Value = detStag.Telephone; emailAdd.Value = detStag.Email;
                                DropDownListSangAdd.SelectedValue = detStag.Sang; ppereadd.Value = detStag.PrenomPere; nmereadd.Value = detStag.NomMere; pmereadd.Value = detStag.PrenomMere;
                                profPereadd.Value = detStag.ProfPere; profMereadd.Value = detStag.ProfMere; adresseadd.Value = detStag.Adresse; telTuteuradd.Value = detStag.TelTuteur;
                                DropDownListSitFamAdd.SelectedValue = detStag.SitFamParents; derEtabFreadd.Value = detStag.DerEtabFre; dropDownNivScolaireAdd.SelectedValue = detStag.NivScolaire;

                                RadioButtonListsitMed.SelectedValue = detStag.SitMedical.ToString();
                                DropDownListcodeSecadd.SelectedValue = detStag.IdSection.ToString();

                                btnsaveEditStg.Visible = true;
                            }
                        }
                       
                    }
                        if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idStg"] != null)
                        {

                            StgToDrop.Text = stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"])).Nom + " " + stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"])).Prenom;
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

        protected void btnAddStag_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionStagiaires.aspx?id="+Session["id"]+"&do=add-edit&opt=add");
        }

        protected void btnAjouterStgAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupération des données 
                string numInsc = numInscAdd.Text, nom = nomAdd.Text, prenom = prenomAdd.Text,status="Admis",
                    sexe = RadioButtonListSex.SelectedValue, lieuNais = lieuNaisAdd.Text, nat = "",
                    sitFam = dropDownSitFamAdd.SelectedValue, telephone = telPerAdd.Value, email = emailAdd.Value,
                    sang = DropDownListSangAdd.SelectedValue, pPere = ppereadd.Value, nMere = nmereadd.Value, pMere = pmereadd.Value,
                    proPere = profPereadd.Value, proMere = profMereadd.Value, adress = adresseadd.Value, telTuteur = telTuteuradd.Value,
                    sitFamP = DropDownListSitFamAdd.SelectedValue, derEtaFre = derEtabFreadd.Value, nivSco = dropDownNivScolaireAdd.SelectedValue,
                    
                    img = FileUploadImgAdd.FileName;
                    FileUploadImgAdd.SaveAs(Server.MapPath("~/Layout/images/Stagiaires/") + Path.GetFileName(FileUploadImgAdd.FileName));

                int sitMed=int.Parse(RadioButtonListsitMed.SelectedValue),
                    codeSec=int.Parse(DropDownListcodeSecadd.SelectedValue),
                    idPersonne, idDetails=0;

                 idDetails = detailsStagiaire.getLastId() + 1; 
                idPersonne = personnelInfo.getLastId() + 1; 
                

                DateTime dateNai=DateTime.Parse( dateNaiAdd.Value);

                if (radioGroupNat.SelectedValue.Equals("Etrangere"))
                {
                    nat = natAdd.Text;
                }
                else
                {
                    nat = radioGroupNat.SelectedValue;
                }


                // Add Personne part

                PersonnelInfo per = new PersonnelInfo(idPersonne,nom,prenom,dateNai,lieuNais,sexe,adress,email,telephone);
                personnelInfo.addPersonnelInfo(per);

                //add Details Stagiaire

                DetailsStagiaire ds = new DetailsStagiaire(idDetails,sang,sitMed,pPere,nMere,pMere,telTuteur,nat,derEtaFre,nivSco,sitFam,proPere,proMere,sitFamP);
                detailsStagiaire.addDetailStagiaire(ds);

                //add Stagiaire
                Stagiaire stg = new Stagiaire(numInsc,img, status, codeSec,idPersonne,idDetails);
                stagiaire.addStagiaire(stg);


                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Stagiaire Bien Ajouter</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc d'ajouter</div><br/>";

            }
        }

        protected void saveEditStg_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupération des données 
                string numInsc = numInscAdd.Text, nom = nomAdd.Text, prenom = prenomAdd.Text, status="Admis",
                    sexe = RadioButtonListSex.SelectedValue, lieuNais = lieuNaisAdd.Text, nat = "",
                    sitFam = dropDownSitFamAdd.SelectedValue, telephone = telPerAdd.Value, email = emailAdd.Value,
                    sang = DropDownListSangAdd.SelectedValue, pPere = ppereadd.Value, nMere = nmereadd.Value, pMere = pmereadd.Value,
                    proPere = profPereadd.Value, proMere = profMereadd.Value, adress = adresseadd.Value, telTuteur = telTuteuradd.Value,
                    sitFamP = DropDownListSitFamAdd.SelectedValue, derEtaFre = derEtabFreadd.Value, nivSco = dropDownNivScolaireAdd.SelectedValue,

                    img = FileUploadImgAdd.FileName;
                FileUploadImgAdd.SaveAs(Server.MapPath("~/Layout/images/Stagiaires/") + Path.GetFileName(FileUploadImgAdd.FileName));

                int sitMed = int.Parse(RadioButtonListsitMed.SelectedValue),
                    codeSec = int.Parse(DropDownListcodeSecadd.SelectedValue),
                    idPersonne=0, idDetails = 0, idStg =int.Parse( Request.QueryString["idStg"]);

                idDetails =(int) stagiaire.getStagiaire(idStg).detailsInfoId;
                idPersonne = (int)stagiaire.getStagiaire(idStg).personnelInfoId;


                DateTime dateNai = DateTime.Parse(dateNaiAdd.Value);

                if (radioGroupNat.SelectedValue.Equals("Etrangere"))
                {
                    nat = natAdd.Text;
                }
                else
                {
                    nat = radioGroupNat.SelectedValue;
                }

                // Add Personne part

                PersonnelInfo per = new PersonnelInfo(idPersonne, nom, prenom, dateNai, lieuNais, sexe, adress, email, telephone);
                personnelInfo.editPersonnelInfo(per,idPersonne);

                //add Details Stagiaire

                DetailsStagiaire ds = new DetailsStagiaire(idDetails, sang, sitMed, pPere, nMere, pMere, telTuteur, nat, derEtaFre, nivSco, sitFam, proPere, proMere, sitFamP);
                detailsStagiaire.editDetailStagiaire(ds,idDetails);

                //add Stagiaire
                Stagiaire stg = new Stagiaire(numInsc, img, status, codeSec, idPersonne, idDetails);
                stagiaire.editStagiaire(stg,idStg);


                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Stagiaire Bien Modifier</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Echèc De Mofification "+ex.Message+"</div><br/>";

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