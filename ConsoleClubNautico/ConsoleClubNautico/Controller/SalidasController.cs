using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace ConsoleClubNautico.Controller
{
    internal class SalidasController
    {
        public void Insertar(Salidas MiObjeto)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    //string consulta = " INSERT INTO Salidas " +
                    //                " (id_Barco, id_Patron, Fecha_Hora, id_Destino, baja,fecha_Baja) " +
                    //                " VALUES " +
                    //                " (Null, @id_Patron, @Fecha_Hora, @id_Destino, 0,NULL)";

                    string consulta = " INSERT INTO Salidas " +
                                    " (id_Salida, id_Barco, id_Patron, Fecha_Hora, id_Destino) " +
                                    " VALUES " +
                                    " (Null,@id_Barco, @id_Patron, @Fecha_Hora, @id_Destino)";



                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@id_Barco", MiObjeto.Barco.id_Barco);
                    comando.Parameters.AddWithValue("@id_Patron", MiObjeto.Patron.id_Patron);
                    comando.Parameters.AddWithValue("@Fecha_Hora", MiObjeto.Fecha_Hora);
                    comando.Parameters.AddWithValue("@id_Destino", MiObjeto.Detino.id_Destino);
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
                    string consulta = "Delete from Salidas";
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
        public List<Salidas> Listar()
        {
            List<Salidas> listar = new List<Salidas>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    //string consulta = " SELECT b.id_Barco, b.matricula, b.id_Socio, b.nombre, b.Id_Amarre ,s.nombre as nombre_socio " +
                    //    ", s.dni , a.cuota " +
                    //    " FROM Salidas b " +
                    //    " INNER JOIN Socios s ON (b.Id_Socio = s.Id_Socio ) " +
                    //    " INNER JOIN Amarres a  ON (b.Id_Amarre = a.Id_Amarre) ";
                    string consulta = "select * from Salidas ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Salidas salida = new Salidas(); //declaracion del objeto
                        salida.Barco.id_Barco = (int)resultado["id_Barco"];
                        salida.Detino.id_Destino = (int)resultado["id_Destino"];
                        salida.Patron.id_Patron = (int)resultado["id_patron"];
                        listar.Add(salida);
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

