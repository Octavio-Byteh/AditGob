using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatOdsObjetivo
    {
        public CatOdsObjetivo()
        {
            CatOdsMeta = new HashSet<CatOdsMetum>();
            TblPoadetalleOds = new HashSet<TblPoadetalleOd>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<CatOdsMetum> CatOdsMeta { get; set; }
        public virtual ICollection<TblPoadetalleOd> TblPoadetalleOds { get; set; }
    }
}
