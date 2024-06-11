using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Asignaciondocentes = new HashSet<Asignaciondocente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;

        public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; }
    }
}
