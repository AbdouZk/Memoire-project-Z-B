<%@ Page Title="Gestion Comptes" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" 
    CodeBehind="GestionComptesPage.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm2"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <title>Gestion Comptes </title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container"> 
        
   

           <% if (Request.QueryString["do"] != null)
                    {
               
                   // declaration 
               
                   suiveStagaireProject.Models.User user=new suiveStagaireProject.Models.User();
                   List<suiveStagaireProject.Models.User> listeUsers=new List<suiveStagaireProject.Models.User>();

               
               
                   //tratement



                        if (Request.QueryString["do"].Equals("add"))
                        {%>
                            <h2 class="h3 bg-info text-center text-white p-2">Ajouter User</h2>
                                <div class="tab-pane addStagiaireBody">
		                        
	                                <div class="row">
	                                  <!-- Username input -->
	                                  <div class=" mb-3 col-12">
			                            <label class="form-label" for="registerName">UserName</label>
			                            <asp:TextBox ID="usernameAddUser" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
			                           
	                                  </div>
	
	                                  <!-- Password input -->
	                                  <div class=" mb-3 col-12">
                                          <label class="form-label" for="passAddUser">Password</label>
			                              <asp:TextBox ID="passAddUser" runat="server" CssClass="form-control" MaxLength="10"  TextMode="Password"></asp:TextBox>
	                                    
		
	                                  </div>

		                              <!--Confirmation Password input -->
	                                  <div class=" mb-4 col-12">
	                                    <label class="form-label" for="confPassAddUser">Confirmation Password</label>
			                            <asp:TextBox ID="confPassAddUser" runat="server" CssClass="form-control" MaxLength="10" TextMode="Password" ></asp:TextBox>
	                                    
                                          <br />
			  
				               			
	                                  </div>

		                            <%--  <!--Group ID  Select --%>
	                                  <div class=" mb-3 col-6">

	                                    <label class="form-label" for="DropDownGroupId">Group Users </label>
			                              <asp:DropDownList ID="DropDownGroupId" CssClass="form-select" runat="server">

					                            <asp:ListItem Value="-1">SVP Sélectionne</asp:ListItem>  
					                            <asp:ListItem Value="1">Admin </asp:ListItem>  
					                            <asp:ListItem Value="2">Chef Service</asp:ListItem>  
					                            <asp:ListItem Value="3">Agent Service</asp:ListItem>  
					                            <asp:ListItem Value="4">Enseignant</asp:ListItem>  
					  
			                              </asp:DropDownList>

             
	                                  </div> 

                                     <%--  <!--Trust ID  Select --%>
	                                  <div class=" mb-4 col-6">

	                                    <label class="form-label" for="DropDownTrustId">Activé / Disactiver</label>
			                              <asp:DropDownList ID="DropDownTrustId" CssClass="form-select" runat="server">

					                            <asp:ListItem Value="-1">SVP Sélectionne<</asp:ListItem>  
					                            <asp:ListItem Value="0">Disactiver </asp:ListItem>  
					                            <asp:ListItem Value="1">Activé</asp:ListItem>  
					                      
					  
			                              </asp:DropDownList>

             
	                                  </div> 

                                
	
	                                  <!-- Submit button -->
                                    
                                        <div class="col-6 text-center">
	                                  <asp:Button ID="btnAjouterUser" runat="server" CssClass="btn btn-primary" Text="Ajouter" OnClick="btnAjouterUser_Click" />
                                            </div>
                                       <div class="col-6 text-center">
	                                   <a href="GestionComptesPage.aspx?id=<%=Session["id"]%>&do=" class="btn btn-danger ">Annuler</a>
                                        </div>
                                    
                                    <br />
                                    <br />
                                     <asp:Label ID="errors" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
                                     <asp:Label ID="seccuss" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>

                                    </div>
	                              </div>
                            
                            
                        <%}
                        else
                        if (Request.QueryString["do"].Equals("edit"))
                        {
                        
                          
                            
                        %>               
                            
                            <h2 class="h3 bg-info text-center">Editer User</h2>
                            <div class="tab-pane addStagiaireBody">
		                        
	    
	                                  <!-- Username input -->
	                                  <div class=" mb-4">
			
			                            <asp:TextBox ID="usernameEditUser" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
			                            <label class="form-label" for="usernameEditUser">UserName</label>
	                                  </div>
	
	                                  <!-- Password input -->
	                                  <div class=" mb-4">

			                              <asp:TextBox ID="passwordEditUser" runat="server" CssClass="form-control" MaxLength="10"  TextMode="Password"></asp:TextBox>
	                                    <label class="form-label" for="passwordEditUser">New Password</label>
		
	                                  </div>

		                              <!--Confirmation Password input -->
	                                  <div class=" mb-4">
	
			                            <asp:TextBox ID="confPasswordEditUser" runat="server" CssClass="form-control" MaxLength="10" TextMode="Password" ></asp:TextBox>
	                                    <label class="form-label" for="confPasswordEditUser">Confirmation New Password</label>
                                          <br />
			  
				               			
	                                  </div>

		                            <%--  <!--Group ID  Select --%>
	                                  <div class=" mb-4">

	                                    <label class="form-label" for="DropDownGroupIdEditUser">Group Users </label>
			                              <asp:DropDownList ID="DropDownGroupIdEditUser" CssClass="form-select" runat="server">

					                            <asp:ListItem Value="-1" >SVP Sélectionne</asp:ListItem>  
					                            <asp:ListItem Value="1">Admin </asp:ListItem>  
					                            <asp:ListItem Value="2">Chef Service</asp:ListItem>  
					                            <asp:ListItem Value="3">Agent Service</asp:ListItem>  
					                            <asp:ListItem Value="4">Enseignant</asp:ListItem>  
					  
			                              </asp:DropDownList>

             
	                                  </div> 

                                     <%--  <!--Trust ID  Select --%>
	                                  <div class=" mb-4">

	                                    <label class="form-label" for="DropDownTrustIdEditUser">Activé / Disactiver</label>
			                              <asp:DropDownList ID="DropDownTrustIdEditUser" CssClass="form-select" runat="server">

					                            <asp:ListItem Value="-1"> SVP Sélectionne </asp:ListItem>  
					                            <asp:ListItem Value="0"> Disactiver </asp:ListItem>  
					                            <asp:ListItem Value="1"> Activé </asp:ListItem>  
					                      
					  
			                              </asp:DropDownList>

             
	                                  </div> 
                                <br />
                            
	                                  <!-- Submit button -->
	                                  <asp:Button ID="saveEditUser" runat="server" CssClass="btn btn-success " Text="Save" OnClick="saveEditUser_Click" />
                                        <a href="GestionComptesPage.aspx?id=<%=Session["id"]%>&do=" class="btn btn-secondary ">Annuler</a>
	    
                                <br />
                                <br />
                                     <asp:Label ID="errorsEdit" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
                                     <asp:Label ID="successEdit" runat="server" CssClass="alert alert-success" Visible="false" ></asp:Label>


	                              </div>
                            
                           
                        <%}
                        else
                        if (Request.QueryString["do"].Equals("delete"))
                        {

                        %> <div class='alert alert-danger' role='alert'>
                                    <h3> Voulez vous confirmer de supprimer user :<b><asp:Label ID="userToDrop" runat="server" Text=""> </asp:Label> </b></h3>
                                
                         
                                    <asp:Button ID="btnDropUser" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropUser_Click"/> 
                                
                                    <asp:Button ID="btnCancelDropUser" runat="server" CssClass="btn btn-secondary" Text="Annuler" OnClick="btnCancelDropUser_Click" /> 

                                   </div>

                        <%} 
                    
                        else
                        if (Request.QueryString["do"].Equals("active"))
                        {

                                user.activeUser(int.Parse(Request.QueryString["id"]));
                                Response.Redirect("GestionComptesPage.aspx?id="+Session["id"]+"&do=");

                        }
                        else
                        if (Request.QueryString["do"].Equals("disactive"))
                        {

                                user.desactiveUser(int.Parse(Request.QueryString["id"]));                                   
                                Response.Redirect("GestionComptesPage.aspx?id="+Session["id"]+"&do=");

                        }
                        else
                        {
                            
                                listeUsers=user.getUsers();
                           
             %> 

                            <h3 class=" d-block p-2 bg-info text-white p-2 text-center"> Liste Des Comptes</h3>

        
                         <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionComptesPage.aspx?id=<%=Session["id"]%>&do=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div> 
                        
                         <table class="table">
                              <thead class="table-dark">
                                <tr>
                                  <th scope="col">Id</th>
                                  <th scope="col">Username</th>
                                  <th scope="col">Role</th>
                                  <th scope="col">Date</th>
                                  <th scope="col">Status (Active/Disactive)</th>
                                  <th scope="col">Options</th>
                                </tr>
                              </thead>
                              <tbody>
                              <%foreach(var u in listeUsers)
                                {%>
                                    <tr>
                                      <th scope="row"><%Response.Write( u.id); %></th>
                                      <td><%Response.Write( u.username);%></td>
                                      <td><%                                    
                                              switch (u.groupID) 
                                              { case 0 :  Response.Write("Pas Actif"); break;
                                                case 1 :  Response.Write("Admin"); break;
                                                case 2 :  Response.Write("Chef Service"); break;
                                                case 3 :  Response.Write("Agent Service"); break;
                                                case 4 :  Response.Write("Enseignant"); break;
                                                default : Response.Write("Erreur"); break;
                                              }
                                          
                                      %></td>
                                      <td><%Response.Write( u.date.Value.ToShortDateString()); %></td>
                                      <td><% if(u.trustID==0){%><span class="badge bg-danger">Disactiver</span> <%}else{%><span class="badge bg-success">Activé</span> <%} %></td>
                                      <td>
                                          <!-- Active ou Disactiver -->
                                          <% if(u.trustID==1){%> <a class="btn btn-danger" href="GestionComptesPage.aspx?id=<%=u.id%>&do=disactive">Disactive</a>  <% }else{%>  <a class="btn btn-success" href="GestionComptesPage.aspx?id=<%=u.id%>&do=active">Activé</a>   <%   }   %>
                                          
                                          <!-- Editer -->
                                          <a class="btn btn-warning" href="GestionComptesPage.aspx?id=<%=u.id%>&do=edit">Editer</a>
                                          <!-- Supprimer -->
                                      
                                          <a class="btn btn-danger" href="GestionComptesPage.aspx?id=<%=u.id%>&do=delete">Supprimer</a>


                                      </td>

                                    
                                    
                                  
                                    </tr>

                             <% } %>               
                              </tbody>
                         
                         
                          </table>

              <%


                        }

              }
              else
              {

                 Response.Redirect("404-page.aspx");              
              }


               %>

      
            <!-- Alert / Heading page  -->
                <asp:Label ID="NotDoAlert" runat="server" Text=""></asp:Label>
        

       
    </div>

   
</asp:Content>
