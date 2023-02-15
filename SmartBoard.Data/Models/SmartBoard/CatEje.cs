using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatEje
    {
        public CatEje()
        {
            CatEstrategia = new HashSet<CatEstrategium>();
            CatObjetivos = new HashSet<CatObjetivo>();
            TblObras = new HashSet<TblObra>();
            TblPoadetallePeds = new HashSet<TblPoadetallePed>();
            TblPoas = new HashSet<TblPoa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Clasifica { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<CatEstrategium> CatEstrategia { get; set; }
        public virtual ICollection<CatObjetivo> CatObjetivos { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
        public virtual ICollection<TblPoadetallePed> TblPoadetallePeds { get; set; }
        public virtual ICollection<TblPoa> TblPoas { get; set; }
    }
}
