<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionSeances.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title>Gestion Seance</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {
                suiveStagaireProject.Models.Seance seance = new suiveStagaireProject.Models.Seance();
                suiveStagaireProject.Models.Exam exam = new suiveStagaireProject.Models.Exam();

                if (Request.QueryString["do"]=="AllSeances")
                {
                   List<suiveStagaireProject.Models.Seance> listeSeance= new List<suiveStagaireProject.Models.Seance>();

                    if (Request.QueryString["searchSeance"]!=null && Request.QueryString["By"]!=null) { 
                        if (Request.QueryString["By"].Equals("ByMod"))
                        { 
                            listeSeance=seance.GetSeancesByMod(Request.QueryString["searchSeance"]);

                        }else if (Request.QueryString["By"].Equals("BySection"))
                        {
                            listeSeance=seance.GetSeancesBySection(Request.QueryString["searchSeance"]);

                        }else if (Request.QueryString["By"].Equals("ByProf"))
                        {
                             listeSeance=seance.GetSeancesByProf(Request.QueryString["searchSeance"]);
                        }
                        else
                        {
                            listeSeance=seance.GetSeances();
                        }
                    }else
                        {
                            listeSeance=seance.GetSeances();
                        }

                %> 

          
        
                <h3 class="text-center bg-info text-white">Liste Des Seances</h3>

                 <div class="row justify-content-end">
                        <div class="col-4 ">
                             <div class="row">
                                 <div class="col-6 mt-3 text-end">
                                    <spam class="   fw-bold">Recharche basé sur : </spam>
                                </div>
                                 <div class="col-6">
                                 <asp:DropDownList runat="server" ID="dropDownBy" CssClass="form-control mb-2 mt-2 bg-black text-white">
                                     <asp:ListItem Text="Module" value="ByMod"/>
                                     <asp:ListItem Text="Section" Value="BySection"/>
                                     <asp:ListItem Text="Prof" Value="ByProf" />
                                 </asp:DropDownList>
                                     </div>
                             </div>

                        </div>
                            <div class="col-4"">
							 
								<input type="search" id="searchSeance" class="form-control mb-2 mt-2" placeholder="Recharher" runat="server"/>
								
							 
							  </div>
							 <div class="col-2 text-end">
							  <asp:Button ID="btnsearchSeance" CssClass="btn btn-success mb-2 mt-2" runat="server" Text="Recharcher" OnClick="btnsearchSeance_Click">	</asp:Button>
							</div>
							

						</div>

                         <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionSeances.aspx?id=<%=Session["id"]%>&do=add-edit&opt=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div> 
                <div class="row">
                    <div class="col-12">
                       <table class="table table-striped text-center">
                          <thead class="table-dark">
                            <tr>

                              <th scope="col">Id</th>
                              <th scope="col" >Module  </th>
                             
                              <th scope="col">Prof</th>
                              <th scope="col">Semestre</th>

                              <th scope="col">Options</th>
                              
                            </tr>
                          </thead>
                          <tbody>
                              <%foreach (var m in listeSeance){ %>
                            <tr>
                                    <td><%=m.idSeance %></td>
                                    <td><%=m.Module.libelle %></td>
                                    
                                    <td><%=m.Enseignant.PersonnelInfo.nom+" "+m.Enseignant.PersonnelInfo.prenom %></td>
                                    <td><%=m.Section.Semestre.saison %></td>
                                    <td >
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionSeances.aspx?id=<%=Session["id"]%>&do=add-edit&idSeance=<%=m.idSeance%>&opt=edit">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionSeances.aspx?id=<%=Session["id"]%>&do=delete&idSeance=<%=m.idSeance%>">Supprimer</a>

                                        <%if(exam.checkExm((int)m.idMod,m.idSec)){%> 

                                        <a class="btn btn-info "  href="GestionSeances.aspx?id=<%=Session["id"]%>&do=AllSeances&opt=addExm&idSeance=<%=m.idSeance%>" >Créer un Examen</a>
                                        
                                        <%}else{
                                          %><a class="btn btn-secondary text-black"  href="#" >Examen a été Créé</a>

                                          <%      }%>
                                        <!-- Creation des examan -->                                    

                                       
                                  </td>
                            </tr>
                              <%} %>
                          </tbody>
                        </table>
                    </div>
                </div>
         <br />
         <br />
                <% if(Request.QueryString["opt"]!=null){ %>
                <!-- Modal -->
                <div class="modal AddExmModal" id="AddExm"  aria-labelledby="Cree un examen" >
                  <div class="modal-dialog">
                    <div class="modal-content">
                      <div class="modal-header">
                        <div class="modal-title w-100 text-white bg-info p-2 text-center" id="Cree un examen">Créer un examen</div>
                        <a class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="window.history.back()"></a>
                      </div>
                      <div class="modal-body">
                       
                          <div class="row">
                              
                              <div class="col-6">
                                  <label class="form-label" for="noteEli">Note Eliminatoire </label>
                                  <input type="text" id="noteEli" runat="server"  />
                              </div>
                              <div class="col-6">
                                  <label class="form-label" for="coef">Coefficient</label>
                                  <input type="text" id="coef" runat="server"  />
                              </div>
                          </div>

                      </div>
                      <div class="modal-footer">
                        <a  class="btn btn-secondary" data-bs-dismiss="modal" onclick="window.history.back()">Annuler</a>
                        <asp:Button ID="btnCreationExm" CssClass="btn btn-primary" runat="server" OnClick="btnCreationExm_Click" Text="Ajouter"></asp:Button>
                      </div>
                    </div>
                  </div>
                </div>
                <%}
                }else if (Request.QueryString["do"] == "add-edit")
                {
                %>
                        
                     <h2 class="d-block p-2 text-center text-white bg-info ">Ajouter Seance</h2> 
                    <div class="row addStagiaireBody">


                        <div class="col-4">
                          <div class=" mt-3 mb-5">
                              <label class="form-label" for="dropDownMod">Libellé Module </label>
                              <asp:DropDownList ID="dropDownMod" CssClass="form-control" runat="server"> </asp:DropDownList>
                            
                          </div>
                        </div>
                        <div class="col-4">
                          <div class=" mt-3 mb-5">
                              <label class="form-label" for="dropDownSec">Code Section </label>
                              <asp:DropDownList ID="dropDownSec" CssClass="form-control" runat="server"> </asp:DropDownList>

                            
                          </div>
                        </div>
                        <div class="col-4">
                          <div class=" mt-3 mb-5">
                              <label class="form-label" for="dropDownProf">Nom Prof </label>
                              <asp:DropDownList ID="dropDownProf" CssClass="form-control" runat="server"> </asp:DropDownList>

                            
                          </div>
                        </div>

                        <div class="col-6 ">
                          <div class=" mt-3 mb-5">
                              <label class="form-label" for="dropDownProf">Type de la seance : </label>
                             <asp:DropDownList ID="DropDownTypeSeance" CssClass="form-control" runat="server"> 

                                 <asp:ListItem Text="Cour" Value="Cour" />
                                 <asp:ListItem Text="TD" Value="TD" />
                                 <asp:ListItem Text="TP" Value="TP" />

                             </asp:DropDownList>

                            
                          </div>
                        </div>
                         <div class="col-6 ">
                          <div class=" mt-3 mb-5">
                                <label class="form-label" for="volumeH">Volume Horaire : </label>
                                <input type="text" id="volumeH" runat="server" class="form-control" />
                        </div>
                        </div>


                        <div class="col-6">
                          <div class=" mt-3 mb-2 text-center">
                             
                              <asp:Button runat="server" ID="btnAddSeance"  CssClass=" btn btn-success" Text="Ajouter" OnClick="btnAddSeance_Click" Visible="false"/>
                              <asp:Button runat="server" ID="btnSaveSeance"  CssClass=" btn btn-success" Text="Save" OnClick="btnSaveSeance_Click" Visible="false"/>

                            
                          </div>
                        </div>
                        <div class="col-6">
                          <div class=" mt-3 mb-2 text-center">
                             
                              <a class=" btn btn-secondary" href="GestionSeances.aspx?id=<%=Session["id"] %>&do=AllSeances">Annuler</a>
                            
                          </div>

                        </div>

                        
                    </div> 
                <%

               
                } else if (Request.QueryString["do"] == "delete")
                {
                               %> 
        					        <h2 class="text-white text-center bg-primary">Supprimer un Module </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer   :<b><asp:Label ID="SeanceToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropSeance" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropSeance_Click"/> 
                            
                                                <a href="GestionSeances.aspx?id=<%=Session["id"]%>&do=AllSeances" class="btn btn-secondary"> Annuler</a>

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
                             
                              <asp:Label runat="server" ID="msgSeance" Text="" CssClass="alert alert-info" Visible="false" />
                            
                          </div>
                  </div>
            </div>
    </div>

</asp:Content>
