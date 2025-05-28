using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Baloncesto
{

    public class GestionBaloncesto
{
    // VARIABLES GLOBALES
    int[] equipo1 = new int[] { 0, 0, 0, 0, 0 }; // Inicializa el ARRAY = Equipo
    int[] equipo2 = new int[] { 0, 0, 0, 0, 0 }; // Inicializa el ARRAY = Equipo
        public void Menu()
    {
        // VARIABLES LOCALES
        Console.WriteLine("INICIO MENU");
        // Anotar(1,2);
        // Anotar(1,2);
        // CREAR MENU

        int opcion = 0;
        do
        {
            Console.WriteLine("OPC 1 : ANOTAR PUNTOS");
            Console.WriteLine("OPC 2 : PUNTOS DE JUGADORES");
            Console.WriteLine("OPC 3 : PUNTUACION");
            Console.WriteLine("OPC 4 : DAR ASISTENCIA");
            Console.WriteLine("OPC 5 : LISTA DE ASISTENCIA");
            Console.WriteLine("OPC 6 : SALIR");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Dime el num. Jugador");
                    int jug = int.Parse(Console.ReadLine());
                    Console.WriteLine("Dime los puntos del jugador");
                    int puntos = int.Parse(Console.ReadLine());
                    Anotar(jug, puntos);
                    break;
                case 2:
                    ListarAnotaciones();
                    break;
                case 3:
                    Puntuacion();
                    break;
                case 4:
                    Console.WriteLine("Dime el num. Jugador");
                    int jug2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Dime la asistencia");
                    int asistencia = int.Parse(Console.ReadLine());
                    DarAsistencia(jug2, asistencia);
                    break;
                case 5:
                   listarAsistencia();
                   break;

             }

        } while (opcion != 6);

        Console.WriteLine("SALIMOS ... ");


    }

    public void Anotar(int numJugador, int puntos)
    {
        // En la posicion del numJugador
        // sumarla puntos

        equipo1[numJugador - 1] = equipo1[numJugador - 1] + puntos;
        Console.WriteLine("PUNTOS {0}: {1}", numJugador, equipo1[numJugador - 1]);
    }

    public void ListarAnotaciones()
    {
        int jugador = 0;
        foreach (int puntos in equipo1)
        {
            jugador++;
            Console.WriteLine($"JUGADOR:  {jugador} - PUNTOS: {puntos} ");
        
        }
    }

    public void Puntuacion()
    {
        int puntosTotales = 0;
        foreach (int puntos in equipo1)
        {
            puntosTotales = puntosTotales + puntos;
        }
        Console.WriteLine($"TOTAL:  {puntosTotales} ");

    }
        public void listarAsistencia()
        {
            int jugador = 0;
            int asistenciasTotales = 0;

            foreach (int asistencia in equipo2)
            {
                jugador++;
                Console.WriteLine($"JUGADOR:  {jugador} - Asistencia: {asistencia} ");
                asistenciasTotales = asistenciasTotales + asistencia;
            }
            Console.WriteLine($"TOTAL Asistencias:  {asistenciasTotales} ");

        }
        public void DarAsistencia(int numJugador, int asistencia)
        {
            // En la posicion del numJugador
            // sumar la asistencia

            equipo2[numJugador - 1] = equipo2[numJugador - 1] + asistencia;
            Console.WriteLine("PUNTOS {0}: {1}", numJugador, equipo2[numJugador - 1]);
        }


    }
}

  
