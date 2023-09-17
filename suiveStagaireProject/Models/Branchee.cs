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


        public List<Branchee> getListeBranchees()
        {
            List<Branchee> listeBrachee = new List<Branchee>();

            listeBrachee = (from b in dc.Branchees select b).ToList<Branchee>();

            return listeBrachee;
        }

        public string getBracheName(int id)
        {
            Branchee branche = new Branchee();

            branche= (from b in dc.Branchees where b.idBrache == id select b).Single();

            return branche.libileBrache;
        }

        
    }
}
