using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBoard.Models
{
    public class RecursosViewModal
    {
        public int Id { get; set; }

        
        [Display(Name = "Obra")]
       
        public int IdTblobra { get; set; }
        public int? IdRecurso { get; set; }
        public string Recurso { get; set; }
        public int? IdEjercicio { get; set; }
        public string Ejercicio { get; set; }
        public int? IdPrograma { get; set; }
        public string Programa { get; set; }
        public int? IdSubprograma { get; set; }
        public string Subprograma { get; set; }

        [Display(Name = "Importe Autorizado")]
        [DataType(DataType.Currency)]
        public decimal Autorizados { get; set; }

        [Display(Name = "Importe Contratado")]
        [DataType(DataType.Currency)]
        public decimal ImporteContratado { get; set; }

        [Display(Name = "Importe Modificado")]
        [DataType(DataType.Currency)]
        public decimal ImporteModificado { get; set; }

        [Display(Name = "Importe Ejercido")]
        [DataType(DataType.Currency)]
        public decimal ImporteEjercido { get; set; }

        [Display(Name = "Importe Por Ejercer")]
        [DataType(DataType.Currency)]
        public decimal ImportePorEjercer { get; set; }
        public bool Activo { get; set; }

        
        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime Registro { get; set; }


        public int? IdTiporecurso { get; set; }
        public string Tiporecurso { get; set; }
        public int? IdRamo { get; set; }
        public string Ramo { get; set; }
        public int? IdRubro { get; set; }
        public string Rubro { get; set; }
        public int? IdFondo { get; set; }

        public string Fondo { get; set; }
        
        public int? IdClasificacion { get; set; }
        public string Clasificacion { get; set; }


        public int? IdClasificadorN1 { get; set; }
        public string ClasificadorN1 { get; set; }
        public int? IdClasificadorN2 { get; set; }
        public string ClasificadorN2 { get; set; }
        public int? IdClasificadorN3 { get; set; }
        public string ClasificadorN3 { get; set; }


        [Display(Name = "Importe Contratado Minimo")]
        [DataType(DataType.Currency)]
        public decimal ImporteContratadoMinimo { get; set; }

        [Display(Name = "Importe Contratado Maximo")]
        [DataType(DataType.Currency)]
        public decimal ImporteContratadoMaximo { get; set; }


    }

    public class ObraconceptoViewModal
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public string Clave { get; set; }
        public string Concepto { get; set; }
        public string Unidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }
        
        public decimal Importe { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public int Idtipoconcepto { get; set; }

    }

    public class PagosViewModal
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int? IdFactura { get; set; }
        public string Numero { get; set; }
        public string NumFactura { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFactura { get; set; }
        public string SolicitudPago { get; set; }
        public string OrdenPago { get; set; }
        [DataType(DataType.Currency)]
        public decimal ImporteTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal Pago { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        public bool Activo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Registro { get; set; }
        public string RutaArchivoFactura { get; set; }
        public string RutaArchivoEvidencia { get; set; }
        public string NombreArchivoFactura { get; set; }
        public string NombreArchivoEvidencia { get; set; }

    }
    public class EstimacionesViewModal
    {
        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int? IdFactura { get; set; }
        public string Numero { get; set; }
        public string NumFactura { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaFactura { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaEstimacion { get; set; }

        [DataType(DataType.Currency)]
        public decimal MontoPagarSinIva { get; set; }

        [DataType(DataType.Currency)]
        public decimal AmortizadoSinIva { get; set; }

        [DataType(DataType.Currency)]
        public decimal Subtotal { get; set; }

        [DataType(DataType.Currency)]
        public decimal SubtotalConIva { get; set; }

        [DataType(DataType.Currency)]
        public decimal CincoMillarSinIva { get; set; }

        [DataType(DataType.Currency)]
        public decimal MontoNetoPagar { get; set; }

        [DataType(DataType.Currency)]
        public decimal Retencion { get; set; }

        [DataType(DataType.Currency)]
        public decimal Devolucion { get; set; }

        [DataType(DataType.Currency)]
        public decimal AvenceFisicoProgramado { get; set; }
        public decimal AvanceFisicoReal { get; set; }
        public decimal AvanceFinancieron { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }

        [DataType(DataType.Currency)]
        public decimal Pagado { get; set; }
        public bool Activo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Registro { get; set; }


        public int? IdRecurso { get; set; }
        public decimal? ImportePorEjercer { get; set; }


    }


}
