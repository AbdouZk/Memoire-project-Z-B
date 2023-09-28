using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class detailsEnseignant
    {
        private int idEns;
        private string specialite;
        private DateTime dateDebut;
        private string username;
        private string userId;
        private string idPers;
        private string nom;
        private string prenom;
        private string adresse;
        private DateTime dateNai;
        private string lieuNai;
        private string sexe;
        private string email;
        private string telephone;

        public detailsEnseignant(int idEns, string specialite, DateTime dateDebut, string username, string userId, string idPers, string nom, string prenom, string adresse, DateTime dateNai, string lieuNai, string sexe, string email, string telephone)
        {
            this.idEns = idEns;
            this.specialite = specialite;
            this.dateDebut = dateDebut;
            this.username = username;
            this.userId = userId;
            this.idPers = idPers;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.dateNai = dateNai;
            this.lieuNai = lieuNai;
            this.sexe = sexe;
            this.email = email;
            this.telephone = telephone;
        }
        public detailsEnseignant()
        {
           
        }

        public int IdEns { get => idEns; set => idEns = value; }
        public string Specialite { get => specialite; set => specialite = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public string Username { get => username; set => username = value; }
        public string UserId { get => userId; set => userId = value; }
        public string IdPers { get => idPers; set => idPers = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime DateNai { get => dateNai; set => dateNai = value; }
        public string LieuNai { get => lieuNai; set => lieuNai = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}