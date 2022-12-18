using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_EmpleadosEscritorio.modelo
{
    //Objeto empleado
    class Empleado
    {
        private string documento;
        private string nombres;
        private string apellidos;
        private int edad;
        private string direccion;
        private string fecha_nacimiento;

        //Constructor
        public Empleado()
        {
            documento = "";
            nombres = "";
            apellidos = "";
            edad = 0;
            direccion = "";
            fecha_nacimiento = "";
        }
        //Getters and setters
        public string Documento { get => documento; set => documento = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
    }
}
