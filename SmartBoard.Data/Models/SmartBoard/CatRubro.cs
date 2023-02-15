using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatRubro
    {
        public CatRubro()
        {
            TblObraRecursos = new HashSet<TblObraRecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int? IdRamo { get; set; }

        public virtual CatRamo IdRamoNavigation { get; set; }
        public virtual ICollection<TblObraRecurso> TblObraRecursos { get; set; }
    }
}
