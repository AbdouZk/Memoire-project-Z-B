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
               List<suiveStagaireProject.Models.CatalogeSection> listeCataloges = new List<suiveStagaireProject.Models.CatalogeSection>();
               List<suiveStagaireProject.Models.Metier.ListeSections> listeSections = new List<suiveStagaireProject.Models.Metier.ListeSections>();



               //tratement



               if (Request.QueryString["do"].Equals("addCat"))
               {%>
                        	<h2 class="badge bg-primary">Ajouter une formation au cataloge</h2>

                          <!-- Braches input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="dropDownBrachees">Branches Professionnelles</label>
                              <asp:DropDownList ID="dropDownBrachees" runat="server"></asp:DropDownList>
                            
                          </div>

                          <!-- code specialite input -->
                          <div class="form-outline mb-4">   
                              <label class="form-label" for="codeSpe">Code de spécialité</label>
                            <asp:TextBox ID="codeSpe" runat="server" CssClass="form-control"></asp:TextBox>
                            
                          </div>

                          <!-- intitulé de la specialite input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="intitulCat">Intitulé de la specialite</label>
                             <asp:TextBox ID="intitulCat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            
                          </div> 
                            
                           <!-- Filier exigees pour l'accès à la formation input -->
                          <div class="form-outline mb-4">
                             
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
                          <div class="form-outline mb-4">
                            
                            <label class="form-label" for="radioNivCat">Niveau formation</label>

                              <asp:RadioButtonList ID="radioNivCat" runat="server" CssClass="form-control">

                                  <asp:ListItem Value="4" Selected="True">Niveau 4</asp:ListItem>
                                  <asp:ListItem Value="5">Niveau 5</asp:ListItem>

                              </asp:RadioButtonList>

                          </div>


                          <!-- Submit button -->
                         
                           <asp:Button ID="btnAjouterCat" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Ajouter" OnClick="btnAjouterCat_Click" /> <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class="btn btn-secondary btn-block mb-4">Annuler</a>
                        
                                           
                            
                    <%}
                        else
if (Request.QueryString["do"].Equals("editCat"))
                        {%>
                           					<h2 class="badge bg-primary">Modifier Formation</h2>

                                        <!-- Braches input -->
                                          <div class="form-outline mb-4">
                                              <label class="form-label" for="bracheeEditCat">Branches Professionnelles</label>
                                               <asp:DropDownList ID="DropDownBracheeEditCat" runat="server"></asp:DropDownList>
                            
                                          </div>

                                          <!-- code specialite input -->
                                          <div class="form-outline mb-4">   
                                              <label class="form-label" for="editCatcodeSpe">Code de spécialité</label>
                                            <asp:TextBox ID="editCatcodeSpe" runat="server" CssClass="form-control"></asp:TextBox>
                            
                                          </div>

                                          <!-- intitulé de la specialite input -->
                                          <div class="form-outline mb-4">
                                              <label class="form-label" for="editCatintitulCat">Intitulé de la specialite</label>
                                             <asp:TextBox ID="editCatintitulCat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            
                                          </div> 
                            
                                           <!-- Filier exigees pour l'accès à la formation input -->
                                          <div class="form-outline mb-4">
                             
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
                                          <div class="form-outline mb-4">
                            
                                            <label class="form-label" for="radioEditCat">Niveau formation</label>

                                              <asp:RadioButtonList ID="radioEditCat" runat="server" CssClass="form-control">

                                                  <asp:ListItem Value="4">Niveau 4</asp:ListItem>
                                                  <asp:ListItem Value="5">Niveau 5</asp:ListItem>

                                              </asp:RadioButtonList>

                                          </div>
                                            <br />
                                                 <asp:Label ID="errorsEdit" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
                                                 <asp:Label ID="successEdit" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>
                                            <br />

                                          <!-- Submit button -->
                         
                                           <asp:Button ID="btnSaveEditCat" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Save" OnClick="btnSaveEditCat_Click" /> <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class="btn btn-secondary btn-block mb-4">Annuler</a>
                        
                                            
                            

                          
                                    <%}
                                        else
if (Request.QueryString["do"].Equals("deleteCat"))
                                        {
                                    %> 
        					        <h2 class="badge bg-primary">Supprimer une fromation </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer La  :<b><asp:Label ID="CatToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropCtaloge" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropCtaloge_Click"/> 
                            
                                                <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class="btn btn-secondary"> Annuler</a>

                                               </div>

                                    <%}
                                        else
if (Request.QueryString["do"].Equals("AllCat"))
                                        {
                                            listeCataloges = cataloge.getListeCatalogeSec();

                    %>
                        					<h2 class="badge bg-primary">Affichage de tous les fromation </h2>
            
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
              else
if (Request.QueryString["do"].Equals("AllSec"))
              {

                    %>
                                <h3 class=" d-block p-2 bg-info text-white"> Liste Des Sections</h3>

                     <table class="table">
                          <thead class="table-dark">
                            <tr>
                              <th scope="col"> Code Section </th>
                              <th scope="col">Libellé </th>
                              <th scope="col">Semestre</th>
                              <th scope="col">D / F</th>
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
                                  <td><%=s.DebSec%> <br /> <%=s.FinSec%></td>
                                  <td><%if (s.ModeGesSec.Equals("R")) { Response.Write("Résidentiel"); } else { Response.Write("Apprentissage"); }%></td>
                                  <td >
                                      <!-- Ajouter -->
                                      
                                      <a class="btn btn-primary " href="GestionSection.aspx?id=<%=Session["id"]%>&do=addSec&idSec=<%=s.IdSec%>">Ajouter</a>
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionSection.aspx?id=<%=Session["id"]%>&do=editSec&idSec=<%=s.IdSec%>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionSection.aspx?id=<%=Session["id"]%>&do=deleteSec&idSec=<%=s.IdSec%>">Supprimer</a>

                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

          <%                            

              }
              else
if (Request.QueryString["do"].Equals("addSec"))
                 
              {%>
                  					<h2 class="badge bg-primary">Ajouter Section</h2>

                      <!-- Cataloge input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="DropDownFormationAdd">Formation Professionnelles</label>
                              <asp:DropDownList ID="DropDownFormationAdd" runat="server"></asp:DropDownList>
                            
                          </div>

                          <!-- Numero de la section input -->
                          <div class="form-outline mb-4">   
                              <label class="form-label" for="numSectionAdd">Numéro de la section</label>
                            <asp:TextBox ID="numSectionAdd" runat="server" CssClass="form-control"></asp:TextBox>
                            
                          </div>

                          <!-- Semestre input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="DropDownListSemestreAdd">Semestre</label>
                              <asp:DropDownList ID="DropDownListSemestreAdd" CssClass="form-select" runat="server">

					                        <asp:ListItem Value="1" >SVP Sélectionne</asp:ListItem>  
					                        <asp:ListItem Value="1" >1ere Semestre</asp:ListItem>  
					                        <asp:ListItem Value="2" >2eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="3" >3eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="4" >4eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="5" >5eme Semestre</asp:ListItem>  
					                
			                          </asp:DropDownList>
                            
                          </div> 
                            
                           <!-- Mode Organisation input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="modeOrgAdd">Mode Organisation de la section</label>
                            <asp:TextBox ID="modeOrgAdd" runat="server" CssClass="form-control"></asp:TextBox>


                          </div> 

                            <!-- Mode Gestion input -->
                          <div class="form-outline mb-4">
                            
                            <label class="form-label" for="modeGesAdd">Mode Gestion</label>

                              <asp:RadioButtonList ID="RadioButtonmodeGesAdd" runat="server" CssClass="form-control">

                                  <asp:ListItem Value="R" Selected="True">Résidentielle</asp:ListItem>
                                  <asp:ListItem Value="A">Apprentissage</asp:ListItem>

                              </asp:RadioButtonList>

                          </div>

                         <!-- Date debut input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="debutForAdd">Date Début</label>
                            <input id="debutForAdd" name = "debutForAdd"  class="form-control" runat="server" type="Date" value="2023-09-28"/>


                          </div> 

                        <!-- Date fin input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="finForAdd">Date Fin</label>
                            <input id="finForAdd" name = "finForAdd"  class="form-control" runat="server" type="Date" value="2023-09-28"/>


                          </div> 

                        <!-- Tuteur Section input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="DropDowntuteurSecAdd">Tuteur Section</label>
                            <asp:DropDownList ID="DropDowntuteurSecAdd" runat="server"></asp:DropDownList>



                          </div> 
            


                          <!-- Submit button -->
                         
                           <asp:Button ID="btnAddSection" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Ajouter" OnClick="btnAddSection_Click" /> <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllSec" class="btn btn-secondary btn-block mb-4">Annuler</a>
                        
        <br />
        <br />

                  <%}else
if (Request.QueryString["do"].Equals("editSec"))
                  {%>
                    					<h2 class="badge bg-primary">Modifier Section</h2>

                      <!-- Cataloge input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="DropDownFormationEdit">Formation Professionnelles</label>
                              <asp:DropDownList ID="DropDownFormationEdit" runat="server"></asp:DropDownList>
                            
                          </div>

                          <!-- Numero de la section input -->
                          <div class="form-outline mb-4">   
                              <label class="form-label" for="numSectionEdit">Numéro de la section</label>
                            <asp:TextBox ID="numSectionEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            
                          </div>

                          <!-- Semestre input -->
                          <div class="form-outline mb-4">
                              <label class="form-label" for="DropDownListSemestreEdit">Semestre</label>
                              <asp:DropDownList ID="DropDownListSemestreEdit" CssClass="form-select" runat="server">

					                        <asp:ListItem Value="1" >SVP Sélectionne</asp:ListItem>  
					                        <asp:ListItem Value="1" >1ere Semestre</asp:ListItem>  
					                        <asp:ListItem Value="2" >2eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="3" >3eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="4" >4eme Semestre</asp:ListItem>  
					                        <asp:ListItem Value="5" >5eme Semestre</asp:ListItem>  
					                
			                          </asp:DropDownList>
                            
                          </div> 
                            
                           <!-- Mode Organisation input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="modeOrgEdit">Mode Organisation de la section</label>
                            <asp:TextBox ID="modeOrgEdit" runat="server" CssClass="form-control"></asp:TextBox>


                          </div> 

                            <!-- Mode Gestion input -->
                          <div class="form-outline mb-4">
                            
                            <label class="form-label" for="RadioButtonmodeGesEdit">Mode Gestion</label>

                              <asp:RadioButtonList ID="RadioButtonmodeGesEdit" runat="server" CssClass="form-control">

                                  <asp:ListItem Value="R" >Résidentielle</asp:ListItem>
                                  <asp:ListItem Value="A">Apprentissage</asp:ListItem>

                              </asp:RadioButtonList>

                          </div>

                         <!-- Date debut input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="debutForEdit">Date Début</label>
                            <input id="debutForEdit" name = "debutForEdit"  class="form-control" runat="server" type="Date" />

                          </div> 

                        <!-- Date fin input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="finForEdit">Date Fin</label>
                            <input id="finForEdit" name = "finForEdit"  class="form-control" runat="server" type="Date" />


                          </div> 

                        <!-- Tuteur Section input -->
                          <div class="form-outline mb-4">
                             
                            <label class="form-label" for="DropDowntuteurSecEdit">Tuteur Section</label>
                            <asp:DropDownList ID="DropDowntuteurSecEdit" runat="server"></asp:DropDownList>



                          </div> 
            


                          <!-- Submit button -->
                         
                           <asp:Button ID="btnEditSection" CssClass="btn btn-primary btn-block mb-4" runat="server" Text="Save" OnClick="btnEditSection_Click" /> 
                           <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllSec" class="btn btn-secondary btn-block mb-4">Annuler</a>
                           <div class="row">
                               <div class="col-12">
							        <div class="form-outline mb-4 ">

								
								        <a target="_blank"  class="btn btn-danger form-control" href="reports/ProcesVerbalSection.aspx?id=<%=Session["id"]%>&do=impression&idSec=<%=Request.QueryString["idSec"]%>">PV d'ouverture de la section</a>


							        </div>
						        </div>
                           </div>
                        
        <br />
        <br />

                  <%}else if (Request.QueryString["do"].Equals("deleteSec"))
                {    
                %> 
                            					<h2 class="badge bg-primary">Supprimer Section</h2>
                            <div class='alert alert-danger' role='alert'>
                                <h3> Voulez vous confirmer de supprimer La Section :<b><asp:Label ID="SecToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                <asp:Button ID="btnDropSection" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropSection_Click"/> 
                            
                                <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllSec" class="btn btn-secondary"> Annuler</a>

                                </div>

                <%
                }
                    else
                  {

                      NotDoAlert.Text = " <div class='alert alert-danger center' role='alert'> Vous pouvez pas naviguer à partir de l'URL </ div > ";

                  }


              } %>

      
        <!-- Alert / Heading page  -->
            <asp:Label ID="NotDoAlert" runat="server" Text=""></asp:Label>
        

       
    </div>



</asp:Content>
