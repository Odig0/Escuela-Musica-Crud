using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Instrumento
    {
        public Instrumento()
        {
            Clases = new HashSet<Clase>();
            Horarioinstrumentos = new HashSet<Horarioinstrumento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<Horarioinstrumento> Horarioinstrumentos { get; set; }
    }
}
