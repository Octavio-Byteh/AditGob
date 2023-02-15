using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatRamo
    {
        public CatRamo()
        {
            CatRubros = new HashSet<CatRubro>();
            TblObraRecursos = new HashSet<TblObraRecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatRubro> CatRubros { get; set; }
        public virtual ICollection<TblObraRecurso> TblObraRecursos { get; set; }
    }
}
