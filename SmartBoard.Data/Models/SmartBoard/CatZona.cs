using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatZona
    {
        public CatZona()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
    }
}
