<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionEnseignants.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
     <title>Gestion Enseignant</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {
                suiveStagaireProject.Models.Enseignant enseignant=new suiveStagaireProject.Models.Enseignant();
                List<suiveStagaireProject.Models.Metier.ListeEnseignant> listeEnseignants=new List<suiveStagaireProject.Models.Metier.ListeEnseignant>();

              if (Request.QueryString["do"] == "add-edit")
                {%>
		 
					<h2 class="d-block p-2 text-center bg-info ">Ajouter Enseignant</h2>
                    <div class="addStagiaireBody">
	
					
					<fieldset>
						<legend class="badge bg-info">Informations Personnel</legend>

					
                        <div class="row"> 
							
							
                            <div class="col-6 ">
						
								<div class=" mb-4">
									<label class="form-label"  for="nomAdd">Nom : </label>
									<asp:TextBox ID="nomAdd" CssClass="form-control" runat="server"></asp:TextBox>
								</div>
							</div>
							<div class="col-6 ">
								<div class=" mb-4">
									<label class="form-label"  for="prenomAdd">Prenom : </label>
									<asp:TextBox ID="prenomAdd" CssClass="form-control" runat="server"></asp:TextBox>
								</div>
							</div>
							


							<div class="col-6 ">
						
								<div class=" mb-4">
									<label class="form-label"  for="dateNaiAdd">Date Naissance : </label>
									<input type="date" name="dateNaiAdd" id="dateNaiAdd" runat="server" class="form-control">
								</div>

							</div>
							<div class="col-6 ">
								
								<div class=" mb-4">
									<label class="form-label" for="lieuNaisAdd">Lieu Naissance : </label>
									<asp:TextBox ID="lieuNaisAdd" CssClass="form-control" runat="server"></asp:TextBox>
			
								</div>
							</div>


								<div class="col-12 ">
									<div class=" mb-4 btn-group">
										<label class="form-label">Sexe: </label>
										
										<asp:RadioButtonList CssClass="form-check" ID="RadioButtonListSex" runat="server">
											
												
												<asp:ListItem Value="Homme" Selected="True"> Homme </asp:ListItem>
												<asp:ListItem Value="Femme"> Femme </asp:ListItem>
											

										</asp:RadioButtonList>
									
									</div>
								</div>
															
				
								<div class=" col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="emailAdd">Email : </label>
										<input class="form-control" type="email" name="emailAdd" id="emailAdd" runat="server">
									</div>
								</div>
							
								<div class=" col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="telPerAdd">Téléphone Pérsonnelle : </label>
										<input class="form-control" type="text" name="telPerAdd" id="telPerAdd" runat="server">
									</div>
								</div>

							<div class="col-12 ">
											<div class=" mb-4 ">
												<label class="form-label" for="adresseadd">Adresse : </label>												
												<input type="text" class="form-control" name="adresseadd" id="adresseadd" runat="server">
											</div>
							</div>
							

						
							
							
						</div>							
					</fieldset>
					<fieldset>

                        <div class="row">
							<div class="col-12 col-md-6 ">
											<div class=" mb-4 ">
												<label class="form-label" for="filiereAdd">Filière : </label>												
												<input type="text" class="form-control" name="filiereAdd" id="filiereAdd" runat="server">
											</div>
							</div>
							<div class="col-12 col-md-6">
						
								<div class=" mb-4">
									<label class="form-label"  for="dateDebutAdd">Date Début de travaille : </label>
									<input type="date" name="dateDebutAdd" id="dateDebutAdd" runat="server" class="form-control">
								</div>

							</div>
							
                        </div>

					</fieldset>
		
		
			
					<div class="row">

						<div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<a  class="btn btn-danger " href="GestionEnseignants.aspx?id=<%=Session["id"]%>&do=AllEns"><i class="fas fa-arrow-alt-circle-left"></i> Reteur</a>

							</div>
						</div>

						<div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<asp:Button Text="Ajouter" ID="btnAjouterEnsAdd" runat="server" CssClass="btn btn-success  " OnClick="btnAjouterEnsAdd_Click" Visible="false"/>
								<asp:Button Text="Save" ID="btnSaveEns" runat="server" CssClass="btn btn-success  " OnClick="btnSaveEns_Click" Visible="false"/>

							</div>
						</div>

						
					</div>
              <br />
              <br />
								

		</div>

                <%}
			  else if (Request.QueryString["do"] == "AllEns")
                {
                    if (Request.QueryString["searchEns"] != null){
							listeEnseignants = enseignant.getListeEnseignantsSearch(Request.QueryString["searchEns"]); 
				    }
                    else
                    { listeEnseignants = enseignant.getListeEnseignants(); }


							%>
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Enseignants</h3>

						<div class="row justify-content-end">
                            <div class="col-8 col-md-4"">
							  <div class="">
								<input type="search" id="searchEns" class="form-control mb-2 mt-5" placeholder="Recharher" runat="server"/>
								
							  </div>
							  </div>
							 <div class="col-4 col-md-2">
							  <asp:Button ID="btnsearchEns" CssClass="btn btn-success form-control mb-2 mt-5" runat="server" Text="Recharcher" OnClick="btnsearchEns_Click">	</asp:Button>
							</div>
							

						</div>
                     <table class="table">
                          <thead class="table-dark">
                            <tr>
							  <th scope="col">ID</th>
                              <th scope="col">Specialité</th>
                              <th scope="col">Nom / Prenom</th>
                              <th scope="col">Date Début</th>
                              
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach(var e in listeEnseignants)
                            {%>
                                <tr>
                                  
                                  <td><%=e.IdEns%></td>                                 
                                  <td><%=e.Specialite%></td>                                 
                                  <td><%=e.Nom +"  "+e.Prenom%> </td>
                                  <td><%=e.DateDebut%> </td>
                                  
                              
                                  <td>
                                      <!-- Ajouter -->
          								  <a class="btn btn-primary" href="GestionEnseignants.aspx?id=<%=Session["id"]%>&idEns=<%=e.IdEns%>&do=add-edit&opt=add">Ajouter</a>
                                      <!-- Editer -->
                                      <a class="btn btn-warning" href="GestionEnseignants.aspx?id=<%=Session["id"]%>&idEns=<%=e.IdEns%>&do=add-edit&opt=edit">Edit</a>
                                      <!-- Supprimer -->  
                                      <a class="btn btn-danger" href="GestionEnseignants.aspx?id=<%=Session["id"]%>&idEns=<%=e.IdEns%>&do=delete">Supprimer</a> 
									  


                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

         


               <%

                }
              else if (Request.QueryString["do"] == "delete")
                {
				
						   
                        %> 
        				<h2 class="badge bg-primary">Supprimer un Enseignant </h2>

                            <div class='alert alert-danger' role='alert'>
                                    <h3> Voulez vous confirmer de supprimer Cette Enseignant  </h3>

                                    <asp:Button ID="btnDropEnseignant" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropEnseignant_Click"/> 
                            
                                    <a href="GestionEnseignants.aspx?id=<%=Session["id"]%>&do=AllEns" class="btn btn-secondary"> Annuler</a>

                                    </div>

                        <%
                }


            }
            else
            {
                  Response.Redirect("404-page.aspx");
            }

            %>
		  <div class="row">
                 <div class="col-6">
                          <div class=" mt-3 mb-4">
                             
                              <asp:Label runat="server" ID="msgEns" Text="" CssClass="alert alert-info" Visible="false" />
                            
                          </div>
                  </div>
            </div>
         <br />
         <br />


    </div>
</asp:Content>
