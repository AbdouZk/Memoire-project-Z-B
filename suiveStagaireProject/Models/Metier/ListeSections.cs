using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class ListeSections
    {
        private string codeSec;
        private string libSec;
        private string semestre;
        private string debSec;
        private string finSec;
        private string modeGesSec;

        public ListeSections()
        {
           
        }

        public ListeSections( string codeSec, string libSec, string semestre, string debSec, string finSec, string modeGesSec)
        {
            
            this.CodeSec = codeSec;
            this.LibSec = libSec;
            this.Semestre = semestre;
            this.DebSec = debSec;
            this.FinSec = finSec;
            this.ModeGesSec = modeGesSec;
        }

        public string CodeSec { get => codeSec; set => codeSec = value; }
        public string LibSec { get => libSec; set => libSec = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string DebSec { get => debSec; set => debSec = value; }
        public string FinSec { get => finSec; set => finSec = value; }
        public string ModeGesSec { get => modeGesSec; set => modeGesSec = value; }
    }
}