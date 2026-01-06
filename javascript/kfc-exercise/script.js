// ====== LOGIN (solo si existen los elementos) ======
const user = "cone@gmail.com";
const password = "milo123";

const inputUser = document.getElementById("email");
const inputPassword = document.getElementById("password");
const btnSesion = document.getElementById("btn");

if (btnSesion && inputUser && inputPassword) {
  btnSesion.addEventListener("click", () => {
    if (user === inputUser.value && password === inputPassword.value) {
      window.location = "./kfc.html";
    } else {
      alert("Usuario o contraseña incorrectos");
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
