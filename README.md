# AddingGoo
## José David Serna Villa; ID: 438672
## Miguel Cálad Posada; ID: 350013
## Sofía González; ID: 450810

Se realizará un juego tipo single-screen en 2D donde el objetivo del jugador será terminar 3 niveles eliminando a todos los enemigos de cada nivel para poder avanzar. El jugador controlará a un personaje llamado Goo, este ser tiene la capacidad de arrastrarse por el suelo y las paredes. El jugador tendrá que esquivar obstáculos utilizando las paredes, y recoger coleccionables que aumentan su stat de FUERZA para conseguir el poder para eliminar a sus enemigos.

### Cambios respecto al avance 1
* Implementada una clase abstracta character que hereda al player y los enemigos, modificada la implementación de la interfaz para permitir una herencia correcta, y una gran cantidad de replanteamientos en la implementación de las funciones, especialmente respecto a que parámetros iban a estar recibiendo. Especial enfoque en los constructores y los parámetros que reciben los elementos que estaban heredando de otras abstracciones. Abierta la posibilidad de que la implementación en unity simplifique muchas de estas cosas
