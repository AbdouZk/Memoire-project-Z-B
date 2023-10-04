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
                   suiveStagaireProject.Models.Stagiaire stagiaire = new suiveStagaireProject.Models.Stagiaire();
                   suiveStagaireProject.Models.Stg_Exm stg_exm = new suiveStagaireProject.Models.Stg_Exm();
               %>



        <% if (Request.QueryString["do"].Equals("chooseSec"))
            { %>
                 <div class="col-12">
                    <h3 class="bg-info text-white text-center">La Section : </h3>
                    <div class="row">

                        <div class="col-6 text-center mb-5 ">
                            <label class="form-label"><b>Sections</b></label>
                            <asp:DropDownList runat="server" ID="dropdownSections" CssClass="form-control ">       </asp:DropDownList>
                        </div>
                         <div class="col-6 text-center mb-5">
                            <label class="form-label"><b>Semestre</b></label>
                            <asp:DropDownList runat="server" ID="DropDownSemestre" CssClass="form-control ">
                                <asp:ListItem Text="Semestre 1" Value="1" />
                                <asp:ListItem Text="Semestre 2" Value="2" />
                                <asp:ListItem Text="Semestre 3" Value="3" />
                                <asp:ListItem Text="Semestre 4" Value="4" />
                                <asp:ListItem Text="Semestre 5" Value="5" />
                            </asp:DropDownList>
                        </div>
                       
                         <div class="col-12 text-center mt-5">
                             
                             <asp:Button Text="Suivant" ID="btnSuivantSec" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantSec_Click" />
                             <a  href="HomePage.aspx?id=<%=Session["id"]%>"  class="btn btn-danger m-5" >Annuler</a>
                        </div>

                    </div>

                </div>

       
        <%} else if (Request.QueryString["do"].Equals("chooseMod")) 
            {%>
            
                <div class="col-12">
                    <h3 class="bg-info text-white text-center">Le Module : </h3>
                    <div class="row">

                         <div class="col-12 mb-5 text-center">
                            <label class="form-label"><b>Modules</b></label>
                            <asp:DropDownList runat="server" ID="dropdownModules" CssClass="form-control ">       </asp:DropDownList>
                        </div>
                         <div class="col-12 mt-5 text-center">
                             
                             <asp:Button Text="Suivant" ID="btnSuivantMod" runat="server" CssClass="btn btn-primary m-5" OnClick="btnSuivantMod_Click" />
                             <a  href="GestionNotes.aspx?id=<%=Session["id"]%>&do=chooseSec"  class="btn btn-danger m-5" >Précédent</a>
                        </div>

                    </div>

                </div>


            <%}

                else if (Request.QueryString["do"].Equals("show"))
                {
                    //suiveStagaireProject.Models.Metier.ListeStagiairesNotes listeStagiairesNotes = new suiveStagaireProject.Models.Metier.ListeStagiairesNotes();
                    %>
                                    <h3 class="bg-info text-white text-center">Saisie Des Notes</h3>

                <div class="col-12 mt-4 mb-5">
                        <div class="row">

                            <div class="col-12 col-md-6">
                                 <label class="form-label">List Stagiaires</label>
                                <asp:ListBox  runat="server" ID="listStgs" CssClass="form-control"  ></asp:ListBox>


                            </div>

                        <div class="col-12 col-md-6">
                            <div class="row">
                                    <div class="col-4 ">
                                        <label class="form-label">Evaluation 1</label>
                                        <asp:TextBox runat="server" ID="e1" CssClass="form-control"  ></asp:TextBox>

                                    </div>
                                     <div class="col-4 ">
                                        <label class="form-label">Evaluation 2</label>
                                        <asp:TextBox runat="server" ID="e2" CssClass="form-control"  ></asp:TextBox>

                                    </div>
                                     <div class="col-4 ">
                                        <label class="form-label">Synthèse</label>
                                        <asp:TextBox runat="server" ID="s" CssClass="form-control"  ></asp:TextBox>

                                    </div>
                                     <div class="col-12 mt-3 text-center">
                                       <asp:Button runat="server" ID="btnIsererNote" Text="Inserer"      CssClass="btn btn-primary me-2" OnClick="btnIsererNote_Click"/>
                                       <asp:Button runat="server" ID="btnEditNote"   Text="Modifier"     CssClass="btn btn-warning me-2"/>
                                       <asp:Button runat="server" ID="btnDeleteNote" Text="Supprimer"    CssClass="btn btn-danger me-2"/>

                                    </div>
                            </div>
                          </div>
                            <div class="col-12 text-center">
                                <asp:Label Text="" ID="errorInsertNotes" runat="server" Visible="false" />
                            </div>
                        </div>
                </div>
                                    <h3 class="bg-info text-white text-center">Affichage Notes de module : <%=module.getModule(int.Parse(Request.QueryString["idMod"])).libelle %></h3>
                                    <h5 class="bg-info text-white text-center">La Section : <%=section.detailsSections(int.Parse(Request.QueryString["idSec"])).CodeSec+" "+section.detailsSections(int.Parse(Request.QueryString["idSec"])).NumSec %></h5>

                <div class="col-12">
                    <table class="table stripe">
                      <thead class="table-dark">
                          <tr >

                              <th style="width:300px">Name </th>
                              <th style="width:300px"> date Naissance</th>

                              <th>E1</th>
                              <th>E2</th>
                              <th>Synthese</th>
                              
                          </tr>


                      </thead>

                      <tbody>

                    <% foreach (var s in stg_exm.getAllStgBySec( int.Parse(Request.QueryString["idSem"]),int.Parse(Request.QueryString["idMod"]) )) {
                        %>
                            <tr>

                                <td><%=stagiaire.getStagiaire(s).PersonnelInfo.nom+" "+stagiaire.getStagiaire(s).PersonnelInfo.prenom %> </td>
                                <td><%=stagiaire.getStagiaire(s).PersonnelInfo.dateNai.Value.ToShortDateString() %> </td>

                                <% foreach (var ns in stg_exm.getAllStg_ExmByStg(s)){
                                    if (ns.Examen.typeExamen.Equals("E1")) { 
                                   %> 
                                    <td><%=ns.note %> </td>
                                    
                                                                        
                                   <% break;
                                           }
                                       } %>
                                 <% foreach (var ns in stg_exm.getAllStg_ExmByStg(s)){
                                    if (ns.Examen.typeExamen.Equals("E2")) { 
                                   %> 
                                    <td><%=ns.note %> </td>
                                    
                                                                        
                                   <% break;
                                           }
                                       } %>
                                 <% foreach (var ns in stg_exm.getAllStg_ExmByStg(s)){
                                    if (ns.Examen.typeExamen.Equals("S")) { 
                                   %> 
                                    <td><%=ns.note %> </td>
                                    
                                                                        
                                   <% break;
                                           }
                                       }

                                       %>
                               
                            
                            </tr>  
                              
                        <%} %>

                      </tbody>

                    </table>
                </div>
            <%}
                else if (Request.QueryString["do"].Equals("add-edit"))
                {%>

            <h3 class="bg-info text-white text-center">Saisie Des Notes</h3>

        <%  } else
if (Request.QueryString["do"].Equals("delete")) {

            }
            else
            {
                Response.Redirect("404-page.aspx");

            }%>
                
              

          </div>
    </div>

</asp:Content>
