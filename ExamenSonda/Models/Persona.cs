using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSonda.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fechaNac { get; set; }
        public string sexo { get; set; }
    }
}