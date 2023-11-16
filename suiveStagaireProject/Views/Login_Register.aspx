<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Register.aspx.cs" Inherits="suiveStagaireProject.Views.Login_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

	 <!-- bootstrap css file  -->
    <link href="../Layout/css/bootstrap.css" rel="stylesheet" />
	    <link href="../Layout/css/bootstrap.css.map" rel="stylesheet" />


    <!-- fontawesome css file  -->
    <link href="../Layout/css/fontawesome.css" rel="stylesheet" />

    <!-- data tables css file  -->
    <link href="../Layout/css/jquery.dataTables.min.css" rel="stylesheet" />

    <!-- main css file  -->
    <link href="../Layout/css/mainStyle.css" rel="stylesheet" />


</head>
<body class="Log_Reg_Page">
    
<div class="content">

		<div>
			<div class="nav justify-content-center headerLogReg">

				<img src="../Layout/images/INSFP-LOGO-WHITE.jpg" />
				<h2>INSFP Hadni Said Oued Aissi _ Tizi-Ouzou </h2> <i class="fa fa-school fa-2x"> </i>
		 
			</div>
		</div>


    <form id="form1" runat="server">
       

			<div class="container">

				<div class="LogIn">
						
	
						<div class="">
							<div >
	
								<h2 class="text-center mb-5 p-3">Log in <i class="fas fa-sign-in-alt"></i></h2>
		

								<!-- user input -->

							  <div class=" mb-4" >
								  <label class="form-label" for="username">Nom d'utilisateur</label>
								<input id="usernameLogin" runat="server" class="form-control" maxlength="50" required="required" />
								
								  
							  </div>

							  <!-- Password input -->
							  <div class=" mb-4">
								  <label class="form-label" for="password">Mot de passe</label>
								<input id="passwordLogin" runat="server" class="form-control" type="password" maxlength="10" required="required"/>
								
							  </div>

							 
								<div class="text-center">
							  <!-- Submit button -->
							  <asp:Button ID="Button1" Width="250" runat="server" CssClass="btn btn-primary " Text="Login" OnClick="Button1_Click" />
								</div>
							   <br /> <br />
									<div class="">
			  
									 <asp:Label ID="errorLog" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
									</div>
	
					</div>
		 

			  				

						</div>
						<br />
						<br />
						
			
				</div>	

			</div>

		</form>
</div>




	<footer class="">
        <center> 
		<p>&copy All Right Reserved <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></p>
        </center>
    </footer>

    <script>
        history.pushState(null, null, document.URL);

        // Add a popstate event listener to prevent manual back navigation
        window.addEventListener('popstate', function () {
            history.pushState(null, null, document.URL);
        });
    </script>

	 <!-- bootstrap js file  -->
    <script src="../Layout/js/bootstrap.js"></script>

    <!-- jquery js file  -->
    <script src="../Layout/js/jqueryc.js"></script>

    <!-- fontawesome js file  -->
    <script src="../Layout/js/fontawesome.js"></script>

    <!-- data tables js file  -->
    <script src="../Layout/js/jquery.dataTables.min.js"></script>

    <!-- main script js file  -->
    <script src="../Layout/js/maisScript.js"></script>

</body>
</html>
