using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatEstadorevision
    {
        public CatEstadorevision()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
