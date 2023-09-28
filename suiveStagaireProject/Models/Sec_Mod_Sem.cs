using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Sec_Mod_Sem
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Sec_Mod_Sem(int? secId, int? modId, int? semId, int? noteElim, int? coef)
        {
            this.secId = secId;
            this.modId = modId;
            this.semId = semId;
            this.noteElim = noteElim;
            this.coef = coef;
        }

        public void addSec_Mod_Sem(Sec_Mod_Sem sms)
        {
            dc.ExecuteCommand("INSERT INTO Sec_Mod_Sem (secId,modId,semId,noteElim,coef) VALUES ({0},{1},{2},{3},{4})", sms.secId, sms.modId, sms.semId,sms.noteElim,sms.coef) ;
            dc.SubmitChanges();
        }
        public void deleteSec_Mod_SemByModule(int idmod)
        {
            var query = from sms in dc.Sec_Mod_Sems where sms.modId == idmod select sms;

            dc.Sec_Mod_Sems.DeleteAllOnSubmit(query);
            dc.SubmitChanges();

        }
        public void deleteSec_Mod_SemBySection(int idSec)
        {
            var query = from sms in dc.Sec_Mod_Sems where sms.secId == idSec select sms;

            dc.Sec_Mod_Sems.DeleteAllOnSubmit(query);
            dc.SubmitChanges();

        }

    }
}