using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatMunicipio
    {
        public CatMunicipio()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public int Idregion { get; set; }
        public int? Idtipomunicipio { get; set; }
        public int? Idgdo { get; set; }
        public string Region { get; set; }
        public string Municipio { get; set; }
        public decimal? InversionMunicipal { get; set; }
        public int? Sduop { get; set; }
        public int? Capaseg { get; set; }
        public int? Cicaeg { get; set; }
        public int? Igife { get; set; }
        public int? TotalObras { get; set; }
        public string Clave { get; set; }
        public string Partido { get; set; }
        public int? Delega { get; set; }
        public string Presidente { get; set; }
        public int? PobTot { get; set; }
        public int? Indice { get; set; }
        public int? Pobhom { get; set; }
        public int? Pobmun { get; set; }
        public int? Listan { get; set; }
        public int? Munis { get; set; }
        public int? Secciones { get; set; }
        public int? Casillas { get; set; }
        public int? Totviv { get; set; }
        public int? Sindrenaje { get; set; }
        public int? Posine { get; set; }
        public int? Pobtotiind { get; set; }
        public int? Cobagua { get; set; }
        public int? Cobelect { get; set; }
        public int? Cobdren { get; set; }
        public int? Totpiso { get; set; }
        public int? Lugest { get; set; }
        public int? Lugnal { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Gdeshum { get; set; }

        public virtual CatRegion IdregionNavigation { get; set; }
        public virtual CatCattipomunicipio IdtipomunicipioNavigation { get; set; }
        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
