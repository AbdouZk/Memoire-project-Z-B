<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="GestionStagiaires.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
     <title>Gestion Stagiaires</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div class="container "> 
        
        
            
        

       <% if (Request.QueryString["do"] != null)
           {

               // declaration 

               suiveStagaireProject.Models.Stagiaire stagiaire=new suiveStagaireProject.Models.Stagiaire();
               List<suiveStagaireProject.Models.Stagiaire> listeStagiaires=new List<suiveStagaireProject.Models.Stagiaire>();



               //tratement



               if (Request.QueryString["do"].Equals("add-edit"))
               {%>
                           <h2 class="d-block p-2 text-center text-white bg-info ">Ajouter Stagiaire</h2> 
          <div class="addStagiaireBody">
	
					
					<fieldset>
						<legend class="badge bg-info">Informations Personnel</legend>

					
                        <div class="row"> 
							
							<div class="col-12 ">
								<div class=" mb-4">
								
								<label for="numInscAdd" class="form-label">numero d'inscription : </label>
								
								<asp:TextBox ID="numInscAdd" CssClass="form-control " runat="server" MaxLength="4"></asp:TextBox>
								
								</div>
							</div>
							
                            <div class="col-6 ">
						
								<div class=" mb-4">
									<label class="form-label"  for="nomAdd">Nom : </label>
									<asp:TextBox ID="nomAdd" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
								</div>
							</div>
							<div class="col-6 text-end">
						
								<div class=" mb-4">
									<label class="form-label"  for="nomAdd"> اللقب  </label>
									<asp:TextBox ID="nomAddAr" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
								</div>
							</div>
							<div class="col-6 ">
								<div class=" mb-4">
									<label class="form-label"  for="prenomAdd">Prenom : </label>
									<asp:TextBox ID="prenomAdd" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
								</div>
							</div>
							<div class="col-6 text-end">
								<div class=" mb-4">
									<label class="form-label"  for="prenomAdd"> الاسم </label>
									<asp:TextBox ID="prenomAddAr" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
								</div>
							</div>


							<div class="col-6 col-md-6">
						
								<div class=" mb-4">
									<label class="form-label"  for="dateNaiAdd">Date Naissance : </label>
									<input type="date" name="dateNaiAdd" id="dateNaiAdd" runat="server" class="form-control">
								</div>

							</div>
							<div class="col-6 col-md-6">
								
								<div class=" mb-4">
									<label class="form-label" for="lieuNaisAdd">Lieu Naissance : </label>
									<asp:TextBox ID="lieuNaisAdd" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
			
								</div>
							</div>
							<div class="col-6 col-md-6 text-end">
								
								<div class=" mb-4">
									<label class="form-label" for="lieuNaisAdd"> مكان الميلاد </label>
									<asp:TextBox ID="lieuNaisAddAr" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
			
								</div>
							</div>


							<div class="col-12 ">
								<label class="form-label"  for="nat">Nationalité : </label>
								<div class=" row mb-4">
									<div class="col-6">
											
											<asp:RadioButtonList ID="radioGroupNat" runat="server" CssClass="form-check"  >
												<asp:ListItem Value="Algerian"  Selected="True" Text="Algérien" />
												<asp:ListItem Value="Etrangere" Text="Etrangère" />
											</asp:RadioButtonList>
									</div>
									<div class="col-6">
										
								
										<asp:TextBox  ID="natAdd" CssClass="form-control" runat="server" Enabled="false" MaxLength="20"></asp:TextBox>

									</div>
								</div>

							</div>


								<div class="col-12 col-md-6">
									<div class=" mb-4 btn-group p-2">
										<label class="form-label">Sexe: </label>
										
										<asp:RadioButtonList CssClass="form-check" ID="RadioButtonListSex" runat="server">
											
												
												<asp:ListItem Value="Homme" Selected="True"> Homme </asp:ListItem>
												<asp:ListItem Value="Femme"> Femme </asp:ListItem>
											

										</asp:RadioButtonList>
									
									</div>
								</div>
							
								<div class=" col-12">
									<div class=" mb-4 ">
										<label class="form-label">Situations Familiare : </label>

										<asp:DropDownList CssClass="form-control" runat="server" ID="dropDownSitFamAdd">
											<asp:ListItem Value="Célibataire">Célibataire</asp:ListItem>
											<asp:ListItem Value="Marié">Marié</asp:ListItem>
											<asp:ListItem Value="Divorcé">Divorcé</asp:ListItem>
										</asp:DropDownList>
									</div>
								</div>	
				
								<div class=" col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="emailAdd">Email : </label>
										<input class="form-control" type="email" name="emailAdd" id="emailAdd" runat="server" maxlength="50">
									</div>
								</div>
							
								<div class=" col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="telPerAdd">Téléphone Pérsonnelle : </label>
										<input class="form-control" type="text" name="telPerAdd" id="telPerAdd" runat="server" MaxLength="15">
									</div>
								</div>
							

						
							<div class=" col-12">
									<div class=" mb-4 ">
										<label class="form-label" for="img">Photo personnel: </label>
										<asp:FileUpload ID="FileUploadImgAdd" CssClass="form-control" runat="server" />
									</div>
							</div>
							
						</div>							
					</fieldset>
		
		

					<fieldset>	
						<legend class="badge bg-info">Informatons medicale</legend>
						<div class="row">

							<div class="col-12 col-md-6">
									<div class=" mb-4 btn-group p-2">
										<label class="form-label">Situation Médicale : </label>
										
										<asp:RadioButtonList CssClass="form-check" ID="RadioButtonListsitMed" runat="server">
											
												
												<asp:ListItem Value="1" Selected="True"> En santé </asp:ListItem>
												<asp:ListItem Value="0"> Handicape </asp:ListItem>
											

										</asp:RadioButtonList>
									
									</div>
								</div>

							<div class=" col-12 col-md-6">
									<div class=" mb-4 ">
										<label class="form-label">Group sanguin : </label>

										<asp:DropDownList CssClass="form-control" runat="server" ID="DropDownListSangAdd">
											<asp:ListItem Value="O+">O+</asp:ListItem>
											<asp:ListItem Value="O-">O-</asp:ListItem>
											<asp:ListItem Value="A+">A+</asp:ListItem>
											<asp:ListItem Value="A-">A-</asp:ListItem>
											<asp:ListItem Value="B+">B+</asp:ListItem>
											<asp:ListItem Value="B-">B-</asp:ListItem>
											<asp:ListItem Value="AB+">AB+</asp:ListItem>
											<asp:ListItem Value="AB-">AB-</asp:ListItem>
										</asp:DropDownList>
									</div>
								</div>	

							   



						</div>		


						
					</fieldset>
			
			
					<fieldset>

						<legend class="badge bg-info">Informatons familaire</legend>
						
									<div class="row">

										<div class="col-6 col-md-6">
											<div class=" mb-4 ">
												<label class="form-label" for="ppereadd">Prenom Père : </label>												
												<input type="text" class="form-control" name="ppereadd" id="ppereadd" runat="server" MaxLength="30">
											</div>
										</div>

										<div class="col-6 col-md-6">
											<div class=" mb-4 ">
												<label class="form-label" for="profPereadd">Profession du père  : </label>												
												<input type="text" class="form-control" name="profPereadd" id="profPereadd" runat="server" MaxLength="30">
											</div>
										</div>


										<div class="col-6 col-md-4">
											<div class=" mb-4 ">
												<label class="form-label" for="nmereadd">Nom Mère: </label>												
												<input type="text" class="form-control" name="nmereadd" id="nmereadd" runat="server" MaxLength="30">
											</div>
										</div>

										<div class="col-6 col-md-4">
											<div class=" mb-4 ">
												<label class="form-label" for="pmereadd">Prenom Mère: </label>												
												<input type="text" class="form-control" name="pmereadd" id="pmereadd" runat="server" MaxLength="30">
											</div>
										</div>

										<div class="col-12 col-md-4">
											<div class=" mb-4 ">
												<label class="form-label" for="profMereadd">Profession de la mère  : </label>												
												<input type="text" class="form-control" name="profMereadd" id="profMereadd" runat="server" MaxLength="30">
											</div>
										</div>

										<div class="col-6 col-md-6">
											<div class=" mb-4 ">
												<label class="form-label" for="adresseadd">Adresse : </label>												
												<input type="text" class="form-control" name="adresseadd" id="adresseadd" runat="server" MaxLength="30">
											</div>
										</div>
										
										<div class="col-6 col-md-6 text-end">
											<div class=" mb-4 ">
												<label class="form-label" for="adresseadd">  العنوان  </label>												
												<input type="text" class="form-control" name="adresseadd" id="adresseaddAr" runat="server" MaxLength="150">
											</div>
										</div>

										<div class="col-6 col-md-6">
											<div class=" mb-4 ">
												<label class="form-label" for="telTuteuradd">Téléphone Tuteur :  </label>												
												<input type="text" class="form-control" name="telTuteuradd" id="telTuteuradd" runat="server" MaxLength="15">
											</div>
										</div>

										<div class=" col-12">
											<div class=" mb-4 ">
												<label class="form-label">Situation familiare des parents : </label>

												<asp:DropDownList CssClass="form-control" runat="server" ID="DropDownListSitFamAdd">
													<asp:ListItem Value="Marié">Marié</asp:ListItem>
													<asp:ListItem Value="Divorcé">Divorcé</asp:ListItem>
													<asp:ListItem Value="Décédé">Décédé</asp:ListItem>
												</asp:DropDownList>
											</div>
										</div>	

									</div>
									

				
					</fieldset>

					<fieldset>

						<legend class="badge bg-info">Informations scolaire</legend>
								
                        <div class="row">

							<div class="col-12 col-md-6">
								<div class=" mb-4 ">
									<label class="form-label" for="derEtabFreadd">Dernier établissement fréquenté : </label>												
									<input type="text" class="form-control" name="derEtabFreadd" id="derEtabFreadd" runat="server" MaxLength="100">
								</div>
							</div>

							<div class="col-12 col-md-6">
								<div class=" mb-4 ">
									<label class="form-label" for="dropDownNivScolaireAdd">Niveau Scolaire : </label>												
									<asp:DropDownList ID="dropDownNivScolaireAdd" CssClass="form-select" runat="server">

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
							</div>



                        </div>
									
								
			
							
					</fieldset>
					
					<fieldset>
                        <legend class="badge bg-info">Informations De la Section</legend>
                        <div class="row">
								<div class="col-12">
									<div class=" mb-4 ">
										<label class="form-label" for="codeSecadd">Code Section : </label>												
										<asp:DropDownList ID="DropDownListcodeSecadd" CssClass="form-control" runat="server"></asp:DropDownList>
									</div>
								</div>

								<div class="col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="DropDownListEmp"> Apprantisage : </label>												
										<input type="checkbox" id="rORaStag" class="form-check" runat="server" style="width:40px"/>
										</div>
									</div>
								<div class="col-6">
									<div class=" mb-4 ">
										<label class="form-label" for="DropDownListEmp"> Employeurs : </label>												
										<asp:DropDownList ID="DropDownListEmp" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
									</div>
								</div>
								
						</div>


					</fieldset>			
					<div class="row">
						<div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<asp:Button Text="Ajouter" ID="btnAjouterStgAdd" runat="server" CssClass="btn btn-success  " OnClick="btnAjouterStgAdd_Click" Visible="false"/>
							    <asp:Button Text="Save" ID="btnsaveEditStg" runat="server" CssClass="btn btn-success " OnClick="saveEditStg_Click"  Visible="false"/>

							</div>
						</div>
						

						<div class="col-12 col-md-6 text-center">
							<div class=" mb-4 ">

								<spam  class="btn btn-danger" onclick="window.history.back()" >Annuler</spam>

							</div>
						</div>
					</div>
              <br />
              <br />
								

		</div>
                    <%}
                        else
			   if (Request.QueryString["do"].Equals("delete"))
                        {


                                    %> 
        					        <h2 class="badge bg-primary">Supprimer un Stagiaire </h2>

                                        <div class='alert alert-danger' role='alert'>
                                                <h3> Voulez vous confirmer de supprimer Le Stagiaire  :<b><asp:Label ID="StgToDrop" runat="server" Text=""> </asp:Label> </b></h3>

                                                <asp:Button ID="btnDropStagiaire" CssClass="btn btn-danger" runat="server" Text="Confirmer" OnClick="btnDropStagiaire_Click"/> 
                            
                                                <a href="GestionStagiaires.aspx?id=<%=Session["id"]%>&do=AllStg" class="btn btn-secondary"> Annuler</a>

                                               </div>

                                    <%

                                        }
						else
			   if (Request.QueryString["do"].Equals("details"))
                                        { suiveStagaireProject.Models.Stagiaire Dstag = new suiveStagaireProject.Models.Stagiaire();
                                            Dstag = stagiaire.getStagiaire(int.Parse(Request.QueryString["idStg"]));
											%>
						<section  style="">
						  <div class="container py-3 h-60">
							<div class="row d-flex justify-content-center align-items-center h-80">
							  <div class="col col-lg-12 mb-4 mb-lg-0">
								<div class="card mb-3" style="border-radius: .5rem;">
								  <div class="row g-0">
									<div class="col-md-4 gradient-custom text-center text-white"
									  style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
									  <img src="../Layout/images/Stagiaires/<%=Dstag.img %>" alt="Avatar" class="img-fluid my-5" style="width: 110px; height:120px;border-radius:20px" />
									  <h5><%=Dstag.PersonnelInfo.nom %> <%=Dstag.PersonnelInfo.prenom %></h5>
									  <p style="color:#22025c"><%=Dstag.Section.CatalogeSection.intituleSpe %></p>
									  
									</div>
									<div class="col-md-8">
										
										<div class="d-flex justify-content-center">
											
										</div>
									  <div class="card-body gradient-custom-body p-4">
										  <div class="row">
											<div style="text-align:center" class="col-12  align-content-center " style="text-transform:uppercase">republic algerien democratique et populaire</div>
											<div style="text-align:center" class="col-12  justify-content-center" style="text-transform:uppercase">Ministre de la Formation et de l’Enseignement Professionnels</div>
											<div style="text-align:center" class="col-12  justify-content-center" style="text-transform:uppercase">INSFP Hadni Said oude aissi tizi ouzou</div>
                                              <br />
											<p class="h4" style="text-align:center">Carte Stagiaire</p>
											</div>
										<h6>Information</h6>
										<hr class="mt-0 mb-4">
										<div class="row pt-1">
											 <div class="col-6 mb-3">
											<h6>Numéro d'inscription</h6>
											<p class="text-muted"><%=Dstag.numInsc %></p>
										  </div>
											 <div class="col-6 mb-3">
											<h6>Date /Lieu Naissance  </h6>
											<p class="text-muted"><%=Dstag.PersonnelInfo.dateNai.Value.ToShortDateString() %> <%=Dstag.PersonnelInfo.lieuNai %></p>
										  </div>
										  <div class="col-6 mb-3">
											<h6>Adresse</h6>
											<p class="text-muted"><%=Dstag.PersonnelInfo.adresse %></p>
										  </div>
										  <div class="col-6 mb-3">
											<h6>Phone</h6>
											<p class="text-muted"><%=Dstag.PersonnelInfo.telephone %></p>
										  </div>
											
										</div>
										
										<hr class="mt-0 mb-4">
										<div class="row pt-1">
										  <div class="col-6 mb-3">
											<h6>Niveau</h6>
											<p class="text-muted"><% if (Dstag.Section.CatalogeSection.niveauFormation.Equals("4")) { Response.Write("BT"); } else { Response.Write("<h6>BTS</h6>"); } %></p>
										  </div>
										  <div class="col-6 mb-3">
											<h6>Section</h6>
											<p class="text-muted"><%=Dstag.Section.codeSection %></p>
										  </div>
										</div>
										<div class="d-flex justify-content-center">
                                            <p> <%=" <b>Du :</b>"+  Dstag.Section.dateOuv.ToShortDateString() + "&nbsp;&nbsp;<b> Au :</b>" +Dstag.Section.dateFin.ToShortDateString() %></p>
										</div>
									  </div>
									</div>
								  </div>
								</div>
							  </div>
									<div class="col-12 col-md-6">
										<div class=" mb-4 ">

											<spam  class="btn btn-secondary form-control" onclick="window.history.back()" ><i class="fas fa-arrow-alt-circle-left"></i> Reteur</spam>

										</div>
									</div>
									<div class="col-6 col-md-3 ">
										<div class=" mb-4 ">

											<a target="_blank" class="btn btn-warning form-control" href="reports/AttestationDeStage.aspx?id=<%=Session["id"]%>&do=impression&idStg=<%=Dstag.id %>"><i class="fas fa-info-circle"></i>Fiche de scolarite </a>

										</div>
									</div>
								   <div class="col-6 col-md-3 ">
										<div class=" mb-4 ">

											<a target="_blank" class="btn btn-warning form-control" href="reports/AttestationDeStageAr.aspx?id=<%=Session["id"]%>&do=impression&idStg=<%=Dstag.id %>"><i class="fas fa-info-circle"></i> شهادة مدرسية </a>

										</div>
									</div>
							</div>
						  </div>
						</section>

                        <%}
                            else
               if (Request.QueryString["do"].Equals("AllStg")){

                                if (Request.QueryString["searchStg"] != null) { listeStagiaires = stagiaire.getStagiaires(Request.QueryString["searchStg"]); }
                                else
                                { listeStagiaires = stagiaire.getStagiaires(); }


							%>
                          <h3 class=" d-block p-2 bg-info text-white text-center"> Liste Des Stagiaires</h3>


						<div class="row justify-content-end">
                            <div class="col-8 col-md-4 text-end">
							  <div class="">
								<input type="search" id="searchStg" class="form-control mb-2 mt-5" placeholder="Recharher" runat="server"/>
								
							  </div>
							  </div>
							 <div class="col-4 col-md-2 text-end">
							  <asp:Button ID="btnsearchStg" CssClass="btn btn-success mb-2 mt-5" runat="server" Text="Recharcher" OnClick="btnsearchStg_Click">	</asp:Button>
							</div>
							

						</div>

						<!-- Ajouter -->  
                        <div class="text-end mb-3 mt-3">
							
                              <a class="btn btn-primary " href="GestionStagiaires.aspx?id=<%=Session["id"]%>&do=add-edit&opt=add">Ajouter <i class="fa fa-plus fa-lg"></i></a>
                        

                        </div> 
                     <table class="table">
                          <thead class="table-dark">
                            <tr>
							  <th scope="col">IMG</th>
                              <th scope="col">N°_Inscription</th>
                              <th scope="col">Nom / Prenom</th>
                              <th scope="col">Date Naissance</th>
                              <th scope="col">Section</th>
                              
                              <th scope="col" style="width:400px">Options</th>
                            </tr>
                          </thead>
                          <tbody>
                          <%foreach(var s in listeStagiaires)
                            {%>
                                <tr>
                                  <th scope="row"><img src="../Layout/images/Stagiaires/<%=s.img %>" width="30" height="30" /></th>
                                  <td><%=s.numInsc%></td>                                 
                                  <td><%=s.PersonnelInfo.nom +"  "+s.PersonnelInfo.prenom%> </td>
                                  <td><%=s.PersonnelInfo.dateNai.Value.ToShortDateString()%> </td>
                                  <td><%=s.Section.codeSection%> </td>
                                  
                              
                                  <td>
                                     
                                      <!-- Detalis -->
                                      <a  class="btn btn-warning" href="GestionStagiaires.aspx?id=<%=Session["id"]%>&idStg=<%=s.id%>&do=add-edit&opt=edit">Details</a>
                                      <!-- Supprimer -->  
                                      <a  class="btn btn-danger" href="GestionStagiaires.aspx?id=<%=Session["id"]%>&idStg=<%=s.id%>&do=delete">Supprimer</a> 
									  <!--  Carte  --> <br /> 
                                      <a style="width:220px" class="btn btn-secondary mt-2"  href="GestionStagiaires.aspx?id=<%=Session["id"]%>&idStg=<%=s.id%>&do=details">Carte</a>


                                  </td>

                                    
                                    
                                  
                                </tr>

                         <% } %>               
                          </tbody>
                         
                         
                      </table>

         


						 <%}
						

          }
          else
          {

			 Response.Redirect("404-page.aspx");		              
          }


           %>

      
        <!-- Alert / Heading page  -->
            <asp:Label ID="NotDoAlert" runat="server" Text=""></asp:Label>
        

       
    </div>
    <br />
    <br />

	 <script>
        
         var inputField = document.getElementById("ContentPlaceHolder1_natAdd");
         var toggleButton2 = document.getElementById("ContentPlaceHolder1_rORaStag");
         var toggleButton1 = document.getElementById("ContentPlaceHolder1_radioGroupNat_1");
         var toggleButton0 = document.getElementById("ContentPlaceHolder1_radioGroupNat_0");
         var checkFiled = document.getElementById("ContentPlaceHolder1_DropDownListEmp");
         

        // Add a click event listener to the button Radio natAdd 
        toggleButton1.addEventListener("click", function() {
			
            inputField.disabled = !inputField.disabled;
		});

		toggleButton0.addEventListener("click", function () {
			
            inputField.disabled = !inputField.disabled;
		});

         toggleButton2.addEventListener("click", function () {

			 checkFiled.disabled = !checkFiled.disabled;
         });
     </script>

</asp:Content>
