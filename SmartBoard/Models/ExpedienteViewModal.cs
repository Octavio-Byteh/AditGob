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

    public partial class ExpedienteContratoViewModal
    {
   

        [Required(ErrorMessage = "ZAP es campo obligatorio")]
        [Display(Name = "ZAP")]
        public int? Idzap { get; set; }

        [Required(ErrorMessage = "Normativa Aplicable es campo obligatorio")]
        [Display(Name = "Normativa Aplicable")]
        public int? IdnormativaAplicable { get; set; }

        [Required(ErrorMessage = "Modalidad de ejecución es campo obligatorio")]
        [Display(Name = "Modalidad de ejecución")]
        public int? IdmodalidadEjecicion { get; set; }

        [Required(ErrorMessage = "Contratación es campo obligatorio")]
        [Display(Name = "Contratacion")]
        public int? Idcontratacion { get; set; }


        //[Required(ErrorMessage = "Adjudicación es campo obligatorio")]
        [Display(Name = "Adjudicación")]
        public int? IdtipoAdjudicacion { get; set; }


        [Required(ErrorMessage = "Tipo contrato es campo obligatorio")]
        [Display(Name = "Tipo contrato")]
        public int? IdtipoContrato { get; set; }


        [Required(ErrorMessage = "Grado de Marginación es campo obligatorio")]
        [Display(Name = "Grado de Marginación")]
        public int? Idgradomarginal { get; set; }

        public string Localidad { get; set; }
        //public int? Idgradomarginal { get; set; }
        //public int? IdnormativaAplicable { get; set; }
        //public int? IdmodalidadEjecicion { get; set; }
        //public int? Idcontratacion { get; set; }
        //public int? IdtipoAdjudicacion { get; set; }
        //public int? IdtipoContrato { get; set; }

        [Required(ErrorMessage = "Entidad Ejecutora es campo obligatorio")]
        [Display(Name = "Entidad Ejecutora")]
        public string EntidadEjecutora { get; set; }

        [Required(ErrorMessage = "Contratista  es campo obligatorio")]
        [Display(Name = "Contratista")]
        public string ContratistaNombre { get; set; }

        [Required(ErrorMessage = "Benficiarios  es campo obligatorio")]
        [Display(Name = "Beneficiarios")]
        public string BeneficiarioNombre { get; set; }
        //public string BeneficiarioDomicilio { get; set; }


        [Required(ErrorMessage = "Avance Fisico campo obligatorio")]
        [Display(Name = "Avance Fisico")]
        public decimal? Porcentajeavance { get; set; }

        [Required(ErrorMessage = "Avance financiero campo obligatorio")]
        [Display(Name = "Avance financiero")]
        public decimal? AvanceFinanciero { get; set; }

    }
    public partial class ExpedienteViewModal : ExpedienteContratoViewModal
    {
        public int Id { get; set; }
     
        public int? Idpoadetalle { get; set; }
   

        [Required(ErrorMessage = "Región es campo obligatorio")]
        [Display(Name = "Región")]
        public int Idregion { get; set; }

        [Required(ErrorMessage = "Municipio es campo obligatorio")]
        [Display(Name = "Municipio")]
        public int Idmunicipio { get; set; }



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

    }

    
    public partial class ExpedienteViewModalDetalle : ExpedienteContratoViewModal
    {
        public int Id { get; set; }

        public int? Idpoadetalle { get; set; }
        //public int? Year { get; set; }
        //public string Region { get; set; }

        [Required(ErrorMessage = "Región es campo obligatorio")]
        [Display(Name = "Región")]
        public int? Idregion { get; set; }

        [Required(ErrorMessage = "Municipio es campo obligatorio")]
        [Display(Name = "Municipio")]
        public int? Idmunicipio { get; set; }

        //[Required(ErrorMessage = "Localidad es campo obligatorio")]
        //[Display(Name = "Localidad")]
        //public int? Idlocalidad { get; set; }


        //[Required(ErrorMessage = "Programa es campo obligatorio")]
        [Display(Name = "Programa")]
        public int? Idprogsoc { get; set; }

        //public int Iddependencia { get; set; }
        //public int? Idestadoobra { get; set; }
        //public int? Idestadorevision { get; set; }
        //public int Idprogsog { get; set; }

        //[Required(ErrorMessage = "Vertiente es campo obligatorio")]
        [Display(Name = "Vertiente")]
        public int? Idvertiente { get; set; }


        //[Required(ErrorMessage = "SubVertiente es campo obligatorio")]
        [Display(Name = "SubVertiente")]
        public int? Idsubvertiente { get; set; }

        //[Required(ErrorMessage = "Tipo es campo obligatorio")]
        //[Display(Name = "Tipo")]
        //public int? Idcategoria { get; set; }
        //public int Idunidadmedida { get; set; }
        //public int Idejecutor { get; set; }
        //public int Ideje { get; set; }
        //public int? Numeroobra { get; set; }


        [Required(ErrorMessage = "Nombre es campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombreobra { get; set; }
        //public string Descripcion { get; set; }
        public decimal? Inversion { get; set; }
        //public string Fuentefinanciamiento { get; set; }
        public string Coordenadax { get; set; }
        public string Coordenaday { get; set; }

        public string Coordenadas { get; set; }

        //public bool? Inaguracion { get; set; }
        //public int? PeriodoInforme { get; set; }
        //public decimal? Porcentajeavance { get; set; }
        //public DateTime? Fechainicio { get; set; }
        //public DateTime? Fechatermino { get; set; }
        //public bool? Posibleconflicto { get; set; }
        //public string Observaciones { get; set; }
        //public bool? Georeferenciado { get; set; }
        //public int? NumeroreferenciaCiceco { get; set; }
        //public string Imagenobra { get; set; }
        //public string Observacionesrevision { get; set; }
        //public DateTime Fecharegistro { get; set; }
        //public string BeneficiarioNombre { get; set; }
        //public string BeneficiarioDomicilio { get; set; }

        [Required(ErrorMessage = "No. De Contrato es campo obligatorio")]
        [Display(Name = "No. De Contrato")]
        public string folio { get; set; }

        public decimal? InversionFederal { get; set; }
        public decimal? InversionEstatal { get; set; }
        public decimal? InversionMunicipal { get; set; }
        public decimal? InversionBeneficiario { get; set; }


        //public int CantidadBeneficioHombre { get; set; }
        //public int CantidadBeneficioMujer { get; set; }
        //public int CantidadUnidadmedida { get; set; }

        [Required(ErrorMessage = "No. De Obra es campo obligatorio")]
        [Display(Name = "No. De Obra")]
        public string Expediente { get; set; }
        //public decimal AvanceFinanciero { get; set; }


        public List<ExpedientePlantillaViewModel> checklist { get; set; }
        public List<ExpedienteDocumentoViewModel> documentoproceso { get; set; }


        public EstimacionesViewModal estimacion { get; set; }
        public List<EstimacionesViewModal> estimaciones { get; set; }
        public List<ObraconceptoViewModal> conceptos { get; set; }
        public RecursosViewModal recurso { get; set; }
        public List<RecursosViewModal> recursos { get; set; }


    }
}
