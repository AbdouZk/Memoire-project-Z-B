using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Semestre
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Semestre(int idSemestre, string saison)
        {
            this.idSemestre = idSemestre;
            this.saison = saison;
        }

        public void addSemestre(Semestre s)
        {
            dc.ExecuteCommand("INSERT INTO Semestre VALUES ({0},{1}) ",s.idSemestre,s.saison);
            dc.SubmitChanges();
        }
        public Semestre getSemestre(int id)
        {
            return (from s in dc.Semestres where s.idSemestre == id select s).Single();
        }

        public void editSemester(int idSem,string sem)
        {
            var semestre = from s in dc.Semestres where s.idSemestre == idSem select s;



            foreach(var s in semestre)
            {
                s.saison = sem;
            }

            dc.SubmitChanges();
        }


    }
}