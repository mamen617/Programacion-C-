
/********************************************************************************************************************
* Instrucciones
* 

* Ejercicio: Sistema de Inventario 

* Descripción: 

* Se les pide a los alumnos que implementen un sistema de inventario para una tienda. El inventario debe permitir las siguientes acciones: 

* Mostrar los productos disponibles: Listar todos los productos con su nombre, cantidad y precio. 
* Agregar un nuevo producto: Permitir añadir un producto al inventario. 
* Actualizar la cantidad de un producto existente. 
* Eliminar un producto del inventario. 
* Calcular el valor total del inventario. 

* Requisitos: 

* Usar una lista para manejar dinámicamente los productos agregados o eliminados. 

* Usaremos:
*   una clase Producto
*   una clase Gestion
*   un dicicionario para guardar el producto con clave y valor

*/


using System;
using Inventario;
GestionProducto miGestion = new GestionProducto();


Console.WriteLine("****************************************************************");
Console.WriteLine("Iniciamos generando el dicicionario de datos********************");
Console.WriteLine("****************************************************************");


miGestion.Generar_Diccionario();
miGestion.Imprimir_Diccionario();

Ficheros miFichero = new Ficheros();




//Ejemplo de Menú de opciones
string opcion = "";
while (opcion != "S")
{

    Console.WriteLine("****************************************************************");
    Console.WriteLine("******************MENÚ DE OPCIONES******************************");
    Console.WriteLine("****************************************************************\n");


    Console.WriteLine("1.- Imprimir Listado");
    Console.WriteLine("2.- Agregar nuevos productos");
    Console.WriteLine("3.- Actualizar cantidad de productos");
    Console.WriteLine("4.- Eliminar producto");
    Console.WriteLine("5.- Calcular el valor del inventario");
    Console.WriteLine("\n Teclee una opción ....");
    opcion = Console.ReadLine();

    if (opcion == "1")// Imprimir listado
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Listado de productos********************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Imprimir_Diccionario();
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "2")// Agregar Producto
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Agregar un nuevo producto***************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Agregar_Producto_Dicicionario("ratones", "ratones", 50, 700);
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "3") // Actualizar cantidad de productos
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Actualizar cantidad de productos********************************");
        Console.WriteLine("****************************************************************");
        miGestion.Agregar_Producto_Dicicionario("ratones", "ratones", 50, 700);
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "4") // Eliminar productos
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Eliminar producto***********************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Borrar_Producto_Dicicionario("ratones");
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "5") //Calcular total del inventario
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Eliminar producto***********************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Imprimir_Totales();
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "6") //Generar fichero csv
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Generar fichero csv*********************************************");
        Console.WriteLine("****************************************************************");
        miFichero.Generar_Fichero_Csv();
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "S")
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Hemos salido de la aplicación***********************************");
        Console.WriteLine("****************************************************************");
        
    }
}





