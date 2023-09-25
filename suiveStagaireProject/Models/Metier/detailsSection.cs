using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class detailsSection
    {
        private string codeSec;
        private string numSec;
        private string libFor;
        private string modeOrg;
        private string modeGes;
        private string debSec;
        private string finSec;
        private string nivSec;
        private string turtSec;
        private int nbrStag;
        private int nbrFilles;
        private int nbrhandicape;
        private int nbretrangere;

        public detailsSection()
        {
        }

        public detailsSection(string codeSec, string numSec, string libFor, string modeOrg, string modeGes, string debSec, string finSec,string nivSec, string turtSec,int nbrStag, int nbrFilles, int nbrhandicape, int nbretrangere)
        {
            this.CodeSec = codeSec;
            this.NumSec = numSec;
            this.LibFor = libFor;
            this.ModeOrg = modeOrg;
            this.ModeGes = modeGes;
            this.DebSec = debSec;
            this.FinSec = finSec;
            this.NivSec = nivSec;
            this.TurtSec = turtSec;
            this.NbrStag = nbrStag;
            this.NbrFilles = nbrFilles;
            this.Nbrhandicape = nbrhandicape;
            this.Nbretrangere = nbretrangere;
        }

        public string CodeSec { get => codeSec; set => codeSec = value; }
        public string NumSec { get => numSec; set => numSec = value; }
        public string LibFor { get => libFor; set => libFor = value; }
        public string ModeOrg { get => modeOrg; set => modeOrg = value; }
        public string ModeGes { get => modeGes; set => modeGes = value; }
        public string DebSec { get => debSec; set => debSec = value; }
        public string FinSec { get => finSec; set => finSec = value; }
        public string NivSec { get => nivSec; set => nivSec = value; }
        public string TurtSec { get => turtSec; set => turtSec = value; }
        public int NbrStag { get => nbrStag; set => nbrStag = value; }
        public int NbrFilles { get => nbrFilles; set => nbrFilles = value; }
        public int Nbrhandicape { get => nbrhandicape; set => nbrhandicape = value; }
        public int Nbretrangere { get => nbretrangere; set => nbretrangere = value; }
    }
}