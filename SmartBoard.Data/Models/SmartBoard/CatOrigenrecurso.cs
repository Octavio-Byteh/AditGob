using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatOrigenrecurso
    {
        public CatOrigenrecurso()
        {
            TblObraRecursos = new HashSet<TblObraRecurso>();
            TblPoadetalleinversions = new HashSet<TblPoadetalleinversion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TblObraRecurso> TblObraRecursos { get; set; }
        public virtual ICollection<TblPoadetalleinversion> TblPoadetalleinversions { get; set; }
    }
}
