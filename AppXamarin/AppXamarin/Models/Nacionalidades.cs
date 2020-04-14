using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Models
{
   public  class Nacionalidades
    {
        public int NacionalidadID { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
