using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatTipoDeContrato
    {
        public CatTipoDeContrato()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Idtipoobra { get; set; }

        public virtual CatTipoObra IdtipoobraNavigation { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
