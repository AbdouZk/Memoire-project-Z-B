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
        List <suiveStagaireProject.Models.Metier.detailsStagiaire> Listestag= new List<suiveStagaireProject.Models.Metier.detailsStagiaire>();

        Listestag=stagiaire.listeStagiairesSection(int.Parse(Request.QueryString["idSec"]));
        
        %>



                                                                          

                                <h3 class="col-12  text-center mt-3 mb-4 fw-bold">Liste des stagiaires incorpores </h3> 
    
    <div class="">
                <table class="">
                    <tr >
                        <td style="width: 10%;">N° Inscription</td>
                        <td style="width: 16%;">Nom et Prenom</td>
                        <td style="width: 15%;">Date et Lieu Naissance</td>
                        <td style="width: 10%;">Prénom Père</td>
                        <td style="width: 15%;">Nom et Prénom Mère</td>
                        <td style="width: 20%;"> Adresse</td>
                        <td style="width: 10%;">Observation</td>
                    </tr>

                    <% foreach(var dStg in Listestag){

                            %>

                        <tr>
                            <td><%=dStg.NumInsc %></td>
                            <td><%=dStg.Nom+" "+dStg.Prenom %></td>
                            <td><%=dStg.DateNai.ToShortDateString()+" "+dStg.LieuNai %></td>
                            <td><%=dStg.PrenomPere %></td>
                            <td><%=dStg.Nom+" "+dStg.PrenomPere %></td>
                            <td><%=dStg.Adresse %></td>
                            <td>Admis</td>
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
