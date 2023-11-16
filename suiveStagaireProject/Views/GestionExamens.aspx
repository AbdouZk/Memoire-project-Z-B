<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionExamens.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title>Gestion Examen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {
                suiveStagaireProject.Models.Exam exam = new suiveStagaireProject.Models.Exam();

                if (Request.QueryString["do"]=="AllExamens")
                {
                    List<suiveStagaireProject.Models.Exam> listeExm= new List<suiveStagaireProject.Models.Exam>();

                    if (Request.QueryString["searchExm"]!=null && Request.QueryString["By"]!=null) { 
                        if (Request.QueryString["By"].Equals("ByMod"))
                        { 
                            listeExm=exam.GetExamaByMod(Request.QueryString["searchExm"]);

                        }else if (Request.QueryString["By"].Equals("BySection"))
                        {
                            listeExm=exam.GetExamaBySec(Request.QueryString["searchExm"]);

                        }else if (Request.QueryString["By"].Equals("ByProf"))
                        {
                             listeExm=exam.GetExamaByProf(Request.QueryString["searchExm"]);
                        }
                        else
                        {
                            listeExm=exam.GetExamas();
                        }
                    }else
                        {
                            listeExm=exam.GetExamas();
                        }

                %> 

                
                <h3 class="text-center bg-info text-white p-2">Liste Des Examens</h3>
                            <div class="row justify-content-end">
                              <div class="col-4 ">
                             <div class="row">
                                 <div class="col-6 mt-3 text-end">
                                    <spam class="   fw-bold">Recharche basé sur : </spam>
                                </div>
                                 <div class="col-6">
                                 <asp:DropDownList runat="server" ID="dropDownBy" CssClass="form-control mb-2 mt-3 bg-black text-white">
                                     <asp:ListItem Text="Module" value="ByMod"/>
                                     <asp:ListItem Text="Section" Value="BySection"/>
                                     <asp:ListItem Text="Prof" Value="ByProf" />
                                 </asp:DropDownList>
                                     </div>
                             </div>

                        </div>
                            <div class="col-6 col-md-4 text-end">
							 
								<input type="search" id="searchExm" class="form-control mb-2 mt-3" placeholder="Recharher" runat="server"/>
									 
							  </div>
							 <div class="col-3 col-md-2 text-end">
							  <asp:Button ID="btnsearchExm" CssClass="btn btn-success mb-2 mt-3" runat="server" Text="Recharcher" OnClick="btnsearchExm_Click">	</asp:Button>
							</div>
							

						</div>
                         <!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
                         <a  class="btn btn-primary " href="GestionSeances.aspx?id=<%=Session["id"]%>&do=AllSeances">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        </div> 
                       <table class="table table-striped ">
                          <thead class="table-dark">
                            <tr>

                              <th scope="col">Module</th>
                              <th scope="col">Section</th>
                              <th scope="col">Coefficient</th>
                              <th scope="col">Note Elim</th>

                              <th scope="col">Options</th>
                              
                            </tr>
                          </thead>
                          <tbody>
                              <%foreach (var m in listeExm){ %>
                            <tr>
                                    <td><%=m.Seance.Module.libelle %></td>
                                    <td><%=m.Seance.Section.codeSection %></td>
                                    <td><%=m.coef %></td>
                                    <td><%=m.noteEli %></td>
                                    
                                    <td >
                                      <!-- Editer -->

                                      <a class="btn btn-warning " href="GestionExamens.aspx?id=<%=Session["id"]%>&do=edit&idExm=<%=m.idExamen%>&codeSec=<%=m.Seance.idSec%>&idMod=<%=m.Seance.idMod %>">Editer</a>
                                      
                                      <!-- Supprimer -->                                    
                                      <a class="btn btn-danger " href="GestionExamens.aspx?id=<%=Session["id"]%>&do=delete&idExm=<%=m.idExamen %>&codeSec=<%=m.Seance.idSec%>&idMod=<%=m.Seance.idMod %>">Supprimer</a>

                                  </td>
                            </tr>
                              <%} %>
                          </tbody>
                        </table>
         <br />
         <br />
                <%
               
                }
                 else if (Request.QueryString["do"] == "delete")
                {
                               %> 
        					        <h2 class="text-white text-center bg-primary">Supprimer un Examen </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer l'examen de <b><asp:Label ID="ExmToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropExm" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropExm_Click" /> 
                            
                                                <a href="GestionExamens.aspx?id=<%=Session["id"]%>&do=AllExamens" class="btn btn-secondary"> Annuler</a>

                                               </div>

                                    <%

                }else if (Request.QueryString["do"] == "edit")
                {
                %>
                    <h3 class="bg-info text-white text-center"> Modifier Examen</h3>
                    <div class="row addStagiaireBody">
                        <div class="col-12 ">
                          <div class=" mt-3 mb-5 text-center">
                              <asp:Label class=" h3 p-2 bg-info text-white" runat="server" ID="examaInfo" >  </asp:Label>
                            
                          </div>

                        </div>

                       
                              
                              <div class="col-6 text-center">
                                  <label class="form-label" for="noteEli">Note Eliminatoire </label>
                                  <input type="text" id="noteEli" class="form-control-lg" runat="server"  />
                              </div>
                              <div class="col-6 text-center">
                                  <label class="form-label" for="coef">Coefficient</label>
                                  <input type="text" id="coef" class="form-control-lg" runat="server"  />
                              </div>
                          

                        <div class="col-6 text-end">
                          <div class=" mt-3 mb-2 ">
                             
                              <asp:Button runat="server" ID="btnSaveExm"  CssClass=" btn btn-success" Text="Save" OnClick="btnSaveExm_Click"/>

                            
                          </div>
                        </div>
                        <div class="col-6 text-start">
                          <div class=" mt-3 mb-2 ">
                             
                              <a class=" btn btn-secondary" href="GestionExamens.aspx?id=<%=Session["id"] %>&do=AllExamens">Annuler</a>
                            
                          </div>

                        </div>

                        
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
                             
                              <asp:Label runat="server" ID="msgModule" Text="" CssClass="alert alert-info" Visible="false" />
                            
                          </div>
                  </div>
            </div>
    </div>

</asp:Content>
