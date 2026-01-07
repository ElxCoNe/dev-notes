let firstName = prompt("Ingrese su nombre")
let age = prompt("Ingrese su edad")


const numberAge = Number(age)

if (age === "" || isNaN(numberAge) || numberAge <= 0){
    console.error("Error: Por favor, ingresa una edad válida en números.")

}else{
    if(numberAge < 18){
        alert(`Hola ${firstName}, eres menor de edad. ¡Sigue aprendiendo y disfrutando del código!`)
    }else{
        alert(`Hola ${firstName}, eres mayor de edad. ¡Prepárate para grandes oportunidades en el mundo de la programación!`)
    }
}

