using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stagiaire stagiare = new Stagiaire();
            Enseignant enseignant = new Enseignant();
            Section section = new Section();
            Module module = new Module();
            Employeur employeur = new Employeur();
            CatalogeSection cataloge = new CatalogeSection();

            try
            {
                nbrFormations.Text = cataloge.getNbrOfItem().ToString();
                nbrSections.Text = section.getNbrOfItem().ToString();
                nbrModules.Text = module.getNbrOfItem().ToString();

                nbrStagiaires.Text = stagiare.getNbrOfItem().ToString();
                nbrStaStats.Text = stagiare.getNbrOfGirls()+" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; "+stagiare.getNbrOfEtrangere()+" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; "+stagiare.getNbrOfHandicape()+" &nbsp; &nbsp; &nbsp; &nbsp ";

                nbrEns.Text = enseignant.getNbrOfItem().ToString();
                nbrEmp.Text = employeur.getNbrOfItem().ToString();
            
            }
            catch (Exception ex)
            {

            }
        }
    }
} 