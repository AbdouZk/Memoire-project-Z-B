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
				<H2>INSFP Hadni Said Oued Aissi _ Tizi-Ouzou </H2> <i class="fa fa-school fa-2x"> </i>
		 
			</div>
		

	</div>



    <form id="form1" runat="server">
       

    <div class="container">

	<div class="LogIn">
	<!-- Pills navs -->
	<ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist">
	  <li class="nav-item" role="presentation">
	    <a class="nav-link active" id="tab-login" data-mdb-toggle="pill" href="#pills-login" role="tab"
	      aria-controls="pills-login" aria-selected="true" onclick="toLogin()">Login</a>
	  </li>
	  <li class="nav-item" role="presentation">
	    <a class="nav-link" id="tab-register" data-mdb-toggle="pill" href="#pills-register" role="tab"
	      aria-controls="pills-register" aria-selected="false" onclick="toRegister()">Register</a>
	  </li>
	  
	  
	</ul>
	<!-- Pills navs -->
	
	<!-- Pills content -->
	<div class="tab-content">
	  <div class="tab-pane fade show active " id="pills-login" role="tabpanel" aria-labelledby="tab-login">
	
				<h2>Log in</h2>
		

  <!-- user input -->

		  <div class="form-outline mb-4">
			<input type="text" id="username" class="form-control" name="username" />
			<label class="form-label" for="username">Username</label>
		  </div>

		  <!-- Password input -->
		  <div class="form-outline mb-4">
			<input type="password" id="password" class="form-control" name="password" maxlength="10" size="10"/>
			<label class="form-label" for="password">Password</label>
		  </div>

		  <!-- 2 column grid layout for inline styling -->
		  <div class="row mb-4">
			<div class="col d-flex justify-content-center">
			  <!-- Checkbox -->
			  <div class="form-check">
				<input class="form-check-input" type="checkbox" value="" id="form1Example3" checked />
				<label class="form-check-label" for="form1Example3"> Remember me </label>
			  </div>
			</div>

			<div class="col">
			  <!-- Simple link -->
			  <a href="#">Forgot password?</a>
			</div>
		  </div>

		  <!-- Submit button -->
		  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="Button1_Click" />

	
			  </div>

		<div class="tab-pane fade " id="pills-register" role="tabpanel" aria-labelledby="tab-register">
		<h2>Register</h2>

	
	    
	      <!-- Username input -->
	      <div class="form-outline mb-4">
			<input type="text" name="username" class="form-control" id="registerName" />
			<label class="form-label" for="registerName">UserName</label>
	      </div>
	
	      <!-- Password input -->
	      <div class="form-outline mb-4">

			<input type="password" class="form-control" name="password" id="registerPassword" maxlength="10" size="10"/>
	        <label class="form-label" for="registerPassword">Password</label>
		
	      </div>

		  <!--Confirmation Password input -->
	      <div class="form-outline mb-4">

			<input type="password" class="form-control" name="confpassword" id="confpassword" maxlength="10" size="10"/>
	        <label class="form-label" for="confpassword">Confirmation Password</label>
			
	      </div>

		  <!--Group ID  Select -->
	      <div class="form-outline mb-4">

	        <label class="form-label" for="confpassword">Group ID </label>

			  <select class="form-select" aria-label="Default select example">
			  <option selected value="0">Choisissez auquel vous appartenez</option>
			  <option value="1">Administrateur</option>
			  <option value="2">Chef Service</option>
			  <option value="3">Agent Service</option>
			  <option value="4">Enseignant</option>
			  <option value="5">Stagiaire</option>

			</select>
             
	      </div>
	
	      <!-- Submit button -->
	      <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-block" Text="Register" />
	    
	  </div>
	</div>
	<!-- Pills content -->
	</div>	
</div>


    </form>

</div>

	<footer class="">
        <center> 
		<p>&copy All Right Reserved <% DateTime.Now.Year.ToString(); %></p>
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
