using suiveStagaireProject.Models.Metier;
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


        public List<Sec_Mod_Sem> getEns_Sec()
        {
            return (from sms in dc.Sec_Mod_Sems select sms).ToList<Sec_Mod_Sem>();
        }
        public List<Sec_Mod_Sem> getEns_SecBySec(int idSec)
        {
            return (from sms in dc.Sec_Mod_Sems where sms.secId==idSec select sms).ToList<Sec_Mod_Sem>();
        }
        public List<Sec_Mod_Sem> getEns_SecBySem(int idSem)
        {
            return (from sms in dc.Sec_Mod_Sems where sms.semId == idSem select sms).ToList<Sec_Mod_Sem>();
        }
        public Sec_Mod_Sem getEns_SecByAll(int idSec,int idSem,int idMod)
        {
            return (from sms in dc.Sec_Mod_Sems where sms.secId == idSec && sms.semId==idSem && sms.modId==idMod select sms).Single();
        }
        public List<detailsModSecSem> getSecSemMod(int idSec)
        {
            return (from sms in dc.Sec_Mod_Sems 
                    join m in dc.Modules on sms.modId equals m.idModule
                    where sms.secId==idSec
                     select new detailsModSecSem((int)sms.secId,(int)sms.semId,(int)sms.modId,m.libelle,(int)sms.noteElim,(int)sms.coef,"Semestre "+sms.semId)).ToList<detailsModSecSem>();
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
        public void deleteSec_Mod_Sem(Sec_Mod_Sem sms)
        {            

            dc.Sec_Mod_Sems.DeleteOnSubmit(sms);
            dc.SubmitChanges();

        }

        public int countSecModSemByAll(int idSec, int idSem, int idMod)
        {
            int rowCount = dc.Sec_Mod_Sems
                           .Where(item => item.secId == idSec && item.semId == idSem && item.modId == idMod)
                           .Count();
            return rowCount;

        }
        public List<Object> getModuleByEns(int idSec,int idSem,int idEns)
        {
            return (from sms in dc.Sec_Mod_Sems
                    join m in dc.Modules on sms.modId equals m.idModule
                    join em in dc.Ens_Mods on sms.modId equals em.modId
                    where sms.secId==idSec && sms.semId==idSem && em.ensId==idEns
                    select new { libMod = m.libelle, idMod = m.idModule }
                    ).ToList<Object>();
        }

        public List<Object> getModuleByEns(int idSec, int idSem)
        {
            return (from sms in dc.Sec_Mod_Sems
                    join m in dc.Modules on sms.modId equals m.idModule
                    where sms.secId == idSec && sms.semId == idSem 
                    select new { libMod = m.libelle, idMod = m.idModule }
                    ).ToList<Object>();
        }
    }
}