﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionModules.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
     <title>Gestion Modules</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {
                suiveStagaireProject.Models.Module module = new suiveStagaireProject.Models.Module();

                if (Request.QueryString["do"]=="AllModules")
                {
                %>
                <h3 class="text-center bg-info text-white">Liste Des Modules</h3>
                         <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionModules.aspx?id=<%=Session["id"]%>&do=add-edit&opt=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div> 
                       <table class="table table-striped ">
                          <thead class="table-dark">
                            <tr>

                              <th scope="col">Id</th>
                              <th scope="col">Libellé</th>
                              <th scope="col">Options</th>
                              
                            </tr>
                          </thead>
                          <tbody>
                              <%foreach (var m in module.getModules()){ %>
                            <tr>
                                    <td><%=m.idModule %></td>
                                    <td><%=m.libelle %></td>
                                    <td >
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionModules.aspx?id=<%=Session["id"]%>&do=add-edit&idModule=<%=m.idModule%>&opt=edit">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionModules.aspx?id=<%=Session["id"]%>&do=delete&idModule=<%=m.idModule%>">Supprimer</a>

                                  </td>
                            </tr>
                              <%} %>
                          </tbody>
                        </table>
        <br />
        <br />
                <%
                }else if (Request.QueryString["do"] == "add-edit")
                {
                %>
                        <h3 class="bg-info text-white text-center"> Ajouter Module</h3>
                    <div class="row addStagiaireBody">
                        <div class="col-12">
                          <div class=" mt-3 mb-5">
                              <label class="form-label" for="DropDownFormationAdd">Libellé Module </label>
                              <input type="text" runat="server" id="libModule" required  class="form-control"/>
                            
                          </div>
                        </div>
                        <div class="col-4">
                          <div class=" mt-3 mb-2 text-center">
                             
                              <asp:Button runat="server" ID="btnAddModule"  CssClass=" btn btn-success" Text="Ajouter" OnClick="btnAddModule_Click" Visible="false"/>
                              <asp:Button runat="server" ID="btnSaveModule"  CssClass=" btn btn-success" Text="Save" OnClick="btnSaveModule_Click" Visible="false"/>

                            
                          </div>
                        </div>
                        <div class="col-4">
                          <div class=" mt-3 mb-2 text-center">
                             
                              <a class=" btn btn-secondary" href="GestionModules.aspx?id=<%=Session["id"] %>&do=AllModules">Annuler</a>
                            
                          </div>

                        </div>

                        
                    </div> 
                <%

                }
                 else if (Request.QueryString["do"] == "delete")
                {
                               %> 
        					        <h2 class="text-white text-center bg-primary">Supprimer un Module </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer cette Module  :<b><asp:Label ID="ModToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropModule" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropModule_Click"/> 
                            
                                                <a href="GestionModules.aspx?id=<%=Session["id"]%>&do=AllModules" class="btn btn-secondary"> Annuler</a>

                                               </div>

                                    <%

                }else if (Request.QueryString["do"] == "action")
                {

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
                             
                              <asp:Label runat="server" ID="msgModule" Text="" CssClass="alert alert-info" Visible="false" />
                            
                          </div>
                  </div>
            </div>
    </div>


</asp:Content>
