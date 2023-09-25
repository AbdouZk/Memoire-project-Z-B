using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Enseignant
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();


        public List<Enseignant> getAllEnseignat()
        {
            return (from e in dc.Enseignants select e).ToList<Enseignant>();
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
    }
}