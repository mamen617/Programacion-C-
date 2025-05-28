
/*
 * Crea un sistema de gestión de citas médicas en C# usando 5 diccionarios independientes (uno por especialidad) con las siguientes características:

Desarrolla una aplicación de consola en C# para gestionar citas médicas en un ambulatorio con 5 especialidades:

- Otorrinolaringología (otorrino)

- Oftalmología (oftalmologo)

- Endocrinología (endocrino)

- Cardiología (cardiólogo)

- Medicina General


* Estructura de datos:

5 diccionarios separados(Dictionary<clave, Cita>), uno por especialidad, donde la clave será un objeto DateTime que combine fecha y hora.
Cada cita debe almacenar:

- Nombre del paciente

- Fecha (DateTime)

- Hora (TimeSpan)


* Cada cita debe validar que no se solape con otra en la misma especialidad (uso eficiente de claves en diccionarios).
Debes de validar que se puedan hace rlas siguientes operaciones:

- Registrar nueva cita (validar que no existan duplicados en misma fecha/hora)

- Modificar fecha/hora de cita existente

- Cancelar cita (cambiar estado)

- Listar todas las citas por especialista


* Revisa que este todo correcto y que no haya fallos. Documenta el programa.

ADICIONAL:

Crea una opcion de menu que escriba el diccionario en un fiochero CSV

 */

using System;
using Ambulatorio;
GestionCitas miGestion = new GestionCitas();


Console.WriteLine("****************************************************************");
Console.WriteLine("Iniciamos generando el dicicionario de datos********************");
Console.WriteLine("****************************************************************");
Console.WriteLine("\n");


//miGestion.Generar_Diccionario();
//miGestion.Imprimir_Diccionario();
//Ficheros miFichero = new Ficheros();



//Ejemplo de Menú de opciones
string opcion = "";

while (opcion != "S")
{

    Console.WriteLine("****************************************************************");
    Console.WriteLine("******************MENÚ DE OPCIONES******************************");
    Console.WriteLine("****************************************************************\n");


    Console.WriteLine("1.- Registrar nueva cita (validar que no existan duplicados en misma fecha/hora)");
    Console.WriteLine("2.- Modificar fecha/hora de cita existente");
    Console.WriteLine("3.- Cancelar cita" );
    Console.WriteLine("4.- Listar todas las citas por especialista");
    Console.WriteLine("5.- Escribir fichero csv con las citas");
    Console.WriteLine("S.- Pulse cualquier otra letra para salir");
    Console.WriteLine("\n Teclee una opción ....");
    opcion = Console.ReadLine();

    if (opcion == "1")// Registrar una nueva cita
    {

        string sEspecialidad = "otorrino";
        String sNombrePaciente = "pepe";
        DateTime dtFecha = DateTime.Now.Date;
        TimeSpan TsHora = new TimeSpan(8, 00, 0);
        String sClave = dtFecha.ToString() + TsHora.ToString();

               
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Registrar una Cita**********************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Agregar_cita_Dicicionario(sEspecialidad, sClave, sNombrePaciente, dtFecha, TsHora);
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
        miGestion.Imprimir_Diccionario_Otorrino();
    }
    else if (opcion == "2")// Modificar fecha y hora
    {
        String sNombrePaciente = "pepe";
        string sEspecialidad = "otorrino";
        DateTime dtFecha = DateTime.Now.Date;
        TimeSpan TsHora = new TimeSpan(8, 00, 0);
        String sClave = DateTime.Now.Date.ToString() + TsHora.ToString();
        miGestion.Borrar_cita_Dicicionario(sEspecialidad, sClave);
        //Añadiriamos la nueva clave------------------------------------------------------

         dtFecha = DateTime.Now.Date;
         TsHora = new TimeSpan(9, 00, 0);

        miGestion.Agregar_cita_Dicicionario(sEspecialidad, sClave, sNombrePaciente, dtFecha, TsHora);
        miGestion.Imprimir_Diccionario_Otorrino();


        Console.WriteLine("****************************************************************");
        Console.WriteLine("Modificar Fecha y Hora *****************************************");
        Console.WriteLine("****************************************************************");
       // miGestion.Agregar_Producto_Dicicionario("ratones", "ratones", 50, 700);
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    else if (opcion == "3") // Cancelar cita
    {
        string sEspecialidad = "otorrino";
        TimeSpan horaFija = new TimeSpan(8, 00, 0);
        String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();

        Console.WriteLine("****************************************************************");
        Console.WriteLine("Cancelar cita***************************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Borrar_cita_Dicicionario(sEspecialidad ,sClave);
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
        miGestion.Imprimir_Diccionario_Otorrino();
    }
    else if (opcion == "4") // Listar todas las citas
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Listar todas las citas******************************************");
        Console.WriteLine("****************************************************************");
        miGestion.Imprimir_Diccionario_Otorrino();
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
        
    }
    else if (opcion == "5") //Escribir fichero csv con las citas
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Escribir fichero csv con las citas******************************");
        Console.WriteLine("****************************************************************");
       // miGestion.Imprimir_Totales();
        Console.WriteLine("****************************************************************");
        Console.WriteLine("\n");
    }
    
    else // si pulsamos cualquier otra letra ponemos opcion a "S"
    {
        opcion = "S";
        Console.WriteLine("****************************************************************");
        Console.WriteLine("Hemos salido de la aplicación***********************************");
        Console.WriteLine("****************************************************************");

    }
}