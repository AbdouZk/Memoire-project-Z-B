using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class detailsStagiaire
    {
    
        // detailStg table
        private string sang;
        private int sitMedical;
        private string prenomPere;
        private string nomMere;
        private string prenomMere;
        private string telTuteur;
        private string nat;
        private string derEtabFre;
        private string nivScolaire;
        private string sitFam;
        private string profPere;
        private string profMere;
        private string sitFamParents;

        //personnelInfo Table 
        private string nom;
        private string prenom;
        private DateTime dateNai;
        private string lieuNai;
        private string sexe;
        private string adresse;
        private string email;
        private string telephone;

        // stagiaire table
        private int id;
        private string numInsc;
        private string img;
        private string statusStg;
        private int idSection;  
        private int personnelInfoId;
        private int detailsInfoId;

        // section table
        private int ididSec;
        private DateTime dateOuv;
        private DateTime dateFin;
        private int numSection;
        private string modeGes;

        // cataloge table
        private string libForm;
        private string nivForm;
        private string codeFor;

        public detailsStagiaire()
        {
        }

        public detailsStagiaire(string sang, int sitMedical, string prenomPere, string nomMere, string prenomMere, string telTuteur, string nat, string derEtabFre, string nivScolaire, string sitFam, string profPere, string profMere, string sitFamParents, string nom, string prenom, DateTime dateNai, string lieuNai, string sexe, string adresse, string email, string telephone, int id, string numInsc, string img, string statusStg, int idSection, int personnelInfoId, int detailsInfoId, int ididSec, DateTime dateOuv, DateTime dateFin, int numSection, string modeGes, string libForm, string nivForm, string codeFor)
        {
            this.Sang = sang;
            this.SitMedical = sitMedical;
            this.PrenomPere = prenomPere;
            this.NomMere = nomMere;
            this.PrenomMere = prenomMere;
            this.TelTuteur = telTuteur;
            this.Nat = nat;
            this.DerEtabFre = derEtabFre;
            this.NivScolaire = nivScolaire;
            this.SitFam = sitFam;
            this.ProfPere = profPere;
            this.ProfMere = profMere;
            this.SitFamParents = sitFamParents;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNai = dateNai;
            this.LieuNai = lieuNai;
            this.Sexe = sexe;
            this.Adresse = adresse;
            this.Email = email;
            this.Telephone = telephone;
            this.Id = id;
            this.NumInsc = numInsc;
            this.Img = img;
            this.StatusStg =  statusStg;
            this.IdSection = idSection;
            this.PersonnelInfoId = personnelInfoId;
            this.DetailsInfoId = detailsInfoId;
            this.IdidSec = ididSec;
            this.DateOuv = dateOuv;
            this.DateFin = dateFin;
            this.NumSection = numSection;
            this.ModeGes = modeGes;
            this.LibForm = libForm;
            this.NivForm = nivForm;
            this.codeFor = codeFor;
        }

        public string Sang { get => sang; set => sang = value; }
        public int SitMedical { get => sitMedical; set => sitMedical = value; }
        public string PrenomPere { get => prenomPere; set => prenomPere = value; }
        public string NomMere { get => nomMere; set => nomMere = value; }
        public string PrenomMere { get => prenomMere; set => prenomMere = value; }
        public string TelTuteur { get => telTuteur; set => telTuteur = value; }
        public string Nat { get => nat; set => nat = value; }
        public string DerEtabFre { get => derEtabFre; set => derEtabFre = value; }
        public string NivScolaire { get => nivScolaire; set => nivScolaire = value; }
        public string SitFam { get => sitFam; set => sitFam = value; }
        public string ProfPere { get => profPere; set => profPere = value; }
        public string ProfMere { get => profMere; set => profMere = value; }
        public string SitFamParents { get => sitFamParents; set => sitFamParents = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNai { get => dateNai; set => dateNai = value; }
        public string LieuNai { get => lieuNai; set => lieuNai = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public int Id { get => id; set => id = value; }
        public string NumInsc { get => numInsc; set => numInsc = value; }
        public string Img { get => img; set => img = value; }
        public string StatusStg { get => statusStg; set => statusStg = value; }
        public int IdSection { get => idSection; set => idSection = value; }
        public int PersonnelInfoId { get => personnelInfoId; set => personnelInfoId = value; }
        public int DetailsInfoId { get => detailsInfoId; set => detailsInfoId = value; }
        public int IdidSec { get => ididSec; set => ididSec = value; }
        public DateTime DateOuv { get => dateOuv; set => dateOuv = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public int NumSection { get => numSection; set => numSection = value; }
        public string ModeGes { get => modeGes; set => modeGes = value; }
        public string LibForm { get => libForm; set => libForm = value; }
        public string NivForm { get => nivForm; set => nivForm = value; }
        public string CodeForm { get => codeFor; set => codeFor = value; }
    }
}