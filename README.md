# AddingGoo
## José David Serna Villa; ID: 438672
## Miguel Cálad Posada; ID: 350013
## Sofía González; ID: 450810

Se realizará un juego tipo single-screen en 2D donde el objetivo del jugador será terminar 3 niveles eliminando a todos los enemigos de cada nivel para poder avanzar. El jugador controlará a un personaje llamado Goo, este ser tiene la capacidad de arrastrarse por el suelo y las paredes. El jugador tendrá que esquivar obstáculos utilizando las paredes, y recoger coleccionables que aumentan su stat de FUERZA para conseguir el poder para eliminar a sus enemigos.

### Cambios respecto al avance 1
* Implementada una clase abstracta character que hereda al player y los enemigos, modificada la implementación de la interfaz para permitir una herencia correcta, y una gran cantidad de replanteamientos en la implementación de las funciones, especialmente respecto a que parámetros iban a estar recibiendo. Especial enfoque en los constructores y los parámetros que reciben los elementos que estaban heredando de otras abstracciones. Abierta la posibilidad de que la implementación en unity simplifique muchas de estas cosas
### Cambios respecto al avance 2
* Se han aplicado singletons para levelManager, gameManager y el propio Player, también se ha modificado un poco las funciones para acceder correctamente a ellas a través de otros scripts (movido el powerUp a la interfaz IDealDamage) También se han añadido diferentes referencias a los manager dentro de las otras entidades para recibir correctamente la información. Hay detalles para pulir de varios intentos fallidos por acomodar la inicialización de los enemigos activos y las escenas. Probablemente el movimiento necesite una revisión. Porque el level manager carga el siguiente nivel aumentando el indice de la escena actual, y como el sceneManager está indexado en la build, la escena que carga no es la escena del nivel 2 (no implementada) sino la escena siguiente en el indice, que varia durante la ejecución (puede terminar saliendo gameOver aun al ganar el nivel)
* Build del primer nivel: https://drive.google.com/file/d/17ox31Q095GKvqC9Fc1m1t4l153l34LCY/view?usp=sharing

### Notas: No alcanzamos a realizar la build adecuadamente y por las carreras el juego empieza en la escena de juego y no en el menú.
