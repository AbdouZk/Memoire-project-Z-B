using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Stg_Exm
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Stg_Exm(int? stgId, int? exmId, int? semId, decimal? note)
        {
            this.stgId = stgId;
            this.exmId = exmId;
            this.semId = semId;
            this.note = note;
        }

        public void addStg_Exm(Stg_Exm se)
        {
            dc.ExecuteCommand("INSERT INTO Stg_Exm(stgId,exmId,semId,note) VALUES({0},{1},{2},{3})", se.stgId, se.exmId,se.semId, se.note);
            dc.SubmitChanges();
        }

        public void deleteStg_Exm(Stg_Exm se)
        {
            dc.Stg_Exms.DeleteOnSubmit(se);
            dc.SubmitChanges();
        }

        public void editStg_Exm(Stg_Exm obj)
        {
            var query = from se in dc.Stg_Exms where se.exmId == obj.exmId && se.stgId == obj.stgId && se.semId==obj.semId select se;
            foreach(var se in query)
            {
                se.note = note;
            }

            dc.SubmitChanges();
        }

        public Stg_Exm getStg_Exm(int id)
        {
            return (from se in dc.Stg_Exms where se.idStg_Exm == id select se).Single();   
        }

        public List<Stg_Exm> getAllStg_Exm()
        {
            return (from se in dc.Stg_Exms  select se).ToList<Stg_Exm>();
        }

        public List<Stg_Exm> getAllStg_ExmByStg(int idStg)
        {
            return (from se in dc.Stg_Exms
                    where se.stgId==idStg
                    select se).ToList<Stg_Exm>();
        }

        public List<int> getAllStgBySec(int idSem,int idMod)
        {
            var distinctStudentsWithExams = (
                    from s in dc.Stagiaires
                    join se in dc.Stg_Exms on s.id equals se.stgId
                    where se.semId==idSem && se.Examen.idMod==idMod
                    select s.id                     
                ).Distinct().ToList<int>();

            return distinctStudentsWithExams;
        }
        public List<Stg_Exm> getAllStg_ExmBySecSem(int idSec,int idSem)
        {
            return (from se in dc.Stg_Exms 
                    join s in dc.Stagiaires on se.stgId equals s.id
                    where s.idSection== idSec && se.semId== idSem
                    
                    select se).ToList<Stg_Exm>();
        }

        public List<ListeStagiairesNotes> getStagiaireNote(int idSec,int idSem)
        {
            return (from se in dc.Stg_Exms
                    join exm in dc.Examens on se.exmId equals idStg_Exm
                    join s in dc.Stagiaires on se.stgId equals s.id
                    join pi in dc.PersonnelInfos on s.personnelInfoId equals pi.idPersonne
                    where (se.semId==idSem && s.idSection==idSec) && exm.typeExamen=="S"

                    select new ListeStagiairesNotes(s.id,exm.idExamen,(int)se.semId,exm.typeExamen,pi.nom+" "+pi.prenom,(DateTime)pi.dateNai,(decimal) se.note)
                    ).ToList<ListeStagiairesNotes>();
        }
    }
}