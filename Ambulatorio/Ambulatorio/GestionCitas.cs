using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ambulatorio
{
    public class GestionCitas
    {

        Dictionary<String, Citas> Dic_Otorrino = new Dictionary<string, Citas>(); // 1- Otorrinolaringología(otorrino)
        Dictionary<String, Citas> Dic_Oftalmologo = new Dictionary<string, Citas>(); // 2- Oftalmología(oftalmologo)
        Dictionary<String, Citas> Dic_Endocrino= new Dictionary<string, Citas>(); // 3- Endocrinología(endocrino)
        Dictionary<String, Citas> Dic_Cardiologo = new Dictionary<string, Citas>(); // 4- Cardiología(cardiólogo)
        Dictionary<String, Citas> Dic_Mgeneral = new Dictionary<string, Citas>(); // 5- Medicina General

        

        public void Generar_Diccionario_Otorrino()
        {
            // Añado elementos
            TimeSpan horaFija = new TimeSpan(8, 00, 0);
            String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();
            Dic_Otorrino.Add (sClave, new Citas("otorrino", "pepe", DateTime.Now.Date, horaFija));
       
        }
        //// Recorrer elementos
        public void Imprimir_Diccionario_Otorrino()
        {

            foreach (KeyValuePair<string, Citas> misCitas in Dic_Otorrino)
            {

                Console.WriteLine(misCitas.Key); // Imprime la clave
                
                misCitas.Value.Imprimir(); // Imprime TODO

                // Console.WriteLine(misCitas.Value.getNombrePaciente()); // Imprime un valor
            }

        }

        //oftalmología
        public void Generar_Diccionario_Oftalmologo()
        {
            // Añado elementos
            TimeSpan horaFija = new TimeSpan(8, 00, 0);
            String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();
            Dic_Oftalmologo.Add (sClave, new Citas("oftalmologo", "juan", DateTime.Now.Date, horaFija));
       
        }
        public void Imprimir_Diccionario_Oftalmologo()
        {
            foreach (KeyValuePair<string, Citas> misCitas in Dic_Oftalmologo)
            {
                Console.WriteLine(misCitas.Key); // Imprime la clave
                misCitas.Value.Imprimir(); // Imprime TODO
            }
        }

        //endocrino
        public void Generar_Diccionario_Endocrino()
        {
            // Añado elementos
            TimeSpan horaFija = new TimeSpan(8, 00, 0);
            String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();
            Dic_Oftalmologo.Add(sClave, new Citas("endocrino", "juan", DateTime.Now.Date, horaFija));

        }
        public void Imprimir_Diccionario_Endocrino()
        {
            foreach (KeyValuePair<string, Citas> misCitas in Dic_Endocrino)
            {
                Console.WriteLine(misCitas.Key); // Imprime la clave
                misCitas.Value.Imprimir(); // Imprime TODO
            }
        }

        //cardiologo
        public void Generar_Diccionario_Cardiologo()
        {
            // Añado elementos
            TimeSpan horaFija = new TimeSpan(8, 00, 0);
            String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();
            Dic_Oftalmologo.Add(sClave, new Citas("cardiologo", "juan", DateTime.Now.Date, horaFija));

        }
        public void Imprimir_Diccionario_Cardiologo()
        {
            foreach (KeyValuePair<string, Citas> misCitas in Dic_Cardiologo)
            {
                Console.WriteLine(misCitas.Key); // Imprime la clave
                misCitas.Value.Imprimir(); // Imprime TODO
            }
        }
        //medicina general
        public void Generar_Diccionario_Mgeneral()
        {
            // Añado elementos
            TimeSpan horaFija = new TimeSpan(8, 00, 0);
            String sClave = DateTime.Now.Date.ToString() + horaFija.ToString();
            Dic_Oftalmologo.Add(sClave, new Citas("mgeneral", "juan", DateTime.Now.Date, horaFija));

        }
        public void Imprimir_Diccionario_Mgeneral()
        {
            foreach (KeyValuePair<string, Citas> misCitas in Dic_Mgeneral)
            {
                Console.WriteLine(misCitas.Key); // Imprime la clave
                misCitas.Value.Imprimir(); // Imprime TODO
            }
        }


        public void Agregar_cita_Dicicionario(string especialidad, string clave, string nombrePaciente, DateTime fecha, TimeSpan hora)
        {
            switch (especialidad.ToLower())
            {
                case "otorrino":
                    if (!Dic_Otorrino.ContainsKey(clave))
                    {
                        Dic_Otorrino.Add(clave,new Citas(especialidad,nombrePaciente,fecha,hora));
                    }
                    break;
                case "oftalmologo":
                    if (!Dic_Oftalmologo.ContainsKey(clave))
                    {
                        Dic_Oftalmologo.Add(clave, new Citas(especialidad, nombrePaciente, fecha, hora));
                    }
                    break;
                case "endocrino":
                    if (!Dic_Endocrino.ContainsKey(clave))
                    {
                        Dic_Endocrino.Add(clave, new Citas(especialidad, nombrePaciente, fecha, hora));
                    }
                    break;
                case "cardiologo":
                    if (!Dic_Cardiologo.ContainsKey(clave))
                    {
                        Dic_Cardiologo.Add(clave, new Citas(especialidad, nombrePaciente, fecha, hora));
                    }
                    break;
                case "mgeneral":
                    if (!Dic_Mgeneral.ContainsKey(clave))
                    {
                        Dic_Mgeneral.Add(clave, new Citas(especialidad, nombrePaciente, fecha, hora));
                    }
                    break;
                default: // especialidad no coincide con ningún valor
                    break;
            }
        }

        public void Borrar_cita_Dicicionario(string especialidad, string clave)
        {
            switch (especialidad)
            {
                case "otorrino":
                    if (Dic_Otorrino.ContainsKey(clave))
                    {
                        Dic_Otorrino.Remove(clave);
                    }
                    break;
                case "oftalmologo":
                    if (Dic_Oftalmologo.ContainsKey(clave))
                    {
                        Dic_Oftalmologo.Remove(clave);
                    }
                    break;
                case "endocrino":
                    if (Dic_Endocrino.ContainsKey(clave))
                    {
                        Dic_Endocrino.Remove(clave);
                    }
                    break;
                case "cardiologo":
                    if (Dic_Cardiologo.ContainsKey(clave))
                    {
                        Dic_Cardiologo.Remove(clave);
                    }
                    break;
                case "mgeneral":
                    if (Dic_Mgeneral.ContainsKey(clave))
                    {
                        Dic_Mgeneral.Remove(clave);
                    }
                    break;
                default: // especialidad no coincide con ningún valor
                    break;
            }
        }

    }
}
