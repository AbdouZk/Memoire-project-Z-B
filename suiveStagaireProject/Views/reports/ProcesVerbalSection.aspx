<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="ProcesVerbalSection.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Proces Verbal d'ouverture de la section</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
      suiveStagaireProject.Models.Section section= new suiveStagaireProject.Models.Section();
        suiveStagaireProject.Models.Metier.detailsSection DSec= new suiveStagaireProject.Models.Metier.detailsSection();

        DSec=section.detailsSections(int.Parse(Request.QueryString["idSec"]));
        DSec.NbrFilles=section.nbrGirlsSection(int.Parse(Request.QueryString["idSec"]));
        DSec.Nbrhandicape=section.nbrHandicapeSection(int.Parse(Request.QueryString["idSec"]));
        DSec.Nbretrangere=section.nbrEtrangerSection(int.Parse(Request.QueryString["idSec"]));
        DSec.NbrStag=section.nbrStagSection(int.Parse(Request.QueryString["idSec"]));
        
        %>
    
    <div style="margin-top:0px" class="container">
        <div class="row"> 

                                        <h6 class=" col-12 text-center fw-bold mt-2">REPUBLIQUE ALGERIENNE DEMOCRATIQUE ET POPULAIRE</h6>
                                        <h6 class="col-12 text-center fw-bold mt-2">MINISTERE DE LA FORMATION ET DE L'ENSEIGNEMENT PROFESSIONNELS</h6>

                                <h6 class="col-12 text-start  mt-5 ">Direction de la formation professionnelle wilaya de Tizi Ouzou</h6>

                                <h6 class="col-12 text-start mt-2 mb-5"> ETABLISSEMENT : Hadni Said Oude Aissi</h6>
                                   


                                                                          <h3 class="col-12  text-center mt-5 mb-5 fw-bold e"><B class="text-uppercas">Proces Verbal d'ouverture de la section </B> (<% if(DSec.ModeGes=="R"){Response.Write("Résidentielle");}else{Response.Write("Apprantisage");} %>)</h3>
                                

                                <div class="col-6  mt-3">Numéro	 : <b><%=DSec.NumSec %></b></div>
                                <div class="col-6 mt-3">Date     :<b><%=DateTime.Now.ToShortDateString() %> </b></div>
                                

                               <div class="col-12  mt-3 mb-3">Spécialité :   <b> <%=DSec.LibFor %></b>                </div>

                                <div class="col-12  mt-3 mb-3">Mode d'organisation de la formation :   <b><%=DSec.ModeOrg %> </b>                </div>

                                <div class="col-12  mt-3 mb-3">Mode de gestion de la formation :   <b> <% if(DSec.ModeGes=="R"){Response.Write("Résidentielle");}else{Response.Write("Apprantisage");} %> </b>                </div>

                                <div class="col-6  mt-3 mb-3">Code de la section :	<b><%=DSec.CodeSec %></b> </div>
                                <div class="col-6  mt-3 mb-3">Niveau de qualification :<b>  <% if(DSec.NivSec=="4"){Response.Write("BT");}else{Response.Write("BTS");} %> </b>    </div>

                                <div class="col-6  mt-3 mb-3">Début de formation : <b><%=DSec.DebSec %>   </b>      </div>
                                <div class="col-6  mt-3 mb-3">Fin de formation :  <b><%=DSec.FinSec %> </b>     </div>
                                
            
                                <div class="col-12  mt-3">Nombre de stagiaires : <b><%=DSec.NbrStag +"  , Dont filles :"+DSec.NbrFilles+" , Dont handicapés : "+DSec.Nbrhandicape+" , Dont étrangers : "+DSec.Nbretrangere %></b>	 </div>

                                <div class="col-12  mt-3 mb-5">Tuteur de la section :<b> <%=DSec.TurtSec %> </b>    </div>
                                
                               
                               

                
                                 <div class="col-12 text-end mt-5 mb-4" > Le Directeur</div>




                                
            </div>
        


        <div class="row justify-content-center" > 

                                                            <span class="no-print  col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="no-print col-4 btn btn-secondary mt-3 mb-5 me-2" onclick="window.history.back()" >Annuler</span>
        </div>

</div>
</asp:Content>
