using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class EscuelaMusicaContext : DbContext
    {
        public EscuelaMusicaContext()
        {
        }

        public EscuelaMusicaContext(DbContextOptions<EscuelaMusicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<AniO> AniOs { get; set; } = null!;
        public virtual DbSet<Asignaciondocente> Asignaciondocentes { get; set; } = null!;
        public virtual DbSet<Bimestral> Bimestrals { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Duracionnivel> Duracionnivels { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Evaluacion> Evaluacions { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<Horarioinstrumento> Horarioinstrumentos { get; set; } = null!;
        public virtual DbSet<Instrumento> Instrumentos { get; set; } = null!;
        public virtual DbSet<Mensualidad> Mensualidads { get; set; } = null!;
        public virtual DbSet<Nivel> Nivels { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Profesor> Profesors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=DESKTOP-2J8LJOL;database=EscuelaMusica;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("ADMINISTRADOR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AniO>(entity =>
            {
                entity.ToTable("ANiO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Año)
                    .HasColumnType("date")
                    .HasColumnName("año");
            });

            modelBuilder.Entity<Asignaciondocente>(entity =>
            {
                entity.ToTable("ASIGNACIONDOCENTE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_asignacion");

                entity.Property(e => e.GrupoId).HasColumnName("grupo_id");

                entity.Property(e => e.ProfesorId).HasColumnName("profesor_id");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Asignaciondocentes)
                    .HasForeignKey(d => d.AdministradorId)
                    .HasConstraintName("FK__ASIGNACIO__admin__534D60F1");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Asignaciondocentes)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK__ASIGNACIO__grupo__5165187F");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Asignaciondocentes)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__ASIGNACIO__profe__52593CB8");
            });

            modelBuilder.Entity<Bimestral>(entity =>
            {
                entity.ToTable("BIMESTRAL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Año)
                    .HasColumnType("date")
                    .HasColumnName("año");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.ToTable("CLASE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Horario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.InstrumentoId).HasColumnName("instrumento_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.Instrumento)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.InstrumentoId)
                    .HasConstraintName("FK__CLASE__instrumen__44FF419A");
            });

            modelBuilder.Entity<Duracionnivel>(entity =>
            {
                entity.ToTable("DURACIONNIVEL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DuracionMeses).HasColumnName("duracion_meses");

                entity.Property(e => e.NivelId).HasColumnName("nivel_id");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Duracionnivels)
                    .HasForeignKey(d => d.NivelId)
                    .HasConstraintName("FK__DURACIONN__nivel__4222D4EF");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("ESTUDIANTE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.GrupoId).HasColumnName("grupo_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK__ESTUDIANT__grupo__3F466844");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("EVALUACION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.NivelId).HasColumnName("nivel_id");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__EVALUACIO__estud__4BAC3F29");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.NivelId)
                    .HasConstraintName("FK__EVALUACIO__nivel__4CA06362");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("GRUPO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Horario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Horarioinstrumento>(entity =>
            {
                entity.ToTable("HORARIOINSTRUMENTO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.GrupoId).HasColumnName("grupo_id");

                entity.Property(e => e.Horario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.InstrumentoId).HasColumnName("instrumento_id");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Horarioinstrumentos)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK__HORARIOIN__grupo__48CFD27E");

                entity.HasOne(d => d.Instrumento)
                    .WithMany(p => p.Horarioinstrumentos)
                    .HasForeignKey(d => d.InstrumentoId)
                    .HasConstraintName("FK__HORARIOIN__instr__47DBAE45");
            });

            modelBuilder.Entity<Instrumento>(entity =>
            {
                entity.ToTable("INSTRUMENTO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Mensualidad>(entity =>
            {
                entity.ToTable("MENSUALIDAD");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.GrupoId).HasColumnName("grupo_id");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Mensualidads)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__MENSUALID__estud__5629CD9C");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Mensualidads)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK__MENSUALID__grupo__571DF1D5");
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.ToTable("NIVEL");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("PAGO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.MensualidadId).HasColumnName("mensualidad_id");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__PAGO__estudiante__5AEE82B9");

                entity.HasOne(d => d.Mensualidad)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.MensualidadId)
                    .HasConstraintName("FK__PAGO__mensualida__59FA5E80");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("PROFESOR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("especialidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
