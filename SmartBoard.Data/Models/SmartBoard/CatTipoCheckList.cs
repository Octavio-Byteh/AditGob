using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatTipoCheckList
    {
        public CatTipoCheckList()
        {
            CatChecklists = new HashSet<CatChecklist>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatChecklist> CatChecklists { get; set; }
    }
}
