using suiveStagaireProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace suiveStagaireProject.Views
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        Section section = new Section();
        Seance seance = new Seance();
        Exam exm = new Exam();
        Module module = new Module();
        Note note = new Note();
        Stagiaire stagiaire = new Stagiaire();
        Enseignant enseignant = new Enseignant();

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login_Register.aspx");
                }

                int groupId = int.Parse(Session["groupId"].ToString());

                if (Session["trustId"].ToString().Equals("0")  || ((groupId == 2 || groupId==3) && (Request.QueryString["opt"]=="saisirS" || Request.QueryString["opt"] == "saisirR")) )
                {
                    Response.Redirect("HomePage.aspx?id=" + Session["id"]);
                }


                if (Session["groupId"].ToString() == "4")
                {

                    int idEns = enseignant.getEnseignatByUserId(int.Parse(Session["id"].ToString())).idEnseiginant;
                    string codeSec="";
                    if (Request.QueryString["codeSec"] != null) { codeSec= Request.QueryString["codeSec"]; }
                    if (dropdownSections.Items.Count == 0)
                    {
                        dropdownSections.DataSource = enseignant.getSectionByEns(idEns);
                        dropdownSections.DataTextField = "codeSec";
                        dropdownSections.DataValueField = "codeSec";
                        dropdownSections.DataBind();
                    }
                    if (dropdownModules.Items.Count == 0)
                    {
                        dropdownModules.DataSource = seance.GetModulesByProf_Section(idEns,codeSec);
                        dropdownModules.DataTextField = "libMod";
                        dropdownModules.DataValueField = "idMod";
                        dropdownModules.DataBind();
                    }

                }
                else
                {
                    if (dropdownSections.Items.Count == 0)
                    {
                        dropdownSections.DataSource = section.getAllSection();
                        dropdownSections.DataTextField = "codeSection";
                        dropdownSections.DataValueField = "codeSection";
                        dropdownSections.DataBind();
                    }



                }



                if (Request.QueryString["do"] != null)
                {


                    if (Request.QueryString["do"].Equals("show") && Request.QueryString["opt"] != null && Request.QueryString["codeSec"] != null)
                    {
                        string codeSec = (Request.QueryString["codeSec"]);

                        if (listStgs.Items.Count == 0)
                        {
                            listStgs.DataSource = stagiaire.getStagiairesBySecAdmisRatt(codeSec);
                            listStgs.DataTextField = "nom";
                            listStgs.DataValueField = "idStg";
                            listStgs.DataBind();

                            listStgsR.DataSource = stagiaire.getStagiairesBySec_Status(codeSec,"Rattrapage");
                            listStgsR.DataTextField = "nom";
                            listStgsR.DataValueField = "idStg";
                            listStgsR.DataBind();
                        }

                        if (Request.QueryString["edit"] != null && Request.QueryString["idStg"] != null && Request.QueryString["idExm"] != null)
                        {
                            if (Request.QueryString["edit"].Equals("S"))
                            {
                                if (!btnSaveNote.Visible)
                                {
                                    listStgs.SelectedValue = Request.QueryString["idStg"];
                                    e1.Text = note.GetNote(int.Parse(Request.QueryString["idStg"]), int.Parse(Request.QueryString["idExm"]), "E1").ToString();
                                    e2.Text = note.GetNote(int.Parse(Request.QueryString["idStg"]), int.Parse(Request.QueryString["idExm"]), "E2").ToString();
                                    s.Text = note.GetNote(int.Parse(Request.QueryString["idStg"]), int.Parse(Request.QueryString["idExm"]), "S").ToString();
                                    btnIsererNote.Visible = false;
                                    btnSaveNote.Visible = true;
                                }
                            }else
                            if (Request.QueryString["edit"].Equals("R"))
                             {
                                if (!btnSaveNoteR.Visible)
                                {
                                    listStgsR.SelectedValue = Request.QueryString["idStg"];
                                    r.Text = note.GetNote(int.Parse(Request.QueryString["idStg"]), int.Parse(Request.QueryString["idExm"]), "R").ToString();
                                    btnIsererNoteR.Visible = false;
                                    btnSaveNoteR.Visible = true;
                                }
                             }
                        }
                    }
                    else if (Request.QueryString["do"].Equals("chooseMod") && Request.QueryString["opt"] != null && Request.QueryString["codeSec"] != null)
                    {
                        string codeSec = (Request.QueryString["codeSec"]);

                        if (dropdownModules.Items.Count == 0)
                        {
                            dropdownModules.DataSource = module.getModuleBySection(codeSec);
                            dropdownModules.DataTextField = "libMod";
                            dropdownModules.DataValueField = "idMod";
                            dropdownModules.DataBind();
                        }

                        if (Request.QueryString["opt"].Equals("saisirS"))
                        {

                        }
                        else if (Request.QueryString["opt"].Equals("saisirR"))
                        {
                            btnSuivantMod.Visible = false;
                            btnSuivantModR.Visible = true;
                        }


                    }

                    else
                    if (Request.QueryString["do"].Equals("chooseSec") && Request.QueryString["opt"] != null)
                    {
                        if (Request.QueryString["opt"].Equals("saisirS"))
                        {

                        }
                        else if (Request.QueryString["opt"].Equals("saisirR"))
                        {
                            btnSuivantSec.Visible = false;
                            btnSuivantSecR.Visible = true;
                        }
                        else if (Request.QueryString["opt"].Equals("DelebS"))
                        {
                            btnSuivantSec.Visible = false;
                            btnSuivantSecDel.Visible = true;
                        }
                        else if (Request.QueryString["opt"].Equals("DelebR"))
                        {
                            btnSuivantSec.Visible = false;
                            btnSuivantSecDelR.Visible = true;
                        }

                    }
                    else
                    if (Request.QueryString["do"].Equals("delete") && Request.QueryString["id"] != null)
                    {



                    }
                }
                else
                {
                    Response.Redirect("404-page.aspx");
                }

            }
            catch (Exception ex)
            {

            }

        }


        protected void btnSuivantSec_Click(object sender, EventArgs e)
        {
            try
            {
                string idSec = (dropdownSections.SelectedValue);

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseMod&&opt=saisirS&codeSec=" + idSec);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSuivantMod_Click(object sender, EventArgs e)
        {
            try
            {

                string idSec = (Request.QueryString["codeSec"]);
                int idMod = int.Parse(dropdownModules.SelectedValue);
                int idExm = exm.GetExma(idMod, idSec).idExamen;

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirS&codeSec=" + idSec + "&idMod=" + idMod + "&idExm=" + idExm);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnIsererNote_Click(object sender, EventArgs e)
        {
            try
            {
               
                int idStg = int.Parse(listStgs.SelectedValue);
                int idExm = int.Parse(Request.QueryString["idExm"]);

                decimal? ev1 = decimal.Parse(e1.Text);
                decimal? ev2 = decimal.Parse(e2.Text);
                decimal? syn = decimal.Parse(s.Text);

                if (e1.Text.Equals("") || e2.Text.Equals("") || s.Text.Equals(""))
                {
                    errorInsertNotes.Text = "<div class='alert alert-danger'>Valeur vide !</div>";
                    errorInsertNotes.Visible = true;

                }else 
                if (ev1 > 20 || ev2 > 20 || syn > 20)
                {
                    errorInsertNotes.Text = "<div class='alert alert-danger'>Valeur sup à 20 !</div>";
                    errorInsertNotes.Visible = true;

                }            
                else {
                    errorInsertNotes.Visible = false;
                note.addNote(new Note(idExm, idStg, "E1", ev1));
                note.addNote(new Note(idExm, idStg, "E2", ev2));
                note.addNote(new Note(idExm, idStg, "S", syn));

                if (listStgs.SelectedIndex != listStgs.Items.Count - 1)
                {
                    listStgs.SelectedIndex = listStgs.SelectedIndex + 1;
                }

                e1.Text = "";
                e2.Text = "";
                s.Text = "";
                e1.Focus();
                }
            }
            catch (Exception ex)
            {
                errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Ajouter</div>";
                errorInsertNotes.Visible = true;
            }
        }

        protected void btnSaveNote_Click(object sender, EventArgs e)
        {
            try
            {
                int idStg = int.Parse(listStgs.SelectedValue);
                int idExm = int.Parse(Request.QueryString["idExm"]);

                decimal ev1 = decimal.Parse(e1.Text);
                decimal ev2 = decimal.Parse(e2.Text);
                decimal syn = decimal.Parse(s.Text);

                note.editNote(note.GetNoteByStg_Exm_Type(idStg, idExm, "E1"), ev1);
                note.editNote(note.GetNoteByStg_Exm_Type(idStg, idExm, "E2"), ev2);
                note.editNote(note.GetNoteByStg_Exm_Type(idStg, idExm, "S"), syn);



                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirS&codeSec=" + Request.QueryString["codeSec"] + "&idStg=" + Request.QueryString["idStg"] + "&idMod=" + Request.QueryString["idMod"] + "&idExm=" + Request.QueryString["idExm"]);

            }
            catch (Exception ex)
            {
                errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Modifier</div>";
                errorInsertNotes.Visible = true;
            }
        }

        protected void btnSuivantSecDel_Click(object sender, EventArgs e)
        {
            try
            {
                string codeSection = dropdownSections.SelectedValue;

                Response.Redirect("reports/DelebirationSenthese.aspx?id=" + Session["id"] + "&do=impression&opt=DelebS&codeSec=" + codeSection );

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSuivantSecR_Click(object sender, EventArgs e)
        {
            try
            {
                string idSec = (dropdownSections.SelectedValue);

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=chooseMod&&opt=saisirR&codeSec=" + idSec);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSuivantSecDelR_Click(object sender, EventArgs e)
        {
            try
            {
                string codeSection = dropdownSections.SelectedValue;

                Response.Redirect("reports/DelebirationSenthese.aspx?id=" + Session["id"] + "&do=impression&opt=DelebR&codeSec=" + codeSection );

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSuivantModR_Click(object sender, EventArgs e)
        {
            try
            {

                string idSec = (Request.QueryString["codeSec"]);
                int idMod = int.Parse(dropdownModules.SelectedValue);
                int idExm = exm.GetExma(idMod, idSec).idExamen;

                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirR&codeSec=" + idSec + "&idMod=" + idMod + "&idExm=" + idExm);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnImprission_Click(object sender, EventArgs e)
        {
            try
            {

                string codeSec = (Request.QueryString["codeSec"]);
                int idExm = (int.Parse(Request.QueryString["idExm"]));
               

                Response.Redirect("reports/NoteIpression.aspx?id=" + Session["id"] + "&do=impression&opt=S&codeSec=" + codeSec+"&idExm="+idExm);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnIsererNoteR_Click(object sender, EventArgs e)
        {
            try
            {

                int idStg = int.Parse(listStgsR.SelectedValue);
                int idExm = int.Parse(Request.QueryString["idExm"]);
               
                decimal? Ratt = decimal.Parse(r.Text);

                if (Ratt.Value.Equals(""))
                {
                    errorInsertNotes.Text = "<div class='alert alert-danger'>Valeur vide !</div>";
                    errorInsertNotes.Visible = true;

                }
                else
                if (Ratt > 20 )
                {
                    errorInsertNotes.Text = "<div class='alert alert-danger'>Valeur sup à 20 !</div>";
                    errorInsertNotes.Visible = true;

                }
                else
                {
                    errorInsertNotes.Visible = false;
                    note.addNote(new Note(idExm, idStg, "R", Ratt));

                    if (listStgs.SelectedIndex != listStgs.Items.Count - 1)
                    {
                        listStgs.SelectedIndex = listStgs.SelectedIndex + 1;
                    }

                   
                    r.Text = "";
                    r.Focus();
                }
            }
            catch (Exception ex)
            {
                errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Ajouter</div>";
                errorInsertNotes.Visible = true;
            }
        }

        protected void btnSaveNoteR_Click(object sender, EventArgs e)
        {
            try
            {
                int idStg = int.Parse(listStgs.SelectedValue);
                int idExm = int.Parse(Request.QueryString["idExm"]);

                decimal Ratt = decimal.Parse(r.Text);
                

                note.editNote(note.GetNoteByStg_Exm_Type(idStg, idExm, "R"), Ratt);



                Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirR&codeSec=" + Request.QueryString["codeSec"] + "&idStg=" + Request.QueryString["idStg"] + "&idMod=" + Request.QueryString["idMod"] + "&idExm=" + Request.QueryString["idExm"]);

            }
            catch (Exception ex)
            {
                errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Modifier</div>";
                errorInsertNotes.Visible = true;
            }
        }

        protected void btnImprissionR_Click(object sender, EventArgs e)
        {
            try
            {

                string codeSec = (Request.QueryString["codeSec"]);
                int idExm = (int.Parse(Request.QueryString["idExm"]));


                Response.Redirect("reports/NoteIpression.aspx?id=" + Session["id"] + "&do=impression&opt=R&codeSec=" + codeSec + "&idExm=" + idExm);

            }
            catch (Exception ex)
            {

            }
        }
    }
}