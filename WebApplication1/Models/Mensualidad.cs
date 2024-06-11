using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Mensualidad
    {
        public Mensualidad()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;
        public int? EstudianteId { get; set; }
        public int? GrupoId { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
        public virtual Grupo? Grupo { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
