<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="ListeStagiairesIncorpores.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm3" %>
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
        suiveStagaireProject.Models.Stagiaire stagiaire= new suiveStagaireProject.Models.Stagiaire();

       
        
        %>



                                                                          

                                <h3 class="col-12  text-center mt-3 mb-4 fw-bold">Liste des stagiaires incorpores </h3> 
    
    <div style="margin:5px">
                <table >
                    <tr >
                        <td style="width: 10%;">N° Inscription</td>
                        <td style="width: 16%;">Nom et Prenom</td>
                        <td style="width: 15%;">Date et Lieu Naissance</td>
                        <td style="width: 10%;">Prénom Père</td>
                        <td style="width: 15%;">Nom et Prénom Mère</td>
                        <td style="width: 20%;"> Adresse</td>
                        <td style="width: 10%;">Observation</td>
                    </tr>

                    <% foreach(var dStg in stagiaire.getStagiairesBySec(Request.QueryString["idSec"])){

                            %>

                        <tr>
                            <td><%=dStg.numInsc %></td>
                            <td><%=dStg.PersonnelInfo.nom+" "+dStg.PersonnelInfo.prenom %></td>
                            <td><%=dStg.PersonnelInfo.dateNai.Value.ToShortDateString()+" "+dStg.PersonnelInfo.lieuNai %></td>
                            <td><%=dStg.DetailsStagiaire.prenomPere %></td>
                            <td><%=dStg.DetailsStagiaire.nomMere+" "+dStg.DetailsStagiaire.prenomMere %></td>
                            <td><%=dStg.PersonnelInfo.adresse %></td>
                            <td><%=dStg.statusStg %></td>
                        </tr>

                    <%

                        } 
                       
                    %>

                </table>


                
                                 <div class="text-start mt-2" > Le responsable</div>
                                 <div class="text-end mt-2" > Le Directeur</div>




                                
            
        


        <div class="row justify-content-center no-print " > 

                                                            <span class=" col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="col-4 btn btn-secondary mt-3 mb-5 me-2" onclick=" window.history.back()" >Annuler</span>
        </div>

        

        </div>
                                                        


                                
                               



</asp:Content>
