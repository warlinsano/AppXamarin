using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models
{
  public  class Empleados
    {
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Condicion { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime? Fecha_salida { get; set; }

        public int NacionalidadID { get; set; }


        public virtual Nacionalidades Nacionalidad { get; set; }
    }
}
