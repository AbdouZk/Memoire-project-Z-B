<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionBranches.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title>Branchees</title>
    <meta charset="utf-8"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        
    <div class="container">

        
            <div class="row">

            


   <% if (Request.QueryString["do"]!=null)
       {
           suiveStagaireProject.Models.Branchee branchee = new suiveStagaireProject.Models.Branchee();

           if (Request.QueryString["do"].Equals("add-edit"))
           {
                %>
                        
                    <div class="row addStagiaireBody">
                        <div class="col-6">
                          <div class=" mt-3 ">
                              <label class="form-label" for="libBranche">Libellé Branche </label>
                              <input type="text" runat="server" id="libBranche" required maxlength="50"  class="form-control"/>
                            
                          </div>  

                        </div>
                        <div class="col-6">
                            <div class=" mt-3 mb-5 text-end">
                                <label class="form-label" for="libBrancheAr">اسم الفرع </label>
                                <input type="text" runat="server" id="libBrancheAr" required maxlength="50"  class="form-control"/>
                            
                              </div>
                         </div>
                      
                        <div class="col-6 text-center">
                          <div class=" mt-3 mb-2">
                             
                              <asp:Button runat="server" ID="btnAddBranche"  CssClass=" btn btn-success " Text="Ajouter" OnClick="btnAddBranche_Click" Visible="false"/>
                              <asp:Button runat="server" ID="btnSaveBranche"  CssClass=" btn btn-success " Text="Save" OnClick="btnSaveBranche_Click" Visible="false"/>

                            
                          </div>
                        </div>
                        <div class="col-6 text-center">
                          <div class=" mt-3 mb-2">
                             
                              <a class=" btn btn-secondary text-center" href="GestionBranches.aspx?id=<%=Session["id"] %>&do=AllBranches">Annuler</a>
                            
                          </div>

                        </div>

                       

                        </div>
                 
                <%
       
           }
           else if (Request.QueryString["do"].Equals("delete"))
           {

                         %> 
        					        <h2 class="text-white text-center bg-primary">Supprimer une Branche </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer cette Branche  :<b><asp:Label ID="BraToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropBranche" CssClass="btn btn-danger text-center" runat="server" Text="Confirmer" OnClick="btnDropBranche_Click"/> 
                            
                                                <a href="GestionBranches.aspx?id=<%=Session["id"]%>&do=AllBranches" class="btn btn-secondary text-ce"> Annuler</a>

                                               </div>

                                    <%

           } else
           if (Request.QueryString["do"].Equals("AllBranches"))
           
           {

                     %>
                <h3 class="text-center bg-info text-white">Liste Des Branches</h3>
                         <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionBranches.aspx?id=<%=Session["id"]%>&do=add-edit&opt=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div>              
                       <table class="table text-center table-striped ">
                          <thead class="table-dark">
                            <tr>

                              <th scope="col">Id</th>
                              <th scope="col">Libellé</th>
                              <th scope="col">Options</th>
                              
                            </tr>
                          </thead>
                          <tbody>
                              <%foreach (var m in branchee.getListeBranchees()){ %>
                            <tr>
                                    <td><%=m.idBrache %></td>
                                    <td><%=m.libileBrache %> / <%=m.LibileBracheAr %></td>
                                    <td >
                                    
                                        <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionBranches.aspx?id=<%=Session["id"]%>&do=add-edit&idBranche=<%=m.idBrache%>&opt=edit">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionBranches.aspx?id=<%=Session["id"]%>&do=delete&idBranche=<%=m.idBrache%>">Supprimer</a>

                                  </td>
                            </tr>
                              <%} %>
                          </tbody>
                        </table>
                <%
                
             }
            else
            {
                Response.Redirect("404-page.aspx");

            }

      }else
      {
            Response.Redirect("404-page.aspx");

      }
   %>
              

          </div>
        <br />
        <asp:Label Text="" runat="server" ID="toAlert" Visible="false" />
        <br />
        <br />
    </div>

</asp:Content>
