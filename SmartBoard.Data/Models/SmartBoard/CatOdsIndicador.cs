using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatOdsIndicador
    {
        public CatOdsIndicador()
        {
            TblPoadetalleOds = new HashSet<TblPoadetalleOd>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }
        public int? IdOdsMeta { get; set; }

        public virtual CatOdsMetum IdOdsMetaNavigation { get; set; }
        public virtual ICollection<TblPoadetalleOd> TblPoadetalleOds { get; set; }
    }
}
