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

        public PersonnelInfo(int idPersonne, string nom, string nomAr, string prenom, string prenomAr, DateTime? dateNai, string lieuNai, string lieuNaiAr, string sexe, string adresse, string adresseAr, string email, string telephone)
        {
            this.idPersonne = idPersonne;
            this.nom = nom;
            this.nomAr = nomAr;
            this.prenom = prenom;
            this.prenomAr = prenomAr;
            this.dateNai = dateNai;
            this.lieuNai = lieuNai;
            this.lieuNaiAr = lieuNaiAr;
            this.sexe = sexe;
            this.adresse = adresse;
            this.adresseAr = adresseAr;
            this.email = email;
            this.telephone = telephone;
        }
        public PersonnelInfo(int idPersonne, string nom,  string prenom,  DateTime? dateNai, string lieuNai,  string sexe, string adresse,  string email, string telephone)
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
            dc.ExecuteCommand("insert into PersonnelInfo (idPersonne,nom,nomAr,prenom,prenomAr,dateNai,lieuNai,lieuNaiAr,sexe,adresse,adresseAr,email,telephone) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})",
                pi.idPersonne,pi.nom,pi.nomAr, pi.prenom,pi.prenomAr,pi.dateNai,pi.lieuNai,pi.lieuNaiAr,pi.sexe,pi.adresse,pi.adresseAr,pi.email,pi.telephone);
            dc.SubmitChanges();
        }

        public void addPersonnelInfoEns(PersonnelInfo pi)
        {
            dc.ExecuteCommand("insert into PersonnelInfo (idPersonne,nom,prenom,dateNai,lieuNai,sexe,adresse,email,telephone) values ({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                pi.idPersonne, pi.nom, pi.prenom, pi.dateNai, pi.lieuNai, pi.sexe, pi.adresse, pi.email, pi.telephone);
            dc.SubmitChanges();
        }

        public void editPersonnelInfoStg(PersonnelInfo pi,int id)
        {
            
          
            var query = from pinfo in dc.PersonnelInfos where pinfo.idPersonne == id select pinfo;

            foreach (var pinfo in query)
            {
                pinfo.nom = pi.nom;
                pinfo.nomAr = pi.nomAr;
                pinfo.prenom = pi.prenom;
                pinfo.prenomAr = pi.prenomAr;
                pinfo.dateNai = pi.dateNai;
                pinfo.lieuNai = pi.lieuNai;
                pinfo.lieuNaiAr = pi.lieuNaiAr;
                pinfo.sexe = pi.sexe;
                pinfo.adresse = pi.adresse;
                pinfo.adresseAr = pi.adresseAr;
                pinfo.email = pi.email;
                pinfo.telephone = pi.telephone;
            }

            dc.SubmitChanges();
        }
        public void editPersonnelInfoEns(PersonnelInfo pi, int id)
        {


            var query = from pinfo in dc.PersonnelInfos where pinfo.idPersonne == id select pinfo;

            foreach (var pinfo in query)
            {
                pinfo.nom = pi.nom;
                pinfo.prenom = pi.prenom;
                pinfo.dateNai = pi.dateNai;
                pinfo.lieuNai = pi.lieuNai;
                pinfo.sexe = pi.sexe;
                pinfo.adresse = pi.adresse;
                pinfo.email = pi.email;
                pinfo.telephone = pi.telephone;
            }

            dc.SubmitChanges();
        }

        public void deletePersonnelInfo(PersonnelInfo pi)
        {
            dc.PersonnelInfos.DeleteOnSubmit(pi);
            dc.SubmitChanges();
        }
    
        public int getLastId()
        {
            return dc.PersonnelInfos.OrderByDescending(item => item.idPersonne).Select(item => item.idPersonne).FirstOrDefault();
        }
    }
}