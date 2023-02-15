using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatCattipomunicipio
    {
        public CatCattipomunicipio()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
