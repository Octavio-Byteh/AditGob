using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatRegion
    {
        public CatRegion()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int? Clave { get; set; }

        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
    }
}
