using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatEjecutor
    {
        public CatEjecutor()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
