using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Stagiaire
    {

        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Stagiaire(int id, string numInsc, string img, string statusStg, string idSection, int? personnelInfoId, int? detailsInfoId, int? epoloyeurID)
        {
            this.id = id;
            this.numInsc = numInsc;
            this.img = img;
            this.statusStg = statusStg;
            this.idSection = idSection;
            this.personnelInfoId = personnelInfoId;
            this.detailsInfoId = detailsInfoId;
            this.employeurId = epoloyeurID;
        }
        public Stagiaire(int id, string numInsc, string img, string statusStg, string idSection, int? personnelInfoId, int? detailsInfoId)
        {
            this.id = id;
            this.numInsc = numInsc;
            this.img = img;
            this.statusStg = statusStg;
            this.idSection = idSection;
            this.personnelInfoId = personnelInfoId;
            this.detailsInfoId = detailsInfoId;
            
        }
        public List<Stagiaire> getStagiaires()
        {
            return (from s in dc.Stagiaires select s).ToList<Stagiaire>();
        }
        public List<Stagiaire> getStagiaires(string search)
        {
            return (from s in dc.Stagiaires where s.PersonnelInfo.nom.Contains(search) || s.PersonnelInfo.prenom.Contains(search) select s).ToList<Stagiaire>();
        }
        public Stagiaire getStagiaire(int id)
        {
            return (from s in dc.Stagiaires where s.id==id select s).Single();
        }
        public List<Stagiaire> getStagiairesBySec(string codeSec)
        {
            return (from s in dc.Stagiaires where s.idSection == codeSec select s).OrderBy(item=> item.PersonnelInfo.nom).ToList<Stagiaire>();
        }
        public List<Stagiaire> getStagiairesBySecR(string codeSec)
        {
            return (from s in dc.Stagiaires where s.idSection == codeSec && s.statusStg=="Rattrapage" select s).OrderBy(item => item.PersonnelInfo.nom).ToList<Stagiaire>();
        }
        public List<Object> getStagiairesBySecAdmisRatt(string codeSec)
        {
            List<Stagiaire> list= (from s in dc.Stagiaires where s.idSection == codeSec && (s.statusStg=="Admis" || s.statusStg=="Rattrapage" ) select s).OrderBy(item => item.PersonnelInfo.nom).ToList<Stagiaire>();
            return (from s in list select new { nom = s.PersonnelInfo.nom + " " + s.PersonnelInfo.prenom, idStg = s.id }).ToList<Object>();
        }
        public List<Object> getStagiairesBySec_Status(string codeSec, string status)
        {
            List<Stagiaire> list = (from s in dc.Stagiaires where s.idSection == codeSec && s.statusStg == status  select s).OrderBy(item => item.PersonnelInfo.nom).ToList<Stagiaire>();
            return (from s in list select new { nom = s.PersonnelInfo.nom + " " + s.PersonnelInfo.prenom, idStg = s.id }).ToList<Object>();
        }
        public List<Object> getListStagiairesBySec(string codeSec)
        {
            List<Stagiaire> listeStags = (from s in dc.Stagiaires
                                          where s.idSection == codeSec select s).OrderBy(item=>item.PersonnelInfo.nom).ToList<Stagiaire>();

            return (from s in listeStags  select new {nom=s.PersonnelInfo.nom+" "+s.PersonnelInfo.prenom+ " " + s.PersonnelInfo.dateNai.Value.ToShortDateString(), idStg=s.id }).ToList<Object>();
        }
        public void addStagiaireA(Stagiaire stg)
        {

            dc.ExecuteCommand("INSERT INTO Stagiaire (id,numInsc,img,statusStg,idSection,personnelInfoId,detailsInfoId,employeurId) VALUES ({0},{1},{2},{3},{4},{5},{6},{7})",
              stg.id,stg.numInsc, stg.img, stg.statusStg, stg.idSection, stg.personnelInfoId, stg.detailsInfoId,stg.employeurId);
            dc.SubmitChanges();
        }
        public void addStagiaireR(Stagiaire stg)
        {

            dc.ExecuteCommand("INSERT INTO Stagiaire (id,numInsc,img,statusStg,idSection,personnelInfoId,detailsInfoId) VALUES ({0},{1},{2},{3},{4},{5},{6})",
              stg.id, stg.numInsc, stg.img, stg.statusStg, stg.idSection, stg.personnelInfoId, stg.detailsInfoId);
            dc.SubmitChanges();
        }
        public void deleteStagiaire(Stagiaire stg)
        {
            dc.Stagiaires.DeleteOnSubmit(stg);
            dc.SubmitChanges();
        }
        public void editStagiaireA(Stagiaire stg,int id)
        {

            var stag = from s in dc.Stagiaires where s.id == id select s;

            foreach (var s in stag)
            {             
                
                s.idSection = stg.idSection;
                s.employeurId = stg.employeurId;
            }


            dc.SubmitChanges();
        }
        public void editStagiaireR(Stagiaire stg, int id)
        {

            var stag = from s in dc.Stagiaires where s.id == id select s;

            foreach (var s in stag)
            {
                s.employeurId = null;
                s.idSection = stg.idSection;             
            }


            dc.SubmitChanges();
        }
        public void stgChangeStatus( int id,string status)
        {

            var stag = from s in dc.Stagiaires where s.id == id select s;

            foreach (var s in stag)
            {
                s.statusStg = status;
                
            }


            dc.SubmitChanges();
        }
        public int getLastId()
        {
            return dc.Stagiaires.OrderByDescending(item => item.id).Select(item => item.id).FirstOrDefault();
        }
        public int getNbrOfItem()
        {
            return dc.Stagiaires.Count();
        }
        public int getNbrOfGirls()
        {
            return dc.Stagiaires.Where(item=> item.PersonnelInfo.sexe=="Femme").Count();
        }
        public int getNbrOfEtrangere()
        {
            return dc.Stagiaires.Where(item => item.DetailsStagiaire.nat!= "Algerian").Count();
        }
        public int getNbrOfHandicape()
        {
            return dc.Stagiaires.Where(item => item.DetailsStagiaire.sitMedical==0).Count();
        }
    }
}