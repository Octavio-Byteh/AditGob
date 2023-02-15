using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatEstrategium
    {
        public CatEstrategium()
        {
            CatLineaaccions = new HashSet<CatLineaaccion>();
            TblPoadetallePeds = new HashSet<TblPoadetallePed>();
            TblPoas = new HashSet<TblPoa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clasifica { get; set; }
        public string Clave { get; set; }
        public int? Ideje { get; set; }

        public virtual CatEje IdejeNavigation { get; set; }
        public virtual ICollection<CatLineaaccion> CatLineaaccions { get; set; }
        public virtual ICollection<TblPoadetallePed> TblPoadetallePeds { get; set; }
        public virtual ICollection<TblPoa> TblPoas { get; set; }
    }
}
