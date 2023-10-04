﻿using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Stagiaire
    {

        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Stagiaire(string numInsc, string img, int? idSection, int? personnelInfoId, int? detailsInfoId)
        {
            this.numInsc = numInsc;
            this.img = img;
            this.idSection = idSection;
            this.personnelInfoId = personnelInfoId;
            this.detailsInfoId = detailsInfoId;
        }

        public Stagiaire(string numInsc, string img, int? idSection, int? personnelInfoId, int? detailsInfoId, DetailsStagiaire detailsStagiaire, PersonnelInfo personnelInfo) : this(numInsc, img, idSection, personnelInfoId, detailsInfoId)
        {
            DetailsStagiaire = detailsStagiaire;
            PersonnelInfo = personnelInfo;
        }

        public Stagiaire(string numInsc, string img, string statusStg, int? idSection, int? personnelInfoId, int? detailsInfoId)
        {
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
        public List<ListeStagiaires> getStagiaires(int idSec)
        {
            return (from s in dc.Stagiaires 
                    join sec in dc.Sections on s.idSection equals sec.idSec
                    where sec.idSec==idSec 
                    select new ListeStagiaires(s.id,"","","",s.statusStg,s.PersonnelInfo.nom+" "+s.PersonnelInfo.prenom,"","")).ToList<ListeStagiaires>();
        }

        public Stagiaire getStagiaire(int id)
        {
            return (from s in dc.Stagiaires where s.id==id select s).Single();
        }

        public void addStagiaire(Stagiaire stg)
        {

            dc.ExecuteCommand("INSERT INTO Stagiaire (numInsc,img,statusStg,idSection,personnelInfoId,detailsInfoId) VALUES ({0},{1},{2},{3},{4},{5})",
              stg.numInsc,stg.img,stg.statusStg,stg.idSection,stg.personnelInfoId,stg.detailsInfoId);
            dc.SubmitChanges();
        }

        public void deleteStagiaire(Stagiaire stg)
        {
            dc.Stagiaires.DeleteOnSubmit(stg);
            dc.SubmitChanges();
        }

        public void editStagiaire(Stagiaire stg,int id)
        {

            var stag = from s in dc.Stagiaires where s.id == id select s;

            foreach (var s in stag)
            {
                s.numInsc = stg.numInsc;
                s.img = stg.img;
                s.statusStg = stg.statusStg;
                s.idSection = stg.idSection;
                

            }


            dc.SubmitChanges();
        }
        
        public List<ListeStagiaires> viewStagiaires()
        {
            var query =(from s in dc.Stagiaires 
                       join ss in dc.Sections on s.idSection equals ss.idSec
                       join pi in dc.PersonnelInfos on s.personnelInfoId equals pi.idPersonne
                       join cs in dc.CatalogeSections on ss.idCat equals cs.idCataloge
                       select new ListeStagiaires(s.id,s.numInsc,cs.codeSpe+" "+ss.numSection.ToString(),pi.dateNai.ToString()+" "+pi.lieuNai, s.statusStg,pi.nom,pi.prenom,s.img)
                       ).ToList<ListeStagiaires>();

            return query;
        }

        public List<ListeStagiaires> viewStagiairesSearch(string name)
        {
            var query = (from s in dc.Stagiaires
                         join ss in dc.Sections on s.idSection equals ss.idSec
                         join pi in dc.PersonnelInfos on s.personnelInfoId equals pi.idPersonne
                         join cs in dc.CatalogeSections on ss.idCat equals cs.idCataloge
                         where pi.nom.Contains(name) || pi.prenom.Contains(name)
                         select new ListeStagiaires(s.id, s.numInsc, cs.codeSpe + " " + ss.numSection.ToString(), pi.dateNai.ToString() + " " + pi.lieuNai,s.statusStg, pi.nom, pi.prenom, s.img)
                       ).ToList<ListeStagiaires>();

            return query;
        }

        public List<detailsStagiaire> listeStagiairesSection(int id)
        {
            List<detailsStagiaire> liste = (from s in dc.Stagiaires
                         join ss in dc.Sections on s.idSection equals ss.idSec
                         join pi in dc.PersonnelInfos on s.personnelInfoId equals pi.idPersonne
                         join ds in dc.DetailsStagiaires on s.detailsInfoId equals ds.id
                         join cs in dc.CatalogeSections on ss.idCat equals cs.idCataloge
                         where s.idSection == id
                         select new detailsStagiaire(ds.sang, (int)ds.sitMedical, ds.prenomPere, ds.nomMere, ds.prenomMere, ds.telTuteur, ds.nat, ds.derEtabFre, ds.nivScolaire, ds.sitFam, ds.profPere, ds.profMere, ds.sitFamParents,
                                                     pi.nom, pi.prenom, (DateTime)pi.dateNai, pi.lieuNai, pi.sexe, pi.adresse, pi.email, pi.telephone,
                                                     s.id, s.numInsc, s.img,s.statusStg, (int)s.idSection, (int)s.personnelInfoId, (int)s.detailsInfoId,
                                                     ss.idSec, (DateTime)ss.dateOuv, (DateTime)ss.dateFin, (int)ss.numSection, ss.modeGestionForm.ToString(),
                                                     cs.intituleSpe, cs.niveauFormation.ToString(), cs.codeSpe)
                       ).ToList<detailsStagiaire>();

            return liste;
        }


        public detailsStagiaire detailsStagiaires(int id)
        {
            var query = (from s in dc.Stagiaires
                         join ss in dc.Sections on s.idSection equals ss.idSec
                         join pi in dc.PersonnelInfos on s.personnelInfoId equals pi.idPersonne
                         join ds in dc.DetailsStagiaires on s.detailsInfoId equals ds.id
                         join cs in dc.CatalogeSections on ss.idCat equals cs.idCataloge
                         where s.id==id
                         select new detailsStagiaire(ds.sang,(int)ds.sitMedical,ds.prenomPere,ds.nomMere,ds.prenomMere,ds.telTuteur,ds.nat,ds.derEtabFre,ds.nivScolaire,ds.sitFam,ds.profPere,ds.profMere,ds.sitFamParents,
                                                     pi.nom,pi.prenom,(DateTime)pi.dateNai,pi.lieuNai,pi.sexe,pi.adresse,pi.email,pi.telephone,
                                                     s.id,s.numInsc,s.img, s.statusStg, (int)s.idSection, (int)s.personnelInfoId, (int)s.detailsInfoId,
                                                     ss.idSec, (DateTime)ss.dateOuv, (DateTime)ss.dateFin, (int)ss.numSection, ss.modeGestionForm.ToString(),
                                                     cs.intituleSpe,cs.niveauFormation.ToString(),cs.codeSpe)
                       ).Single();

            return query;
        }


    }
}