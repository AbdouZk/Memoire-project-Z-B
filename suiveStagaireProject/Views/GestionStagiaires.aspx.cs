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

                if (Request.QueryString["do"].Equals("add") && Request.QueryString["id"] != null)
                {
                    if (DropDownListcodeSecadd.Items.Count==0)
                    {
                        DropDownListcodeSecadd.DataSource = section.viewSections();
                        DropDownListcodeSecadd.DataValueField = "idSec";
                        DropDownListcodeSecadd.DataTextField  = "codeSec";
                        DropDownListcodeSecadd.DataBind();
                    }

                }
                else
                {

                }


                if (Request.QueryString["do"].Equals("edit") && Request.QueryString["idStg"] != null)
                {

                    Stagiaire stag = new Stagiaire();
                    detailsStagiaire detStag = new detailsStagiaire();

                    detStag = stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"]));

                    if (DropDownListCodeSecEdit.Items.Count == 0)
                    {
                        DropDownListCodeSecEdit.DataSource = section.viewSections();
                        DropDownListCodeSecEdit.DataValueField = "idSec";
                        DropDownListCodeSecEdit.DataTextField = "codeSec";
                        DropDownListCodeSecEdit.DataBind();
                    }


                    numInscEdit.Text = detStag.NumInsc; nomEdit.Text = detStag.Nom;  prenomEdit.Text = detStag.Prenom;
                    RadioButtonListSexEdit.SelectedValue = detStag.Sexe;
                    string dateNai = detStag.DateNai.ToString("yyyy-MM-dd");
                    dateNaiEdit.Value = dateNai;
                    lieuNaisEdit.Text = detStag.LieuNai; natEdit.Text = detStag.Nat;
                    DropDownListSitFamEdit.SelectedValue = detStag.SitFam; telPerEdit.Value = detStag.Telephone;  emailAEdit.Value = detStag.Email;
                    DropDownListSangEdit.SelectedValue = detStag.Sang; ppereEdit.Value = detStag.PrenomPere; nmereEdit.Value = detStag.NomMere; pmereEdit.Value = detStag.PrenomMere;
                    profPereEdit.Value = detStag.ProfPere; profMereEdit.Value = detStag.ProfMere; adresseEdit.Value = detStag.Adresse; telTuteurEdit.Value = detStag.TelTuteur;
                    DropDownListSitFamParEdit.SelectedValue = detStag.SitFamParents;  derEtabFreEdit.Value = detStag.DerEtabFre; dropDownNivScolaireEdit.SelectedValue= detStag.NivScolaire;

                    RadioButtonListSitMedEdit.SelectedValue = detStag.SitMedical.ToString();
                    DropDownListCodeSecEdit.SelectedValue = detStag.IdSection.ToString();




                }
                else
                {
                    
                }


                if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idStg"] != null)
                {

                    StgToDrop.Text = stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"])).Nom +" "+ stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"])).Prenom;
                    StgToDrop.Visible = true;



                }
                else
                {
                    StgToDrop.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddStag_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionStagiaires.aspx?id="+Session["id"]+"&do=add");
        }

        protected void btnAjouterStgAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupération des données 
                string numInsc = numInscAdd.Text, nom = nomAdd.Text, prenom = prenomAdd.Text,
                    sexe = RadioButtonListSex.SelectedValue, lieuNais = lieuNaisAdd.Text, nat = natAdd.Text,
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


                // Add Personne part

                PersonnelInfo per = new PersonnelInfo(idPersonne,nom,prenom,dateNai,lieuNais,sexe,adress,email,telephone);
                personnelInfo.addPersonnelInfo(per);

                //add Details Stagiaire

                DetailsStagiaire ds = new DetailsStagiaire(idDetails,sang,sitMed,pPere,nMere,pMere,telTuteur,nat,derEtaFre,nivSco,sitFam,proPere,proMere,sitFamP);
                detailsStagiaire.addDetailStagiaire(ds);

                //add Stagiaire
                Stagiaire stg = new Stagiaire(numInsc,img,codeSec,idPersonne,idDetails);
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
                string
                    numInsc = numInscEdit.Text, nom = nomEdit.Text, prenom = prenomEdit.Text,
                    sexe = RadioButtonListSexEdit.SelectedValue, lieuNais = lieuNaisEdit.Text, nat = natEdit.Text,
                    sitFam = DropDownListSitFamEdit.SelectedValue, telephone = telPerEdit.Value, email = emailAEdit.Value,
                    sang = DropDownListSangEdit.SelectedValue, pPere = ppereEdit.Value, nMere = nmereEdit.Value, pMere = pmereEdit.Value,
                    proPere = profPereEdit.Value, proMere = profMereEdit.Value, adress = adresseEdit.Value, telTuteur = telTuteurEdit.Value,
                    sitFamP = DropDownListSitFamParEdit.SelectedValue, derEtaFre = derEtabFreEdit.Value, nivSco = dropDownNivScolaireEdit.SelectedValue,
                    
                img = FileUploadImgEditStg.FileName;
                FileUploadImgEditStg.SaveAs(Server.MapPath("~/Layout/images/Stagiaires/") + Path.GetFileName(FileUploadImgEditStg.FileName));

                int sitMed = int.Parse(RadioButtonListSitMedEdit.SelectedValue),
                    codeSec = int.Parse(DropDownListCodeSecEdit.SelectedValue),
                    idStg= int.Parse(Request.QueryString["idStg"].ToString()),
                    idPersonne = (int)stagiaire.getStagiaire(idStg).personnelInfoId,
                    idDetails = (int)stagiaire.getStagiaire(idStg).detailsInfoId;




                DateTime dateNai = DateTime.Parse(dateNaiEdit.Value);

               

                // edit Personne part

               // PersonnelInfo per = new PersonnelInfo(idPersonne, nom, prenom, dateNai, lieuNais, sexe, adress, email, telephone);
                //personnelInfo.editPersonnelInfo(per,idPersonne);

                //edit Details Stagiaire

               // DetailsStagiaire ds = new DetailsStagiaire(idDetails, sang, sitMed, pPere, nMere, pMere, telTuteur, nat, derEtaFre, nivSco, sitFam, proPere, proMere, sitFamP);
                //detailsStagiaire.editDetailStagiaire(ds,idDetails);


                //edit Stagiaire
                Stagiaire stg = new Stagiaire(numInsc, img, codeSec, idPersonne, idDetails);
                stagiaire.editStagiaire(stg, idStg);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Stagiaire Bien Modifier</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>" + ex.Message + " </div><br/>";

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