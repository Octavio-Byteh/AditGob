using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatOdsMetum
    {
        public CatOdsMetum()
        {
            CatOdsIndicadors = new HashSet<CatOdsIndicador>();
            TblPoadetalleOds = new HashSet<TblPoadetalleOd>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }
        public int? IdOdsObjetivo { get; set; }

        public virtual CatOdsObjetivo IdOdsObjetivoNavigation { get; set; }
        public virtual ICollection<CatOdsIndicador> CatOdsIndicadors { get; set; }
        public virtual ICollection<TblPoadetalleOd> TblPoadetalleOds { get; set; }
    }
}
