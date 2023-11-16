<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="NoteIpression.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Liste Stagiaires Incorpores</title>
    <style>
        table{
            width: 98%;
            border:1px solid;

        } 
        tr{
            border:1px solid;

        }
        td{
            border:1px solid;
            text-align:center;
            font-size:11px

        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <%
        suiveStagaireProject.Models.Note note= new suiveStagaireProject.Models.Note();
        suiveStagaireProject.Models.Stagiaire stagiaire= new suiveStagaireProject.Models.Stagiaire();
        suiveStagaireProject.Models.Exam exam= new suiveStagaireProject.Models.Exam();

       int idExm=int.Parse(Request.QueryString["idExm"]) ;
       string opt=(Request.QueryString["opt"]) ;
        
        %>

                 <div style="margin:10px">             

                                <h3 class="col-12  text-center mt-3 mb-4 fw-bold">Module : <%=exam.GetExma(idExm).Seance.Module.libelle %> <% if (opt == "S"){ %>(Synthèse)<% }else{ %>(Rattrapage) <%} %> </h3> 
                                                                                                                                               
                                <div class="col-12  text-start mt-2 mb-1 ">Section : <%=Request.QueryString["codeSec"] %> </div> 
                                <div class="col-12  text-start mt-2  ">coef : <%=exam.GetExma(idExm).coef %> </div> 
                                <div class="col-12  text-start mb-3 ">Note eliminatoire : <%=exam.GetExma(idExm).noteEli %> </div> 
     
    
                <table >
                    <tr >
                        
                        <td style="width: 16%;">Nom </td>
                        <td style="width: 16%;">Prenom</td>
                        <td style="width: 15%;">Date </td>     
                        <% if (opt == "S") { %>
                        <td style="width: 10%;"> E1</td>
                        <td style="width: 10%;"> E2</td>
                        <td style="width: 10%;"> Synthèse</td>
                        <% } else {%> 
                        <td style="width: 20%;"> Rattrapage </td>
                        <% }%>
                        <td style="width: 20%;">Observation</td>
                    </tr>

                    <%


                              if (opt == "S") { %>
                                    <%foreach (var n in note.getAllStgBySec((Request.QueryString["codeSec"])))
                                    { %>
                                <tr>

                                    <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.nom  %> </td>
                                    <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.prenom %> </td>
                                    <td><%=stagiaire.getStagiaire((int)n.stgID).PersonnelInfo.dateNai.Value.ToShortDateString() %> </td>

                                    <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "E1") %></td>
                                    <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "E2") %></td>
                                    <td><%=note.GetNote((int)n.stgID, int.Parse(Request.QueryString["idExm"]), "S") %></td>
                                   
                                   
                                    
                                    <td></td>
                                </tr>   
                                   <% }%>
                           <% }else if(opt=="R") {%> 
                                    <%foreach (var n in stagiaire.getStagiairesBySecR((Request.QueryString["codeSec"])))
                                        { if (note.GetMoyenByExm_stg_S(idExm, n.id) < 10)
                                            {%>
                                        <tr>

                                            <td><%=stagiaire.getStagiaire(n.id).PersonnelInfo.nom  %> </td>
                                            <td><%=stagiaire.getStagiaire(n.id).PersonnelInfo.prenom %> </td>
                                            <td><%=stagiaire.getStagiaire(n.id).PersonnelInfo.dateNai.Value.ToShortDateString() %> </td>

                                            <td><%=note.GetNote((int)n.id, int.Parse(Request.QueryString["idExm"]), "R") %></td>
                                    
                                            <td></td>
                                        </tr>   
                                        <%} 
                                     }%>
                     
                          
                             <%}%>

                </table>


                
                                 <div class="text-start mt-5" > Signature Enseignant ( <%=exam.GetExma(idExm).Seance.Enseignant.PersonnelInfo.nom+" "+exam.GetExma(idExm).Seance.Enseignant.PersonnelInfo.prenom %> )</div>
                                 




                                
            
        


        <div class="row justify-content-center no-print " > 

                                                            <span class=" col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="col-4 btn btn-secondary mt-3 mb-5 me-2" onclick=" window.history.back()" >Annuler</span>
        </div>

        

        </div>
                                                        


                                
                               



</asp:Content>