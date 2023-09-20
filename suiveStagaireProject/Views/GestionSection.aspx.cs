using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        CatalogeSection cataloge = new CatalogeSection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId =int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0") || groupId>=3)
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }

                if (Request.QueryString["do"].Equals("addCat") && Request.QueryString["idCat"] != null)
                {
                    CatalogeSection cat = new CatalogeSection();
                    Branchee branche = new Branchee();

                    if (dropDownBrachees.Items.Count==0) {
                        dropDownBrachees.DataSource = branche.getListeBranchees();
                        dropDownBrachees.DataTextField = "libileBrache";
                        dropDownBrachees.DataValueField = "idBrache";

                        dropDownBrachees.DataBind();
                    }
                    
                }
                else
                {
                 
                }


                if (Request.QueryString["do"].Equals("editCat") && Request.QueryString["idCat"] != null)
                {
                    CatalogeSection cat = new CatalogeSection();
                    Branchee branche = new Branchee();
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
                else
                {
                    errorsEdit.Text = "User Introuvable !";
                    errorsEdit.Visible = true;
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

        

        protected void btnSaveEditCat_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["idCat"]);
                int branchId = int.Parse(DropDownBracheeEditCat.SelectedValue);
                string codSec = editCatcodeSpe.Text;
                string intitul = editCatintitulCat.Text;
                string FilierExigess = dropDownFilierEditCat.SelectedValue;
                int niveau = int.Parse(radioEditCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec, intitul, FilierExigess, niveau);
                cataloge.updateCatlogSec(cat,id);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Editer</div><br/>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div><br/>";
            }

        }

        protected void btnDropCtaloge_Click(object sender, EventArgs e)
        {
            try{ 

                CatalogeSection cat = cataloge.getCatalogeSec(int.Parse(Request.QueryString["idCat"]));
                cataloge.deleteCatalogeSec(cat);
                Response.Redirect("GestionSection.aspx?id=" + Session["id"] + "&do=AllCat");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAjouterCat_Click(object sender, EventArgs e)
        {
            try
            {

                int branchId =int.Parse( dropDownBrachees.SelectedValue );
                string codSec = codeSpe.Text;
                string intitul = intitulCat.Text;
                string FilierExigess = dropDownFilierExigess.SelectedValue;
                int niveau =int.Parse( radioNivCat.SelectedItem.Value);

                CatalogeSection cat = new CatalogeSection(branchId, codSec,intitul, FilierExigess, niveau);
                cataloge.addCatalogeSec(cat);

                NotDoAlert.Text = "<div class='alert alert-success' role='alert'>Bien Ajouter</div>";

            }
            catch (Exception ex)
            {
                NotDoAlert.Text = "<div class='alert alert-danger' role='alert'>Operation Echéc</div>";
            }
        }
    }
}