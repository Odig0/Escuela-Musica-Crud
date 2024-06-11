using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Duracionnivel
    {
        public int Id { get; set; }
        public int? NivelId { get; set; }
        public int DuracionMeses { get; set; }

        public virtual Nivel? Nivel { get; set; }
    }
}
