# Listado de eventos comunes para `addEventListener`

## Eventos de mouse

| Evento      | Descripción                                 |
| ----------- | ------------------------------------------- |
| click       | Cuando el usuario hace clic                 |
| dblclick    | Doble clic                                  |
| mouseover   | Cuando el cursor entra en un elemento       |
| mouseout    | Cuando el cursor sale del elemento          |
| mousemove   | Cuando el cursor se mueve sobre un elemento |
| mousedown   | Cuando se presiona un botón del mouse       |
| mouseup     | Cuando se suelta un botón del mouse         |
| contextmenu | Clic derecho del mouse                      |

---

## Eventos de teclado

| Evento   | Descripción                  |
| -------- | ---------------------------- |
| keydown  | Cuando se presiona una tecla |
| keyup    | Cuando se suelta una tecla   |
| keypress | (Obsoleto, usar keydown)     |

---

## Eventos de formularios

| Evento | Descripción                               |
| ------ | ----------------------------------------- |
| submit | Cuando se envía un formulario             |
| change | Cuando cambia el valor de un input/select |
| input  | Cuando se escribe (mientras se escribe)   |
| focus  | Cuando un input recibe foco               |
| blur   | Cuando un input pierde el foco            |
| reset  | Cuando se resetea un formulario           |

---

## 📄 Eventos del documento o ventana

| Evento           | Descripción                                         |
| ---------------- | --------------------------------------------------- |
| load             | Cuando la página terminó de cargar                  |
| DOMContentLoaded | Cuando el DOM está listo (antes de imágenes)        |
| resize           | Cuando la ventana del navegador cambia de tamaño    |
| scroll           | Cuando se hace scroll                               |
| beforeunload     | Antes de que el usuario cierre o recargue la página |
| unload           | Cuando se cierra la página                          |

---

## Eventos de dispositivos (touch/pantalla)

| Evento            | Descripción                               |
| ----------------- | ----------------------------------------- |
| touchstart        | Cuando se toca un elemento                |
| touchmove         | Cuando el dedo se mueve sobre la pantalla |
| touchend          | Cuando se levanta el dedo                 |
| orientationchange | Cambio de orientación del dispositivo     |

---

## Ejemplo básico

```
const boton = document.getElementById('miBoton');

boton.addEventListener('click', () => {
  alert('¡Clic en el botón!');
});
```
