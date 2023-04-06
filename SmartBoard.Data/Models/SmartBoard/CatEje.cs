using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatEje
    {
        public CatEje()
        {
            CatEstrategia = new HashSet<CatEstrategium>();
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clasifica { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<CatEstrategium> CatEstrategia { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
