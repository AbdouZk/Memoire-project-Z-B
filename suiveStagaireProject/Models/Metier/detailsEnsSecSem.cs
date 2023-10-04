using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class detailsEnsSecSem
    {
        private int idSec;
        private int idSem;
        private int idEns;
        private string fullNameEns;
        private string speEns;

        public int IdSec { get => idSec; set => idSec = value; }
        public int IdSem { get => idSem; set => idSem = value; }
        public int IdEns { get => idEns; set => idEns = value; }
        public string FullNameEns { get => fullNameEns; set => fullNameEns = value; }
        public string SpeEns { get => speEns; set => speEns = value; }

        public detailsEnsSecSem(int idSec, int idSem, int idEns, string fullNameEns, string speEns)
        {
            this.idSec = idSec;
            this.idSem = idSem;
            this.idEns = idEns;
            this.fullNameEns = fullNameEns;
            this.speEns = speEns;
        }

        public detailsEnsSecSem()
        {
        }

    }
}