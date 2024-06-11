using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Asignaciondocentes = new HashSet<Asignaciondocente>();
            Estudiantes = new HashSet<Estudiante>();
            Horarioinstrumentos = new HashSet<Horarioinstrumento>();
            Mensualidads = new HashSet<Mensualidad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Horario { get; set; } = null!;

        public virtual ICollection<Asignaciondocente> Asignaciondocentes { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Horarioinstrumento> Horarioinstrumentos { get; set; }
        public virtual ICollection<Mensualidad> Mensualidads { get; set; }
    }
}
