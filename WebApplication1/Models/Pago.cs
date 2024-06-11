using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Estado { get; set; } = null!;
        public int? MensualidadId { get; set; }
        public int? EstudianteId { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
        public virtual Mensualidad? Mensualidad { get; set; }
    }
}
