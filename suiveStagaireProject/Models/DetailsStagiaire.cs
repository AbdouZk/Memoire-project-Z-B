using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class DetailsStagiaire
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public DetailsStagiaire(int id, string sang, int? sitMedical, string prenomPere, string nomMere, string prenomMere, string telTuteur, string nat, string derEtabFre, string nivScolaire, string sitFam, string profPere, string profMere, string sitFamParents, EntitySet<Stagiaire> stagiaires)
        {
            this.id = id;
            this.sang = sang;
            this.sitMedical = sitMedical;
            this.prenomPere = prenomPere;
            this.nomMere = nomMere;
            this.prenomMere = prenomMere;
            this.telTuteur = telTuteur;
            this.nat = nat;
            this.derEtabFre = derEtabFre;
            this.nivScolaire = nivScolaire;
            this.sitFam = sitFam;
            this.profPere = profPere;
            this.profMere = profMere;
            this.sitFamParents = sitFamParents;
            Stagiaires = stagiaires;
        }

        public DetailsStagiaire(int id, string sang, int? sitMedical, string prenomPere, string nomMere, string prenomMere, string telTuteur, string nat, string derEtabFre, string nivScolaire, string sitFam, string profPere, string profMere, string sitFamParents)
        {
            this.id = id;
            this.sang = sang;
            this.sitMedical = sitMedical;
            this.prenomPere = prenomPere;
            this.nomMere = nomMere;
            this.prenomMere = prenomMere;
            this.telTuteur = telTuteur;
            this.nat = nat;
            this.derEtabFre = derEtabFre;
            this.nivScolaire = nivScolaire;
            this.sitFam = sitFam;
            this.profPere = profPere;
            this.profMere = profMere;
            this.sitFamParents = sitFamParents;
            
        }
    

        public DetailsStagiaire getDetailsStagiaire(int id)
        {
            return (from ds in dc.DetailsStagiaires where ds.id == id select ds).Single();
        }
        
        public void addDetailStagiaire(DetailsStagiaire dStg)
        {
     
            dc.ExecuteCommand("INSERT INTO DetailsStagiaire (id,sang,sitMedical,prenomPere,nomMere,prenomMere,telTuteur,nat,derEtabFre,nivScolaire,sitFam,profPere,profMere,sitFamParents) values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})",
                           dStg.id, dStg.sang, dStg.sitMedical, dStg.prenomPere, dStg.nomMere, dStg.prenomMere, dStg.telTuteur, dStg.nat, dStg.derEtabFre, dStg.nivScolaire, dStg.sitFam, dStg.profPere, dStg.profMere, dStg.sitFamParents);
            dc.SubmitChanges();
        }  
        
        public void deleteDetailStagiaire(DetailsStagiaire dStg)
        {
            dc.DetailsStagiaires.DeleteOnSubmit(dStg);
            dc.SubmitChanges();
        }  
        
        public void editDetailStagiaire(DetailsStagiaire dStg,int id)
        {

            dc.ExecuteCommand("UPDATE DetailsStagiaire SET sang={0},sitMedical={1},prenomPere={2},nomMere={3},prenomMere={4},telTuteur={5},nat={6},derEtabFre={7},nivScolaire={8},sitFam={9},profPere={10},profMere={11},sitFamParents={12} Where id={13})",
                              dStg.sang, dStg.sitMedical, dStg.prenomPere, dStg.nomMere, dStg.prenomMere, dStg.telTuteur, dStg.nat, dStg.derEtabFre, dStg.nivScolaire, dStg.sitFam, dStg.profPere, dStg.profMere, dStg.sitFamParents,dStg.id);


            dc.SubmitChanges();
        }
    
        public int getLastId()
        {
            return dc.DetailsStagiaires.OrderByDescending(item=>item.id).Select(item=> item.id).FirstOrDefault();
        }
    }
}