using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Evaluacion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Nota { get; set; }
        public int? EstudianteId { get; set; }
        public int? NivelId { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
        public virtual Nivel? Nivel { get; set; }
    }
}
