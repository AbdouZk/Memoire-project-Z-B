<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionSection.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title>Gestion Section</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container"> 
        

        

       <% if (Request.QueryString["do"] != null)
           {

               // declaration 

               suiveStagaireProject.Models.CatalogeSection cataloge = new suiveStagaireProject.Models.CatalogeSection();
               suiveStagaireProject.Models.Branchee branchee = new suiveStagaireProject.Models.Branchee();
               suiveStagaireProject.Models.Section section = new suiveStagaireProject.Models.Section();
              

               //tratement


             if (Request.QueryString["do"].Equals("AllSec"))
              {

                    %>
                                <h3 class=" d-block p-2 bg-info text-white text-center"> Liste Des Sections</h3>
                        <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                              <a class="btn btn-primary " href="GestionSection.aspx?id=<%=Session["id"]%>&do=add-editSec">Ajouter</a>
                        </div> 

                     <table class="table text-center ">
                          <thead class="table-dark">
                            <tr>
                              <th scope="col"> Code Section </th>
                              <th scope="col"> Branche </th>
                              <th scope="col">Libellé </th>
                              <th scope="col">Semestre</th>
                              <th scope="col">Mode </th>
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%
                             
                              foreach (var s in section.getAllSection())
                              {%>
                                <tr>
                                  <td><%=s.codeSection%> </td>
                                  <td >
                                      <%=s.CatalogeSection.Branchee.libileBrache%> 
                                      <br />
                                      <%=s.CatalogeSection.Branchee.LibileBracheAr%> 

                                  </td>
                                  <td>
                                      <%=s.CatalogeSection.intituleSpe%> 
                                      <br />
                                      <%=s.CatalogeSection.intituleSpeAr %>

                                  </td>
                                  <td><%=s.Semestre.saison%></td>
                                  <td><%if (s.modeGestionForm.Equals('R')) { Response.Write("Résidentiel"); } else { Response.Write("Apprentissage"); }%></td>
                                  <td >
                                      
                                      
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionSection.aspx?id=<%=Session["id"]%>&do=add-editSec&opt=edit&idSec=<%=s.codeSection%>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionSection.aspx?id=<%=Session["id"]%>&do=deleteSec&idSec=<%=s.codeSection%>">Supprimer</a>

                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>
                     
                         

          <%                            

             }
                 else if (Request.QueryString["do"].Equals("add-editSec"))

              {%>
                  					<h3 class="text-center text-white bg-primary">Ajouter Section</h3>
              <div class="addStagiaireBody">
                <div class="row">
                    <div class="col-6">
                      <!-- Cataloge input -->
                          <div class=" mb-4">
                              <label class="form-label" for="DropDownFormationAdd">Formation Professionnelles</label>
                              <asp:DropDownList ID="DropDownFormationAdd"  CssClass="form-control"  runat="server"></asp:DropDownList>
                            
                          </div>
                    </div>
                    <div class="col-6">
                          <!-- Numero de la section input -->
                          <div class=" mb-4">   
                              <label class="form-label" for="numSectionAdd">Numéro de la section</label>
                            <asp:TextBox ID="numSectionAdd" runat="server" CssClass="form-control"></asp:TextBox>
                            
                          </div>
                    </div>
                    
                    
                    <div class="col-12">
                            <!-- Mode Gestion input -->
                          <div class=" mb-4">
                            
                            <label class="form-label" for="modeGesAdd">Mode Gestion</label>

                              <asp:RadioButtonList ID="RadioButtonmodeGesAdd" runat="server" CssClass="form-control">

                                  <asp:ListItem Value="R" Selected="True">Résidentielle</asp:ListItem>
                                  <asp:ListItem Value="A">Apprentissage</asp:ListItem>

                              </asp:RadioButtonList>

                          </div>
                      </div>
        
        

                    </div>
                         <!-- Date debut input -->
                          <div class=" mb-4">
                             
                            <label class="form-label" for="debutForAdd">Date Début</label>
                            <input id="debutForAdd" name = "debutForAdd"  class="form-control" runat="server" type="Date" value="2023-09-28"/>


                          </div> 

                        <!-- Date fin input -->
                          <div class=" mb-4">
                             
                            <label class="form-label" for="finForAdd">Date Fin</label>
                            <input id="finForAdd" name = "finForAdd"  class="form-control" runat="server" type="Date" value="2023-09-28"/>


                          </div> 

                        <!-- Tuteur Section input -->
                          <div class=" mb-4">
                             
                            <label class="form-label" for="DropDowntuteurSecAdd">Tuteur Section</label>
                            <asp:DropDownList ID="DropDowntuteurSecAdd" CssClass="form-control" runat="server"></asp:DropDownList>


                          </div> 
                        
                               
                      <div class="row">

                          <!-- Submit button -->

                         <div class="col-12 mt-5 mb-5">
                            <div class="row ">
                                <div class="col-6 text-center">
                                     <asp:Button ID="btnAddSec" runat="server" CssClass="btn btn-primary" Text="Ajouter" OnClick="btnAddSec_Click" />
                                     <asp:Button ID="btnSaveSec" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveSec_Click" Visible="false"/>
                                </div>
                                <div class="col-6 text-center">
                                    <a class=" btn btn-secondary text-center" href="GestionSection.aspx?id=<%=Session["id"] %>&do=AllSec">Annuler</a>
                                </div>
                            </div>
                         </div>
                          <div class="col-6 mt-5 mb-3 text-center">
                              <asp:Button ID="btnFicheOuvertureSec" runat="server" CssClass="btn btn-lg btn-dark " Text="Fiche d'Ouverture de la Section " Visible="false" OnClick="btnFicheOuvertureSec_Click" />
                          </div>
                           <div class="col-6 mt-5 mb-3 text-center">
                                <asp:Button ID="btnListeStagSec" runat="server" CssClass="btn btn-lg btn-dark " Text="Liste des stagaires admis" Visible="false" OnClick="btnListeStagSec_Click" />

                          </div>
                     </div>
                  </div>
        <br />
        <br />

                  <%}
                 else if (Request.QueryString["do"].Equals("deleteSec"))
                      {
                %> 
                            					<h2 class="badge bg-primary">Supprimer Section</h2>
                            <div class='alert alert-danger' role='alert'>
                                <h3> Voulez vous confirmer de supprimer La Section :<b><asp:Label ID="SecToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                <asp:Button ID="btnDropSection" CssClass=" btn-danger" runat="server" Text="Confirmer" OnClick="btnDropSection_Click"/> 
                            
                                <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllSec" class=" btn-secondary"> Annuler</a>

                                </div>
                <%}
                        
                else
                {

                Response.Redirect("404-page.aspx");

                }


          } %>

      
        <!-- Alert / Heading page  -->
            <asp:Label ID="NotDoAlert" runat="server" Text=""></asp:Label>
        

       
    </div>
    <br />
    <br />


</asp:Content>
