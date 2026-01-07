const user = "cone@gmail.com";
const password = "milo123";

const inputUser = document.getElementById("email");
const inputPassword = document.getElementById("password");
const btnSesion = document.getElementById("btn");
 
if (btnSesion && inputUser && inputPassword) {
  btnSesion.addEventListener("click", () => {
    if (user === inputUser.value && password === inputPassword.value) {

      sessionStorage.setItem("session", "yes");

      Swal.fire({
        title: "Credenciales correctas",
        text: "Bienvenido",
        icon: "success",
        confirmButtonText: "Cool",
      })
      
      setTimeout(() => {
        window.location = "./kfc.html";
        
      }, 1000);
      
     

     
    } else {
      Swal.fire({
        title: "Error!",
        text: "Revisa bien tus credenciales",
        icon: "error",
        confirmButtonText: "Cool",
      });
    }
  });
}






const themeSelect = document.getElementById("theme");
const html = document.documentElement;


if (themeSelect) {


  const savedTheme = localStorage.getItem("theme")

  if (savedTheme) {

    html.setAttribute("data-bs-theme", savedTheme)
    themeSelect.value = savedTheme
  }

  themeSelect.addEventListener("change", () => {

    const theme = themeSelect.value;

    if (theme) {

      html.setAttribute("data-bs-theme", theme);
      localStorage.setItem("theme", theme)

    }
  })

}
