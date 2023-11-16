<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="ReleveNotes.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
      
         table{
             
         }
         td {
            padding :5px;
            border:1px solid;
            text-align:center;
            font-size:12px;
            width:auto;
         }
        th{
            border:1px solid;
            text-align:center;
            font-size:11px;
            width:auto;

        }
        hr {
            margin:2px -2px;
            height:2px;
            border:solid 1px;
        }
        .borderless{
            border:none;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    
    <%
        suiveStagaireProject.Models.Stagiaire stg= new suiveStagaireProject.Models.Stagiaire();
        suiveStagaireProject.Models.Section sec= new suiveStagaireProject.Models.Section();
        suiveStagaireProject.Models.Exam exm = new suiveStagaireProject.Models.Exam();
        suiveStagaireProject.Models.Note note = new suiveStagaireProject.Models.Note();

        int i=0;
        string codeSec=Request.QueryString["codeSec"];
        suiveStagaireProject.Models.Stagiaire s= stg.getStagiaire(int.Parse(Request.QueryString["idStg"]));
        decimal? total = 0;
        decimal? totalR = 0;
        int? coef = 0;
        bool ratt = false;
        bool rattG = false;
        decimal? moy =  0;
        decimal? moyR = 0;
        decimal? moyGenR =0;
        decimal? moyGenS = 0;

        %>       

  

    <div  class="container">
        <div class="row"> 

                                        <h5 class=" col-12 text-center fw-bold mt-1">REPUBLIQUE ALGERIENNE DEMOCRATIQUE ET POPULAIRE</h5>
                                        <h6 class="col-12 text-center fw-bold ">MINISTERE DE LA FORMATION ET DE L'ENSEIGNEMENT PROFESSIONNELS</h6> 
                                        <h6 class="col-12 text-center fw-bold ">INSTITUT NATIONAL SPECIALISE DE FORMATION PROFESSIONELLE</h6> 
                                        <h6 class="col-12 text-center fw-bold ">HADNI SAID OUED-AISSI TIZI-OUZOU</h6> 

            <div class="col-12 text-start  mt-1 "><b>Sous Direction Des Etudes Et Des Stages</b></div>
            <div class="col-6 text-start">N° &nbsp &nbsp &nbsp /SIOAIP/SDES/<%=DateTime.Now.Year %></div> <div class="col-6 text-end">Oued-Aissi, le <%=DateTime.Now.ToShortDateString() %></div>

            <div class="col-12 mt-2 text-center">
                                                        <span class=" text-uppercase p-2 " style="width:200px; border:1px solid"><b>Releve de notes semestriel</b></span>

            </div>
                                        <h6 class="col-12 text-end  mt-2  border-1 p-1">Spécialité :<b> <%=s.Section.CatalogeSection.Branchee.libileBrache +"\\"+s.Section.CatalogeSection.intituleSpe %></b> </h6>
            <div class="col-12">
                <div class="row">
                    <div class="col-6 ">
                         <h6 class="col-12 text-start   ">Nom : <b> <%=s.PersonnelInfo.nom %></b></h6>
                         <h6 class="col-12 text-start  mt-1 ">Prenom : <b> <%=s.PersonnelInfo.prenom %></b> </h6>
                         <h6 class="col-12 text-start  mt-1 ">Né (e) le : <b> <%=s.PersonnelInfo.dateNai.Value.ToShortDateString() %></b>  &nbsp &nbsp &nbsp à : <b> <%=s.PersonnelInfo.lieuNai %></b> </h6>
                        </div>
                    <div class="col-6">
                                                 <h6 class="col-12 text-end  mt-2 ">Niveau de qualification :<b> <% if(s.Section.CatalogeSection.niveauFormation==5){Response.Write("Technicien Suprérieur");}else{Response.Write("Technicien");} %></b> </h6>
                                                 <h6 class="col-12 text-end  mt-2 ">Promotion :<b> <%=s.Section.codeSection.Substring(s.Section.codeSection.Length-1) %></b> </h6>

                        </div>
                </div>
            </div>

            <div class="col-12">
                                        <h4 class="col-12 text-center mb-2 ">SEMESTRE <b> <%=s.Section.Semestre.saison %></b> </h4>

                </div>

                                       
                                
                                        <table>
                                            <thead>
                                            <tr >
                                                <th>N°</th>
                                                <th >Module</th>
                                                <th colspan="2" class="text-center ">
                                                    <table class="borderless w-100">
                                                        <tr class="">
                                                            <td colspan="2" style="border-top: none ;border-left: none ;border-right: none ;" > Moyenne Semestrielle /20 </td>
                                                        </tr> 
                                                        <tr class="" >
                                                            <td style="border:none"> Avant Rattrapage</td>
                                                            <td style="border-bottom: none ;border-right: none ;"> Aprés Rattrapage</td>
                                                        </tr>
                                                    </table>
                                                   
                                                     
                                                </th>
                                                
                                                <th style="width:50px">Coef</th>
                                                <th style="width:50px">Note Eliminatoire</th>
                                                <th>Observations</th>

                                            </tr>
                                            </thead>
                                            <tbody>
                                                <%   moyGenR = note.getMoynneGenR(s);
                                                     moyGenS = note.getMoynneGenS(s);
                                                 %>
                                            <%foreach(var e in exm.GetExamaBySec(codeSec)){i++;
                                                    ratt = false;
                                                    moy =  note.GetMoyenByExm_stg_S(e.idExamen, s.id);
                                                    moyR = note.GetNote( s.id,e.idExamen, "R");


                                                    if (moy<e.noteEli || (moy<10 && moyGenS<10) ) { ratt = true; rattG = true; }
                                                    %>
                                                <tr>

                                                    <td><%=i %></td>
                                                    <td><b><%=e.Seance.Module.libelle %></b></td>
                                                    <td><b><%=moy.ToString().Substring(0,Math.Min(5,moy.ToString().Length)) %></b></td>
                                                    <%total=total+(moy*e.coef); %>
                                                    <%totalR=totalR+(moyR*e.coef); %>
                                                    <td><% if (ratt && moyR!=0) { %> <b><%=moyR.ToString().Substring(0,Math.Min(5,moyR.ToString().Length)) %></b>  <% } else { %> &nbsp &nbsp<%="  /  " %>&nbsp &nbsp<% } %>   </td>
                                                    <td><%=e.coef %></td>
                                                    <% coef=coef+e.coef ;%>
                                                    <td><%=e.noteEli %></td>
                                                    <td><%=" " %></td>

                                                </tr>

                                            <%      ratt = false;
                                                } %>
                                               
                                             </tbody>
                                            
                                                <tr >
                                                    <td colspan="2" ><b> Moyenne Générale du Semestre Avant Rattrapage </b></td>
                                                    <td colspan="2"><b><%=moyGenS.ToString().Substring(0,Math.Min(5,moyGenS.ToString().Length)) %> </b></td>
                                                    <td colspan="3" class="borderless"> <b>La Sous Direction des Etude et des Stages</b></td>
                                                </tr>
                                                <tr >
                                                    <td colspan="2" ><b> Moyenne Générale du Semestre Aprés Rattrapage </b></td>
                                                    <td colspan="2"> <% if (rattG) { %> <b><%=moyGenR.ToString().Substring(0,Math.Min(5,moyGenR.ToString().Length)) %></b>  <% } else { %> &nbsp &nbsp<%="  /  " %>&nbsp &nbsp<% } %>   </td>
                                                    <td colspan="3" class="borderless"></td>

                                                   
                                                </tr>
                                                <tr >
                                                    <td colspan="4" ><b> Décision du jury : <%if(total/coef>=10){Response.Write("Admis(e)");}else{Response.Write("Ajourné(e)");} %> </b></td>
                                                    <td colspan="3" class="borderless"></td>
                                                   
                                                </tr>

                                                <% total=0;    coef=0; %>
                                            
                                        </table>
                                                                          
                                

                                
                
                                 <div class="col-12 text-start mt-5" > <b>NB</b>: il n'est délivré qu'un seul exemplaire du présent document</div>




                                
            </div>


        <div class="row justify-content-center" > 

                                                            <span class="no-print  col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="no-print col-4 btn btn-secondary mt-3 mb-5 me-2" onclick="window.history.back()" >Annuler</span>
        </div>

</div>
</div>
</asp:Content>
