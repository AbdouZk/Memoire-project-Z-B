<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionEmployeurs.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title>Employeurs</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {
                suiveStagaireProject.Models.Employeur employeur=new suiveStagaireProject.Models.Employeur();
                List<suiveStagaireProject.Models.Employeur> listeEmployeurs=new List<suiveStagaireProject.Models.Employeur>();

              if (Request.QueryString["do"] == "add-edit")
                {%>
		 
					<h2 class="d-block p-2 text-center bg-info ">Ajouter Employeur</h2>
                    <div class="addStagiaireBody">
	
					
					<fieldset>
						<legend class="badge bg-info">Informations d'employeur</legend>

					
                        <div class="row"> 
													
                            <div class="col-6 ">
						
								<div class=" mb-4">
									<label class="form-label"  for="nomEmp">Nom complet d'emplyeur: </label>
									<asp:TextBox ID="nomEmp" CssClass="form-control" runat="server"></asp:TextBox>
								</div>
							</div>
							<div class="col-6 ">
								<div class=" mb-4">
									<label class="form-label"  for="">Adresse : </label>
									<asp:TextBox ID="adresseEmp" CssClass="form-control" runat="server"></asp:TextBox>
								</div>
							</div>
							
							<div class="col-6 ">
						
								<div class=" mb-4">
									<label class="form-label"  for="dateNaiAdd">Status (Active/Désactive) : </label>
                                    <asp:DropDownList ID="dropDownStatusEmp" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Active"  Text="Active" />
                                        <asp:ListItem Value="Desactive" Text="Desactive" />
                                    </asp:DropDownList>
								</div>

							</div>
							

					</fieldset>
		
		
			
					<div class="row">

						

						<div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<asp:Button Text="Ajouter" ID="btnAjouterEmp" runat="server" CssClass="btn btn-success  " OnClick="btnAjouterEmp_Click" Visible="false"/>
								<asp:Button Text="Save" ID="btnSaveEmp" runat="server" CssClass="btn btn-success  " OnClick="btnSaveEmp_Click" Visible="false"/>

							</div>
						</div>
                        <div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<a  class="btn btn-danger " href="GestionEmployeurs.aspx?id=<%=Session["id"]%>&do=AllEmp"> Reteur</a>

							</div>
						</div>

						
					</div>
              <br />
              <br />
								

		</div>

                <%}
			  else if (Request.QueryString["do"] == "AllEmp")
                {
                    if (Request.QueryString["searchEmp"] != null){
							listeEmployeurs = employeur.GetEmployeurs(Request.QueryString["searchEmp"]); 
				    }
                    else
                    { listeEmployeurs = employeur.GetEmployeurs(); }


							%>
                          <h3 class=" d-block p-2 bg-info text-white"> Liste Des Employeurs</h3>
		
						<div class="row justify-content-end">
                            <div class="col-8 col-md-4"">
							  <div class="">
								<input type="search" id="searchEmp" class="form-control mb-2 mt-5" placeholder="Recharher" runat="server"/>
								
							  </div>
							  </div>
							 <div class="col-4 col-md-2">
							  <asp:Button ID="btnsearchEmp" CssClass="btn btn-success form-control mb-2 mt-5" runat="server" Text="Recharcher" OnClick="btnsearchEmp_Click">	</asp:Button>
							</div>
							

						</div>
				
										  <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionEmployeurs.aspx?id=<%=Session["id"]%>&do=add-edit&opt=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div>  


                     <table class="table">
                          <thead class="table-dark">
                            <tr>
							  <th scope="col">ID</th>
                              <th scope="col">Nom / Prenom</th>
                              <th scope="col">Adresse</th>
                              <th scope="col">Status</th>
                              
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach(var e in listeEmployeurs)
                            {%>
                                <tr>
                                  
                                  <td><%=e.idEpoloyeur%></td>                                 
                                  <td><%=e.Name%> </td>
                                  <td><%=e.Adresse%> </td>
                                  <td><%=e.status%> </td>
                                  
                              
                                  <td>
                        
                                      <!-- Editer -->
                                      <a class="btn btn-warning" href="GestionEmployeurs.aspx?id=<%=Session["id"]%>&idEmp=<%=e.idEpoloyeur%>&do=add-edit&opt=edit">Edit</a>
                                      <!-- Supprimer -->  
                                      <a class="btn btn-danger" href="GestionEmployeurs.aspx?id=<%=Session["id"]%>&idEmp=<%=e.idEpoloyeur%>&do=delete">Supprimer</a> 
									  


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
        				<h2 class="badge bg-primary">Supprimer un Employeur </h2>

                            <div class='alert alert-danger' role='alert'>
                                    <h3> Voulez vous confirmer de supprimer Cet Employeur  </h3>

                                    <asp:Button ID="btnDropEmp" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropEmp_Click"/> 
                            
                                    <a href="GestionEmployeurs.aspx?id=<%=Session["id"]%>&do=AllEmp" class="btn btn-secondary"> Annuler</a>

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
                             
                              <asp:Label runat="server" ID="msgEmp" Text="" CssClass="alert alert-info" Visible="false" />
                            
                          </div>
                  </div>
            </div>
         <br />
         <br />


    </div>

</asp:Content>
