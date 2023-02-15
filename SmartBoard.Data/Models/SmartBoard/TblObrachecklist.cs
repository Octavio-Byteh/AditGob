using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObrachecklist
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public string Nombre { get; set; }
        public bool Administracion { get; set; }
        public bool Licitacion { get; set; }
        public bool Invitacion { get; set; }
        public bool Adjudicacion { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecharegistro { get; set; }
        public int? Numero { get; set; }
        public int? PaginaInicio { get; set; }
        public int? PaginaFinal { get; set; }
        public string Observaciones { get; set; }
        public bool? Estitulo { get; set; }
        public string Titulo { get; set; }
        public string TituloShort { get; set; }
        public string Norma { get; set; }

        public virtual TblObra IdTblobraNavigation { get; set; }
    }
}
