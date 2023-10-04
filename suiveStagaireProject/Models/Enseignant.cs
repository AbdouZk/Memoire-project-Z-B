using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Enseignant
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Enseignant(int idEnseiginant, DateTime? dateDebut, string specialite, int? userId, int? personnelInfosId)
        {
            this.idEnseiginant = idEnseiginant;
            this.dateDebut = dateDebut;
            this.specialite = specialite;
            this.userId = userId;
            this.personnelInfosId = personnelInfosId;
        }

        public Enseignant( DateTime? dateDebut, string specialite, int? userId, int? personnelInfosId)
        {
           
            this.dateDebut = dateDebut;
            this.specialite = specialite;
            this.userId = userId;
            this.personnelInfosId = personnelInfosId;
        }

        public List<Enseignant> getAllEnseignats()
        {
            return (from e in dc.Enseignants select e).ToList<Enseignant>();
        }
        public Enseignant getEnseignat(int id)
        {
            return (from e in dc.Enseignants where e.idEnseiginant==id select e).Single();
        }

        public Enseignant getEnseignatByUserId(int id)
        {
            return (from e in dc.Enseignants where e.userId == id select e).Single();
        }


        public object getEnseignantsNames()
        {

            return from e in dc.Enseignants
                   join pi in dc.PersonnelInfos
                   on e.personnelInfosId equals pi.idPersonne
                   select new
                   {
                       idEns = e.idEnseiginant, 
                       nameEns=pi.nom+" " +pi.prenom
                        
                   };
        }

        public void addEnseignant(Enseignant ens)
        {
            dc.ExecuteCommand("INSERT INTO Enseignant (dateDebut,specialite,personnelInfosId) VALUES ({0},{1},{2})",ens.dateDebut,ens.specialite,ens.personnelInfosId);
            dc.SubmitChanges();
        }

        public void editEnseignant(Enseignant ens,int id)
        {
        

            var query = from e in dc.Enseignants where e.idEnseiginant == id select e;

            foreach(var e in query)
            {
                e.dateDebut = ens.dateDebut;
                e.specialite = ens.specialite;
            }

            dc.SubmitChanges();
        }

        public void deleteEnseignant(Enseignant ens)
        {
            dc.Enseignants.DeleteOnSubmit(ens);
            dc.SubmitChanges();
        }

        public List<ListeEnseignant> getListeEnseignants()
        {
            return (from e in dc.Enseignants
                    join de in dc.PersonnelInfos on e.personnelInfosId equals de.idPersonne
                    select new ListeEnseignant(e.idEnseiginant, e.specialite, e.dateDebut.Value.ToShortDateString(), "", "", e.personnelInfosId.ToString(), de.nom, de.prenom)
                    ).ToList<ListeEnseignant>();
                    
        }

        public List<ListeEnseignant> getListeEnseignantsSearch(string name)
        {
            return (from e in dc.Enseignants
                    join de in dc.PersonnelInfos on e.personnelInfosId equals de.idPersonne
                    where de.nom.Contains(name) || de.prenom.Contains(name)
                    select new ListeEnseignant(e.idEnseiginant, e.specialite, e.dateDebut.Value.ToShortDateString()," ", " ", e.personnelInfosId.ToString(), de.nom, de.prenom)
                    ).ToList<ListeEnseignant>();

        }

        public detailsEnseignant getDetailsEnseignant(int id)
        {

            return (from e in dc.Enseignants
                    join de in dc.PersonnelInfos on e.personnelInfosId equals de.idPersonne
                    where e.idEnseiginant==id
                    select new detailsEnseignant(e.idEnseiginant, e.specialite, e.dateDebut.Value, "", "", e.personnelInfosId.ToString(), de.nom, de.prenom,de.adresse,de.dateNai.Value,de.lieuNai,de.sexe,de.email,de.telephone)
                    ).Single();
        }
    }
}