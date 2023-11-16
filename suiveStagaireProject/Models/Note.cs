using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Note
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Note(int? exmID, int? stgID, string typeNote, decimal? note1)
        {
            this.exmID = exmID;
            this.stgID = stgID;
            this.typeNote = typeNote;
            this.note1 = note1;
        }

        public void addNote(Note note)
        {
            dc.ExecuteCommand("INSERT INTO Notes(exmID,stgID,typeNote,note) VALUES({0},{1},{2},{3})",
                note.exmID, note.stgID,note.typeNote, note.note1);
            dc.SubmitChanges();
        }
        public Note GetNote(int id)
        {
            return (from n in dc.Notes where n.idNote == id select n).Single();
        }
        public Note GetNoteByStg_Exm_Type(int idstg, int idexm, string type)
        {
            try
            {
                return (from n in dc.Notes
                        where n.stgID == idstg
                        && n.exmID == idexm
                        && n.typeNote == type
                        select n).Single();
            }
            catch (Exception ex)
            {
                return new Note(0,0,"0",0);
            }
        }
        public decimal? GetNote(int idstg,int idexm,string type)
        {
            try
            {
             return (from n in dc.Notes
                                where n.stgID ==idstg 
                                && n.exmID ==idexm 
                                && n.typeNote ==type 
                                select n.note1).Single();
            }catch(Exception ex)
            {
                return 0;
            }
           
        }
        public List<Note> GetNotes()
        {
            return (from n in dc.Notes select n).ToList<Note>();
        }
        public List<Note> GetNotesByExm(int idExm)
        {
            return (from n in dc.Notes where n.exmID==idExm select n).ToList<Note>();
        }
        public List<Note> GetNotesByExm_stg(int idExm, int idStg)
        {
            return (from n in dc.Notes where n.exmID == idExm && n.stgID==idStg select n).ToList<Note>();
        }
        public decimal? GetMoyenByExm_stg_S(int idExm, int idStg)
        {
            decimal? e1 = GetNoteByStg_Exm_Type(idStg,idExm,"E1").note1;
            decimal? e2 = GetNoteByStg_Exm_Type(idStg,idExm,"E2").note1;
            decimal? s = GetNoteByStg_Exm_Type(idStg,idExm,"S").note1;
           

            return (e1+e2+(s*2))/4;
        }
        public decimal getMoynneGenS(Stagiaire stg)
        {
            decimal T = 0;
            int coef = 0;

            var listExm = from exm in dc.Exams where exm.Seance.idSec == stg.idSection select exm;
            foreach (var e in listExm)
            {
                coef = coef + (int)e.coef;
                T = T + (decimal)(GetMoyenByExm_stg_S((int)e.idExamen,stg.id) * e.coef);
            }


            return T/coef;
        }
        public decimal getMoynneGenR(Stagiaire stg)
        {
            decimal T = 0;
            int coef = 0;
            decimal? Moy = 0;

            var listExm = from exm in dc.Exams where exm.Seance.idSec == stg.idSection select exm;
            foreach (var e in listExm)
            {
                coef = coef + (int)e.coef;
                decimal? moyR = GetNote( stg.id, e.idExamen, "R");
                decimal? moyS = GetMoyenByExm_stg_S(e.idExamen, stg.id);

                if (moyR>0 && moyS<10) { Moy = moyR; } else { Moy = moyS; }
                T = T + (decimal)(Moy * e.coef);
            }


            return T / coef;
        }
        public List<Note> getAllStgBySec( string codeSec)
        {
            var list = (from s in dc.Notes where s.Stagiaire.idSection == codeSec select s).GroupBy(item => item.stgID).Select(group=>group.First());

            return(
                    from s in list
                    where s.Stagiaire.idSection == codeSec 
                    select s
                ).OrderBy(item=>item.Stagiaire.PersonnelInfo.nom).ToList<Note>();

           
        }
        public List<Note> getAllStgBySecR(string codeSec)
        {
            var list = (from s in dc.Notes where s.Stagiaire.idSection == codeSec select s).GroupBy(item => item.stgID).Select(group => group.First());

            return (from s in list
                    where s.Stagiaire.idSection == codeSec && s.Stagiaire.statusStg=="Rattrapage"
                    select s
                    ).ToList<Note>();

          
        }
        public void editNote(Note note,decimal noteStg)
        {
            var query = from n in dc.Notes where n.idNote ==note.idNote select n;
            foreach (var n in query)
            {
                n.typeNote = note.typeNote;
                n.note1 = noteStg;
                
            }
            dc.SubmitChanges();
        }
        public void deleteNote(Note note)
        {

            dc.Notes.DeleteOnSubmit(note);
            dc.SubmitChanges();
        }
        public int getLastId()
        {
            return dc.Notes.OrderByDescending(item => item.idNote).Select(item => item.idNote).FirstOrDefault();
        }
    }
}