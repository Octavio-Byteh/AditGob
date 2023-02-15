using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoadetalleOd
    {
        public int Id { get; set; }
        public int Idpoadetalle { get; set; }
        public int? Idodsobjetivo { get; set; }
        public int? Idodsmeta { get; set; }
        public int? Idodsindicador { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Comentarios { get; set; }

        public virtual CatOdsIndicador IdodsindicadorNavigation { get; set; }
        public virtual CatOdsMetum IdodsmetaNavigation { get; set; }
        public virtual CatOdsObjetivo IdodsobjetivoNavigation { get; set; }
        public virtual TblPoadetalle IdpoadetalleNavigation { get; set; }
    }
}
