<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionFormation.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">

        
            <div class="row">

          
                


        <% if (Request.QueryString["do"]!=null)
            {
             suiveStagaireProject.Models.CatalogeSection cataloge=new suiveStagaireProject.Models.CatalogeSection();
                if (Request.QueryString["do"].Equals("addCat")) 
                {  %>
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
                            <asp:TextBox ID="codeSpe" runat="server" CssClass="form-control" maxlength="20" ></asp:TextBox>
                            
                          </div>

                          <!-- intitulé de la specialite input -->
                          <div class=" mb-4">
                              <label class="form-label" for="intitulCat">Intitulé de la specialite</label>
                             <asp:TextBox ID="intitulCat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" maxlength="150" ></asp:TextBox>
                            
                          </div> 
                             <!-- intitulé de la specialite Arab input -->
                          <div class=" mb-4  text-end">
                              <label class="form-label " for="intitulCat"> اسم التخصص </label>
                             <asp:TextBox ID="intitulCatAr" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" maxlength="150" ></asp:TextBox>
                            
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
                                    <a href="GestionFormation.aspx?id=<%=Session["id"]%>&do=AllCat" class=" btn-danger btn text-center">Annuler</a>
                                </div>
                                               

                            </div> 
                            <br />
                                    
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
                                           <!-- intitulé de la specialite input -->
                                          <div class=" mb-4  text-end">
                                              <label class="form-label" for="editCatintitulCat"> اسم التخصص </label>
                                             <asp:TextBox ID="editCatintitulCatAr" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            
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
                                               
                                         </div>
                                 <br /><br />
        
                            

                          
                                    <%
                }
                else if (Request.QueryString["do"].Equals("deleteCat"))
                {
                       %> 
        					<h2 class="badge bg-primary">Supprimer une fromation </h2>

                                <div class='alert alert-danger' role='alert'>
                                        <h3> Voulez vous confirmer de supprimer La  :<b><asp:Label ID="CatToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                        <asp:Button ID="btnDropCtaloge" CssClass="btn btn-danger text-center" runat="server" Text="Confirmer" OnClick="btnDropCtaloge_Click"/> 
                            
                                        <a href="GestionSection.aspx?id=<%=Session["id"]%>&do=AllCat" class="btn btn-secondary text-center"> Annuler</a>

                                </div>

                     <%

                } 
                else if (Request.QueryString["do"].Equals("AllCat")) 
                         { 
                  

                    %>
                        					
            
                    <h3 class=" d-block p-2 bg-info text-white text-center"> Liste Des Formations Existants </h3>
                      <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionFormation.aspx?id=<%=Session["id"]%>&do=addCat">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div> 
                     <table class="table text-center">
                          <thead class="table-dark">
                            <tr>
                              <th scope="col">Id</th>
                              <th scope="col">Braches professionnelles</th>
                              <th scope="col">Code specialite</th>
                              <th scope="col">Intitule de specialite</th>
                              <th scope="col">Niveau</th>
                              <th scope="col">Options</th>
                            </tr>
                          </thead>
                          <tbody>  

                          <%foreach (var c in cataloge.getListeCatalogeSec())
                              {%>
                                <tr>
                                  <th scope="row"><%=c.idCataloge%></th>
                                  <td><%=c.Branchee.libileBrache%></td>
                                  <td><%=c.codeSpe%></td>
                                  <td>
                                      <%=c.intituleSpe %>
                                      <br />
                                      <%=c.intituleSpeAr %>
                                  </td>
                                  <td><%=c.niveauFormation%></td>
                                  <td >
                            
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionFormation.aspx?id=<%=Session["id"]%>&do=editCat&idCat=<%=c.idCataloge%>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionFormation.aspx?id=<%=Session["id"]%>&do=deleteCat&idCat=<%=c.idCataloge%>">Supprimer</a>

                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

          <%       
                                           
                            
                   


                }else
                {
                    Response.Redirect("404-page.aspx");

                }

           }else
           {
                
                Response.Redirect("404-page.aspx");
           }%>
                
              
                <asp:Label Text="" ID="NotDoAlert" runat="server" Visible="false" />


          </div>
    <br />
    <br />
    </div>
</asp:Content>
