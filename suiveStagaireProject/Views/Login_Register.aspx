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
							<div class="tab-pane fade show active " id="pills-login" role="tabpanel" aria-labelledby="tab-login">
	
								<h2>Log in</h2>
		

								<!-- user input -->

							  <div class=" mb-4" >
								<asp:TextBox ID="usernameLog" runat="server" CssClass="form-control" ></asp:TextBox>
								<label class="form-label" for="username">
								  Username</label>
							  </div>

							  <!-- Password input -->
							  <div class=" mb-4">
								<asp:TextBox ID="passwordLog" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
								<label class="form-label" for="password">Password</label>
							  </div>

							  <!-- 2 column grid layout for inline styling -->
							  <div class="row mb-4">
									<div class="col d-flex justify-content-center">
									  <!-- Checkbox -->
									  <div class="form-check">
										<asp:CheckBox CssClass="form-check-input" ID="CheckRemember" Checked="true" runat="server" />
										<label class="form-check-label" for="form1Example3"> Remember me </label>
									  </div>
									</div>

									<div class="col">
								  <!-- forgot password link -->
								  <a href="#">Forgot password?</a>
								</div>
			  	
							  </div>

							  <!-- Submit button -->
							  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="Button1_Click" />

							   <br /> <br />
									<div class="">
			  
									 <asp:Label ID="errorLog" runat="server" CssClass="alert alert-danger" Visible="false" ></asp:Label>
									</div>
	
					</div>
		 

			  				

						</div>
						<br />
						<br />
						<div>
						<asp:Label ID="errors" runat="server" CssClass="alert alert-danger" Visible="false" />
						<asp:Label ID="successEg" runat="server" CssClass="alert alert-success" Visible="false" />

						</div>
				<!-- Pills content -->
				</div>	

			</div>

		</form>
</div>




	<footer class="">
        <center> 
		<p>&copy All Right Reserved <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></p>
        </center>
    </footer>

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
