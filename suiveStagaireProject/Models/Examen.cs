using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Examen
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Examen(string typeExamen, int? idMod)
        {
            this.typeExamen = typeExamen;
            this.idMod = idMod;
        }

        public void addExamen(Examen exm)
        {
            dc.ExecuteCommand("INSERT INTO Examen (typeExamen,idMod) VALUES({0},{1})",exm.typeExamen,exm.idMod);
            dc.SubmitChanges();
        }

        public void EditExamen(Examen exm)
        {

            var query = from ex in dc.Examens where ex.idExamen == idExamen select ex;

            foreach (var ex in query)
            {
                ex.typeExamen = exm.typeExamen;
            }

            dc.SubmitChanges();
        }

        public void DeleteExamen(int idMod)
        {
            dc.ExecuteCommand("DELETE FROM Examen WHERE idMod={0}",idMod);
            dc.SubmitChanges();
        }

        public List<Examen> getExemenModule(int idM)
        {
            return (from em in dc.Examens where em.idMod == idM select em).ToList<Examen>();
        }

    }
}