
let button = document.getElementById("btn")

let cont = 0;

button.addEventListener("click", () => {


    let txt_name = document.getElementById("txt_name");
    let txt_lastName = document.getElementById("txt_last_name"); 
    let tableBody = document.getElementById("tableBody") 
    
    

    if(txt_name.value != "" && txt_lastName.value != ""){
        txt_name.classList.add('is-valid');
        txt_lastName.classList.add('is-valid');
        txt_name.classList.remove('is-invalid');
        txt_lastName.classList.remove('is-invalid');



        Swal.fire({
            title: "Correcto",
            text: "You clicked the button!",
            icon: "success"
        });


        

        cont++;


        let addBody = `
        <tr>
            <td>${cont}</td>
            <td>${txt_name.value}</td>
            <td>${txt_lastName.value}</td>
            
        </tr>`

        tableBody.innerHTML += addBody


    }else {
        txt_name.classList.add('is-invalid');
        txt_lastName.classList.add('is-invalid');
        txt_name.classList.remove('is-valid');
        txt_lastName.classList.remove('is-valid');

        Swal.fire({
            title: "Incorrecto",
            text: "You clicked the button!",
            icon: "error"
        });
    }
});
