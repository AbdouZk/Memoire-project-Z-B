<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section >
        <img src="../Layout/images/HomePic.jpg" class="img-fluid" />
    </section>

    <section>
        <br />
        <br />
        <div class="container">

            <div class="row">

                

                <div class="col-12">

                    <center>

                        <h3>Formations</h3>
                        <p><b>INSFP Hadni Said Oude Aissi</b></p>
                        
                    </center>
                </div>

                
                <div class="col-md-4 formation">

                   <div class="card bg-dark text-white">

                        <img src="../Layout/images/INFDAM.jpg" class="img-fluid" alt="potfolio3">
                        <div class="card-content p-3">
                            <h3>Informatique </h3><h5>Développeur d'application multiplateformes</h5> 
                            <p> est un professionnel de l'informatique spécialisé dans la création d'applications logicielles qui peuvent fonctionner sur plusieurs plates-formes ou systèmes d'exploitation différents. Ces plates-formes peuvent inclure des systèmes d'exploitation mobiles tels qu'Android et iOS, des systèmes d'exploitation de bureau tels que Windows, macOS et Linux, ainsi que des navigateurs web.</p>                        </div>

                    </div>
                    
           
                </div>
                <div class="col-md-4 formation">

                   <div class="card bg-dark text-white">

                        <img src="../Layout/images/FroidFormation.jpg" class="img-fluid" alt="potfolio3">
                        <div class="card-content p-3">
                            <h3>Froid </h3><h5>installation et maintenance équipement froid et climatisation</h5> 
                            <p>Cela comprend la mise en place initiale de systèmes de climatisation et de réfrigération dans des bâtiments résidentiels, commerciaux ou industriels. L'installation peut impliquer la configuration des unités de climatisation, la connexion des conduites de réfrigération, l'installation de compresseurs et de ventilateurs, la mise en place de thermostats, ainsi que la mise en service initiale pour garantir que le système fonctionne correctement.</p>                       

                        </div>

                    </div>
                    
           
                </div>
                <div class="col-md-4 formation">

                   <div class="card bg-dark text-white">

                        <img src="../Layout/images/Telecom.jpg" class="img-fluid" alt="potfolio3">
                        <div class="card-content p-3">
                            <h3>Télécommunications </h3><h5>Télécommunications</h5> 

                            <p>Ce domaine englobe divers aspects de la communication à distance, y compris la transmission de données, la voix, la vidéo, et d'autres formes d'information à travers des réseaux de télécommunication.</p>                        
                            <p><b>Fondamentaux des Télécommunications  Réseaux de Télécommunications echnologies de Communication <br />
                                ect ...</b></p>
                        </div>

                    </div>
                    
               <br />
                    <br />
                </div>

                 <div class="col-12 text-center" id="Statistiques">
                    
                     <h3>Statistiques</h3>
                                <p><b>INSFP Hadni Said Oude Aissi</b></p>

                </div>

                <div class="col-12 stats-total ">
                    <div class="row">
                        
                        
                             <div class="col-12 col-md-4 stats-item bg-info">
                         <a href="GestionFormation.aspx?id=<%=Session["id"] %>&do=AllCat" class="text-white">
                             <h2>Nombre des Formation</h2> <i class="fas fa-laptop fa-lg"></i>

                             <asp:Label Text="" ID="nbrFormations"  Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" />
                         </a>
                            </div>
                         
                         <div class="col-12 col-md-4 stats-item bg-warning">
                         <a href="GestionSection.aspx?id=<%=Session["id"] %>&do=AllSec" class="text-white">

                             <h2>Nombre des Section</h2> <i class="fas fa-clipboard-list fa-lg"></i>

                             <asp:Label Text="" ID="nbrSections"  Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" />
                         </a>
                        </div>
                         <div class="col-12 col-md-4 stats-item bg-success">
                          <a href="GestionModules.aspx?id=<%=Session["id"] %>&do=AllModules" class="text-white">

                              <h2>Nombre des Module</h2> <i class="fas fa-book fa-lg"></i>

                             <asp:Label Text="" ID="nbrModules"  Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" />
                        </a>
                        </div>
                         <div class="col-12 col-md-4 stats-item bg-success d-block text-center" >
                        <a href="GestionStagiaires.aspx?id=<%=Session["id"] %>&do=AllStg" class="text-white">

                             <h2>Nombre des Stagiaires</h2> <i class="fas fa-user-graduate fa-lg"></i> 

                             <asp:Label Text="" ID="nbrStagiaires" Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" /> 

                             <h5>Filles <i class="fas fa-female"></i> &nbsp &nbsp  Etrangère <i class="fas fa-passport"></i> &nbsp &nbsp  Handicapé <i class="fas fa-wheelchair"></i></h5>

                             <asp:Label Text="" ID="nbrStaStats" runat="server" />
                            
                        </a>
                        </div>
                         <div class="col-12 col-md-4 stats-item bg-danger">
                           <a href="GestionEnseignants.aspx?id=<%=Session["id"] %>&do=AllEns" class="text-white">
                      
                              <h2>Nombre des Enseignants</h2> <i class="fas fa-user-tie fa-lg"></i>

                             <asp:Label Text="" ID="nbrEns"  Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" />
                            </a>
                        </div>
                         <div class="col-12 col-md-4 stats-item bg-primary">
                         <a href="GestionEmployeurs.aspx?id=<%=Session["id"] %>&do=AllEmp" class="text-white">
                        
                             <h2>Nombre des Employeurs</h2> <i class="fas fa-user-tie fa-lg"></i>

                             <asp:Label Text="" ID="nbrEmp"  Width="99%" Height="80" CssClass="d-flex justify-content-center align-items-center fs-3" runat="server" />
                            </a>
                        </div>
                        

                    </div>

                </div>
            
             <!-- start About -->
                 <div class="col-12">

                    <center id="About">
                         <h3 > Historique </h3>
                                <p><b>INSFP Hadni Said Oude Aissi</b></p>
                        <br />
                        <br />
                        <div class="row">

                            <div class="col-12 col-md-6">
                               <div class="image-About">  
                                
                                    <img src="../Layout/images/EntrerINSFP.jpg" class="img-fluid"   alt="about image">

                                </div>
                            </div>
                             <div class="col-12 col-md-6 text-start">
                                 <b >Historique </b>
                                 <p>&nbsp &nbsp &nbsp &nbsp Créé en tant que Centre de Formation des Adultes (CFA) datant de l'époque coloniale, la première partie de la branche architecturale a été introduite au début des années 1950 dans le cadre de la reconstruction de la France après sa dévastation pendant la Seconde Guerre mondiale monde.
                                    Après l'indépendance de l'Algérie, l'institution a été transformée en centre de formation continue professionnelle et par apprentissage (CFPA) pour diverses spécialités surtout dans les branches de la construction, de l'électricité, de la mécanique et de la technique administrative et le management.
                                    L'Institut National Professionnel de la Formation Professionnelle (INSFP) de Oued Aissi est un institut de formation à l'administration publique créé en tant qu'institution nationale dédiée formation professionnelle et régie par le décret n° 90-236 du 28 juillet 1990 arrêté n°12-125 du 19 mars 2012 portant statut type des instituts nationaux spécialisés de formation professionnelle.
                                 </p>

                            </div>

                        </div>
                    </center>
                     <br />
                     <br />
                </div>
               
       
            <!-- end About -->
                <hr />
            <!-- start Contact -->
               
                <div class="col-12 text-center" id="Contact">
                    
                     <h3>Contact </h3>
                                <p><b>INSFP Hadni Said Oude Aissi</b></p>

                </div>

                       

                <div class="col-12" >
                    <div class="text-end text-info">
                        
                        <h2 class=" d-inline p-2 text-bg-light ">INSFP Hadni Said Oude Aissi</h2>
                        <h5 class="text-bg-light">
                            <i class="fa fa-phone"></i> Tel/Fax : 026 41 40 94 
                            </h5>
                        <h5 class="text-bg-light">
                            <i class="fa fa-address-card"></i> Address: M4RC+4M6, N15, Irdjen 
                        </h5>
                        <p>Find us on social networks <i class="fab fa-facebook-square "style="color:dodgerblue"></i> <i class="fab fa-twitter-square"></i> <i class="fab fa-instagram-square" style="color:orangered"></i> </p>
                    </div>

                </div>
                   


                
                 <!-- end Contact -->

            </div>
        </div>
    </section>
 <br />
    <br />
   

</asp:Content>
