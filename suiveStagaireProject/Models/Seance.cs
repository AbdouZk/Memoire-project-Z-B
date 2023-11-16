using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Seance
    {
        myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Seance(string idSeance, string typeSeance, int? vH, string idSec, int? idEns, int? idMod)
        {
            this.idSeance = idSeance;
            this.typeSeance = typeSeance;
            VH = vH;
            this.idSec = idSec;
            this.idEns = idEns;
            this.idMod = idMod;
        }

        public void addSeabce(Seance seance)
        {
            dc.ExecuteCommand("INSERT INTO Seance(idSeance,typeSeance,VH,idSec,idEns,idMod) VALUES({0},{1},{2},{3},{4},{5})", seance.idSeance,seance.typeSeance,seance.VH,seance.idSec,seance.idEns,seance.idMod);
            dc.SubmitChanges();
        }
        public Seance GetSreance(string id)
        {
            return (from s in dc.Seances where s.idSeance == id select s).Single();
        }
        public List<Seance> GetSeances()
        {
            return (from s in dc.Seances select s).ToList<Seance>();
        }
        public List<Seance> GetSeancesByMod(string mod)
        {
            return (from s in dc.Seances where s.Module.libelle.Contains(mod) select s).ToList<Seance>();
        }
        public List<Seance> GetSeancesBySection(string codeSec)
        {
            return (from s in dc.Seances where s.Section.codeSection.Contains(codeSec) select s).ToList<Seance>();
        }
        public List<Seance> GetSeancesByProf(string Ens)
        {
            return (from s in dc.Seances where s.Enseignant.PersonnelInfo.nom.Contains(Ens) || s.Enseignant.PersonnelInfo.prenom.Contains(Ens) select s).ToList<Seance>();
        }
        public List<Object> GetModulesByProf_Section(int Ens, string codeSec)
        {
            var listMod = (from s in dc.Seances where s.idEns == Ens && s.idSec == codeSec select s);
            return (from s in listMod select new { libMod=s.Module.libelle , idMod=s.idMod }).ToList<Object>();
        }
        public void editSeance(Seance seance, string id)
        {
            var query = from s in dc.Seances where s.idSeance == id select s;
            foreach (var s in query) { 
            
                s.typeSeance = seance.typeSeance;
                s.VH = seance.VH;
                s.idSec = seance.idSec;
                s.idEns = seance.idEns;
                s.idMod = seance.idMod;
                
            }
            dc.SubmitChanges();
        }
        public void deleteSeance(Seance seance)
        {

            dc.Seances.DeleteOnSubmit(seance);
            dc.SubmitChanges();
        }
       


    }
}