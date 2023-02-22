using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatTipoConcepto
    {
        public CatTipoConcepto()
        {
            TblObraconceptos = new HashSet<TblObraconcepto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string HexColor { get; set; }
        public bool EsPrincipal { get; set; }

        public virtual ICollection<TblObraconcepto> TblObraconceptos { get; set; }
    }
}
