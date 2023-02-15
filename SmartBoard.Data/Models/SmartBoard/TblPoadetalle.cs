using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoadetalle
    {
        public TblPoadetalle()
        {
            TblObras = new HashSet<TblObra>();
            TblPoadetalleAreas = new HashSet<TblPoadetalleArea>();
            TblPoadetalleOds = new HashSet<TblPoadetalleOd>();
            TblPoadetallePeds = new HashSet<TblPoadetallePed>();
            TblPoadetalleinversions = new HashSet<TblPoadetalleinversion>();
        }

        public int Id { get; set; }
        public int IdProgramaoperativo { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechatermino { get; set; }
        public int Iddependencia { get; set; }
        public string Objetivo { get; set; }
        public string Actividades { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool Activo { get; set; }
        public DateTime Fechaactividad { get; set; }
        public int Year { get; set; }
        public string Nombre { get; set; }

        public virtual TblPoa IdProgramaoperativoNavigation { get; set; }
        public virtual CatDependencium IddependenciaNavigation { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
        public virtual ICollection<TblPoadetalleArea> TblPoadetalleAreas { get; set; }
        public virtual ICollection<TblPoadetalleOd> TblPoadetalleOds { get; set; }
        public virtual ICollection<TblPoadetallePed> TblPoadetallePeds { get; set; }
        public virtual ICollection<TblPoadetalleinversion> TblPoadetalleinversions { get; set; }
    }
}
