using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace suiveStagaireProject
{
    public partial class MainPageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login_Register.aspx");
            }

            User user = new User();
            Enseignant enseignant = new Enseignant();
            if (Session["groupId"].Equals("4")) 
            {
                userWelcome.Text = "<p>Bienvenue " + enseignant.getEnseignatByUserId(int.Parse(Session["id"].ToString())).PersonnelInfo.nom + enseignant.getEnseignatByUserId(int.Parse(Session["id"].ToString())).PersonnelInfo.prenom + "</p> ";

            }
            else
            {
                userWelcome.Text = "<p>Bienvenue " + user.getUser(int.Parse(Session["id"].ToString())).username + "</p> ";

            }
            

            lblYear.Text = DateTime.Now.Year.ToString()+" - "+ (int.Parse(DateTime.Now.Year.ToString())+1);
           
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session["id"] = null; Session["username"] = null; Session["trustId"] = null;Session["groupId"] = null;
            Response.Redirect("Login_Register.aspx");
        }

        protected void btnCRUDcomptes_Click(object sender, EventArgs e)
        {
            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString() != "1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=add");
            }
            

        }

        protected void btnListeComp_Click(object sender, EventArgs e)
        {

            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString()!="1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                 Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=All");
            }
           
        }

        protected void btnActDis_Click(object sender, EventArgs e)
        {
            if (Session["trustId"].ToString().Equals("0") || Session["groupId"].ToString() != "1")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("GestionComptesPage.aspx?id=" + Session["id"] + "&do=All");
            }
           
        }

     

        protected void btnCRUDsec_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=add-editSec");
        }

        protected void btnListSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllSec");

        }

        protected void BtnCRUDsta_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionStagiaires.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");

        }

        protected void btnListeStagaires_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionStagiaires.aspx?id=" + Session["id"] + "&do=AllStg");

        }

        

        protected void btnListModules_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionModules.aspx?id="+Session["id"]+"&do=AllModules");
        }

        protected void btnCRUDmodules_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionModules.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");

        }

        protected void btnListeEns_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEnseignants.aspx?id=" + Session["id"] + "&do=AllEns");

        }

        protected void btnCrudens_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEnseignants.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");
        }

        protected void btnSaisieNote_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseSec&opt=saisirS");

        }

        protected void btnAjouterFormation_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionFormation.aspx?id=" + Session["id"] + "&do=addCat");
        }

        protected void btnListeFormation_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionFormation.aspx?id=" + Session["id"] + "&do=AllCat");

        }

        protected void btnAjouetrExm_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=AllSeances");

        }

        protected void btnListeExm_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionExamens.aspx?" + Session["id"]+ "&do=AllExamens");
        }

        protected void btnAjouterSeance_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");
        }

        protected void btnListeSeances_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionSeances.aspx?id=" + Session["id"] + "&do=AllSeances");
        }

        protected void btnAjouterBr_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionBranches.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");

        }

        protected void btnListesBr_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionBranches.aspx?id=" + Session["id"] + "&do=AllBranches");

        }

        protected void btnCrudEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEmployeurs.aspx?id=" + Session["id"] + "&do=add-edit&opt=add");

        }

        protected void btnListeEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEmployeurs.aspx?id=" + Session["id"] + "&do=AllEmp");
        }

        protected void btnDeliNote_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseSec&opt=DelebS");

        }

        protected void btnSaisieNoteR_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseSec&opt=saisirR");

        }

        protected void btnDeliNoteR_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseSec&opt=DelebR");

        }
    }
}