using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoadetallePed
    {
        public int Id { get; set; }
        public int? Ideje { get; set; }
        public int? Idestrategia { get; set; }
        public int? Idlineaaccion { get; set; }
        public int? Idobjetivo { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Comentarios { get; set; }
        public int Idpoadetalle { get; set; }

        public virtual CatEje IdejeNavigation { get; set; }
        public virtual CatEstrategium IdestrategiaNavigation { get; set; }
        public virtual CatLineaaccion IdlineaaccionNavigation { get; set; }
        public virtual CatObjetivo IdobjetivoNavigation { get; set; }
        public virtual TblPoadetalle IdpoadetalleNavigation { get; set; }
    }
}
