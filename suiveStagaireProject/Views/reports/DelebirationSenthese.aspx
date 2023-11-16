<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="DelebirationSenthese.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Deleberation des Sentheses</title>
     <style>
        table{
            width: 98%;
            border:1px solid;

        } 
        tr{
            border:1px solid;

        }

        td, th{
            border:1px solid;
            text-align:center;
            font-size:11px

        }
        hr {
            margin:2px -2px;
            height:2px;
            border:solid 1px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        suiveStagaireProject.Models.Stagiaire stg= new suiveStagaireProject.Models.Stagiaire();
        suiveStagaireProject.Models.Section sec= new suiveStagaireProject.Models.Section();
        suiveStagaireProject.Models.Exam exm = new suiveStagaireProject.Models.Exam();
        suiveStagaireProject.Models.Note note = new suiveStagaireProject.Models.Note();
        suiveStagaireProject.Models.Semestre semestre = new suiveStagaireProject.Models.Semestre();


        int i=0;
        string codeSec=Request.QueryString["codeSec"];
        string opt=Request.QueryString["opt"];
        decimal? total = 0;
        int? coef = 0;
        bool grey=false;
        string del;
        decimal? moy =  0;
        decimal? moyR = 0;
        decimal? Moy = 0;
        decimal? moyGenR =0;
        decimal? moyGenS = 0;
        string FinaleD = "";
        if (opt.Equals("DelebS")) { del="Synthèse"; } else {del="Rattrapage"; }
        int duree = sec.getAcutualSem(codeSec);

        if (stg.getStagiairesBySecR(codeSec).Count==0 && del=="Rattrapage")
        {
            del = "Finale";
        }

        switch (duree)
        {
            case 0 :
            case 1 :
            case 2 :
            case 3 :
            case 4 :
            case 5 :
            case 6 :semestre.editSemester((int)sec.getSection(codeSec).semestreId, "1");

                break;

            case 7 :
            case 8 :
            case 9 :
            case 10 :
            case 11 :
            case 12 :semestre.editSemester((int)sec.getSection(codeSec).semestreId, "2");

                break;

            case 13 :
            case 14 :
            case 15 :
            case 16 :
            case 17 :
            case 18 :semestre.editSemester((int)sec.getSection(codeSec).semestreId, "3");

                break;

            case 19 :
            case 20 :
            case 21 :
            case 22 :
            case 23 :
            case 24 :semestre.editSemester((int)sec.getSection(codeSec).semestreId, "4");

                break;

            case 25 :
            case 26 :
            case 27 :
            case 28 :
            case 29 :
            case 30 :semestre.editSemester((int)sec.getSection(codeSec).semestreId, "5");

                break;

            default: semestre.editSemester((int)sec.getSection(codeSec).semestreId, "5");
                break;
        }

        %>
  

    <div style="margin-top:0px" class="container">
        <div class="row"> 

                                        <h6 class=" col-12 text-center fw-bold mt-1">REPUBLIQUE ALGERIENNE DEMOCRATIQUE ET POPULAIRE</h6>
                                        <h6 class="col-12 text-center fw-bold mt-1">MINISTERE DE LA FORMATION ET DE L'ENSEIGNEMENT PROFESSIONNELS</h6>                                                                                       
                                        <h6 class="col-12 text-center  mt-2 text-uppercase">Résultats de délibération des évaluations semestrielle (<%=del %>)</h6>
                                                                <div class="text-end"> <%=DateTime.Now.ToString("MMMM")+" "+DateTime.Now.Year %>

                                         <p class="text-start">Spécialité : <%=sec.getSection(codeSec).CatalogeSection.Branchee.libileBrache+"\\"+sec.getSection(codeSec).CatalogeSection.intituleSpe %> 
                                             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp Section :  <%=codeSec %>
                                             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp Semestre : <%=sec.getSection(codeSec).Semestre.saison %>

                                         </p>
        </div>
        </div> 
        <%if (del.Equals("Synthèse") )
            { %>
                                        <table style="margin:0px">
                                            <tr>
                                                <th>N°</th>
                                                <th>Nom</th>
                                                <th>Prenom</th>
                                                <% foreach (var e in exm.GetExamaBySec(codeSec))
                                                    { %>
                                                <th style="width:100px">
                                                    <%=e.Seance.Module.libelle %> <hr />
                                                    Coef: <%=e.coef %> <hr />
                                                    Note elim: <%=e.noteEli %>
                                                </th>
                                                <%} %>
                                                <th>Total</th>
                                                <th style="width:30px">moyenne</th>
                                                <th>Décision des jury</th>

                                            </tr>
                                            
                                            <%foreach (var s in stg.getStagiairesBySec(codeSec))
                                                {
                                                    i++;
                                                     moyGenS = note.getMoynneGenS(s);
                                                    %>
                                              <tr>
                                                  <td><%=i %> </td>
                                                  <td><%=s.PersonnelInfo.nom %> </td>
                                                  <td><%=s.PersonnelInfo.prenom %> </td>



                                                  <% foreach (var e in exm.GetExamaBySec(codeSec))
                                                      {
                                                          moy = note.GetMoyenByExm_stg_S(e.idExamen, s.id);
                                                          if (moy < e.noteEli || moyGenS<10) { grey = true; }

                                                          %>
                                                        <td <% if (moy < e.noteEli || (grey && moy<10))
                                                            {%> class="grey-background" <%} %> >
                                                           <%=moy.ToString().Substring(0, Math.Min(5, moy.ToString().Length)) %>
                                                           <%total = total + (moy * e.coef); %>
                                                           <%coef = coef + e.coef; %>
                                                        </td>
                                                  <%}


                                                      %>
                                                  <td><%=total.ToString().Substring(0, Math.Min(6, total.ToString().Length)) %></td>
                                                  <td  <% if ( grey)
                                                      {%> class="grey-background" <%} %> ><%=moyGenS.ToString().Substring(0, Math.Min(5, moyGenS.ToString().Length)) %></td>
                                                  <td><%if ( grey) { Response.Write("Rattrapage"); stg.stgChangeStatus(s.id,"Rattrapage"); } else { Response.Write("Admis"); stg.stgChangeStatus(s.id,"Admis"); }  %>
                                                    <%if (Session["groupId"].ToString() != "4" && !grey)
                                                        { %>  <span class="no-print m-4"><a href="ReleveNotes.aspx?codeSec=<%=codeSec %>&idStg=<%=s.id %>">  <i class="fas fa-scroll fa-lg"></i> </a></span> <%} %>

                                                  </td>

                                              </tr>

                                            <%  total = 0; coef = 0; grey = false;
                                                } %>

                                        </table>
        <%}else if(del.Equals("Rattrapage") || del.Equals("Finale")) { %>
           
              <table style="margin:0px">
                                            <tr>
                                                <th>N°</th>
                                                <th>Nom</th>
                                                <th>Prenom</th>
                                                <% foreach (var e in exm.GetExamaBySec(codeSec))
                                                    { %>
                                                <th style="width:100px">
                                                    <%=e.Seance.Module.libelle %> <hr />
                                                    Coef: <%=e.coef %> <hr />
                                                    Note elim: <%=e.noteEli %>
                                                </th>
                                                <%} %>
                                                <th>Total</th>
                                                <th style="width:30px">moyenne</th>
                                                <th>Décision des jury</th>

                                            </tr>
                  <%List<suiveStagaireProject.Models.Stagiaire> listeStag = new List<suiveStagaireProject.Models.Stagiaire>();

                      if (del.Equals("Rattrapage"))
                      {
                          listeStag = stg.getStagiairesBySecR(codeSec);
                      } else
                      {
                         listeStag = stg.getStagiairesBySec(codeSec);

                      }
                  %>
                                            
                                            <%foreach (var s in listeStag)
                                                {
                                                    moyGenR = note.getMoynneGenR(s);
                                                    i++; 
                                                       %>
                                              <tr>
                                                  <td><%=i %> </td>
                                                  <td><%=s.PersonnelInfo.nom %> </td>
                                                  <td><%=s.PersonnelInfo.prenom %> </td>


                                                  <% foreach (var e in exm.GetExamaBySec(codeSec))
                                                      {
                                                          moyR = note.GetNote((int)s.id, e.idExamen, "R");
                                                          moy = note.GetMoyenByExm_stg_S(e.idExamen, s.id);

                                                          if (moyR > 0) { Moy = moyR; } else { Moy = moy; }

                                                          if (Moy < e.noteEli || moyGenR < 9+(1/2)) { grey = true; }

                                                          %>
                                                        <td <% if (Moy < e.noteEli || (grey && Moy<10))
                                                            {%> class="grey-background" <%} %> >
                                                           <%=Moy.ToString().Substring(0, Math.Min(5, Moy.ToString().Length)) %>
                                                           <%total = total + (Moy * e.coef); %>
                                                           <%coef = coef + e.coef; %>
                                                        </td>
                                                  <%}


                                                      %>
                                                  <td><%=total.ToString().Substring(0, Math.Min(6, total.ToString().Length)) %></td>
                                                  <td  <% if ( grey)
                                                      {%> class="grey-background" <%} %> ><%=(total / coef).ToString().Substring(0, Math.Min(5, (total / coef).ToString().Length)) %></td>
                                                  <td><%if (moyGenR < 9+(1/2) || grey) { Response.Write("Ajournée"); stg.stgChangeStatus(s.id,"Ajournee"); } else { Response.Write("Admis"); ; stg.stgChangeStatus(s.id,"Admis"); }  %> 
                                                      
                                                       <%if (Session["groupId"].ToString() != "4")
                                                        { %>  <span class="no-print m-4"><a href="ReleveNotes.aspx?codeSec=<%=codeSec %>&idStg=<%=s.id %>">  <i class="fas fa-scroll fa-lg"></i> </a> </span>
                                                        <%} %>

                                              </tr>

                                            <%  total = 0; coef = 0; grey = false;
                                                } %>

                                        </table>












            <%} %>
        <div style="margin-top:0px" class="container">
        <div class="row">                                                                
                                

                                
                
                                 <div class="col-12 text-end  mt-3" > Visa du Directeur</div>




                                
            </div>


        <div class="row justify-content-center" > 

                                                            <span class="no-print  col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="no-print col-4 btn btn-secondary mt-3 mb-5 me-2" onclick="window.history.back()" >Annuler</span>
        </div>

</div>
</div>

</asp:Content>
