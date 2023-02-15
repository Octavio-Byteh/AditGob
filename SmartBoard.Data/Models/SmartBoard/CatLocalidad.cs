using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatLocalidad
    {
        public CatLocalidad()
        {
            TblLocalidadinformacions = new HashSet<TblLocalidadinformacion>();
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public int? Idmunicipio { get; set; }
        public string Partido { get; set; }
        public string Nombre { get; set; }
        public double? Pobtot95 { get; set; }
        public double? Indice95 { get; set; }
        public string Grado95 { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool? Activo { get; set; }
        public string Clave { get; set; }

        public virtual CatMunicipio IdmunicipioNavigation { get; set; }
        public virtual ICollection<TblLocalidadinformacion> TblLocalidadinformacions { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
