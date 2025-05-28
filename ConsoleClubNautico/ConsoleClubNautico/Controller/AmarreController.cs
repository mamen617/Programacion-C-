using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleClubNautico.Controller
{
    internal class AmarreController
    {
        public void Insertar(Amarres MiObjeto)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = " INSERT INTO amarres (ID_Amarre, cuota) " +
                        " VALUES (Null, @cuota)";
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@cuota", MiObjeto.cuota);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void BorrarTabla()
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = "Delete from Amarres";
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public List<Amarres> Listar()
        {
            List<Amarres> listar = new List<Amarres>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    string consulta = " SELECT ID_Amarre, nombre, cuota from Amarres ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Amarres amarre = new Amarres();
                        amarre.id_Amarre = (int)resultado["id_Amarre"];
                        amarre.nombre = (string)resultado["nombre"];
                        amarre.cuota = (double)resultado["cuota"];
                        listar.Add(amarre);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listar;
        }
    }
}


