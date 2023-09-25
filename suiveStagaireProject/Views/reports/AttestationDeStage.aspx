﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="AttestationDeStage.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Attestation De Stage</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        suiveStagaireProject.Models.Stagiaire stagiaire= new suiveStagaireProject.Models.Stagiaire();
        suiveStagaireProject.Models.Metier.detailsStagiaire Dstag= new suiveStagaireProject.Models.Metier.detailsStagiaire();

        Dstag=stagiaire.detailsStagiaires(int.Parse(Request.QueryString["idStg"]));
        
        %>

    <div style="margin-top:0px" class="container">
        <div class="row"> 

                                        <h6 class=" col-12 text-center fw-bold mt-2">REPUBLIQUE ALGERIENNE DEMOCRATIQUE ET POPULAIRE</h6>
                                        <h6 class="col-12 text-center fw-bold mt-2">MINISTERE DE LA FORMATION ET DE L'ENSEIGNEMENT PROFESSIONNELS</h6>

                                <h6 class="col-12 text-start  mt-5 ">Direction de la formation professionnelle wilaya de Tizi Ouzou</h6>

                                <h6 class="col-12 text-start mt-2 mb-3"> ETABLISSEMENT : Hadni Said Oude Aissi</h6>
                                   


                                                                          <h3 class="col-12  text-center mt-4 mb-4 fw-bold">ATTESTATION DE STAGE</h3>
                                <p class="fs-5 mt-3">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp Je soussigné, Directeur de l'établissement certifie que le stagiaire inscrit sous </p> 
                                <p class="fs-5 mt-2" > le N°: <b><%=Dstag.NumInsc %></b></p>

                                <div class="col-6  mt-3">Prénom	 : <b><%=Dstag.Prenom %></b></div>
                                <div class="col-6 mt-3">Nom     :<b> <%=Dstag.Nom %></b></div>
                                
                                <div class="col-6  mt-3">Date et lieu de naissance :	<b><%=Dstag.DateNai.ToShortDateString() %></b> </div>
                                <div class="col-6  mt-3">À  :    <b>  <%=Dstag.LieuNai %>       </b>               </div>


                                <div class="col-12  mt-3">Adresse :   <b> <%=Dstag.Adresse %>  </b>                </div>
            
                                <div class="col-12  mt-3">Suit la formation dans la spécialité : <b><%=Dstag.LibForm %></b>	 </div>

                                <div class="col-6  mt-3">Niveau de qualification :<b> <% if(Dstag.NivForm=="4"){Response.Write("BT");}else{Response.Write("BTS");} %>  </b>    </div>
                                <div class="col-6  mt-3">Gestion de formation    :<b> <% if(Dstag.ModeGes=="R"){Response.Write("Résidentielle");}else{Response.Write("Apprantisage");} %> </b>   </div>



                                <div class="col-12  mt-3 mb-3">Année de formation : <b> <%=DateTime.Now.Year +" - "+(int.Parse(DateTime.Now.Year.ToString())+1) %>   </b>   </div>

                                <div class="col-6  mt-3 mb-5">Du : <b> <%=Dstag.DateOuv.ToShortDateString() %>  </b>      </div> <div class="col-6  mt-3">Au :  <b> <%=Dstag.DateFin.ToShortDateString() %> </b>     </div>
                               

                
                                 <div class="col-12 text-end mt-5 mb-4" > Visa du Directeur</div>




                                
            </div>
        <div class="col-12  mt-5 "><b>Observation :</b> il n'est délivré qu'un seul certificat durant le semestre.</div>


        <div class="row justify-content-center" > 

                                                            <span class="no-print  col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="no-print col-4 btn btn-secondary mt-3 mb-5 me-2" onclick="window.close()" >Annuler</span>
        </div>

</div>


                                                        


                                
                               



                                
            </asp:Content>
