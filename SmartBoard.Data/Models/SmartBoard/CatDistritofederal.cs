using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatDistritofederal
    {
        public CatDistritofederal()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Partido { get; set; }
        public string Diputado { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
    }
}
