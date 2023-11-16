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

        public Section(string codeSection, DateTime dateOuv, DateTime dateFin, string tuteurSection, char modeGestionForm, int? semestreId, int idCat)
        {
            this.codeSection = codeSection;
            this.dateOuv = dateOuv;
            this.dateFin = dateFin;
            this.tuteurSection = tuteurSection;
            this.modeGestionForm = modeGestionForm;
            this.semestreId = semestreId;
            this.idCat = idCat;
        }

        public Section getSection(string code)
        {
            return (from s in dc.Sections where s.codeSection == code select s).Single();
        }
        public List<Section> getAllSection()
        {
            return (from s in dc.Sections select s).ToList<Section>();
        }
        public void addSection(Section section)
        {
            dc.ExecuteCommand("INSERT INTO Section (codeSection,dateOuv,dateFin,tuteurSection,modeGestionForm,semestreId,idCat) VALUES ({0},{1},{2},{3},{4},{5},{6})",
            section.codeSection, section.dateOuv,section.dateFin,section.tuteurSection,section.modeGestionForm,section.semestreId, section.idCat);

            dc.SubmitChanges();
        }        
        public void editSection(Section section, string code)
        {

            var sec = from s in dc.Sections where s.codeSection== code select s;

            foreach(var s in sec)
            {
                s.dateOuv = section.dateOuv;
                s.dateFin = section.dateFin;
                s.tuteurSection = section.tuteurSection;
                s.modeGestionForm = section.modeGestionForm;
                s.semestreId = section.semestreId;
                s.idCat = section.idCat;
                
            }

            dc.SubmitChanges();
        }
        public void deleteSection(Section section)
        {

            dc.Sections.DeleteOnSubmit(section);
            dc.SubmitChanges();
        }
        public int nbrMonthStudy(string codeSection)
        {
            DateTime databaseDate = (from s in dc.Sections where s.codeSection == codeSection select s.dateOuv).Single(); ;

            int monthsDifference = ((DateTime.Now.Year - databaseDate.Year) * 12) + DateTime.Now.Month - databaseDate.Month;

            return monthsDifference;
        }
        public int nbrStagSection(string code)
        {

            var count = dc.Stagiaires
                .Join(
                    dc.Sections,
                    a => a.idSection,
                    b => b.codeSection,
                    (a, b) => new { TableA = a, TableB = b }
                )
               
                .Where(joined => joined.TableA.idSection == code)
                .Count();

            return count;

        }
        public int nbrGirlsSection(string code)
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
                    c => c.codeSection,           
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => joined.TableB.sexe == "Femme" &&  joined.TableA.idSection == code) 
                .Count();

            return count;

        }
        public int nbrHandicapeSection(string code)
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
                    c => c.codeSection,
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => joined.TableB.sitMedical == 0 && joined.TableA.idSection == code)
                .Count();

            return count;

        }
        public int nbrEtrangerSection(string code)
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
                    c => c.codeSection,
                    (ab, c) => new { ab.TableA, ab.TableB, TableC = c }
                )
                .Where(joined => (joined.TableB.nat != "Algerian" ) && joined.TableA.idSection == code)
                .Count();

            return count;

        }
        public int countSecById(string code)
        {
            int rowCount = dc.Sections
                           .Where(item => item.codeSection == code)
                           .Count();
            return rowCount;
        }
        public int getAcutualSem(string codeSection)
        {
            DateTime startDate = (from s in dc.Sections where s.codeSection == codeSection select s.dateOuv).Single();
            DateTime DateNow  = DateTime.Now;


            return ((DateNow.Year - startDate.Year) * 12) + DateNow.Month - startDate.Month;
        }
        public int getNbrOfItem()
        {
            return dc.Sections.Count();
        }
    }
}