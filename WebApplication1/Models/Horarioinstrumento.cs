using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Horarioinstrumento
    {
        public int Id { get; set; }
        public int? InstrumentoId { get; set; }
        public int? GrupoId { get; set; }
        public string Horario { get; set; } = null!;

        public virtual Grupo? Grupo { get; set; }
        public virtual Instrumento? Instrumento { get; set; }
    }
}
