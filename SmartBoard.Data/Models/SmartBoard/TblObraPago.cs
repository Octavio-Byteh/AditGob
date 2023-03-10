using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObraPago
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int? IdFactura { get; set; }
        public string Numero { get; set; }
        public string NumFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string SolicitudPago { get; set; }
        public string OrdenPago { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal Pago { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Activo { get; set; }
        public DateTime Registro { get; set; }
        public string RutaArchivoFactura { get; set; }
        public string RutaArchivoEvidencia { get; set; }
        public string NombreArchivoFactura { get; set; }
        public string NombreArchivoEvidencia { get; set; }

        public virtual TblObra IdTblobraNavigation { get; set; }
    }
}
