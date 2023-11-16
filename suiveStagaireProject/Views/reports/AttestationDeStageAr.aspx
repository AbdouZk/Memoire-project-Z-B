<%@ Page Title="" Language="C#" MasterPageFile="~/Views/reports/ReporsMaster.Master" AutoEventWireup="true" CodeBehind="AttestationDeStageAr.aspx.cs" Inherits="suiveStagaireProject.Views.reports.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <title>Attestation De Stage AR</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%
        suiveStagaireProject.Models.Stagiaire stagiaire= new suiveStagaireProject.Models.Stagiaire();
        suiveStagaireProject.Models.Stagiaire Dstag= new suiveStagaireProject.Models.Stagiaire();

        Dstag=stagiaire.getStagiaire(int.Parse(Request.QueryString["idStg"]));
        
        %>

     <div style="margin-top:0px" class="container">
        <div class="row"> 

                                        <h6 class=" col-12 text-center fw-bold mt-2">الجمهوريه الجزائرية الديمقراطية الشعبية </h6>
                                        <h6 class="col-12 text-center fw-bold mt-2">وزارة التكوين والتعليم المهنيين</h6>

                                <h6 class="col-12 text-end  mt-5 ">مديرية التكوين المهني لولاية : تيزي وزو</h6>

                                <h6 class="col-12 text-end mt-2 mb-3"> مؤسسة التكوين : المعهد الوطني المتخصص في التكوين المهني هدني السعيد واد عيسي</h6>
                                   


                                                                          <h3 class="col-12  text-center mt-4 mb-4 fw-bold">شهادة مدرسية</h3>
                                <p class="fs-5 mt-3 text-end"> : (إن مـديـر(ة) المعـهـد يـشـهـد بـأن المتربص(ة) الـمـتـمـهـن (ة &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</p> 
                                

                                
                                <div class="col-6 mt-3 text-end">   اللقب : <b> <%=Dstag.PersonnelInfo.nomAr %></b></div>
                                <div class="col-6  mt-3 text-end"> الإسم : <b><%=Dstag.PersonnelInfo.prenomAr %></b> </div>
                                            
                                <div class="col-6  mt-3 text-end">   بــ : <b>  <%=Dstag.PersonnelInfo.lieuNaiAr %>       </b>                     </div>
                                <div class="col-6  mt-3 text-end">	 تاريخ و مكان الإزدياد  :<b><%=Dstag.PersonnelInfo.dateNai.Value.ToShortDateString() %></b> </div>


                                <div class="col-12  mt-3 text-end">  العنوان :  <b> <%=Dstag.PersonnelInfo.adresseAr %>  </b>              </div>
                                <div class="col-12  mt-3 text-end"><b> <%=Dstag.numInsc %>  </b>  : مسجل(ة) تحت رقم                </div>
            
                                <div class="col-12  mt-3 text-end">  ليتابع تكوينا في اختصاص  : <b><%if(Dstag.Section.CatalogeSection.niveauFormation==5){Response.Write("تقنى سامي "+Dstag.Section.CatalogeSection.Branchee.LibileBracheAr+"/خيار :"+Dstag.Section.CatalogeSection.intituleSpeAr);} %>  </b>	 </div>

                                <div class="col-12  mt-3 text-end">  نمط التكوين  : <b> <% if(Dstag.Section.modeGestionForm=='R'){Response.Write(" اقامي");}else{Response.Write("تمهيني");} %> </b> </div>
                                

                                <div class="col-6  mt-3 text-end"><b> <%=Dstag.Section.dateFin.ToShortDateString() %> </b> : الى     </div>
                                <div class="col-6  mt-3 mb-3 text-end">  مدة التكوين من : <b> <%=Dstag.Section.dateOuv.ToShortDateString() %>  </b> </div> 
                                

                                <div class="col-12  mt-3 mb-3 text-end"><b> <%=DateTime.Now.Year +" - "+(int.Parse(DateTime.Now.Year.ToString())+1) %>   </b> : السنة التكوينية    </div>

                                <div class="col-6  mt-3 text-end"><b><%=Dstag.PersonnelInfo.prenom %></b> : الاسم بالأحرف اللاتنية 	  </div>
                                <div class="col-6 mt-3 text-end"> <b> <%=Dstag.PersonnelInfo.nom %></b> : اللقب بالأحرف اللاتنية   </div>

                                <div class="col-12 text-end mt-5 mb-4 text-end" ><b><%=DateTime.Now.ToShortDateString() %> </b>: حررت بـواد عيسي في </div>
                                <div class="col-12 text-end mt-5 mb-5 text-center" > (إمضاء المدير(ة </div>




                                
            </div>
        <div class="col-12  mt-5 text-end">. لا تسلم إلا نسخة واحدة من هذه الشهادة  </div>


        <div class="row justify-content-center" > 

                                                            <span class="no-print  col-4 btn btn-primary mt-3 mb-5 me-2" onclick="window.print()">Imprimer</span>
                                                            <span class="no-print col-4 btn btn-secondary mt-3 mb-5 me-2" onclick="window.close()" >Annuler</span>
        </div>

</div>



</asp:Content>
