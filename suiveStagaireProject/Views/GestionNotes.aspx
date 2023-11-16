<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionNotes.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
         <title>Gestion Notes</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
    <div class="container">

        
            <div class="=row">

               <% 

                   suiveStagaireProject.Models.Module module = new suiveStagaireProject.Models.Module();
                   suiveStagaireProject.Models.Section section = new suiveStagaireProject.Models.Section();
                   suiveStagaireProject.Models.Exam exam = new suiveStagaireProject.Models.Exam();
                   suiveStagaireProject.Models.Note note = new suiveStagaireProject.Models.Note();
                   suiveStagaireProject.Models.Stagiaire stagiaire = new suiveStagaireProject.Models.Stagiaire();
               %>



        <% if (Request.QueryString["do"].Equals("chooseSec"))
            { %>
                 
                    <h3 class="bg-info text-white text-center p-2">Sélectionner une section  </h3>
                    

                        <div class="col-12 text-center mb-5 ">
                            <label class="form-label mt-2"><b>Sections</b></label><br />
                            <asp:DropDownList runat="server" ID="dropdownSections" CssClass="form-control-lg mt-1">       </asp:DropDownList>
                        </div>
                        
                       
                         <div class="col-12 text-center mt-5">
                             
                             <asp:Button Text="Suivant" ID="btnSuivantSec" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantSec_Click" />
                             <asp:Button Text="Suivant" ID="btnSuivantSecDel" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantSecDel_Click" Visible="false" />
                             <asp:Button Text="Suivant" ID="btnSuivantSecR" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantSecR_Click" Visible="false" />
                             <asp:Button Text="Suivant" ID="btnSuivantSecDelR" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantSecDelR_Click" Visible="false" />
                             <a  href="HomePage.aspx?id=<%=Session["id"]%>"  class="btn btn-danger m-5" >Annuler</a>
                        </div>



       
        <%} else if (Request.QueryString["do"].Equals("chooseMod")) 
            {%>
            
                
                    <h3 class="bg-info text-white text-center p-2">Sélectionner un module </h3>
                    

                         <div class="col-12 mb-5 text-center">
                            <label class="form-label mt-2"><b>Modules</b></label><br />
                            <asp:DropDownList runat="server" ID="dropdownModules" CssClass="form-control-lg mt-1">       </asp:DropDownList>
                        </div>
                         <div class="col-12 mt-5 text-center">
                             
                             <asp:Button Text="Suivant" ID="btnSuivantMod" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantMod_Click" />
                             <asp:Button Text="Suivant" ID="btnSuivantModR" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantModR_Click" Visible="false" />
                             <a  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=chooseSec"  class="btn btn-danger m-5" >Précédent</a>
                        </div>

                   

                


            <%}

                else if (Request.QueryString["do"].Equals("show"))
                {
                   string saisir= Request.QueryString["opt"];
                    %>
                                    <h3 class="bg-info text-white text-center">Saisie Des Notes</h3>

                
                                    <h3 class="bg-info text-white text-center">Affichage Notes de module : <%=module.getModule(int.Parse(Request.QueryString["idMod"])).libelle %> </h3>
                                    <h5 class="bg-info text-white text-center">La Section : <%=Request.QueryString["codeSec"] %></h5>
                   <% if (saisir.Equals("saisirS"))
                       { %>
                            <div class="col-12">
             
                                <table class="table stripe">
                                  <thead class="table-dark">
                                      <tr >

                                          <th style="width:300px">Name </th>
                                          <th style="width:300px"> date Naissance</th>
                                          <th>E1</th>
                                          <th>E2</th>
                                          <th>Synthese</th>
                                          <th>Options</th>

                              
                                      </tr>
                                       </thead> 
                                      <%


                                          foreach (var n in note.getAllStgBySec((Request.QueryString["codeSec"])))
                                          { %>
                                      <tr>

                                            <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.nom + " " + stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.prenom %> </td>
                                            <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.dateNai.Value.ToShortDateString() %> </td>
                                            <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "E1") %></td>
                                            <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "E2") %></td>
                                            <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "S") %></td>
                                            <td>
                                                <a  id="btnEditNote"   class="btn btn-warning me-2" href="GestionNotes.aspx?id=<%=Session["id"]%>&do=show&edit=S&opt=<%=Request.QueryString["opt"]%>&codeSec=<%=Request.QueryString["codeSec"]%>&idStg=<%=(int)n.stgID%>&idMod=<%=Request.QueryString["idMod"]%>&idExm=<%=Request.QueryString["idExm"]%>" >Modifier</a>
                                                <a  id="btnDeleteNote" class="btn btn-danger me-2"  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=delete&codeSec=<%=Request.QueryString["codeSec"]%>&idStg=<%=(int)n.stgID%>&idMod=<%=Request.QueryString["idMod"]%>&idExm=<%=Request.QueryString["idExm"]%>"  >Supprimer</a>
                                            </td>
                                        </tr>  

                                          
                     
                          
                                      <% 
                                          }%>

                 

                     

                                  <tbody>

                                  </tbody>

                                </table>
                            </div>
                            <div class="col-12 mt-4 ">
                                    <div class="row">

                                        <div class="col-12 col-md-4 mt-2">

                                            <asp:DropDownList  runat="server" ID="listStgs" CssClass="form-control"  ></asp:DropDownList>


                                        </div>

                                    <div class="col-12 col-md-8 mt-2">
                                        <div class="row">
                                     
                                                 <div class="col-12 col-md-8 text-center mt-2 me-auto">
                                                    <asp:TextBox runat="server" ID="e1" CssClass="me-auto" Width="80" MaxLength="5"  ></asp:TextBox>
                                                    <asp:TextBox runat="server" ID="e2" CssClass="me-auto" Width="80" MaxLength="5"  ></asp:TextBox>
                                                    <asp:TextBox runat="server" ID="s"  CssClass="me-auto" Width="80" MaxLength="5"  ></asp:TextBox>
                                        
                                                </div>
                                    
                                                 <div class="col-12 col-md-4 text-center mt-2">
                                                   <asp:Button runat="server" ID="btnIsererNote" Text="Inserer" CssClass="btn btn-primary me-2" OnClick="btnIsererNote_Click"/>                                       
                                                   <asp:Button runat="server" ID="btnSaveNote" Text="Save" CssClass="btn btn-primary me-2" OnClick="btnSaveNote_Click" Visible="false"/>                                       
                                                   <asp:Button runat="server" ID="btnImprission" Text="Imprimer" CssClass="btn btn-success " OnClick="btnImprission_Click" />                                       
                                                </div>
                                        </div>
                                      </div>
                                        <div class="col-12 text-center">
                                             <a  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=chooseMod&opt=<%=Request.QueryString["opt"] %>&codeSec=<%=Request.QueryString["codeSec"] %>" class="btn btn-danger m-5" >Précédent</a>

                                        </div>
                                        <div class="col-12 text-center">
                                            <asp:Label Text="" ID="errorInsertNotes" runat="server" Visible="false" />
                                        </div>
                                    </div>
                            </div>
                     <%}
                         else if (saisir.Equals("saisirR")) { 
                          %>
                            <div class="col-12">
             
                                <table class="table stripe">
                                  <thead class="table-dark">
                                      <tr >

                                          <th style="width:300px">Name </th>
                                          <th style="width:300px"> date Naissance</th>                                          
                                          <th>Rattrapage</th>
                                          <th>Options</th>

                              
                                      </tr>
                                       </thead> 
                                      <%


                                          foreach (var n in note.getAllStgBySecR((Request.QueryString["codeSec"])))
                                          { if (note.GetMoyenByExm_stg_S(int.Parse(Request.QueryString["idExm"]), (int)n.stgID )< 10)
                                              {  %>
                                      <tr>

                                            <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.nom + " " + stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.prenom %> </td>
                                            <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.dateNai.Value.ToShortDateString() %> </td>
                                            
                                            <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "R") %></td>

                                            <td>
                                                <a  id="btnEditNoteR"   class="btn btn-warning me-2" href="GestionNotes.aspx?id=<%=Session["id"]%>&do=show&opt=<%=Request.QueryString["opt"]%>&edit=R&codeSec=<%=Request.QueryString["codeSec"]%>&idStg=<%=(int)n.stgID%>&idMod=<%=Request.QueryString["idMod"]%>&idExm=<%=Request.QueryString["idExm"]%>" >Modifier</a>
                                                <a  id="btnDeleteNoteR" class="btn btn-danger me-2"  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=deleteR&codeSec=<%=Request.QueryString["codeSec"]%>&idStg=<%=(int)n.stgID%>&idMod=<%=Request.QueryString["idMod"]%>&idExm=<%=Request.QueryString["idExm"]%>"  >Supprimer</a>
                                            </td>
                                        </tr>  


                     
                          
                                      <%    }

                                          }%>

                 

                     

                                  <tbody>

                                  </tbody>

                                </table>
                            </div>
                            <div class="col-12 mt-4 ">
                                    <div class="row">

                                        <div class="col-12 col-md-4 mt-2">

                                            <asp:DropDownList  runat="server" ID="listStgsR" CssClass="form-control"  ></asp:DropDownList>


                                        </div>

                                    <div class="col-12 col-md-8 mt-2">
                                        <div class="row">
                                     
                                                 <div class="col-12 col-md-8 text-center mt-2 me-auto">
                                                   
                                                    <asp:TextBox runat="server" ID="r"  CssClass="me-auto" Width="80" MaxLength="5"  ></asp:TextBox>
                                        
                                                </div>
                                    
                                                 <div class="col-12 col-md-4 text-center mt-2">
                                                   <asp:Button runat="server" ID="btnIsererNoteR" Text="Inserer" CssClass="btn btn-primary me-2" OnClick="btnIsererNoteR_Click"/>                                       
                                                   <asp:Button runat="server" ID="btnSaveNoteR" Text="Save" CssClass="btn btn-primary me-2" OnClick="btnSaveNoteR_Click" Visible="false"/>                                       
                                                   <asp:Button runat="server" ID="btnImprissionR" Text="Imprimer" CssClass="btn btn-success " OnClick="btnImprissionR_Click" />                                       
                                                </div>
                                        </div>
                                      </div>
                                        <div class="col-12 text-center">
                                             <a  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=chooseMod&opt=<%=Request.QueryString["opt"] %>&codeSec=<%=Request.QueryString["codeSec"] %>" class="btn btn-danger m-5" >Précédent</a>

                                        </div>
                                        <div class="col-12 text-center">
                                            <asp:Label Text="" ID="errorInsertNotesR" runat="server" Visible="false" />
                                        </div>
                                    </div>
                            </div>
                         
                         
                         
                     
                         
                         
                       <%} %>
              <%}

                else if (Request.QueryString["do"].Equals("deleteR"))
                {
                      try
                    {
                            string idSec = Request.QueryString["codeSec"];
                            int idExm = int.Parse(Request.QueryString["idExm"]);
                            int idStg = int.Parse(Request.QueryString["idStg"]);
                            int idMod = int.Parse(Request.QueryString["idMod"]);

                            note.deleteNote(note.GetNoteByStg_Exm_Type(idExm,idStg,"R"));

                            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirS&codeSec=" + idSec + "&idMod=" + idMod+ "&idExm=" + idExm);

                    }
                    catch (Exception ex)
                    {
                        errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Supprimer</div>";
                        errorInsertNotes.Visible = true;
                    }


                } else if (Request.QueryString["do"].Equals("delete")) {

                    try
                    {
                            string idSec = Request.QueryString["codeSec"];
                            int idExm = int.Parse(Request.QueryString["idExm"]);
                            int idStg = int.Parse(Request.QueryString["idStg"]);
                            int idMod = int.Parse(Request.QueryString["idMod"]);

                            note.deleteNote(note.GetNoteByStg_Exm_Type(idExm,idStg,"E1"));
                            note.deleteNote(note.GetNoteByStg_Exm_Type(idExm,idStg,"E2"));
                            note.deleteNote(note.GetNoteByStg_Exm_Type(idExm,idStg,"S"));

                            Response.Redirect("GestionNotes.aspx?id=" + Session["id"] + "&do=show&opt=saisirS&codeSec=" + idSec + "&idMod=" + idMod+ "&idExm=" + idExm);

                    }
                    catch (Exception ex)
                    {
                        errorInsertNotes.Text = "<div class='alert alert-danger'>Echec de Supprimer</div>";
                        errorInsertNotes.Visible = true;
                    }
                }else
                {
                    Response.Redirect("404-page.aspx");

                }%>
                
              

          </div>
    </div>
      

</asp:Content>
