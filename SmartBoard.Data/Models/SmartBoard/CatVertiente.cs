using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatVertiente
    {
        public CatVertiente()
        {
            CatSubvertientes = new HashSet<CatSubvertiente>();
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<CatSubvertiente> CatSubvertientes { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
