using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Ens_Mod
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Ens_Mod(int? ensId, int? modId)
        {
            this.ensId = ensId;
            this.modId = modId;
        }

        public List<Ens_Mod> getEM (Ens_Mod obj)
        {
            return (from em in dc.Ens_Mods select em).ToList<Ens_Mod>();

        }
        public List<Ens_Mod> getEMByMod(int idmod)
        {
            return (from em in dc.Ens_Mods where em.modId==idmod select em).ToList<Ens_Mod>();

        }
        public void deleteEM(int idmod)
        {
            var query=from em in dc.Ens_Mods where em.modId == idmod select em ;

            dc.Ens_Mods.DeleteAllOnSubmit(query);
            dc.SubmitChanges();

        }
        public List<Ens_Mod> getEMByEns(int idEns)
        {
            return (from em in dc.Ens_Mods where em.ensId == idEns select em).ToList<Ens_Mod>();

        }
        public void AddEns_Mod(Ens_Mod obj)
        {
            dc.ExecuteCommand("INSERT INTO Ens_Mod (ensId,modId) VALUES({0},{1})",obj.ensId,obj.modId);

            dc.SubmitChanges();
        }
    }
}