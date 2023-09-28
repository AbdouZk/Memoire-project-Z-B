using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class ListeEnseignant
    {
        private int idEns;
        private string specialite;
        private string dateDebut;
        private string username;
        private string userId;
        private string idPers;
        private string nom;
        private string prenom;

        public int IdEns { get => idEns; set => idEns = value; }
        public string Specialite { get => specialite; set => specialite = value; }
        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string Username { get => username; set => username = value; }
        public string UserId { get => userId; set => userId = value; }
        public string IdPers { get => idPers; set => idPers = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public ListeEnseignant(int idEns, string specialite, string dateDebut, string username, string userId, string idPers, string nom, string prenom)
        {
            this.idEns = idEns;
            this.specialite = specialite;
            this.dateDebut = dateDebut;
            this.username = username;
            this.userId = userId;
            this.idPers = idPers;
            this.nom = nom;
            this.prenom = prenom;
        }

        public ListeEnseignant()
        {
        }
    }
}