using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Module
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Module(int idModule, string libelle)
        {
            this.idModule = idModule;
            this.libelle = libelle;
        }

        public void addModule(Module mod)
        {
            dc.ExecuteCommand("INSERT INTO Module (idModule,libelle) VALUES({0},{1})", mod.idModule, mod.libelle);
            dc.SubmitChanges();
        }
        public void EditModule(Module mod, int id)
        {
            dc.ExecuteCommand("UPDATE Module SET libelle={0} WHERE idModule={1} ", mod.libelle, mod.idModule);


            dc.SubmitChanges();
        }
        public void deleteModule(Module mod)
        {
            dc.Modules.DeleteOnSubmit(mod);
            dc.SubmitChanges();
        }
        public Module getModule(int id)
        {
            return (from m in dc.Modules where m.idModule == id select m).Single();
        }
        public List<Object> getModuleBySection(string code)
        {
            List<Seance> listeSeances= (from s in dc.Seances
                                        join m in dc.Modules on s.idMod equals m.idModule
                                        where s.idSec == code
                                        select s).GroupBy(item => item.idMod).Select(grp => grp.First()).ToList<Seance>();


            return (from obj in listeSeances select new {idMod=obj.idMod, libMod=obj.Module.libelle }).ToList<Object>();
        }

        public Module getModule(string name)
        {
            return (from m in dc.Modules where m.libelle==name select m).Single();
        }
        public List<Module> getModules()
        {
            return (from m in dc.Modules select m).ToList<Module>();

        }
        public List<Module> getModules(string name)
        {
            return (from m in dc.Modules where m.libelle.Contains(name) select m).ToList<Module>();

        }

        public int getLastModuleId()
        {
            return dc.Modules.OrderByDescending(item => item.idModule).Select(item => item.idModule).FirstOrDefault();
        }

        public int getNbrOfItem()
        {
            return dc.Modules.Count();
        }

    }
}