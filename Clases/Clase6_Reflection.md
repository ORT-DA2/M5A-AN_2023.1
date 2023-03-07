
# Reflection

  

## Introducción a Reflection

  

Reflection es la capacidad de un proceso para examinar, hacer introspección y modificar su **propia** estructura y comportamiento.

  

Algunos lenguajes que soportan esta característica son:

  

- C#

- Java

- Objective-C

- PHP

- Python

- ECMAScript

- y mas...

  

En .Net, Reflection es la **habilidad** de un programa de **autoexaminarse** con el objetivo de encontrar ensamblados (.dll), módulos, o información de tipos en **tiempo de ejecución**. En otras palabras, a nivel de código vamos a tener clases y objetos, que nos van a permitir referenciar a ensamblados, y a los tipos que se encuentran contenidos.

  

`Se dice que un programa se refleja en sí mismo (de ahí el termino "reflexión"), a partir de extraer metadata de sus assemblies y de usar esa metadata para ciertos fines. Ya sea para informarle al usuario o para modificar su comportamiento.`

  

Al usar Reflection en C#, estamos pudiendo obtener la información detallada de un objeto, sus métodos, e incluso crear objetos e invocar sus métodos en tiempo de ejecución, sin haber tenido que realizar una referencia al ensamblado que contiene la clase y a su namespace.

  

Específicamente lo que nos permite usar Reflection es el namespace `System.Reflecion`, que contiene clases e interfaces que nos permiten manejar todo lo mencionado anteriormente: ensamblados, tipos, métodos, campos, crear objetos, invocar métodos, etc.

  

## Estructura de un assembly/ensamblado

  

Los assemblies contienen módulos, los módulos contienen tipos y los tipos contienen miembros. Reflection provee clases para encapsular estos elementos. Entonces como dijimos posible utilizar reflection para crear dinámicamente instancias de un tipo, obtener el tipo de un objeto existente e invocarle métodos y acceder a sus atributos de manera dinámica.

  

![alt text](http://www.codeproject.com/KB/cs/DLR/structure.JPG)

  

## ¿Para qué podría servir?

Permite escribir programas que no tienen que **"conocer todo"** en tiempo de compilación, lo que los hace más **"dinámicos"**, ya que pueden vincularse en **"tiempo de ejecución"**. El código se puede escribir en interfaces conocidas, pero las clases reales que se utilizarán se pueden instanciar utilizando la reflexión de los archivos de configuración y localizando, en tiempo de ejecución, la implementación correcta.

Supongamos por ejemplo, que necesitamos que nuestra aplicación soporte diferentes tipos de loggers (mecanismos para registrar datos/eventos que van ocurriendo en el flujo del programa). Además, supongamos que hay desarrolladores terceros que nos brindan una .dll externa que escribe información de logger y la envía a un servidor. En ese caso, tenemos dos opciones:

  

1) Podemos referenciar al ensamblado directamente y llamar a sus métodos (como hemos hecho siempre)

2) Podemos usar Reflection para cargar el ensamblado y llamar a sus métodos a partir de sus interfaces.

  

En este caso, si quisiéramos que nuestra aplicación sea lo más desacoplada posible, de manera que otros loggers puedan ser agregados (o 'plugged in' -de ahí el nombre plugin-) de forma sencilla y SIN RECOMPILAR la aplicación, es necesario elegir la segunda opción.

  
Por ejemplo podríamos hacer que el usuario elija (a medida que está usando la aplicación), y descargue la .dll de logger para elegir usarla en la aplicación. La única forma de hacer esto es a partir de Reflection. De esta forma, podemos cargar ensamblados externos a nuestra aplicación, y cargar sus tipos en tiempo de ejecución.

  

## Favoreciendo el desacoplamiento

  

Lo que es importante para lograr el desacoplamiento de tipos externos, es que nuestro código referencie a una Interfaz, que es la que toda .dll externa va a tener que cumplir. Tiene que existir entonces ese contrato previo, de lo contrario, no sería posible saber de antemano qué métodos llamar de las librerías externas que poseen clases para usar loggers.
 

## Ejemplo 1 - Teórico

  

Problema:

Marty es un desarrollador junior que recién ha comenzado su carrera y tuvo la buena fortuna de conseguir su primer cliente. Dentro de una serie de condiciones, el cliente exige:

  

1. El sistema debe ser capaz de poder enviar Logs a un servicio externo de la empresa del cliente donde mantiene todo los logs de sus aplicaciones.

2. El cliente lo necesita en una semana funcionando.

  

Marty hace gala de todo el conocimiento adquirido en asignaturas de la universidad, practica estimaciones, etc. y se da cuenta que no puede completar el proyecto en menos de quince días, pues, además de los cambios que les pide el cliente, nunca ha hecho una aplicación que publique hacia un servicio REST.

  

Marty tiene que elegir entre tres opciones.

  

1. Rechaza un trabajo y con ello la oportunidad de consolidarse como proveedor de una gran empresa (sabiendo que puede dar lugar a muchos y mejores trabajos).

2. Consigue una máquina del tiempo, aprende hacer todo y llega a tiempo.

3. Busca la manera de que alguien lo ayude.

  
  

Respuesta:

Como se imaginarán, para este ejemplo, no hay opciones 1 ni 2.

  

¿Cómo puede Marty hacer para completar el trabajo en una semana?

  

**Solución:**

Marty piensa un poco y se acuerda de Jennifer, una compañera de clases de programación 1 con quién alguna vez habló y le comentó que algo entendía de REST en .net Core.

  

Jennifer acepta el desafío, pero surge otro problema. Jennifer por razones de seguridad en el repositorio de Marty no puede acceder a ese código.

  

Entonces Marty, quién algo sabía de Reflection porque tenía un primo que ya había ~~padecido~~ salvado Diseño 2 se le ocurre lo siguiente:

  

- Pasar la **interface** a Jennifer con el comportamiento esperado.

- Jennifer se encarga hacer el desarrollo de esa interface.

- Marty utiliza el desarrollo de Jennifer y entrega a tiempo.

  

¿Cómo se vería una representación diagramática de esa situación?

  

A nivel de clases:

  

Diagrama posible de clases:

![alt text](https://github.com/ORT-DA2/TECNOLOGIA-2020.1/blob/master/Resources/Clase6/UMLClasesReflectionEjemplo1.png)

  
  

A nivel de paquetes:

  

![alt text](https://github.com/ORT-DA2/TECNOLOGIA-2020.1/blob/master/Resources/Clase6/UMLPaquetesReflectionEjemplo1.png)


## Ejemplo 2 - Práctico

Se desea tener una aplicación que se encargue solo de definir el comportamiento de personas, dejando que otros la implementen.

La idea de la separación de responsabilidades es similar al Ejemplo 1 anterior.

Puede revisar el [Código](https://github.com/ORT-DA2/TECNOLOGIA-2020.1/tree/master/Codigo/Clase6/Reflection)

`Tenga presente que las rutas en UNIX (Linux, macOS) se representan diferentes a Windows.` 

Se sugiere revisar los métodos:

 - InspectAssembly();
 - InstantiateObjectUnsecure();
 - InstantiateObjectWithKnownInterface();

En particular la forma de invocar y utilizar el contenido del Assembly.

Diagrama UML del problema
![alt text](https://github.com/ORT-DA2/TECNOLOGIA-2020.1/blob/master/Resources/Clase6/UMLReflecion2.png)

## Más información
- [Documentación Reflection Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection)
- [Sitio con ejemplos](https://www.c-sharpcorner.com/UploadFile/keesari_anjaiah/reflection-in-net/) tener presente que todos los ejemplos están implementados para .Net.

## Problemas que pueden aparecer

### No encuentra el archivo.
Los sistemas de archivos de Unix y Windows manejan diferente las rutas. Tener prestente cuando corresponde utilizar "/" como en Unix o  "\" como en Windows.

### No encuentra la librería.
Revisar que exactamente se está buscando iniciar desde donde se debe.
Ejemplo, se dirección a un a carpeta y la dll está en otra.

## Otras notas
Este material tiene como fuente base un repositorio del [dictado anterior](https://github.com/ORT-DA2/N6A-NA-2019.2-Homeworks-Project/blob/master/Clases/Clase%209%20-%20Reflection.md)  de **Santiago Méndez**
