using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class PersonnelInfo
    {

        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public PersonnelInfo(int idPersonne, string nom, string prenom, DateTime? dateNai, string lieuNai, string sexe, string adresse, string email, string telephone, EntitySet<Stagiaire> stagiaires)
        {
            this.idPersonne = idPersonne;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNai = dateNai;
            this.lieuNai = lieuNai;
            this.sexe = sexe;
            this.adresse = adresse;
            this.email = email;
            this.telephone = telephone;
            Stagiaires = stagiaires;
        }

        public PersonnelInfo(int idPersonne, string nom, string prenom, DateTime? dateNai, string lieuNai, string sexe, string adresse, string email, string telephone, EntitySet<Enseiginant> enseiginants)
        {
            this.idPersonne = idPersonne;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNai = dateNai;
            this.lieuNai = lieuNai;
            this.sexe = sexe;
            this.adresse = adresse;
            this.email = email;
            this.telephone = telephone;
            Enseiginants = enseiginants;
        }

        public PersonnelInfo(int idPersonne, string nom, string prenom, DateTime? dateNai, string lieuNai, string sexe, string adresse, string email, string telephone)
        {
            this.idPersonne = idPersonne;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNai = dateNai;
            this.lieuNai = lieuNai;
            this.sexe = sexe;
            this.adresse = adresse;
            this.email = email;
            this.telephone = telephone;
        }


        public PersonnelInfo getPersonnelInfo(int id)
        {

            return (from pi in dc.PersonnelInfos where pi.idPersonne==id select pi).Single();
        } 
        
       


        public void addPersonnelInfo(PersonnelInfo pi)
        {
            dc.PersonnelInfos.InsertOnSubmit(pi);
            dc.SubmitChanges();
        }

        public void editPersonnelInfo(PersonnelInfo pi,int id)
        {
            var perInfo = from prI in dc.PersonnelInfos where prI.idPersonne == id select prI;

            foreach (var prI in perInfo)
            {
                prI.nom = pi.nom;
                prI.prenom = pi.prenom;
                prI.dateNai = pi.dateNai;
                prI.lieuNai = pi.lieuNai;
                prI.sexe = pi.sexe;
                prI.adresse = pi.adresse;
                prI.telephone = pi.telephone;
                prI.email = pi.email;
            }

            dc.SubmitChanges();
        }

        public void deletePersonnelInfo(PersonnelInfo pi)
        {
            dc.PersonnelInfos.DeleteOnSubmit(pi);
            dc.SubmitChanges();
        }
    }
}