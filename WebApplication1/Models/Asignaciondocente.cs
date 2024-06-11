using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Asignaciondocente
    {
        public int Id { get; set; }
        public int? GrupoId { get; set; }
        public int? ProfesorId { get; set; }
        public int? AdministradorId { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public virtual Administrador? Administrador { get; set; }
        public virtual Grupo? Grupo { get; set; }
        public virtual Profesor? Profesor { get; set; }
    }
}
