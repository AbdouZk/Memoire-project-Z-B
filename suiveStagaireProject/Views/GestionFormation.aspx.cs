using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm10 : System.Web.UI.Page
    {
            Branchee branche = new Branchee();
            CatalogeSection cataloge = new CatalogeSection();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId >= 3)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"] == null)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"].Equals("addCat"))
                {



                    if (dropDownBrachees.Items.Count == 0)
                    {
                        dropDownBrachees.DataSource = branche.getListeBranchees();
                        dropDownBrachees.DataTextField = "libileBrache";
                        dropDownBrachees.DataValueField = "idBrache";

                        dropDownBrachees.DataBind();
                    }

                }

                if (Request.QueryString["do"].Equals("editCat") && Request.QueryString["idCat"] != null)
                {

                    CatalogeSection cat = new CatalogeSection();
                    cat = cataloge.getCatalogeSec(int.Parse(Request.QueryString["idCat"]));

                    if (DropDownBracheeEditCat.Items.Count == 0)
                    {
                        DropDownBracheeEditCat.DataSource = branche.getListeBranchees();
                        DropDownBracheeEditCat.DataTextField = "libileBrache";
                        DropDownBracheeEditCat.DataValueField = "idBrache";
                        DropDownBracheeEditCat.DataBind();
                    }
                    if (editCatcodeSpe.Text.Equals(""))
                    {
                        DropDownBracheeEditCat.SelectedValue = cat.brancheId.ToString();
                        editCatcodeSpe.Text = cat.codeSpe;
                        editCatintitulCat.Text = cat.intituleSpe;
                        dropDownFilierEditCat.SelectedValue = cat.fileresExigees;
                        if (cat.niveauFormation == 4) { radioEditCat.SelectedValue = "4"; } else { radioEditCat.SelectedValue = "5"; }
                    }

                    
                }
              
                if (Request.QueryString["do"].Equals("deleteCat") && Request.QueryString["idCat"] != null)
                {

                    CatToDrop.Text = cataloge.getCatalogeCode(int.Parse(Request.QueryString["idCat"]));
                    CatToDrop.Visible = true;



                }
                else
                {
                    CatToDrop.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterCat_Click(object sender, EventArgs e)
        {
            try
            {

                int branchId = int.Parse(dropDownBrachees.SelectedValue);
                string codSec = codeSpe.Text;
                string intitul = intitulCat.Text;
                string intitulAr = intitulCatAr.Text;
                string FilierExigess = dropDownFilierExigess.SelectedValue;
                int niveau = int.Parse(radioNivCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec, intitul, intitulAr, FilierExigess, niveau);
                cataloge.addCatalogeSec(cat);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Ajouter</div>";
                NotDoAlert.Visible = true;

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div>";
                NotDoAlert.Visible = true;
            }
        }

        protected void btnSaveEditCat_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(Request.QueryString["idCat"]);
                int branchId = int.Parse(DropDownBracheeEditCat.SelectedValue);
                string codSec = editCatcodeSpe.Text;
                string intitul = editCatintitulCat.Text;
                string intitulAr = editCatintitulCatAr.Text;
                string FilierExigess = dropDownFilierEditCat.SelectedValue;
                int niveau = int.Parse(radioEditCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec, intitul, intitulAr, FilierExigess, niveau);
                cataloge.editCatlogCat(cat, id);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Modifier</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div><br/>";
            }

        }

        protected void btnDropCtaloge_Click(object sender, EventArgs e)
        {
            try
            {

                CatalogeSection cat = cataloge.getCatalogeSec(int.Parse(Request.QueryString["idCat"]));
                cataloge.deleteCatalogeSec(cat);
                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllCat");
            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div><br/>";

            }
        }
    }
}