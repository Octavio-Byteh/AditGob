using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObraEstimacion
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int? IdFactura { get; set; }
        public string Numero { get; set; }
        public string NumFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaEstimacion { get; set; }
        public decimal MontoPagarSinIva { get; set; }
        public decimal AmortizadoSinIva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SubtotalConIva { get; set; }
        public decimal CincoMillarSinIva { get; set; }
        public decimal MontoNetoPagar { get; set; }
        public decimal Retencion { get; set; }
        public decimal Devolucion { get; set; }
        public decimal AvenceFisicoProgramado { get; set; }
        public decimal AvanceFisicoReal { get; set; }
        public decimal AvanceFinancieron { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Pagado { get; set; }
        public bool Activo { get; set; }
        public DateTime Registro { get; set; }
        public bool Aplica5millar { get; set; }
        public string RutaArchivoFactura { get; set; }
        public string RutaArchivoEvidencia { get; set; }
        public string NombreArchivoFactura { get; set; }
        public string NombreArchivoEvidencia { get; set; }

        public virtual TblObra IdTblobraNavigation { get; set; }
    }
}
