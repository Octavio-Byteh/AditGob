using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObra
    {
        public TblObra()
        {
            TblObraEstimacions = new HashSet<TblObraEstimacion>();
            TblObraRecursos = new HashSet<TblObraRecurso>();
            TblObrachecklists = new HashSet<TblObrachecklist>();
            TblObraconceptos = new HashSet<TblObraconcepto>();
            TblObradocumentoprocesos = new HashSet<TblObradocumentoproceso>();
        }

        public int Id { get; set; }
        public int? Idpoadetalle { get; set; }
        public int? Year { get; set; }
        public string Region { get; set; }
        public int? Idmunicipio { get; set; }
        public int? Idlocalidad { get; set; }
        public int? Iddependencia { get; set; }
        public int? Idestadoobra { get; set; }
        public int? Idestadorevision { get; set; }
        public int? Idprogsog { get; set; }
        public int? Idvertiente { get; set; }
        public int? Idsubvertiente { get; set; }
        public int? Idcategoria { get; set; }
        public int? Idunidadmedida { get; set; }
        public int? Idejecutor { get; set; }
        public int? Numeroobra { get; set; }
        public string Nombreobra { get; set; }
        public string Descripcion { get; set; }
        public decimal? Inversion { get; set; }
        public string Fuentefinanciamiento { get; set; }
        public string Coordenadax { get; set; }
        public string Coordenaday { get; set; }
        public bool Inaguracion { get; set; }
        public int? PeriodoInforme { get; set; }
        public decimal? Porcentajeavance { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechatermino { get; set; }
        public bool Posibleconflicto { get; set; }
        public string Observaciones { get; set; }
        public bool Georeferenciado { get; set; }
        public int? NumeroreferenciaCiceco { get; set; }
        public string Imagenobra { get; set; }
        public string Observacionesrevision { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public string BeneficiarioNombre { get; set; }
        public string BeneficiarioDomicilio { get; set; }
        public string Numeroobraexterno { get; set; }
        public decimal? InversionFederal { get; set; }
        public decimal? InversionEstatal { get; set; }
        public decimal? InversionMunicipal { get; set; }
        public decimal? InversionBeneficiario { get; set; }
        public int? CantidadBeneficioHombre { get; set; }
        public int? CantidadBeneficioMujer { get; set; }
        public int? CantidadUnidadmedida { get; set; }
        public string Expediente { get; set; }
        public decimal? AvanceFinanciero { get; set; }
        public string Ubicacion { get; set; }
        public string Localidad { get; set; }
        public int? Idgradomarginal { get; set; }
        public int? IdnormativaAplicable { get; set; }
        public int? IdmodalidadEjecicion { get; set; }
        public int? Idcontratacion { get; set; }
        public int? IdtipoAdjudicacion { get; set; }
        public int? IdtipoContrato { get; set; }
        public string EntidadEjecutora { get; set; }
        public string ContratistaNombre { get; set; }
        public int? Idzap { get; set; }
        public int? Ideje { get; set; }
        public int? Idestrategia { get; set; }
        public int? Idlineaacion { get; set; }
        public DateTime? EoPrograInicio { get; set; }
        public DateTime? EoPrograFin { get; set; }
        public DateTime? EoReprograInicio { get; set; }
        public DateTime? EoReprograFin { get; set; }
        public DateTime? EoRealInicio { get; set; }
        public DateTime? EoRealFin { get; set; }

        public virtual CatCategorium IdcategoriaNavigation { get; set; }
        public virtual CatContratacion IdcontratacionNavigation { get; set; }
        public virtual CatDependencium IddependenciaNavigation { get; set; }
        public virtual CatEje IdejeNavigation { get; set; }
        public virtual CatEjecutor IdejecutorNavigation { get; set; }
        public virtual CatEstadoobra IdestadoobraNavigation { get; set; }
        public virtual CatEstadorevision IdestadorevisionNavigation { get; set; }
        public virtual CatEstrategium IdestrategiaNavigation { get; set; }
        public virtual CatGradomarginal IdgradomarginalNavigation { get; set; }
        public virtual CatLineaaccion IdlineaacionNavigation { get; set; }
        public virtual CatLocalidad IdlocalidadNavigation { get; set; }
        public virtual CatModalidadEjecucion IdmodalidadEjecicionNavigation { get; set; }
        public virtual CatMunicipio IdmunicipioNavigation { get; set; }
        public virtual CatNormativaAplicable IdnormativaAplicableNavigation { get; set; }
        public virtual TblPoadetalle IdpoadetalleNavigation { get; set; }
        public virtual CatProgsoc IdprogsogNavigation { get; set; }
        public virtual CatSubvertiente IdsubvertienteNavigation { get; set; }
        public virtual CatTipoAdjudicacion IdtipoAdjudicacionNavigation { get; set; }
        public virtual CatTipoDeContrato IdtipoContratoNavigation { get; set; }
        public virtual CatUnidadmedidum IdunidadmedidaNavigation { get; set; }
        public virtual CatVertiente IdvertienteNavigation { get; set; }
        public virtual CatCattipomunicipio IdzapNavigation { get; set; }
        public virtual ICollection<TblObraEstimacion> TblObraEstimacions { get; set; }
        public virtual ICollection<TblObraRecurso> TblObraRecursos { get; set; }
        public virtual ICollection<TblObrachecklist> TblObrachecklists { get; set; }
        public virtual ICollection<TblObraconcepto> TblObraconceptos { get; set; }
        public virtual ICollection<TblObradocumentoproceso> TblObradocumentoprocesos { get; set; }
    }
}
