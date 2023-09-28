using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class ListeStagiaires
    {
        private int idStg;
        private string numInsc;
        private string codeSec;
        private string dateLieuNais;
        private string status;
        private string nom;
        private string prenom;
        private string img;

        public int IdStg { get => idStg; set => idStg = value; }
        public string NumInsc { get => numInsc; set => numInsc = value; }
        public string CodeSec { get => codeSec; set => codeSec = value; }
        public string DateLieuNais { get => dateLieuNais; set => dateLieuNais = value; }
        public string Status { get =>  status; set =>  status = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Img { get => img; set => img = value; }

        public ListeStagiaires()
        {
        }

        public ListeStagiaires(int idStg, string numInsc, string codeSec,string dateLieuNais, string status, string nom, string prenom, string img)
        {
            this.idStg = idStg;
            this.numInsc = numInsc;
            this.codeSec = codeSec;
            this.dateLieuNais = dateLieuNais;
            this.nom = nom;
            this.prenom = prenom;
            this.img = img;
        }
    }
}