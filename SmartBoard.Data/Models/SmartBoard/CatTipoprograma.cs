using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatTipoprograma
    {
        public CatTipoprograma()
        {
            TblPoas = new HashSet<TblPoa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clasifica { get; set; }

        public virtual ICollection<TblPoa> TblPoas { get; set; }
    }
}
