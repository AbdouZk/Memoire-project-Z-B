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

        public CatalogeSection(int idCataloge, int brancheId, string codeSpe, string intituleSpe, string fileresExigees, int niveauFormation, EntitySet<Section> sections, Branchee brachee)
        {
            this.idCataloge = idCataloge;
            this.brancheId = brancheId;
            this.codeSpe = codeSpe;
            this.intituleSpe = intituleSpe;
            this.fileresExigees = fileresExigees;
            this.niveauFormation = niveauFormation;
            Sections = sections;
            Branchee = brachee;
        }

        public CatalogeSection(int brancheId, string codeSpe, string intituleSpe, string fileresExigees, int niveauFormation)
        {
            this.brancheId = brancheId;
            this.codeSpe = codeSpe;
            this.intituleSpe = intituleSpe;
            this.fileresExigees = fileresExigees;
            this.niveauFormation = niveauFormation;
        }

        public List<CatalogeSection> getListeCatalogeSec()
        {
            List<CatalogeSection> listeCataloges = new List<CatalogeSection>();

            listeCataloges = (from cat in dc.CatalogeSections select cat).ToList<CatalogeSection>();

            return listeCataloges;
        }

        public CatalogeSection getCatalogeSec(int id)
        {
            CatalogeSection Cataloge = new CatalogeSection();

            Cataloge = (from cat in dc.CatalogeSections where cat.idCataloge==id select cat).Single();

            return Cataloge;
        }

        public string getCatalogeCode(int id)
        {
            CatalogeSection Cataloge = new CatalogeSection();

            Cataloge = (from cat in dc.CatalogeSections where cat.idCataloge == id select cat).Single();

            return Cataloge.codeSpe;
        }

        public void addCatalogeSec(CatalogeSection catSec)
        {
            dc.ExecuteCommand("INSERT INTO CatalogeSection (brancheId,codeSpe,intituleSpe,fileresExigees,niveauFormation)  VALUES ({0},{1},{2},{3},{4})",
                catSec.brancheId, catSec.codeSpe, catSec.intituleSpe,catSec.fileresExigees, catSec.niveauFormation);


            dc.SubmitChanges();
        }

        public void updateCatlogSec(CatalogeSection cataloge,int id)
        {
            var cat = from c in dc.CatalogeSections where c.idCataloge == id select c;

            foreach (var c in cat)
            {
                c.brancheId = cataloge.brancheId;
                c.codeSpe = cataloge.codeSpe;
                c.intituleSpe = cataloge.intituleSpe;
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
    }
}