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
               suiveStagaireProject.Models.Enseignant enseignant = new suiveStagaireProject.Models.Enseignant();
               suiveStagaireProject.Models.Ens_Sec ens_sec = new suiveStagaireProject.Models.Ens_Sec();
               suiveStagaireProject.Models.Sec_Mod_Sem sec_mod_sem = new suiveStagaireProject.Models.Sec_Mod_Sem();
               List<suiveStagaireProject.Models.CatalogeSection> listeCataloges = new List<suiveStagaireProject.Models.CatalogeSection>();
               List<suiveStagaireProject.Models.Metier.ListeSections> listeSections = new List<suiveStagaireProject.Models.Metier.ListeSections>();
               List<suiveStagaireProject.Models.Metier.ListeEnseignant> listeEnseignants=new List<suiveStagaireProject.Models.Metier.ListeEnseignant>();
               List<suiveStagaireProject.Models.Module> listeModule=new List<suiveStagaireProject.Models.Module>();



               //tratement



                 if (Request.QueryString["do"].Equals("addCat"))
               {%>
                        	<h2 class="text-center text-white bg-primary">Ajouter une formation au cataloge</h2>
                         <div class="addStagiaireBody">
                          <!-- Braches input -->
                          <div class=" mb-4">
                              <label class="form-label" for="dropDownBrachees">Branches Professionnelles</label>
                              <asp:DropDownList ID="dropDownBrachees" runat="server" CssClass="form-control"></asp:DropDownList>
                            
                          </div>

                          <!-- code specialite input -->
                          <div class=" mb-4">   
                              <label class="form-label" for="codeSpe">Code de spécialité</label>
                            <asp:TextBox ID="codeSpe" runat="server" CssClass="form-control"></asp:TextBox>
                            
                          </div>

                          <!-- intitulé de la specialite input -->
                          <div class=" mb-4">
                              <label class="form-label" for="intitulCat">Intitulé de la specialite</label>
                             <asp:TextBox ID="intitulCat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            
                          </div> 
                            
                           <!-- Filier exigees pour l'accès à la formation input -->
                          <div class=" mb-4">
                             
                            <label class="form-label" for="dropDownFilierExigess">Filier exigees pour l'accès à la formation</label>
			                <asp:DropDownList ID="dropDownFilierExigess" CssClass="form-select" runat="server">

					                        <asp:ListItem Value="-1" >SVP Sélectionne</asp:ListItem>  
					                        <asp:ListItem Value="2eme année secondaire Series: Sciences et Gestion ">2eme année secondaire Series: Sciences et Gestion </asp:ListItem>  
					                        <asp:ListItem Value="2eme année secondaire Series: Sciences">2eme année secondaire Series: Sciences</asp:ListItem>  
					                        <asp:ListItem Value="2eme année secondaire Series: Gestion">2eme année secondaire Series: Gestion</asp:ListItem>  
					                        <asp:ListItem Value="2eme année secondaire Series: Littéraire">2eme année secondaire Series: Littéraire</asp:ListItem>  
					                        <asp:ListItem Value="2eme année secondaire Series: Tout series">2eme année secondaire Series: Tout series</asp:ListItem>  
					                        <asp:ListItem Value="3eme année secondaire Series: Sciences et Gestion">3eme année secondaire Series: Sciences et Gestion </asp:ListItem>  
					                        <asp:ListItem Value="3eme année secondaire Series: Sciences">3eme année secondaire Series: Sciences</asp:ListItem>  
					                        <asp:ListItem Value="3eme année secondaire Series: Gestion">3eme année secondaire Series: Gestion</asp:ListItem> 
					                        <asp:ListItem Value="3eme année secondaire Series: Littéraire">3eme année secondaire Series: Littéraire</asp:ListItem> 
					                        <asp:ListItem Value="3eme année secondaire Series: Tout series">3eme année secondaire Series: Tout series</asp:ListItem> 
					  
			                          </asp:DropDownList>


                          </div> 

                            <!-- Niveau input -->
                          <div class=" mb-4">
                            
                            <label class="form-label" for="radioNivCat">Niveau formation</label>

                              <asp:RadioButtonList ID="radioNivCat" runat="server" CssClass="form-control">

                                  <asp:ListItem Value="4" Selected="True">Niveau 4</asp:ListItem>
                                  <asp:ListItem Value="5">Niveau 5</asp:ListItem>

                              </asp:RadioButtonList>

                          </div>


                        
                        
         <!-- Submit button -->
                            <div class="row justify-content-center">
                                <div class="col-4">
                                                   
                                    <asp:Button ID="btnAjouterCat" CssClass=" btn-primary btn text-center" runat="server" Text="Ajouter" OnClick="btnAjouterCat_Click" />                                                
                                </div>
                                                
                                <div class="col-4">
                                    <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class=" btn-danger btn text-center">Annuler</a>
                                </div>
                                               

                            </div> 
                            <br />
                                    <asp:Label ID="Label1" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
                                    <asp:Label ID="Label2" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>
                    </div>
                             <br /><br />
                                           
                            
                    <%}
                 else if (Request.QueryString["do"].Equals("editCat"))
                        {%>
                           					<h3 class="text-center text-white bg-primary">Modifier Formation</h3>
                                     <div class="addStagiaireBody">
                                        <!-- Braches input -->
                                          <div class=" mb-4">
                                              <label class="form-label" for="bracheeEditCat">Branches Professionnelles</label>
                                               <asp:DropDownList ID="DropDownBracheeEditCat" CssClass="form-control" runat="server"></asp:DropDownList>
                            
                                          </div>

                                          <!-- code specialite input -->
                                          <div class=" mb-4">   
                                              <label class="form-label" for="editCatcodeSpe">Code de spécialité</label>
                                            <asp:TextBox ID="editCatcodeSpe" runat="server" CssClass="form-control"></asp:TextBox>
                            
                                          </div>

                                          <!-- intitulé de la specialite input -->
                                          <div class=" mb-4">
                                              <label class="form-label" for="editCatintitulCat">Intitulé de la specialite</label>
                                             <asp:TextBox ID="editCatintitulCat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            
                                          </div> 
                            
                                           <!-- Filier exigees pour l'accès à la formation input -->
                                          <div class=" mb-4">
                             
                                            <label class="form-label" for="dropDownFilierEditCat">Filier exigees pour l'accès à la formation</label>
			                                <asp:DropDownList ID="dropDownFilierEditCat" CssClass="form-select" runat="server">

					                                        <asp:ListItem Value="-1" >SVP Sélectionne</asp:ListItem>  
					                                        <asp:ListItem Value="2eme année secondaire Series: Sciences et Gestion">2eme année secondaire Series: Sciences et Gestion </asp:ListItem>  
					                                        <asp:ListItem Value="2eme année secondaire Series: Sciences">2eme année secondaire Series: Sciences</asp:ListItem>  
					                                        <asp:ListItem Value="2eme année secondaire Series: Gestion">2eme année secondaire Series: Gestion</asp:ListItem>  
					                                        <asp:ListItem Value="2eme année secondaire Series: Littéraire">2eme année secondaire Series: Littéraire</asp:ListItem>  
					                                        <asp:ListItem Value="3eme année secondaire Series: Sciences et Gestion">3eme année secondaire Series: Sciences et Gestion </asp:ListItem>  
					                                        <asp:ListItem Value="3eme année secondaire Series: Sciences">3eme année secondaire Series: Sciences</asp:ListItem>  
					                                        <asp:ListItem Value="3eme année secondaire Series: Gestion">3eme année secondaire Series: Gestion</asp:ListItem> 
					                                        <asp:ListItem Value="3eme année secondaire Series: Littéraire">3eme année secondaire Series: Littéraire</asp:ListItem> 
					  
			                                          </asp:DropDownList>


                                          </div> 

                                            <!-- Niveau input -->
                                          <div class=" ">
                            
                                            <label class="form-label" for="radioEditCat">Niveau formation</label>

                                              <asp:RadioButtonList ID="radioEditCat" runat="server" CssClass="form-control mb-3">

                                                  <asp:ListItem Value="4">Niveau 4</asp:ListItem>
                                                  <asp:ListItem Value="5">Niveau 5</asp:ListItem>

                                              </asp:RadioButtonList>

                                          </div>
                                           
                                           

                                          <!-- Submit button -->
                                            <div class="row justify-content-center">
                                                <div class="col-4">
                                                   
                                                   <asp:Button ID="btnSaveEditCat" CssClass=" btn-primary btn text-center" runat="server" Text="Save" OnClick="btnSaveEditCat_Click" />
                                                
                                                </div>
                                                
                                                <div class="col-4">
                                                    <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class=" btn-secondary btn text-center">Annuler</a>
                                                </div>
                                               

                                            </div> 
                                            <br />
                                                 <asp:Label ID="errorsEdit" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
                                                 <asp:Label ID="successEdit" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>
                                         </div>
                                 <br /><br />
        
                            

                          
                                    <%}
                 else if (Request.QueryString["do"].Equals("deleteCat"))
                                        {
                                    %> 
        					        <h2 class="badge bg-primary">Supprimer une fromation </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer La  :<b><asp:Label ID="CatToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropCtaloge" CssClass="btn btn-danger text-center" runat="server" Text="Confirmer" OnClick="btnDropCtaloge_Click"/> 
                            
                                                <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class="btn btn-secondary text-center"> Annuler</a>

                                               </div>

                                    <%}
                 else if (Request.QueryString["do"].Equals("AllCat"))
                                        {
                                            listeCataloges = cataloge.getListeCatalogeSec();

                    %>
                        					
            
                    <h3 class=" d-block p-2 bg-info text-white"> Liste Des Formations Existants </h3>

                     <table class="table">
                          <thead class="table-dark">
                            <tr>
                              <th scope="col">Id</th>
                              <th scope="col">Braches professionnelles</th>
                              <th scope="col">Code specialite</th>
                              <th scope="col">Intitule de specialite</th>
                              <th scope="col">Filiere exigées</th>
                              <th scope="col">Niveau</th>
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach (var c in listeCataloges)
                              {%>
                                <tr>
                                  <th scope="row"><%=c.idCataloge%></th>
                                  <td><%= branchee.getBracheName(c.brancheId)%></td>
                                  <td><%=c.codeSpe%></td>
                                  <td><%=c.intituleSpe %></td>
                                  <td><%=c.fileresExigees%></td>
                                  <td><%=c.niveauFormation%></td>
                                  <td >
                                      <!-- Ajouter -->
                                      
                                      <a class="btn btn-primary " href="GestionSection.aspx?id=<%=Session["id"]%>&do=addCat&idCat=<%=c.idCataloge%>">Ajouter</a>
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionSection.aspx?id=<%=Session["id"]%>&do=editCat&idCat=<%=c.idCataloge%>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger m-2" href="GestionSection.aspx?id=<%=Session["id"]%>&do=deleteCat&idCat=<%=c.idCataloge%>">Supprimer</a>

                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

          <%                            }
                 else if (Request.QueryString["do"].Equals("AllSec"))
              {

                    %>
                                <h3 class=" d-block p-2 bg-info text-white"> Liste Des Sections</h3>

                     <table class="table">
                          <thead class="table-dark">
                            <tr>
                              <th scope="col"> Code Section </th>
                              <th scope="col">Libellé </th>
                              <th scope="col">Semestre</th>
                              <th scope="col">Mode </th>
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%
                              listeSections = section.viewSections();
                              foreach (var s in listeSections)
                              {%>
                                <tr>
                                  <th scope="row"><%=s.IdSec%> / <%=s.CodeSec%> </th>
                                  <td><%=s.LibSec%></td>
                                  <td><%=s.Semestre%></td>
                                  <td><%if (s.ModeGesSec.Equals("R")) { Response.Write("Résidentiel"); } else { Response.Write("Apprentissage"); }%></td>
                                  <td >
                                      <!-- Ajouter -->
                                      
                                      <a class="btn btn-primary " href="GestionSection.aspx?id=<%=Session["id"]%>&do=add-editSec">Ajouter</a>
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionSection.aspx?id=<%=Session["id"]%>&do=add-editSec&idSec=<%=s.IdSec%>&idSem=<%=s.Semestre%>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionSection.aspx?id=<%=Session["id"]%>&do=deleteSec&idSec=<%=s.IdSec%>">Supprimer</a>

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
                          <!-- Semestre input -->
                          <div class=" mb-4">
                              <label class="form-label" for="DropDownListSemestreAdd">Semestre</label>
                              <asp:DropDownList ID="DropDownListSemestreAdd" CssClass="form-control" runat="server">

					                        <asp:ListItem Value="0" >SVP Sélectionne</asp:ListItem>  
					                        <asp:ListItem Value="1" >1ere Semestre</asp:ListItem>  
					                        <asp:ListItem Value="2" >2eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="3" >3eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="4" >4eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="5" >5eme Semestre</asp:ListItem>  
					                
			                          </asp:DropDownList>
                            
                          </div> 
                     </div> 
                     <div class="col-6">       
                           <!-- Mode Organisation input -->
                          <div class=" mb-4">
                             
                            <label class="form-label" for="modeOrgAdd">Mode Organisation de la section</label>
                            <asp:TextBox ID="modeOrgAdd" runat="server" CssClass="form-control"></asp:TextBox>


                          </div> 
                      </div> 
                    <div class="col-6">
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
                                     <asp:Button ID="btnSuivantSec" runat="server" CssClass="btn btn-primary" Text="Suivant" OnClick="btnSuivantSec_Click" />
                                     <asp:Button ID="btnSuivantSecEdit" runat="server" CssClass="btn btn-primary" Text="Suivant" OnClick="btnSuivantSecEdit_Click" Visible="false"/>
                                </div>
                                <div class="col-6 text-center">
                                    <asp:Button ID="btnAnnulerSectionAdd" runat="server" CssClass="btn btn-danger" Text="Annuler" OnClick="btnAnnulerSectionAdd_Click" />
                                    <asp:Button ID="btnAnnulerSectionEdit" runat="server" CssClass="btn btn-danger" Text="Annuler" OnClick="btnAnnulerSectionEdit_Click" Visible="false"/>
                                </div>
                            </div>
                         </div>
                          <div class="col-6 mt-5 mb-3 text-center">
<%--                              <a target="_blank" class="btn btn-info form-control" href="reports/ProcesVerbalSection.aspx?id=<%=Session["id"]%>&do=impression&idSec=<%=Request.QueryString["idSec"] %>" ><i class="fas fa-info-circle">La Fiche D'ouverture</i>  </a>--%>
                              <asp:Button ID="btnFicheOuvertureSec" runat="server" CssClass="btn btn-lg btn-dark " Text="La Fiche D'ouverture" Visible="false" OnClick="btnFicheOuvertureSec_Click" />
                          </div>
                           <div class="col-6 mt-5 mb-3 text-center">
<%--                              <a target="_blank" class="btn btn-info form-control" href="reports/ListeStagiairesIncorpores.aspx?id=<%=Session["id"]%>&do=impression&idSec=<%=Request.QueryString["idSec"] %>"><i class="fas fa-info-circle">Liste des stagaires</i>  </a>--%>
                                <asp:Button ID="btnListeStagSec" runat="server" CssClass="btn btn-lg btn-dark " Text="Liste des stagaires" Visible="false" OnClick="btnListeStagSec_Click" />

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
                 else if (Request.QueryString["do"].Equals("aORr"))
             {
                 List<suiveStagaireProject.Models.Metier.detailsEnsSecSem> listeEnseignantsAff = new List<suiveStagaireProject.Models.Metier.detailsEnsSecSem>();
                 int idSec = int.Parse(Request.QueryString["idSec"]);
                 int idSem = int.Parse(Request.QueryString["idSem"]);
                 listeEnseignantsAff = ens_sec.getListeEnseignants(idSec);


                 if (Request.QueryString["searchEns"] != null)
                 {

                     listeEnseignants = enseignant.getListeEnseignantsSearch(Request.QueryString["searchEns"]);
                 }
                 else
                 { listeEnseignants = enseignant.getListeEnseignants(); }


							%>
                    <div class="row">
                        <div class="col-12 col-md-6">
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Enseignants</h3>

						<div class="row justify-content-end">
                            <div class="col-8 col-md-4"">
							  <div class="">
								<input type="search" id="searchEns" class="form-control mb-2 mt-5 " placeholder="Recharher" runat="server"/>
								
							  </div>
							  </div>
							 <div class="col-4 col-md-4">
							  <asp:Button ID="btnsearchEns" CssClass="btn btn-success mb-2 mt-5" runat="server" Text="Recharcher" OnClick="btnsearchEns_Click">	</asp:Button>
							</div>
							

						</div>
                     <table class="table">
                          <thead class="table-dark">
                            <tr>
							                              
                              <th scope="col">Nom / Prenom</th>
                              <th scope="col">Specialité</th>
                              
                              <th scope="col">Action</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach (var e in listeEnseignants)
                              {%>
                                <tr>
                                  
                           
                                  <td><%=e.Nom + "  " + e.Prenom%> </td>
                                  <td><%=e.Specialite%>         </td> 
                                  
                              
                                  <td>
                                    
                                
                                      <!-- Action -->
                                      <%if (ens_sec.countEns_SecByAll(idSec,e.IdEns,idSem) <= 0)
                                          { %>
                                      <a href="GestionSection.aspx?id= <%=Session["id"] %>&do=Affectation&idSec=<%=Request.QueryString["idSec"]%>&idEns=<%=e.IdEns %>&idSem=<%=Request.QueryString["idSem"]%>" class="btn btn-success">Affectation</a>
                                      <%}
                                          else
                                          { %>
                                      <a href="GestionSection.aspx?id= <%=Session["id"] %>&do=Retrait&idSec=<%=Request.QueryString["idSec"]%>&idEns=<%=e.IdEns %>&idSem=<%=Request.QueryString["idSem"]%>" class="btn btn-danger">Retrait</a>
                                      <%} %>
                                         
                                  </td>


                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

                            </div>

                          <div class="col-12 col-md-6">
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Enseignants Appartient</h3>

						
                     <table class="table" style="margin-top:100px">
                          <thead class="table-dark">
                            <tr>
							   <th scope="col">ID</th>                           
                              <th scope="col">Nom / Prenom</th>
                              <th scope="col">Specialité</th>
                              <th scope="col">Semestre</th>
                              
                              
                             
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach (var e in listeEnseignantsAff)
                              {%>
                                <tr>
                                  
                                  <td><%=e.IdEns%>         </td>
                                  <td><%=e.FullNameEns%> </td>
                                  <td><%=e.SpeEns%>         </td> 
                                  <td><%=e.IdSem%>         </td> 
                                   

                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

                            </div>


                        <div class="col-12 mt-5 mb-5">
                            <div class="row">
                                <div class="col-6  text-center">
                                 <asp:Button ID="btnSuivantEns" runat="server" CssClass="btn btn-primary" Text="Suivant" OnClick="btnSuivantEns_Click"/>
                                </div>
                                <div class="col-6  text-center">
                                 <asp:Button ID="btnAnnulerEns" runat="server" CssClass="btn btn-danger" Text="Précédent" OnClick="btnAnnulerEns_Click"/>
                                </div>
                            </div>
                         </div>
                        

                   </div>

         
             <%
                 }
                 else if (Request.QueryString["do"].Equals("Affectation"))
                 {
                     try
                     {
                         if (Request.QueryString["idEns"] != null && Request.QueryString["idSem"] != null && Request.QueryString["idSec"] != null)
                         {
                             int idEns = int.Parse(Request.QueryString["idEns"]);
                             int idSem = int.Parse(Request.QueryString["idSem"]);
                             int idSec = int.Parse(Request.QueryString["IdSec"]);

                             if (ens_sec.countEns_SecByAll(idSec, idEns, idSem) == 0)
                                 ens_sec.addEns_Sec(new suiveStagaireProject.Models.Ens_Sec(idEns, idSec, idSem));


                             string currentUrl = Request.Url.ToString();

                             string newUrl = currentUrl.Replace($"do={ Request.QueryString["do"]}", $"do={"aORr"}");

                             // Redirect to the updated URL
                             Response.Redirect(newUrl);
                         }
                         else { Response.Redirect("404-page.aspx"); }

                     }
                     catch (Exception ex)
                     {
                         NotDoAlert.Text = "<span class='alert alert-danger'> Echèc d'affectation <span>";
                     }

                 }
                 else if (Request.QueryString["do"].Equals("Retrait"))
                 {

                     try
                     {
                         if (Request.QueryString["idEns"] != null && Request.QueryString["idSem"] != null && Request.QueryString["idSec"] != null)
                         {

                             int idEns = int.Parse(Request.QueryString["idEns"]);
                             int idSem = int.Parse(Request.QueryString["idSem"]);
                             int idSec = int.Parse(Request.QueryString["IdSec"]);

                             if (ens_sec.countEns_SecByAll(idSec, idEns, idSem) != 0)
                                 ens_sec.deleteEns_Sec(ens_sec.getEns_Sec(idEns, idSec, idSem));

                             string currentUrl = Request.Url.ToString();

                             string newUrl = currentUrl.Replace($"do={ Request.QueryString["do"]}", $"do={"aORr"}");

                             // Redirect to the updated URL
                             Response.Redirect(newUrl);

                         }
                         else
                         {
                             Response.Redirect("404-page.aspx");
                         }
                     }
                     catch (Exception ex)
                     {
                         NotDoAlert.Text = "<span class='alert alert-danger'> Echèc de reterait <span>";
                     }
                 }
                 else if (Request.QueryString["do"].Equals("aORrMod"))
                 {

                     suiveStagaireProject.Models.Module module = new suiveStagaireProject.Models.Module();
                     List<suiveStagaireProject.Models.Metier.detailsModSecSem> listeModSecSem = new List<suiveStagaireProject.Models.Metier.detailsModSecSem>();
                     
                     int idSem = int.Parse(Request.QueryString["idSem"]);
                     int idSec = int.Parse(Request.QueryString["idSec"]);
                     listeModSecSem = sec_mod_sem.getSecSemMod(idSec);

							%>
                    <div class="row">
                        <div class="col-12 col-md-6">
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Modules</h3>
                          
						<div class="row ">

                            <div class="col-12">
                                <asp:ListBox runat="server" ID="listBoxModAff" CssClass="mb-3 border-dark form-control bg-black text-white text-center " Rows="10"></asp:ListBox>
                            </div>
                            <div class="col-6 col-md-4">
                                <label class="form-label">Note Eliminatoire</label>
                                <input class="form-control" id="noteEl" runat="server" />
                            </div>
                            <div class="col-6 col-md-4">
                                 <label class="form-label">Coefficient</label>
                                 <input class="form-control" id="coef" runat="server" />
                            </div>
                            <div class="col-6 col-md-6 mt-4 mb-5">
                                 <asp:Button  ID="btnAffMod" CssClass="btn btn-success" Text="Affectation" OnClick="btnAffMod_Click" runat="server"/>
                            </div>
                            <div class="col-6 col-md-6 mt-4 mb-5">
                                 <asp:Button  ID="btnRetMod" CssClass="btn btn-danger" Text="Reterait" OnClick="btnRetMod_Click" runat="server"/>
                            </div>

						</div>
							

						</div>
                    

                          

                          <div class="col-12 col-md-6">
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Modules Appartient</h3>
                          
                     <table class="table mt-2" >
                          <thead class="table-dark">
                            <tr>
							   <th scope="col">ID</th>                           
                              <th scope="col">Libellé</th>
                              <th scope="col">Note Elim</th>
                              <th scope="col">Coenf</th>
                              <th scope="col">Semestre</th>
                              
                              
                             
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach (var sms in listeModSecSem)
                              {%>
                                <tr>
                                  
                                  <td><%=sms.IdMod%>         </td>
                                  <td><%=sms.LibMod%>        </td>
                                  <td><%=sms.NoteEli%>        </td>
                                  <td><%=sms.Coenf%>        </td>
                                  <td><%=sms.LibSem%>        </td> 
                                                           
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

                            </div>


                        <div class="col-12 mt-5 mb-5">
                            <div class="row">
                                <div class="col-6 text-center">
                                 <asp:Button ID="btnSuivantMod" runat="server" CssClass="btn btn-primary" Text="Terminer" OnClick="btnSuivantMod_Click"/>
                                </div>
                                <div class="col-6 text-center">
                                 <asp:Button ID="btnAnnulerMod" runat="server" CssClass="btn btn-danger" Text="Précédent" OnClick="btnAnnulerMod_Click"/>
                                </div>
                            </div>
                         </div>
                        

                   </div>

                     <%
                 }
                        
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
