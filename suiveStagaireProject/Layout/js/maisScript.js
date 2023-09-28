let login=document.getElementById("pills-login");
let register=document.getElementById("pills-register");
let btnLogin=document.getElementById("tab-login");
let btnRegister=document.getElementById("tab-register");



function toRegister() {
	login.classList.remove("active");
	login.classList.remove("show");
	btnLogin.classList.remove("active")
	register.classList.add("active");
	register.classList.add("show");
	btnRegister.classList.add("active")
}

function toLogin() {
	
	register.classList.remove("active");
	register.classList.remove("show");
	btnRegister.classList.remove("active")
	login.classList.add("active");
	login.classList.add("show");
	btnLogin.classList.add("active")
	
}

