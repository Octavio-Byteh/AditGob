using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoa
    {
        public TblPoa()
        {
            TblPoadetalles = new HashSet<TblPoadetalle>();
        }

        public int Id { get; set; }
        public int Idtipoprograma { get; set; }
        public DateTime Fechaelabora { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecharegistro { get; set; }
        public string Comentarios { get; set; }
        public int Activo { get; set; }
        public int Ideje { get; set; }
        public int Idestrategia { get; set; }
        public int Idlineaaccion { get; set; }
        public int Idobjetivo { get; set; }
        public DateTime? Fechaactualizacion { get; set; }
        public string Alineacionped { get; set; }
        public int Iddependencia { get; set; }
        public int? Year { get; set; }

        public virtual CatDependencium IddependenciaNavigation { get; set; }
        public virtual CatEje IdejeNavigation { get; set; }
        public virtual CatEstrategium IdestrategiaNavigation { get; set; }
        public virtual CatLineaaccion IdlineaaccionNavigation { get; set; }
        public virtual CatObjetivo IdobjetivoNavigation { get; set; }
        public virtual CatTipoprograma IdtipoprogramaNavigation { get; set; }
        public virtual ICollection<TblPoadetalle> TblPoadetalles { get; set; }
    }
}
