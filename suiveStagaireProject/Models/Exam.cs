using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Exam
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Exam(int idExamen, string seanceID, int? noteEli, int? coef)
        {
            this.idExamen = idExamen;
            this.seanceID = seanceID;
            this.noteEli = noteEli;
            this.coef = coef;
           
        }

        public void addExama(Exam exm)
        {
            dc.ExecuteCommand("INSERT INTO Exam(idExamen,seanceID,noteEli,coef) VALUES({0},{1},{2},{3})",
                exm.idExamen,  exm.seanceID , exm.noteEli ,exm.coef) ;
            dc.SubmitChanges();
        }

        public Exam GetExma( int id)
        {
            return (from exm in dc.Exams where exm.idExamen == id select exm).Single();
        }

        public Exam GetExma(int idMod,string codeSec)
        {
            return  (from e in dc.Exams where e.Seance.idMod == idMod && e.Seance.idSec == codeSec select e).Single();

        }
        public List<Exam> GetExamas()
        {
            return (from exm in dc.Exams select exm).ToList<Exam>();
        }

        public List<Exam> GetExamaByMod(string mod)
        {
            return (from exm in dc.Exams where  exm.Seance.Module.libelle.Contains(mod) select exm).ToList<Exam>();
        }

        public List<Exam> GetExamaByProf(string Prof)
        {
            return (from exm in dc.Exams where  exm.Seance.Enseignant.PersonnelInfo.nom.Contains(Prof) || exm.Seance.Enseignant.PersonnelInfo.prenom.Contains(Prof) select exm).ToList<Exam>();
        }

        public List<Exam> GetExamaBySec(string codeSec)
        {
            return (from exm in dc.Exams where exm.Seance.Section.codeSection.Contains(codeSec) select exm).ToList<Exam>();
        }

        public Exam GetExamaBySection(string codeSec)
        {
            return (from exm in dc.Exams where exm.Seance.Section.codeSection==codeSec select exm).Single();
        }
        public int? GetTotalCoefExama(string codeSec)
        {
            return (from exm in dc.Exams
                    where exm.Seance.Section.codeSection == codeSec
                    select exm).Sum(item => item.coef);
        }

        public void editExama(Exam exm, int id)
        {
            var query = from e in dc.Exams where e.idExamen == id select e;
            foreach (var e in query)
            {
               
                e.noteEli  = exm.noteEli;
                e.coef = exm.coef;
                              
            }
            dc.SubmitChanges();
        }

        public void deleteExama(int idMod, string codeSec)
        {
            List<Exam> exm = (from e in dc.Exams where e.Seance.idMod == idMod && e.Seance.idSec == codeSec select e).ToList<Exam>();
            dc.Exams.DeleteAllOnSubmit(exm);
            dc.SubmitChanges();
        }

        public Boolean checkExm(int idMod,string codeSec)
        {

            int n = (from e in dc.Exams where e.Seance.idMod==idMod && e.Seance.idSec==codeSec select e).Count();
            if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int getLastExmId()
        {
            return dc.Exams.OrderByDescending(item => item.idExamen).Select(item => item.idExamen).FirstOrDefault();
        }
    }
}