using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Ens_Sec
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Ens_Sec(int? ensId, int? secId, int? idSem)
        {
            this.ensId = ensId;
            this.secId = secId;
            this.idSem = idSem;
        }

        public List<Ens_Sec> getEns_Sec()
        {
            return (from es in dc.Ens_Secs select es).ToList<Ens_Sec>();
        }
        public Ens_Sec getEns_Sec(int idEns ,int idSec,int idSem)
        {
            return (from es in dc.Ens_Secs where es.ensId==idEns && es.secId==idSec && es.idSem == idSem select es).Single();
        }
        public List<Ens_Sec> getEns_SecByEns(int idEns)
        {
            return (from es in dc.Ens_Secs where es.ensId==idEns select es).ToList<Ens_Sec>();
        }
        public List<Ens_Sec> getEns_SecBySec(int idSec)
        {
            return (from es in dc.Ens_Secs where es.secId==idSec select es).ToList<Ens_Sec>();
        }
        public void addEns_Sec(Ens_Sec es)
        {
            dc.ExecuteCommand("INSERT INTO Ens_Sec (ensId,secId,idSem) VALUES ({0},{1},{2})",es.ensId,es.secId,es.idSem);
            dc.SubmitChanges();
        }
        public void deleteEns_Sec(Ens_Sec es)
        {
            dc.Ens_Secs.DeleteOnSubmit(es);
            dc.SubmitChanges();
        }
        public void deleteSec_Ens_SemBySection(int idSec)
        {
            var query = from ses in dc.Ens_Secs where ses.secId == idSec select ses;

            dc.Ens_Secs.DeleteAllOnSubmit(query);
            dc.SubmitChanges();

        }
        public void deleteSec_Ens_SemByEns(int idEns)
        {
            var query = from ses in dc.Ens_Secs where ses.ensId == idEns select ses;

            dc.Ens_Secs.DeleteAllOnSubmit(query);
            dc.SubmitChanges();

        }
        public int countEns_SecByEns(int idEns)
        {
            int rowCount = dc.Ens_Secs
                           .Where(item => item.ensId ==idEns ) 
                           .Count();
            return rowCount;
        
        }
        public int countEns_SecBySec(int idSec)
        {
            int rowCount = dc.Ens_Secs
                           .Where(item => item.secId == idSec)
                           .Count();
            return rowCount;

        }
        public int countEns_SecBySecEns(int idSec,int idEns)
        {
            int rowCount = dc.Ens_Secs
                           .Where(item => item.secId == idSec && item.ensId==idEns)
                           .Count();
            return rowCount;

        }
        public int countEns_SecByAll(int idSec,int idEns,int idSem)
        {
            int rowCount = dc.Ens_Secs
                           .Where(item => item.secId == idSec && item.ensId==idEns && item.idSem==idSem)
                           .Count();
            return rowCount;

        }
        public List<detailsEnsSecSem> getListeEnseignants(int idSec )
        {
            return (from e in dc.Enseignants
                    join de in dc.PersonnelInfos on e.personnelInfosId equals de.idPersonne
                    join es in dc.Ens_Secs on e.idEnseiginant equals es.ensId
                    where es.secId==idSec 
                    select new detailsEnsSecSem((int)es.secId,(int) es.idSem,(int) es.ensId,de.nom+" "+de.prenom,e.specialite)
                    ).ToList<detailsEnsSecSem>();

        }
        public List<Object> getSectionByEns(int idEns)
        {
            return (from es in dc.Ens_Secs
                    join s in dc.Sections on es.secId equals s.idSec
                    join cat in dc.CatalogeSections on s.idCat equals cat.idCataloge
                    where es.ensId==idEns
                    select new { codeSec = cat.codeSpe + " " + s.numSection, idSec = es.secId }
                    ).ToList<Object>();
        }

    }
}