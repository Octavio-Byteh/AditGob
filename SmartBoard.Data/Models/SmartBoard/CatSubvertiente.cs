using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatSubvertiente
    {
        public CatSubvertiente()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public int Idvertiente { get; set; }

        public virtual CatVertiente IdvertienteNavigation { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
