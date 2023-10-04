using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models.Metier
{
    public class ListeStagiairesNotes
    {
        private int idStg;
        private int idExm;
        private int idSem;
        private string tExm;
        private string fullName;
        private decimal note;
        private DateTime dateNai;

        public int IdStg { get => idStg; set => idStg = value; }
        public int IdExm { get => idExm; set => idExm = value; }
        public int IdSem { get => idSem; set => idSem = value; }
        public string TExm { get => tExm; set => tExm = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public DateTime DateNai { get => dateNai; set => dateNai = value; }
        public decimal Note { get => note; set => note = value; }

        public ListeStagiairesNotes(int idStg, int idExm,int idSem, string tExm, string fullName, DateTime dateNai, decimal note)
        {
            IdStg = idStg;
            IdExm = idExm;
            IdSem = idSem;
            TExm = tExm;
            FullName = fullName;
            DateNai = dateNai;
            Note = note;
        }

        public ListeStagiairesNotes() { }


    }
}