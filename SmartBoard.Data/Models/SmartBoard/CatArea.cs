using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatArea
    {
        public CatArea()
        {
            TblPoadetalleAreas = new HashSet<TblPoadetalleArea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Responsable { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<TblPoadetalleArea> TblPoadetalleAreas { get; set; }
    }
}
