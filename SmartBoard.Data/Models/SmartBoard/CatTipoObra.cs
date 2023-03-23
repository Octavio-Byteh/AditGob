using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatTipoObra
    {
        public CatTipoObra()
        {
            CatChecklists = new HashSet<CatChecklist>();
            CatTipoAdjudicacions = new HashSet<CatTipoAdjudicacion>();
            CatTipoDeContratos = new HashSet<CatTipoDeContrato>();
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatChecklist> CatChecklists { get; set; }
        public virtual ICollection<CatTipoAdjudicacion> CatTipoAdjudicacions { get; set; }
        public virtual ICollection<CatTipoDeContrato> CatTipoDeContratos { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
