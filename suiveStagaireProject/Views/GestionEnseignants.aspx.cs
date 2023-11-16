using Scrypt;
using suiveStagaireProject.Models;
using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Enseignant enseignant = new Enseignant();
        PersonnelInfo personnelInfo = new PersonnelInfo();
        detailsEnseignant dens = new detailsEnseignant();
        User user = new User();
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


                if (Request.QueryString["do"].Equals("add-edit") && Request.QueryString["opt"] != null)
                {

                    if (Request.QueryString["opt"].Equals("add"))
                    {
                        btnAjouterEnsAdd.Visible = true;
                       

                    }else if (Request.QueryString["opt"].Equals("edit") && Request.QueryString["idEns"] != null)
                    {

                        if (filiereAdd.Value.Equals("")) {
                            dens = enseignant.getDetailsEnseignant(int.Parse(Request.QueryString["idEns"]));

                            nomAdd.Text = dens.Nom; prenomAdd.Text = dens.Prenom;

                            dateNaiAdd.Value = dens.DateNai.ToString("yyyy-MM-dd");

                            lieuNaisAdd.Text = dens.LieuNai;
                            RadioButtonListSex.SelectedValue = dens.Sexe; adresseadd.Value = dens.Adresse;
                            emailAdd.Value = dens.Email; telPerAdd.Value = dens.Telephone;
                            filiereAdd.Value = dens.Specialite; dateDebutAdd.Value = dens.DateDebut.ToString("yyyy-MM-dd");
                        }
                        
                        btnSaveEns.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("404-page.aspx");
                    }
                }
               


                if (Request.QueryString["do"].Equals("delete") && Request.QueryString["idEns"] == null)
                {


                    Response.Redirect("404-page.aspx");


                }


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddEns_Click(object sender, EventArgs e)
        {

        }

        protected void btnsearchEns_Click(object sender, EventArgs e)
        {
            try
            {
                if (!searchEns.Value.Equals(""))
                {
                    Response.Redirect("GestionEnseignants.aspx?id=" + Session["id"] + "&do=AllEns&searchEns=" + searchEns.Value);
                }
                else
                {
                    Response.Redirect("GestionEnseignants.aspx?id=" + Session["id"] + "&do=AllEns");
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterEnsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateNai = DateTime.Parse(dateNaiAdd.Value);
                DateTime dateDebut = DateTime.Parse(dateDebutAdd.Value);
                string
                    nom = nomAdd.Text, prenom = prenomAdd.Text, filier = filiereAdd.Value,
                    lieuNai = lieuNaisAdd.Text, sexe = RadioButtonListSex.SelectedValue, adresse = adresseadd.Value,
                    email = emailAdd.Value, telp = telPerAdd.Value;
                int
                    idPer = personnelInfo.getLastId() + 1;

                // add info to personnel info table
                PersonnelInfo pInfo = new PersonnelInfo(idPer, nom, prenom, dateNai, lieuNai, sexe, adresse, email, telp);
                personnelInfo.addPersonnelInfoEns(pInfo);

                // add a user for this enseignant
                ScryptEncoder encode = new ScryptEncoder();
                string use = email;
                string pass = nom + dateNai.Year.ToString().Substring(2);
                pass = encode.Encode(pass);
                User us = new User(use, pass, 4, 0, DateTime.Now);
                user.addUser(us);

                // add the enseignant
                int idUser = user.getUserLog(use).id;
                Enseignant ens = new Enseignant(dateDebut, filier, idUser, idPer);
                enseignant.addEnseignant(ens);

                msgEns.Text = "Bien Ajouter";
                msgEns.Visible = true;


            }
            catch (Exception ex)
            {
                msgEns.Text = "Echèc d'ajouter";
                msgEns.Visible = false;
            }
        }

        protected void btnDropEnseignant_Click(object sender, EventArgs e)
        {
            try
            {
                int idEns = int.Parse(Request.QueryString["idEns"]);
                Enseignant ens = enseignant.getEnseignat(idEns);
                enseignant.deleteEnseignant(ens);

                personnelInfo.deletePersonnelInfo(personnelInfo.getPersonnelInfo((int)ens.personnelInfosId));

                Response.Redirect("GestionEnseignants.aspx?id=" + Session["id"] + "&do=AllEns");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSaveEns_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateNai = DateTime.Parse(dateNaiAdd.Value);
                DateTime dateDebut = DateTime.Parse(dateDebutAdd.Value);
                string
                    nom = nomAdd.Text, prenom = prenomAdd.Text, filier = filiereAdd.Value,
                    lieuNai = lieuNaisAdd.Text, sexe = RadioButtonListSex.SelectedValue, adresse = adresseadd.Value,
                    email = emailAdd.Value, telp = telPerAdd.Value;
                int
                    idEns = int.Parse(Request.QueryString["idEns"]),
                    idPer = (int)enseignant.getEnseignat(idEns).personnelInfosId;

                PersonnelInfo pInfo = new PersonnelInfo(idPer, nom, prenom, dateNai, lieuNai, sexe, adresse, email, telp);
                personnelInfo.editPersonnelInfoEns(pInfo, idPer);

                Enseignant ens = new Enseignant(dateDebut, filier, null, idPer);
                enseignant.editEnseignant(ens, idEns);

                msgEns.Text = "Bien Modifier";
                msgEns.Visible = true;


            }
            catch (Exception ex)
            {
                msgEns.Text = "Echèc de Modifier";
                msgEns.Visible = false;
            }
        }
    }
}