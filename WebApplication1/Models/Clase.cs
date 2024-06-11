using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Clase
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public int? InstrumentoId { get; set; }

        public virtual Instrumento? Instrumento { get; set; }
    }
}
