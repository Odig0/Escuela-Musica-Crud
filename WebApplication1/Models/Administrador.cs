using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Asignaciondocentes = new HashSet<Asignaciondocente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; }
    }
}
