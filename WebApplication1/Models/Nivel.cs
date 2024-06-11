using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Nivel
    {
        public Nivel()
        {
            Duracionnivels = new HashSet<Duracionnivel>();
            Evaluacions = new HashSet<Evaluacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Duracionnivel> Duracionnivels { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
    }
}
