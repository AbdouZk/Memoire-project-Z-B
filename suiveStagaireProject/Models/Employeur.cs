using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Employeur
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Employeur(int idEpoloyeur, string name, string adresse, string status)
        {
            this.idEpoloyeur = idEpoloyeur;
            Name = name;
            Adresse = adresse;
            this.status = status;
        }

        public Employeur(string name, string adresse, string status)
        {
            Name = name;
            Adresse = adresse;
            this.status = status;
        }

        public void addEmployeur(Employeur emp)
        {
            dc.ExecuteCommand("INSERT INTO Employeur(name,adresse,status) VALUES({0},{1},{2})",emp.Name,emp.Adresse,emp.status);
            dc.SubmitChanges();
        }

        public Employeur GetEmployeur(int id)
        {
            return (from e in dc.Employeurs where e.idEpoloyeur==id select e).Single();
        }

        public List<Employeur> GetEmployeurs()
        {
            return (from e in dc.Employeurs select e).ToList<Employeur>();
        }

        public List<Employeur> GetEmployeurs(string name)
        {
            return (from e in dc.Employeurs where e.Name.Contains(name) select e).ToList<Employeur>();
        }
        public void editEmployeur(Employeur emp, int id)
        {
           var query =from e in dc.Employeurs where e.idEpoloyeur == id select e;
            foreach (var e in query)
            {
                e.Name = emp.Name;
                e.Adresse = emp.Adresse;
                e.status = emp.status;
            }
            dc.SubmitChanges();
        }

        public void deleteEmployeur( Employeur emp)
        {
          
            dc.Employeurs.DeleteOnSubmit(emp);
            dc.SubmitChanges();
        }
        public int getNbrOfItem()
        {
            return dc.Employeurs.Count();
        }
    }
}