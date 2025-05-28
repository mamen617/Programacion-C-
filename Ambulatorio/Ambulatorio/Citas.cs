using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace Ambulatorio
{
    public class Citas
    {
        String especialidad;
        String nombrePaciente;
        DateTime fecha;
        TimeSpan hora;

        //Constructores______________________________________________
        
        public Citas(String especialidad, String nombrePaciente, DateTime fecha, TimeSpan hora)
        {
            this.especialidad = especialidad;
            this.nombrePaciente = nombrePaciente;
            this.fecha = fecha;
            this.hora = hora;
        }

        //Metodos Set y Get___________________________________________
        public void setEspecialidad(string especialidad)
        {
            this.especialidad = especialidad;
        }
        public String getEspecialidad()
        {
            return especialidad;
        }
        public void setNombrePaciente(string nombrePaciente)
        {
            this.nombrePaciente = nombrePaciente;
        }
        public String getNombrePaciente()
        {
            return nombrePaciente;
        }
        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }
        public DateTime getFecha()
        {
            return fecha;
        }
        public void setHora(TimeSpan hora)
        {
            this.hora = hora;
        }
        public TimeSpan getHora()
        {
            return hora;
        }

        public void Imprimir()
        {
            Console.WriteLine("Especialidad: " + especialidad);
            Console.WriteLine("Paciente: " + nombrePaciente);
            Console.WriteLine("Fecha: " + fecha);
            Console.WriteLine("Hora: " + hora);
        }



    }
}
