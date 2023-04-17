using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBoard.Models
{

    public class ObrasViewModel
    {
        public int? cantidad { get; set; }
        public decimal? totalInversion { get; set; }
        public decimal? totalInversionMunicipal { get; set; }

        public int? Year { get; set; }
        
                    public string Region { get; set; }
        public string Municipio { get; set; }
        public string NumeroDeObra { get; set; }
        public string NombreDeLaObra { get; set; }
        public string Descripcion { get; set; }
        public string Inversion { get; set; }
        public string InversionMunicipal { get; set; }

        public double? coordenadax { get; set; }
        public double? coordenaday { get; set; }

        public string strcoordenadax { get; set; }
        public string strcoordenaday { get; set; }

        public int id { get; set; }
        public int idestatusobra { get; set; }
    }

    public class ExpedientePlantillaViewModel
    {
        public int idObra { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public bool administracion { get; set; }
        public bool licitacion { get; set; }
        public bool invitacion { get; set; }
        public bool adjudicacion { get; set; }

        public bool activo { get; set; }

        public int Numero { get; set; }
        public int? PaginaInicio { get; set; }
        public int? PaginaFinal { get; set; }
        public string Observaciones { get; set; }
        public bool? Estitulo { get; set; }
        public string Titulo { get; set; }
        public string TituloShort { get; set; }

        public string Norma { get; set; }

        public bool ArchivoPermite { get; set; }
        public bool ArchivoMultiple { get; set; }
        public string ArchivoExtensions { get; set; }
        public string HexColor { get; set; }
        public int Secuencia { get; set; }

    }

    public class ExpedienteDocumentoViewModel
    {
        public int idObra { get; set; }
        public int id { get; set; }

        public string categoria { get; set; }
        public string estatus { get; set; }
        public string documento { get; set; }
        public string rutaarchivo { get; set; }
        public string nombrearchivo { get; set; }
        public bool aprobado { get; set; }

        public bool activo { get; set; }

        public int Numero { get; set; }
        public int? PaginaInicio { get; set; }
        public int? PaginaFinal { get; set; }
        public string Observaciones { get; set; }
        public bool? Estitulo { get; set; }
        public string Titulo { get; set; }
        public string TituloShort { get; set; }

        public string Norma { get; set; }

        public bool ArchivoPermite { get; set; }
        public bool ArchivoMultiple { get; set; }
        public string ArchivoExtensions { get; set; }
        public string HexColor { get; set; }
        public int Secuencia { get; set; }

        //public List<documento> documentos { get; set; }
    }

    public class ObraChkDocumento
    {
        public bool multiplefile { get; set; }
        public int idObra { get; set; }
        public int id { get; set; }
        public string path { get; set; }
        public string filename { get; set; }
    }


    public partial class TblPoadetalleViewModal
    {
       
        public int Id { get; set; }
        public int IdProgramaoperativo { get; set; }

        [Required(ErrorMessage = "La fecha inicio es campo obligatorio")]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime Fechainicio { get; set; }


        [Required(ErrorMessage = "La fecha termino es campo obligatorio")]
        [Display(Name = "Fecha termino")]
        [DataType(DataType.Date)]
        public DateTime Fechatermino { get; set; }
        public int Iddependencia { get; set; }

        [Required(ErrorMessage = "Objetivo es campo obligatorio")]
        [Display(Name = "Objetivo ")]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "Actividades  es campo obligatorio")]
        [Display(Name = "Actividades ")]
        public string Actividades { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool Activo { get; set; }
        public DateTime Fechaactividad { get; set; }
        public int Year { get; set; }
        [Required(ErrorMessage = "Nombre es campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        //public virtual TblPoa IdProgramaoperativoNavigation { get; set; }
        //public virtual CatDependencium IddependenciaNavigation { get; set; }
        //public virtual ICollection<TblObra> TblObras { get; set; }
        //public virtual ICollection<TblPoadetalleArea> TblPoadetalleAreas { get; set; }
        //public virtual ICollection<TblPoadetalleOd> TblPoadetalleOds { get; set; }
        //public virtual ICollection<TblPoadetallePed> TblPoadetallePeds { get; set; }
        //public virtual ICollection<TblPoadetalleinversion> TblPoadetalleinversions { get; set; }
    }
    public class PoaViewModal
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "El Tipo de programa es campo obligatorio")]
        [Display(Name = "Tipo de Programa")]
        public int Idtipoprograma { get; set; }

        [Required(ErrorMessage = "La fecha de elaboración es campo obligatorio")]
        [Display(Name = "Fecha de elaboración")]
        [DataType(DataType.Date)]
        public DateTime Fechaelabora { get; set; }


        [Required(ErrorMessage = "La fecha de actualización es campo obligatorio")]
        [Display(Name = "Fecha de actualización")]
        [DataType(DataType.Date)]
        public DateTime? Fechaactualizacion { get; set; }

        [Required(ErrorMessage = "Nombre del programa  es campo obligatorio")]
        [Display(Name = "Nombre del programa presupuestario")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Eje es campo obligatorio")]
        [Display(Name = "Eje")]
        public int? Ideje { get; set; }

        [Required(ErrorMessage = "Estrategia es campo obligatorio")]
        [Display(Name = "Estrategia")]
        public int? Idestrategia { get; set; }

        [Required(ErrorMessage = "Objetivo es campo obligatorio")]
        [Display(Name = "Objetivo")]
        public int? Idobjetivo { get; set; }

        [Required(ErrorMessage = "Línea de Acción es campo obligatorio")]
        [Display(Name = "Línea de Acción")]
        public int? Idlineaaccion { get; set; }


        public DateTime Fecharegistro { get; set; }
        public string Comentarios { get; set; }
        public int Activo { get; set; }

        [Required(ErrorMessage = "El año es requerido")]
        [Display(Name = "Programa Operativo Anual")]
        public int? Years { get; set; }


        public List<TblPoadetalleViewModal> PoaDetalle { get; set; }
        

    }

    public class YearViewModal
    {
        public int id { get; set; }
        public int year { get; set; }
    }

    public class ExpedienteNamesViewmodal
    {
        public string NombreZap { get; set; }
        public string NombreMunicipio { get; set; }
        public string NombreModalidadEjecucion { get; set; }
        public string NombreTipoAdjudicacion { get; set; }
        public string NombreContratacion { get; set; }
        public string NombreTipoContrato { get; set; }
        
        public string NombreGradoMarginal { get; set; }
    }

    public partial class ExpedienteContratoViewModal : ExpedienteNamesViewmodal
    {

        //[Required(ErrorMessage = "Entidad Ejecutora es campo obligatorio")]
        [Display(Name = "Entidad Ejecutora")]
        public int? Idejecutor { get; set; }

        //[Required(ErrorMessage = "ZAP es campo obligatorio")]
        [Display(Name = "ZAP")]
        public int? Idzap { get; set; }

        //[Required(ErrorMessage = "Normativa Aplicable es campo obligatorio")]
        [Display(Name = "Normativa Aplicable")]
        public int? IdnormativaAplicable { get; set; }

        //[Required(ErrorMessage = "Modalidad de ejecución es campo obligatorio")]
        [Display(Name = "Modalidad de ejecución")]
        public int? IdmodalidadEjecicion { get; set; }

        //[Required(ErrorMessage = "Contratación es campo obligatorio")]
        [Display(Name = "Contratacion")]
        public int? Idcontratacion { get; set; }

        
        [Display(Name = "Adjudicación")]
        public int? IdtipoAdjudicacion { get; set; }


        //[Required(ErrorMessage = "Tipo contrato es campo obligatorio")]
        [Display(Name = "Tipo contrato")]
        public int? IdtipoContrato { get; set; }


        //[Required(ErrorMessage = "Grado de Marginación es campo obligatorio")]
        [Display(Name = "Grado de Marginación")]
        public int? Idgradomarginal { get; set; }

        public string Localidad { get; set; }
       

        //[Required(ErrorMessage = "Entidad Ejecutora es campo obligatorio")]
        [Display(Name = "Entidad Ejecutora")]
        public string EntidadEjecutora { get; set; }

        //[Required(ErrorMessage = "Contratista  es campo obligatorio")]
        [Display(Name = "Contratista")]
        public string ContratistaNombre { get; set; }

        //[Required(ErrorMessage = "Benficiarios  es campo obligatorio")]
        [Display(Name = "Beneficiarios")]
        public string BeneficiarioNombre { get; set; }
        //public string BeneficiarioDomicilio { get; set; }


        //[Required(ErrorMessage = "Avance Fisico campo obligatorio")]
        [Display(Name = "Avance Fisico")]
        public decimal? Porcentajeavance { get; set; }

        //[Required(ErrorMessage = "Avance financiero campo obligatorio")]
        [Display(Name = "Avance financiero")]
        public decimal? AvanceFinanciero { get; set; }

        // Cambios
        //[Required(ErrorMessage = "Eje es campo obligatorio")]
        [Display(Name = "Eje")]
        public int? Ideje { get; set; }

        //[Required(ErrorMessage = "Estrategia es campo obligatorio")]
        [Display(Name = "Estrategia")]
        public int? Idestrategia { get; set; }
           
        //[Required(ErrorMessage = "Línea de Acción es campo obligatorio")]
        [Display(Name = "Línea de Acción")]
        public int? Idlineaaccion { get; set; }

        [Display(Name = "Programado Inicio")]
        [DataType(DataType.Date)]
        public DateTime? EoPrograInicio { get; set; }
        
        [Display(Name = "Programado Fin")]
        [DataType(DataType.Date)]
        public DateTime? EoPrograFin { get; set; }
        
        [Display(Name = "Re Programado Inicio")]
        [DataType(DataType.Date)]
        public DateTime? EoReprograInicio { get; set; }
        
        [Display(Name = "Re Programado Fin")]
        [DataType(DataType.Date)]
        public DateTime? EoReprograFin { get; set; }
        
        [Display(Name = "Real Inicio")]
        [DataType(DataType.Date)]
        public DateTime? EoRealInicio { get; set; }


        [Display(Name = "Real Fin")]
        [DataType(DataType.Date)]
        public DateTime? EoRealFin { get; set; }

        [Display(Name = "Tipo Obra")]
        public int IdtipoObra { get; set; }

        [Display(Name = "Proveedor Adjudicado")]
        public string ProveedorAdjudicado { get; set; }
        
        [Display(Name = "Entidad Requiriente")]
        public string EntidadRequiriente { get; set; }


    }
    public partial class ExpedienteViewModal : ExpedienteContratoViewModal
    {
        public int? year { get; set; }
        public int? IdEjercicio { get; set; }

        public int Id { get; set; }
     
        public int? Idpoadetalle { get; set; }
   

        [Required(ErrorMessage = "Región es campo obligatorio")]
        [Display(Name = "Región")]
        public int Idregion { get; set; }

        //[Required(ErrorMessage = "Entidad Ejecutora es campo obligatorio")]
        //[Display(Name = "Entidad Ejecutora")]
        //public int? Idejecutor { get; set; }

        [Required(ErrorMessage = "Municipio es campo obligatorio")]
        [Display(Name = "Municipio")]
        public int Idmunicipio { get; set; }


        public string Region { get; set; }

        [Required(ErrorMessage = "Nombre es campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombreobra { get; set; }
        //public string Descripcion { get; set; }
        public decimal? Inversion { get; set; }
        //public string Fuentefinanciamiento { get; set; }
        public string Coordenadax { get; set; }
        public string Coordenaday { get; set; }

        public string Coordenadas { get; set; }


        [Required(ErrorMessage = "No. De Contrato es campo obligatorio")]
        [Display(Name = "No. De Contrato")]
        //[RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(255, ErrorMessage = "El número es demasiado largo")]
        public string folio { get; set; }

        public decimal? InversionFederal { get; set; }
        public decimal? InversionEstatal { get; set; }
        public decimal? InversionMunicipal { get; set; }
        public decimal? InversionBeneficiario { get; set; }


        [Required(ErrorMessage = "No. De Obra es campo obligatorio")]
        [Display(Name = "No. De Obra")]
        //[RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(255, ErrorMessage = "El número de Obra es demasiado largo")]
        public string Expediente { get; set; }
        //public decimal AvanceFinanciero { get; set; }


        [Display(Name = "Objeto de contrato")]
        public string Contrato { get; set; }

        [Display(Name = "Fecha Contrato Inicio")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataInicio { get; set; }

        [Display(Name = "Fecha Contrato Modificada")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataModificada { get; set; }

        [Display(Name = "Fecha Contrato Final")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataFinal { get; set; }

        public List<ExpedientePlantillaViewModel>? checklist { get; set; }
        public List<ExpedienteDocumentoViewModel>? documentoproceso { get; set; }

        public List<EstimacionesViewModal>? estimaciones { get; set; }
        public List<ObraconceptoViewModal>? conceptos { get; set; }
        public List<RecursosViewModal>? recursos { get; set; }

    }


    public partial class ExpedienteViewModalDetalle : ExpedienteContratoViewModal
    {

        public int? year { get; set; }
        public int? IdEjercicio { get; set; }
        public int Id { get; set; }

        public int? Idpoadetalle { get; set; }
      
        [Required(ErrorMessage = "Región es campo obligatorio")]
        [Display(Name = "Región")]
        public int? Idregion { get; set; }

        [Required(ErrorMessage = "Municipio es campo obligatorio")]
        [Display(Name = "Municipio")]
        public int? Idmunicipio { get; set; }

        public string Region { get; set; }


        [Display(Name = "Programa")]
        public int? Idprogsoc { get; set; }

        
        [Display(Name = "Vertiente")]
        public int? Idvertiente { get; set; }


        [Display(Name = "SubVertiente")]
        public int? Idsubvertiente { get; set; }

        [Required(ErrorMessage = "Nombre es campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombreobra { get; set; }
        public decimal? Inversion { get; set; }
        public string Coordenadax { get; set; }
        public string Coordenaday { get; set; }

        public string Coordenadas { get; set; }

        [Required(ErrorMessage = "No. De Contrato es campo obligatorio")]
        [Display(Name = "No. De Contrato")]
        public string folio { get; set; }

        public decimal? InversionFederal { get; set; }
        public decimal? InversionEstatal { get; set; }
        public decimal? InversionMunicipal { get; set; }
        public decimal? InversionBeneficiario { get; set; }


        [Required(ErrorMessage = "No. De Obra es campo obligatorio")]
        [Display(Name = "No. De Obra")]
        public string Expediente { get; set; }
        //public decimal AvanceFinanciero { get; set; }



        [Display(Name = "Objeto de contrato")]
        public string Contrato { get; set; }

        [Display(Name = "Fecha Contrato Inicio")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataInicio { get; set; }

        [Display(Name = "Fecha Contrato Modificada")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataModificada { get; set; }

        [Display(Name = "Fecha Contrato Final")]
        [DataType(DataType.Date)]
        public DateTime? FechaContrataFinal { get; set; }

        public List<ExpedientePlantillaViewModel>? checklist { get; set; }
        public List<ExpedienteDocumentoViewModel>? documentoproceso { get; set; }


        public EstimacionesViewModal? estimacion { get; set; }
        public List<EstimacionesViewModal>? estimaciones { get; set; }
        public List<PagosViewModal>? pagos { get; set; }
        public List<ObraconceptoViewModal>? conceptos { get; set; }
        public RecursosViewModal? recurso { get; set; }
        public List<RecursosViewModal>? recursos { get; set; }

        public TipoConceptoViewModal? TipoConcepto { get; set; }

        public List<ObrasImagenesMetadata>? obrasImagenesMetadata { get; set; }

    }

    public class TipoConceptoViewModal
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public string color { get; set; }
    }

}
