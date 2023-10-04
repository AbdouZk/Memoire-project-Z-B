using suiveStagaireProject.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class Section
    {
        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public Section(int idSec, DateTime dateOuv, DateTime? dateFin, int? numSection,  string tuteurSection, char modeGestionForm, string modeOrgaForm,char sSec, int idCat)
        {
            this.idSec = idSec;
            this.dateOuv = dateOuv;
            this.dateFin = dateFin;
            this.numSection = numSection;
            this.tuteurSection = tuteurSection;
            this.modeGestionForm = modeGestionForm;
            this.modeOrgaForm = modeOrgaForm;
            this.sSec = sSec;
            this.idCat = idCat;
        }

        public Section(DateTime dateOuv, DateTime? dateFin, int? numSection,  string tuteurSection, char modeGestionForm, string modeOrgaForm,char sSec, int idCat)
        {
            
            this.dateOuv = dateOuv;
            this.dateFin = dateFin;
            this.numSection = numSection;          
            this.tuteurSection = tuteurSection;
            this.modeGestionForm = modeGestionForm;
            this.modeOrgaForm = modeOrgaForm;
            this.sSec = sSec;
            this.idCat = idCat;
            
        }

        public Section getSection(int id)
        {
            return (from s in dc.Sections where s.idSec == id select s).Single();
        }

        public List<Section> getAllSection()
        {
            return (from s in dc.Sections select s).ToList<Section>();
        }
        public void addSection(Section section)
        {

            dc.ExecuteCommand("INSERT INTO Section (idSec,dateOuv,dateFin,numSection,tuteurSection,modeGestionForm,modeOrgaForm,sSec,idCat) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8})",
            section.idSec, section.dateOuv,section.dateFin,section.numSection,section.tuteurSection,section.modeGestionForm,section.modeOrgaForm,section.sSec, section.idCat);

            dc.SubmitChanges();
        }        
        public void editSection(Section section,int id)
        {

            var sec = from s in dc.Sections where s.idSec==id select s;

            foreach(var s in sec)
            {
                s.dateOuv = section.dateOuv;
                s.dateFin = section.dateFin;
                s.numSection = section.numSection; 
                s.tuteurSection = section.tuteurSection;
                s.modeGestionForm = section.modeGestionForm;
                s.modeOrgaForm = section.modeOrgaForm;
                s.sSec = section.sSec;
                s.idCat = section.idCat;
                
            }

            dc.SubmitChanges();
        }
        public void deleteSection(Section section)
        {

            dc.Sections.DeleteOnSubmit(section);
            dc.SubmitChanges();
        }
        public List<ListeSections> viewSections()
        {

            var query = (
                            from s in dc.Sections
                            join cat in dc.CatalogeSections on s.idCat equals cat.idCataloge
                            
                            select new ListeSections(s.idSec, cat.codeSpe+" "+s.numSection.ToString(), cat.intituleSpe, s.sSec.ToString(), s.dateOuv.ToString(), s.dateFin.ToString() , s.modeGestionForm.ToString())
                        
                         ).ToList<ListeSections>();

            return query;
        }
        public detailsSection detailsSections(int id)
        {

            var query = (
                            from s in dc.Sections
                            join cat in dc.CatalogeSections
                            on s.idCat equals cat.idCataloge
                            where s.idSec==id
                            select new detailsSection(cat.codeSpe,s.numSection.ToString(),cat.intituleSpe,s.modeOrgaForm,s.modeGestionForm.ToString(),s.dateOuv.ToString(),s.dateFin.ToString(),cat.niveauFormation.ToString(),s.tuteurSection,0,0,0,0)

                         ).Single();

            return query;
        }
        public int nbrStagSection(int id)
        {

            var count = dc.Stagiaires
                .Join(
                    dc.Sections,
                    a => a.idSection,
                    b => b.idSec,
                    (a, b) => new { TableA = a, TableB = b }
                )
               
                .Where(joined => joined.TableA.idSection == id)
                .Count();

            return count;

        }
        public int nbrGirlsSection(int id)
        {

            var count = dc.Stagiaires
                .Join(
                    dc.PersonnelInfos,
                    a => a.personnelInfoId,  
                    b => b.idPersonne,  
                    (a, b) => new { TableA = a, TableB = b }
                )
                .Join(
                    dc.Sections,
                    ab => ab.TableA.idSection,  
                    c => c.idSec,           
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => joined.TableB.sexe == "Femme" &&  joined.TableA.idSection == id) 
                .Count();

            return count;

        }
        public int nbrHandicapeSection(int id)
        {

            var count = dc.Stagiaires
                .Join(
                    dc.DetailsStagiaires,
                    a => a.detailsInfoId,
                    b => b.id,
                    (a, b) => new { TableA = a, TableB = b }
                )
                .Join(
                    dc.Sections,
                    ab => ab.TableA.idSection,
                    c => c.idSec,
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => joined.TableB.sitMedical == 0 && joined.TableA.idSection == id)
                .Count();

            return count;

        }
        public int nbrEtrangerSection(int id)
        {

            var count = dc.Stagiaires
                .Join(
                    dc.DetailsStagiaires,
                    a => a.detailsInfoId,
                    b => b.id,
                    (a, b) => new { TableA = a, TableB = b }
                )
                .Join(
                    dc.Sections,
                    ab => ab.TableA.idSection,
                    c => c.idSec,
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => (joined.TableB.nat != "Algerian" ) && joined.TableA.idSection == id)
                .Count();

            return count;

        }
        public int getLastId()
        {
            return dc.Sections.OrderByDescending(item => item.idSec).Select(item => item.idSec).FirstOrDefault();
        }

        public int countSecById(int id)
        {
            int rowCount = dc.Sections
                           .Where(item => item.idSec == idSec)
                           .Count();
            return rowCount;
        }
    }
}