using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObraconcepto
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        /// <summary>
        /// Tipo  -  1 Adiciones, Tipo 2 - Decutivas
        /// </summary>
        public int Tipo { get; set; }

        public virtual TblObra IdTblobraNavigation { get; set; }
    }
}
