using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class SmartBoardContext : DbContext
    {
        public SmartBoardContext()
        {
        }

        public SmartBoardContext(DbContextOptions<SmartBoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<CatCategoriaCheckList> CatCategoriaCheckLists { get; set; }
        public virtual DbSet<CatCategorium> CatCategoria { get; set; }
        public virtual DbSet<CatCattipomunicipio> CatCattipomunicipios { get; set; }
        public virtual DbSet<CatChecklist> CatChecklists { get; set; }
        public virtual DbSet<CatClasificacion> CatClasificacions { get; set; }
        public virtual DbSet<CatClasificador> CatClasificadors { get; set; }
        public virtual DbSet<CatContratacion> CatContratacions { get; set; }
        public virtual DbSet<CatDependencium> CatDependencia { get; set; }
        public virtual DbSet<CatEje> CatEjes { get; set; }
        public virtual DbSet<CatEjecutor> CatEjecutors { get; set; }
        public virtual DbSet<CatEjercicio> CatEjercicios { get; set; }
        public virtual DbSet<CatEstadoobra> CatEstadoobras { get; set; }
        public virtual DbSet<CatEstadorevision> CatEstadorevisions { get; set; }
        public virtual DbSet<CatEstrategium> CatEstrategia { get; set; }
        public virtual DbSet<CatFondo> CatFondos { get; set; }
        public virtual DbSet<CatGradomarginal> CatGradomarginals { get; set; }
        public virtual DbSet<CatLineaaccion> CatLineaaccions { get; set; }
        public virtual DbSet<CatModalidadEjecucion> CatModalidadEjecucions { get; set; }
        public virtual DbSet<CatMunicipio> CatMunicipios { get; set; }
        public virtual DbSet<CatNormativaAplicable> CatNormativaAplicables { get; set; }
        public virtual DbSet<CatOrigenrecurso> CatOrigenrecursos { get; set; }
        public virtual DbSet<CatPrograma> CatProgramas { get; set; }
        public virtual DbSet<CatProgsoc> CatProgsocs { get; set; }
        public virtual DbSet<CatRamo> CatRamos { get; set; }
        public virtual DbSet<CatRegion> CatRegions { get; set; }
        public virtual DbSet<CatRubro> CatRubros { get; set; }
        public virtual DbSet<CatSubprograma> CatSubprogramas { get; set; }
        public virtual DbSet<CatTipoAdjudicacion> CatTipoAdjudicacions { get; set; }
        public virtual DbSet<CatTipoCheckList> CatTipoCheckLists { get; set; }
        public virtual DbSet<CatTipoConcepto> CatTipoConceptos { get; set; }
        public virtual DbSet<CatTipoDeContrato> CatTipoDeContratos { get; set; }
        public virtual DbSet<CatTipoObra> CatTipoObras { get; set; }
        public virtual DbSet<CatTipoRecurso> CatTipoRecursos { get; set; }
        public virtual DbSet<CatUnidadmedidum> CatUnidadmedida { get; set; }
        public virtual DbSet<Catprogsoc1> Catprogsocs1 { get; set; }
        public virtual DbSet<StgProg> StgProgs { get; set; }
        public virtual DbSet<TblObra> TblObras { get; set; }
        public virtual DbSet<TblObraDocProcHistorium> TblObraDocProcHistoria { get; set; }
        public virtual DbSet<TblObraEstimacion> TblObraEstimacions { get; set; }
        public virtual DbSet<TblObraPago> TblObraPagos { get; set; }
        public virtual DbSet<TblObraRecurso> TblObraRecursos { get; set; }
        public virtual DbSet<TblObrachecklist> TblObrachecklists { get; set; }
        public virtual DbSet<TblObraconcepto> TblObraconceptos { get; set; }
        public virtual DbSet<TblObradocumentoproceso> TblObradocumentoprocesos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VATE5RE\\SQLEXPRESS2019;Database=SmartBoardServer;Persist Security Info=True;User ID=sa;password=devpc123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CatCategoriaCheckList>(entity =>
            {
                entity.ToTable("cat_CategoriaCheckList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatCategorium>(entity =>
            {
                entity.ToTable("cat_categoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatCattipomunicipio>(entity =>
            {
                entity.ToTable("cat_cattipomunicipio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatChecklist>(entity =>
            {
                entity.ToTable("cat_checklist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.ArchivoExtensions)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("archivo_extensions");

                entity.Property(e => e.ArchivoMultiple).HasColumnName("archivo_multiple");

                entity.Property(e => e.ArchivoPermite)
                    .IsRequired()
                    .HasColumnName("archivo_permite")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Estitilo).HasColumnName("estitilo");

                entity.Property(e => e.HexColor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hex_color");

                entity.Property(e => e.Idcategoriachecklist).HasColumnName("idcategoriachecklist");

                entity.Property(e => e.Idtipochecklist).HasColumnName("idtipochecklist");

                entity.Property(e => e.Idtipoobra)
                    .HasColumnName("idtipoobra")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Norma)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("norma");

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nota");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Secuencia).HasColumnName("secuencia");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdcategoriachecklistNavigation)
                    .WithMany(p => p.CatChecklists)
                    .HasForeignKey(d => d.Idcategoriachecklist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_checklist_cat_CategoriaCheckList");

                entity.HasOne(d => d.IdtipochecklistNavigation)
                    .WithMany(p => p.CatChecklists)
                    .HasForeignKey(d => d.Idtipochecklist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_checklist_cat_tipoCheckList");

                entity.HasOne(d => d.IdtipoobraNavigation)
                    .WithMany(p => p.CatChecklists)
                    .HasForeignKey(d => d.Idtipoobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_checklist_cat_tipoObra");
            });

            modelBuilder.Entity<CatClasificacion>(entity =>
            {
                entity.ToTable("cat_clasificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatClasificador>(entity =>
            {
                entity.ToTable("cat_clasificador");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Final).HasMaxLength(255);

                entity.Property(e => e.Inicio).HasMaxLength(255);

                entity.Property(e => e.Mitad).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<CatContratacion>(entity =>
            {
                entity.ToTable("cat_contratacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatDependencium>(entity =>
            {
                entity.ToTable("cat_dependencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Titular)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titular");
            });

            modelBuilder.Entity<CatEje>(entity =>
            {
                entity.ToTable("cat_eje");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clasifica)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("clasifica");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatEjecutor>(entity =>
            {
                entity.ToTable("cat_ejecutor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatEjercicio>(entity =>
            {
                entity.ToTable("cat_ejercicio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatEstadoobra>(entity =>
            {
                entity.ToTable("cat_estadoobra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatEstadorevision>(entity =>
            {
                entity.ToTable("cat_estadorevision");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatEstrategium>(entity =>
            {
                entity.ToTable("cat_estrategia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clasifica)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("clasifica");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Ideje).HasColumnName("ideje");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdejeNavigation)
                    .WithMany(p => p.CatEstrategia)
                    .HasForeignKey(d => d.Ideje)
                    .HasConstraintName("FK_cat_estrategia_cat_eje");
            });

            modelBuilder.Entity<CatFondo>(entity =>
            {
                entity.ToTable("cat_fondo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdRamo).HasColumnName("id_ramo");

                entity.Property(e => e.IdRubro).HasColumnName("id_rubro");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatGradomarginal>(entity =>
            {
                entity.ToTable("cat_gradomarginal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatLineaaccion>(entity =>
            {
                entity.ToTable("cat_lineaaccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clasifica)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("clasifica");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idestrategia).HasColumnName("idestrategia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdestrategiaNavigation)
                    .WithMany(p => p.CatLineaaccions)
                    .HasForeignKey(d => d.Idestrategia)
                    .HasConstraintName("FK_cat_lineaaccion_cat_estrategia");
            });

            modelBuilder.Entity<CatModalidadEjecucion>(entity =>
            {
                entity.ToTable("cat_modalidadEjecucion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatMunicipio>(entity =>
            {
                entity.ToTable("cat_municipio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capaseg)
                    .HasColumnName("CAPASEG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Casillas).HasColumnName("casillas");

                entity.Property(e => e.Cicaeg)
                    .HasColumnName("CICAEG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Cobagua).HasColumnName("cobagua");

                entity.Property(e => e.Cobdren).HasColumnName("cobdren");

                entity.Property(e => e.Cobelect).HasColumnName("cobelect");

                entity.Property(e => e.Delega).HasColumnName("delega");

                entity.Property(e => e.Gdeshum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("gdeshum");

                entity.Property(e => e.Idgdo).HasColumnName("idgdo");

                entity.Property(e => e.Idregion).HasColumnName("idregion");

                entity.Property(e => e.Idtipomunicipio).HasColumnName("idtipomunicipio");

                entity.Property(e => e.Igife)
                    .HasColumnName("IGIFE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Indice).HasColumnName("indice");

                entity.Property(e => e.InversionMunicipal)
                    .HasColumnType("money")
                    .HasColumnName("inversionMunicipal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Listan).HasColumnName("listan");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.Lugest).HasColumnName("lugest");

                entity.Property(e => e.Lugnal).HasColumnName("lugnal");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(255)
                    .HasColumnName("municipio");

                entity.Property(e => e.Munis).HasColumnName("munis");

                entity.Property(e => e.Partido)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("partido");

                entity.Property(e => e.PobTot).HasColumnName("pobTot");

                entity.Property(e => e.Pobhom).HasColumnName("pobhom");

                entity.Property(e => e.Pobmun).HasColumnName("pobmun");

                entity.Property(e => e.Pobtotiind).HasColumnName("pobtotiind");

                entity.Property(e => e.Posine).HasColumnName("posine");

                entity.Property(e => e.Presidente)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("presidente");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("region");

                entity.Property(e => e.Sduop)
                    .HasColumnName("SDUOP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Secciones).HasColumnName("secciones");

                entity.Property(e => e.Sindrenaje).HasColumnName("sindrenaje");

                entity.Property(e => e.TotalObras).HasColumnName("totalObras");

                entity.Property(e => e.Totpiso).HasColumnName("totpiso");

                entity.Property(e => e.Totviv).HasColumnName("totviv");

                entity.HasOne(d => d.IdregionNavigation)
                    .WithMany(p => p.CatMunicipios)
                    .HasForeignKey(d => d.Idregion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_municipio_cat_region");

                entity.HasOne(d => d.IdtipomunicipioNavigation)
                    .WithMany(p => p.CatMunicipios)
                    .HasForeignKey(d => d.Idtipomunicipio)
                    .HasConstraintName("FK_cat_municipio_cat_cattipomunicipio");
            });

            modelBuilder.Entity<CatNormativaAplicable>(entity =>
            {
                entity.ToTable("cat_normativaAplicable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatOrigenrecurso>(entity =>
            {
                entity.ToTable("cat_origenrecurso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatPrograma>(entity =>
            {
                entity.ToTable("cat_programa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatProgsoc>(entity =>
            {
                entity.ToTable("cat_progsoc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Agrupa)
                    .HasMaxLength(50)
                    .HasColumnName("agrupa");

                entity.Property(e => e.Clasifiacion)
                    .HasMaxLength(15)
                    .HasColumnName("clasifiacion");

                entity.Property(e => e.Clave).HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Descripcion2).HasColumnName("descripcion2");

                entity.Property(e => e.Fechap)
                    .HasColumnType("datetime")
                    .HasColumnName("fechap");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.Invben).HasColumnName("invben");

                entity.Property(e => e.Invest).HasColumnName("invest");

                entity.Property(e => e.Invfed).HasColumnName("invfed");

                entity.Property(e => e.Invmun).HasColumnName("invmun");

                entity.Property(e => e.Invorg).HasColumnName("invorg");

                entity.Property(e => e.Presupuesto)
                    .HasColumnType("money")
                    .HasColumnName("presupuesto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subagrupa)
                    .HasMaxLength(50)
                    .HasColumnName("subagrupa");

                entity.Property(e => e.Subagrupa2)
                    .HasMaxLength(50)
                    .HasColumnName("subagrupa2");

                entity.Property(e => e.Subagrupa3)
                    .HasMaxLength(50)
                    .HasColumnName("subagrupa3");

                entity.Property(e => e.Sumar)
                    .HasColumnName("sumar")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CatRamo>(entity =>
            {
                entity.ToTable("cat_ramo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatRegion>(entity =>
            {
                entity.ToTable("cat_region");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clave).HasColumnName("clave");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatRubro>(entity =>
            {
                entity.ToTable("cat_rubro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdRamo).HasColumnName("id_ramo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdRamoNavigation)
                    .WithMany(p => p.CatRubros)
                    .HasForeignKey(d => d.IdRamo)
                    .HasConstraintName("FK_cat_rubro_cat_ramo");
            });

            modelBuilder.Entity<CatSubprograma>(entity =>
            {
                entity.ToTable("cat_subprograma");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatTipoAdjudicacion>(entity =>
            {
                entity.ToTable("cat_tipoAdjudicacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idtipoobra)
                    .HasColumnName("idtipoobra")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdtipoobraNavigation)
                    .WithMany(p => p.CatTipoAdjudicacions)
                    .HasForeignKey(d => d.Idtipoobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_tipoAdjudicacion_cat_tipoObra");
            });

            modelBuilder.Entity<CatTipoCheckList>(entity =>
            {
                entity.ToTable("cat_tipoCheckList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatTipoConcepto>(entity =>
            {
                entity.ToTable("cat_tipoConcepto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsPrincipal).HasColumnName("esPrincipal");

                entity.Property(e => e.HexColor)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("hex_color");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatTipoDeContrato>(entity =>
            {
                entity.ToTable("cat_tipoDeContrato");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idtipoobra)
                    .HasColumnName("idtipoobra")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdtipoobraNavigation)
                    .WithMany(p => p.CatTipoDeContratos)
                    .HasForeignKey(d => d.Idtipoobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_tipoDeContrato_cat_tipoObra");
            });

            modelBuilder.Entity<CatTipoObra>(entity =>
            {
                entity.ToTable("cat_tipoObra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatTipoRecurso>(entity =>
            {
                entity.ToTable("cat_tipoRecurso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatUnidadmedidum>(entity =>
            {
                entity.ToTable("cat_unidadmedida");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Catprogsoc1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("catprogsoc");

                entity.Property(e => e.Column1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column1");

                entity.Property(e => e.Column10)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column10");

                entity.Property(e => e.Column11)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column11");

                entity.Property(e => e.Column12)
                    .HasMaxLength(600)
                    .HasColumnName("column12");

                entity.Property(e => e.Column13)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column13");

                entity.Property(e => e.Column14)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column14");

                entity.Property(e => e.Column15).HasColumnName("column15");

                entity.Property(e => e.Column16).HasColumnName("column16");

                entity.Property(e => e.Column2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column2");

                entity.Property(e => e.Column3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column3");

                entity.Property(e => e.Column4)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column4");

                entity.Property(e => e.Column5)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column5");

                entity.Property(e => e.Column6)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column6");

                entity.Property(e => e.Column7)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column7");

                entity.Property(e => e.Column8)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column8");

                entity.Property(e => e.Column9)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column9");
            });

            modelBuilder.Entity<StgProg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stg_prog");

                entity.Property(e => e.Clasificación).HasMaxLength(255);

                entity.Property(e => e.Fondo).HasMaxLength(255);

                entity.Property(e => e.Programa).HasMaxLength(255);

                entity.Property(e => e.Ramos).HasMaxLength(255);

                entity.Property(e => e.Rubros).HasMaxLength(255);

                entity.Property(e => e.Subprograma).HasMaxLength(255);
            });

            modelBuilder.Entity<TblObra>(entity =>
            {
                entity.ToTable("tbl_obra");

                entity.HasIndex(e => e.Numeroobraexterno, "NonClusteredIndex-NoObra");

                entity.HasIndex(e => e.Year, "NonClusteredIndex-Year");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvanceFinanciero)
                    .HasColumnType("money")
                    .HasColumnName("avanceFinanciero")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BeneficiarioDomicilio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("beneficiario_domicilio");

                entity.Property(e => e.BeneficiarioNombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("beneficiario_nombre");

                entity.Property(e => e.CantidadBeneficioHombre)
                    .HasColumnName("cantidadBeneficioHombre")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CantidadBeneficioMujer)
                    .HasColumnName("cantidadBeneficioMujer")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CantidadUnidadmedida).HasColumnName("cantidad_unidadmedida");

                entity.Property(e => e.ContratistaNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contratistaNombre");

                entity.Property(e => e.Coordenadax)
                    .HasMaxLength(255)
                    .HasColumnName("coordenadax");

                entity.Property(e => e.Coordenaday)
                    .HasMaxLength(255)
                    .HasColumnName("coordenaday");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.EntidadEjecutora)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("entidadEjecutora");

                entity.Property(e => e.EntidadRequiriente)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("entidad_requiriente");

                entity.Property(e => e.EoPrograFin)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_progra_fin");

                entity.Property(e => e.EoPrograInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_progra_inicio");

                entity.Property(e => e.EoRealFin)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_real_fin");

                entity.Property(e => e.EoRealInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_real_inicio");

                entity.Property(e => e.EoReprograFin)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_reprogra_fin");

                entity.Property(e => e.EoReprograInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("eo_reprogra_inicio");

                entity.Property(e => e.Expediente)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("expediente");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.Fechatermino)
                    .HasColumnType("datetime")
                    .HasColumnName("fechatermino");

                entity.Property(e => e.Fuentefinanciamiento)
                    .HasMaxLength(250)
                    .HasColumnName("fuentefinanciamiento");

                entity.Property(e => e.Georeferenciado).HasColumnName("georeferenciado");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Idcontratacion).HasColumnName("idcontratacion");

                entity.Property(e => e.Iddependencia).HasColumnName("iddependencia");

                entity.Property(e => e.Ideje).HasColumnName("ideje");

                entity.Property(e => e.Idejecutor).HasColumnName("idejecutor");

                entity.Property(e => e.Idestadoobra)
                    .HasColumnName("idestadoobra")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Idestadorevision).HasColumnName("idestadorevision");

                entity.Property(e => e.Idestrategia).HasColumnName("idestrategia");

                entity.Property(e => e.Idgradomarginal).HasColumnName("idgradomarginal");

                entity.Property(e => e.Idlineaacion).HasColumnName("idlineaacion");

                entity.Property(e => e.IdmodalidadEjecicion).HasColumnName("idmodalidadEjecicion");

                entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");

                entity.Property(e => e.IdnormativaAplicable).HasColumnName("idnormativaAplicable");

                entity.Property(e => e.Idprogsog).HasColumnName("idprogsog");

                entity.Property(e => e.IdtipoAdjudicacion).HasColumnName("idtipoAdjudicacion");

                entity.Property(e => e.IdtipoContrato).HasColumnName("idtipoContrato");

                entity.Property(e => e.IdtipoObra)
                    .HasColumnName("idtipoObra")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Idunidadmedida).HasColumnName("idunidadmedida");

                entity.Property(e => e.Idzap).HasColumnName("idzap");

                entity.Property(e => e.Imagenobra)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("imagenobra");

                entity.Property(e => e.Inaguracion).HasColumnName("inaguracion");

                entity.Property(e => e.Inversion)
                    .HasColumnType("money")
                    .HasColumnName("inversion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InversionBeneficiario)
                    .HasColumnType("money")
                    .HasColumnName("inversionBeneficiario")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InversionEstatal)
                    .HasColumnType("money")
                    .HasColumnName("inversionEstatal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InversionFederal)
                    .HasColumnType("money")
                    .HasColumnName("inversionFederal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InversionMunicipal)
                    .HasColumnType("money")
                    .HasColumnName("inversionMunicipal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("localidad");

                entity.Property(e => e.Nombreobra).HasColumnName("nombreobra");

                entity.Property(e => e.Numeroobra)
                    .HasColumnName("numeroobra")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Numeroobraexterno)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("numeroobraexterno");

                entity.Property(e => e.NumeroreferenciaCiceco)
                    .HasColumnName("numeroreferenciaCICECO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Observaciones).HasColumnName("observaciones");

                entity.Property(e => e.Observacionesrevision).HasColumnName("observacionesrevision");

                entity.Property(e => e.PeriodoInforme).HasColumnName("periodo_informe");

                entity.Property(e => e.Porcentajeavance)
                    .HasColumnType("money")
                    .HasColumnName("porcentajeavance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Posibleconflicto).HasColumnName("posibleconflicto");

                entity.Property(e => e.ProveedorAdjudicado)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("proveedor_adjudicado");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("region");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbl_obra_cat_categoria");

                entity.HasOne(d => d.IdcontratacionNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idcontratacion)
                    .HasConstraintName("FK_tbl_obra_cat_contratacion");

                entity.HasOne(d => d.IddependenciaNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Iddependencia)
                    .HasConstraintName("FK_tbl_obra_cat_dependencia");

                entity.HasOne(d => d.IdejeNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Ideje)
                    .HasConstraintName("FK_tbl_obra_cat_eje");

                entity.HasOne(d => d.IdejecutorNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idejecutor)
                    .HasConstraintName("FK_tbl_obra_cat_ejecutor");

                entity.HasOne(d => d.IdestadoobraNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idestadoobra)
                    .HasConstraintName("FK_tbl_obra_cat_estadoobra");

                entity.HasOne(d => d.IdestadorevisionNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idestadorevision)
                    .HasConstraintName("FK_tbl_obra_cat_estadorevision");

                entity.HasOne(d => d.IdestrategiaNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idestrategia)
                    .HasConstraintName("FK_tbl_obra_cat_estrategia");

                entity.HasOne(d => d.IdgradomarginalNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idgradomarginal)
                    .HasConstraintName("FK_tbl_obra_cat_gradomarginal");

                entity.HasOne(d => d.IdlineaacionNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idlineaacion)
                    .HasConstraintName("FK_tbl_obra_cat_lineaaccion");

                entity.HasOne(d => d.IdmodalidadEjecicionNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.IdmodalidadEjecicion)
                    .HasConstraintName("FK_tbl_obra_cat_modalidadEjecucion");

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idmunicipio)
                    .HasConstraintName("FK_tbl_obra_cat_municipio");

                entity.HasOne(d => d.IdnormativaAplicableNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.IdnormativaAplicable)
                    .HasConstraintName("FK_tbl_obra_cat_normativaAplicable");

                entity.HasOne(d => d.IdprogsogNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idprogsog)
                    .HasConstraintName("FK_tbl_obra_cat_progsoc");

                entity.HasOne(d => d.IdtipoAdjudicacionNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.IdtipoAdjudicacion)
                    .HasConstraintName("FK_tbl_obra_cat_tipoAdjudicacion");

                entity.HasOne(d => d.IdtipoContratoNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.IdtipoContrato)
                    .HasConstraintName("FK_tbl_obra_cat_tipoDeContrato");

                entity.HasOne(d => d.IdtipoObraNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.IdtipoObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obra_cat_tipoObra");

                entity.HasOne(d => d.IdunidadmedidaNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idunidadmedida)
                    .HasConstraintName("FK_tbl_obra_cat_unidadmedida");

                entity.HasOne(d => d.IdzapNavigation)
                    .WithMany(p => p.TblObras)
                    .HasForeignKey(d => d.Idzap)
                    .HasConstraintName("FK_tbl_obra_cat_cattipomunicipio");
            });

            modelBuilder.Entity<TblObraDocProcHistorium>(entity =>
            {
                entity.ToTable("tbl_ObraDocProc_Historia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdObraDocumentoProceso).HasColumnName("id_ObraDocumentoProceso");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.IdObraDocumentoProcesoNavigation)
                    .WithMany(p => p.TblObraDocProcHistoria)
                    .HasForeignKey(d => d.IdObraDocumentoProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ObraDocProc_Historia_tbl_obradocumentoproceso");
            });

            modelBuilder.Entity<TblObraEstimacion>(entity =>
            {
                entity.ToTable("tbl_obraEstimacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.AmortizadoSinIva)
                    .HasColumnType("money")
                    .HasColumnName("amortizado_sin_iva");

                entity.Property(e => e.Aplica5millar).HasColumnName("aplica5millar");

                entity.Property(e => e.AplicaAnticipo).HasColumnName("aplicaAnticipo");

                entity.Property(e => e.AvanceFinancieron)
                    .HasColumnType("money")
                    .HasColumnName("avance_financieron");

                entity.Property(e => e.AvanceFisicoReal)
                    .HasColumnType("money")
                    .HasColumnName("avance_fisico_real");

                entity.Property(e => e.AvenceFisicoProgramado)
                    .HasColumnType("money")
                    .HasColumnName("avence_fisico_programado");

                entity.Property(e => e.CincoMillarSinIva)
                    .HasColumnType("money")
                    .HasColumnName("cinco_millar_sin_iva");

                entity.Property(e => e.Devolucion)
                    .HasColumnType("money")
                    .HasColumnName("devolucion");

                entity.Property(e => e.FechaEstimacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_estimacion");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_factura");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdRecurso).HasColumnName("id_recurso");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.ImportePorEjercer)
                    .HasColumnType("money")
                    .HasColumnName("importePorEjercer");

                entity.Property(e => e.MontoNetoPagar)
                    .HasColumnType("money")
                    .HasColumnName("monto_neto_pagar");

                entity.Property(e => e.MontoPagarSinIva)
                    .HasColumnType("money")
                    .HasColumnName("monto_pagar_sin_iva");

                entity.Property(e => e.NombreArchivoEvidencia)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombreArchivoEvidencia");

                entity.Property(e => e.NombreArchivoFactura)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombreArchivoFactura");

                entity.Property(e => e.NumFactura)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("num_factura");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Pagado)
                    .HasColumnType("money")
                    .HasColumnName("pagado");

                entity.Property(e => e.Registro)
                    .HasColumnType("datetime")
                    .HasColumnName("registro");

                entity.Property(e => e.Retencion)
                    .HasColumnType("money")
                    .HasColumnName("retencion");

                entity.Property(e => e.RutaArchivoEvidencia)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("rutaArchivoEvidencia");

                entity.Property(e => e.RutaArchivoFactura)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("rutaArchivoFactura");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("money")
                    .HasColumnName("subtotal");

                entity.Property(e => e.SubtotalConIva)
                    .HasColumnType("money")
                    .HasColumnName("subtotal_con_iva");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.TblObraEstimacions)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_tbl_obraEstimacion_tbl_obraRecursos");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObraEstimacions)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obraEstimacion_tbl_obra");
            });

            modelBuilder.Entity<TblObraPago>(entity =>
            {
                entity.ToTable("tbl_obraPagos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_factura");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.ImporteTotal)
                    .HasColumnType("money")
                    .HasColumnName("importe_total");

                entity.Property(e => e.NombreArchivoEvidencia)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombreArchivoEvidencia");

                entity.Property(e => e.NombreArchivoFactura)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombreArchivoFactura");

                entity.Property(e => e.NumFactura)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("num_factura");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.OrdenPago)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("orden_pago");

                entity.Property(e => e.Pago)
                    .HasColumnType("money")
                    .HasColumnName("pago");

                entity.Property(e => e.Registro)
                    .HasColumnType("datetime")
                    .HasColumnName("registro");

                entity.Property(e => e.RutaArchivoEvidencia)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("rutaArchivoEvidencia");

                entity.Property(e => e.RutaArchivoFactura)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("rutaArchivoFactura");

                entity.Property(e => e.SolicitudPago)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("solicitud_pago");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObraPagos)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obraPagos_tbl_obra");
            });

            modelBuilder.Entity<TblObraRecurso>(entity =>
            {
                entity.ToTable("tbl_obraRecursos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Autorizados)
                    .HasColumnType("money")
                    .HasColumnName("autorizados");

                entity.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");

                entity.Property(e => e.IdClasificadorN1).HasColumnName("id_clasificador_n1");

                entity.Property(e => e.IdClasificadorN2).HasColumnName("id_clasificador_n2");

                entity.Property(e => e.IdClasificadorN3).HasColumnName("id_clasificador_n3");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.IdFondo).HasColumnName("id_fondo");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.Property(e => e.IdRamo).HasColumnName("id_ramo");

                entity.Property(e => e.IdRecurso).HasColumnName("id_recurso");

                entity.Property(e => e.IdRubro).HasColumnName("id_rubro");

                entity.Property(e => e.IdSubprograma).HasColumnName("id_subprograma");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.IdTiporecurso).HasColumnName("id_tiporecurso");

                entity.Property(e => e.ImporteContratado)
                    .HasColumnType("money")
                    .HasColumnName("importe_contratado");

                entity.Property(e => e.ImporteContratadoMaximo)
                    .HasColumnType("money")
                    .HasColumnName("importe_contratado_maximo");

                entity.Property(e => e.ImporteContratadoMinimo)
                    .HasColumnType("money")
                    .HasColumnName("importe_contratado_minimo");

                entity.Property(e => e.ImporteEjercido)
                    .HasColumnType("money")
                    .HasColumnName("importe_ejercido");

                entity.Property(e => e.ImporteModificado)
                    .HasColumnType("money")
                    .HasColumnName("importe_modificado");

                entity.Property(e => e.ImportePorEjercer)
                    .HasColumnType("money")
                    .HasColumnName("importe_por_ejercer");

                entity.Property(e => e.Norma)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("norma");

                entity.Property(e => e.Registro)
                    .HasColumnType("datetime")
                    .HasColumnName("registro");

                entity.HasOne(d => d.IdClasificacionNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdClasificacion)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_clasificacion");

                entity.HasOne(d => d.IdClasificadorN1Navigation)
                    .WithMany(p => p.TblObraRecursoIdClasificadorN1Navigations)
                    .HasForeignKey(d => d.IdClasificadorN1)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_clasificador");

                entity.HasOne(d => d.IdClasificadorN2Navigation)
                    .WithMany(p => p.TblObraRecursoIdClasificadorN2Navigations)
                    .HasForeignKey(d => d.IdClasificadorN2)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_clasificador1");

                entity.HasOne(d => d.IdClasificadorN3Navigation)
                    .WithMany(p => p.TblObraRecursoIdClasificadorN3Navigations)
                    .HasForeignKey(d => d.IdClasificadorN3)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_clasificador2");

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdEjercicio)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_ejercicio");

                entity.HasOne(d => d.IdFondoNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdFondo)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_fondo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_programa");

                entity.HasOne(d => d.IdRamoNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdRamo)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_ramo");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_origenrecurso");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_rubro");

                entity.HasOne(d => d.IdSubprogramaNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdSubprograma)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_subprograma");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obraRecursos_tbl_obra");

                entity.HasOne(d => d.IdTiporecursoNavigation)
                    .WithMany(p => p.TblObraRecursos)
                    .HasForeignKey(d => d.IdTiporecurso)
                    .HasConstraintName("FK_tbl_obraRecursos_cat_tipoRecurso");
            });

            modelBuilder.Entity<TblObrachecklist>(entity =>
            {
                entity.ToTable("tbl_obrachecklist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Adjudicacion).HasColumnName("adjudicacion");

                entity.Property(e => e.Administracion).HasColumnName("administracion");

                entity.Property(e => e.ArchivoExtensions)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("archivo_extensions");

                entity.Property(e => e.ArchivoMultiple).HasColumnName("archivo_multiple");

                entity.Property(e => e.ArchivoPermite)
                    .IsRequired()
                    .HasColumnName("archivo_permite")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estitulo).HasColumnName("estitulo");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.HexColor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hex_color");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.Invitacion).HasColumnName("invitacion");

                entity.Property(e => e.Licitacion).HasColumnName("licitacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Norma)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("norma");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.PaginaFinal).HasColumnName("paginaFinal");

                entity.Property(e => e.PaginaInicio).HasColumnName("paginaInicio");

                entity.Property(e => e.Secuencia).HasColumnName("secuencia");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.TituloShort)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titulo_short");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObrachecklists)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obrachecklist_tbl_obra");
            });

            modelBuilder.Entity<TblObraconcepto>(entity =>
            {
                entity.ToTable("tbl_obraconcepto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("money")
                    .HasColumnName("cantidad");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("clave")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("concepto")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.Idtipoconcepto)
                    .HasColumnName("idtipoconcepto")
                    .HasComment("Tipo  -  1 Adiciones, Tipo 2 - Decutivas");

                entity.Property(e => e.Importe)
                    .HasColumnType("money")
                    .HasColumnName("importe");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("money")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Unidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unidad")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObraconceptos)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obraconcepto_tbl_obra");

                entity.HasOne(d => d.IdtipoconceptoNavigation)
                    .WithMany(p => p.TblObraconceptos)
                    .HasForeignKey(d => d.Idtipoconcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obraconcepto_cat_tipoConcepto");
            });

            modelBuilder.Entity<TblObradocumentoproceso>(entity =>
            {
                entity.ToTable("tbl_obradocumentoproceso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Aprobado).HasColumnName("aprobado");

                entity.Property(e => e.ArchivoExtensions)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("archivo_extensions");

                entity.Property(e => e.ArchivoMultiple).HasColumnName("archivo_multiple");

                entity.Property(e => e.ArchivoPermite)
                    .IsRequired()
                    .HasColumnName("archivo_permite")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.Estitulo).HasColumnName("estitulo");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro");

                entity.Property(e => e.HexColor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hex_color");

                entity.Property(e => e.IdTblobra).HasColumnName("id_tblobra");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nombrearchivo)
                    .IsUnicode(false)
                    .HasColumnName("nombrearchivo");

                entity.Property(e => e.Norma)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("norma");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.PaginaFinal).HasColumnName("paginaFinal");

                entity.Property(e => e.PaginaInicio).HasColumnName("paginaInicio");

                entity.Property(e => e.Rutaarchivo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("rutaarchivo");

                entity.Property(e => e.Secuencia).HasColumnName("secuencia");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.TituloShort)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo_short");

                entity.HasOne(d => d.IdTblobraNavigation)
                    .WithMany(p => p.TblObradocumentoprocesos)
                    .HasForeignKey(d => d.IdTblobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_obradocumentoproceso_tbl_obra");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
