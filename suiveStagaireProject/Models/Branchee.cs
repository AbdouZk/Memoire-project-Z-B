using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Models
{
    public partial class Branchee
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Branchee(string libileBrache, string libileBracheAr)
        {
            this.libileBrache = libileBrache;
            LibileBracheAr = libileBracheAr;
        }

        public List<Branchee> getListeBranchees()
        {
            List<Branchee> listeBrachee = new List<Branchee>();

            listeBrachee = (from b in dc.Branchees select b).ToList<Branchee>();

            return listeBrachee;
        }
        public Branchee getListeBranchee(int id)
        {
            
            return (from b in dc.Branchees where b.idBrache==id select b).Single();

           
        }
        public string getBracheName(int id)
        {
            Branchee branche = new Branchee();

            branche= (from b in dc.Branchees where b.idBrache == id select b).Single();

            return branche.libileBrache;
        }

        public void addBranche(Branchee b)
        {
            dc.ExecuteCommand("INSERT INTO Branchees (libileBrache,LibileBracheAr) VALUES({0},{1})", b.libileBrache,b.LibileBracheAr);
            dc.SubmitChanges();
        }

        public void editBranche(Branchee branchee,int idB)
        {
            var query = from b in dc.Branchees where b.idBrache == idB select b;
            foreach(var b in query)
            {
                b.libileBrache = branchee.libileBrache;
                b.LibileBracheAr = branchee.LibileBracheAr;
            }
        }

        public void deleteBranche(Branchee b)
        {
            dc.Branchees.DeleteOnSubmit(b);
            dc.SubmitChanges();
        }
    }
}
