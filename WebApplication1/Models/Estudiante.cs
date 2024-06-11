using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Evaluacions = new HashSet<Evaluacion>();
            Mensualidads = new HashSet<Mensualidad>();
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Edad { get; set; }
        public int? GrupoId { get; set; }

        public virtual Grupo? Grupo { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<Mensualidad> Mensualidads { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
