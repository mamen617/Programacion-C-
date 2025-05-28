using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Inventario
{
    public class Ficheros
    {
        String nombreFichero= "c:\\tmp\\";
        String rutaFichero = "fichero.csv";
        String Linea;

        //Constructores*******************************************

        public Ficheros(String nombreFichero, String rutaFichero)
        {
            this.nombreFichero = nombreFichero;
            this.rutaFichero = rutaFichero;

        }

        // Trabajar con ficheros de texto


        public void EscribirFichero(String linea)
        {
            // Crear una ruta del archivo
            String rutaArchivo = rutaFichero + nombreFichero;
            // Escribir ese archivo
            StreamWriter sw = new StreamWriter(rutaArchivo);
            sw.WriteLine(linea);
            // Cerrar archivo
            sw.Close();

        }

        public void Generar_Fichero_Csv()
        {

        }

        public void LeerFichero()
        {
            // Crear una ruta del archivo
            String rutaArchivo = rutaFichero + nombreFichero;
            // Crear una ruta del archivo
            StreamReader sr = new StreamReader(rutaArchivo);

            string lineaAleer;

            // Crear una ruta del archivo
            while ((lineaAleer = sr.ReadLine()) != null)
            {
                Console.WriteLine(lineaAleer);
            }
        }

    }
}
