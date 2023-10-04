using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class detailsModSecSem
    {
        private int idSec;
        private int idSem;
        private int idMod;
        private string libMod;
        private int noteEli;
        private int coenf;
        private string libSem;

        public int IdSec { get => idSec; set => idSec = value; }
        public int IdSem { get => idSem; set => idSem = value; }
        public int IdMod { get => idMod; set => idMod = value; }
        public string LibMod { get => libMod; set => libMod = value; }
        public int NoteEli { get => noteEli; set => noteEli = value; }
        public int Coenf { get => coenf; set => coenf = value; }
        public string LibSem { get => libSem; set => libSem = value; }

        public detailsModSecSem(int idSec, int idSem, int idMod, string libMod, int noteEli, int coenf, string libSem)
        {
            this.idSec = idSec;
            this.idSem = idSem;
            this.idMod = idMod;
            this.libMod = libMod;
            this.noteEli = noteEli;
            this.coenf = coenf;
            this.libSem = libSem;
        }

        public detailsModSecSem()
        {
        }
    }
}