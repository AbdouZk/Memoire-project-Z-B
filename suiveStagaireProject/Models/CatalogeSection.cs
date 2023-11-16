using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace suiveStagaireProject.Models
{
    public partial class CatalogeSection

    {

        private myLinqToSqlDataContext dc = new myLinqToSqlDataContext();

        public CatalogeSection(int brancheId, string codeSpe, string intituleSpe, string intituleSpeAr, string fileresExigees, int niveauFormation)
        {
            this.brancheId = brancheId;
            this.codeSpe = codeSpe;
            this.intituleSpe = intituleSpe;
            this.intituleSpeAr = intituleSpeAr;
            this.fileresExigees = fileresExigees;
            this.niveauFormation = niveauFormation;
        }

        public List<CatalogeSection> getListeCatalogeSec()
        {          

           return (from cat in dc.CatalogeSections select cat).ToList<CatalogeSection>();
        }       

        public CatalogeSection getCatalogeSec(int id)
        {
            

           return (from cat in dc.CatalogeSections where cat.idCataloge==id select cat).Single();

             
        }

        public string getCatalogeCode(int id)
        {
          

          return  (from cat in dc.CatalogeSections where cat.idCataloge == id select cat.codeSpe).Single();

            
        }

        public void addCatalogeSec(CatalogeSection catSec)
        {
            dc.ExecuteCommand("INSERT INTO CatalogeSection (brancheId,codeSpe,intituleSpe,intituleSpeAr,fileresExigees,niveauFormation)  VALUES ({0},{1},{2},{3},{4},{5})",
                catSec.brancheId, catSec.codeSpe, catSec.intituleSpe,catSec.intituleSpeAr,catSec.fileresExigees, catSec.niveauFormation);


            dc.SubmitChanges();
        }

        public void editCatlogCat(CatalogeSection cataloge,int id)
        {
            var cat = from c in dc.CatalogeSections where c.idCataloge == id select c;

            foreach (var c in cat)
            {
                c.brancheId = cataloge.brancheId;
                c.codeSpe = cataloge.codeSpe;
                c.intituleSpe = cataloge.intituleSpe;
                c.intituleSpeAr = cataloge.intituleSpeAr;
                c.fileresExigees = cataloge.fileresExigees;
                c.niveauFormation = cataloge.niveauFormation;

            }

            dc.SubmitChanges();
        }
        public void deleteCatalogeSec(CatalogeSection catSec)
        {
            dc.CatalogeSections.DeleteOnSubmit(catSec);
            dc.SubmitChanges();
        }
    
        public int getNbrOfItem()
        {
            return dc.CatalogeSections.Count();
        }
    }
}