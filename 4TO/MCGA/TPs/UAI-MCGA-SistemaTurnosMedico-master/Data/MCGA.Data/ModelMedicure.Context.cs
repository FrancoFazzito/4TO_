//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCGA.Data
{
    using System;
    using System.Data.Entity;
    using MCGA.Entities;
    using System.Data.Entity.Infrastructure;
    
    public partial class MedicureContext : DbContext
    {
        public MedicureContext()
            : base("name=MedicureContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TipoDia> TipoDia { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<TipoCancelacion> TipoCancelacion { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoEspecialidad> TipoEspecialidad { get; set; }
        public virtual DbSet<TipoReseva> TipoReseva { get; set; }
        public virtual DbSet<TipoSexo> TipoSexo { get; set; }
        public virtual DbSet<Atencion> Atencion { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Afiliado> Afiliado { get; set; }
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<AgendaCancelacion> AgendaCancelacion { get; set; }
        public virtual DbSet<Bono> Bono { get; set; }
        public virtual DbSet<Cancelacion> Cancelacion { get; set; }
        public virtual DbSet<EspecialidadesProfesional> EspecialidadesProfesional { get; set; }
        public virtual DbSet<Profesional> Profesional { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<HistorialAfiliado> HistorialAfiliado { get; set; }
        public virtual DbSet<TipoKey> TipoKey { get; set; }
        public virtual DbSet<TipoCampo> TipoCampo { get; set; }
        public virtual DbSet<DetalleTipoKey> DetalleTipoKey { get; set; }
        public virtual DbSet<DatoAdicionalAfiliado> DatoAdicionalAfiliado { get; set; }
    }
}
