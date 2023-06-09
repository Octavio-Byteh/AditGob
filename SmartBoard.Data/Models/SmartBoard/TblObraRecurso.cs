﻿using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObraRecurso
    {
        public TblObraRecurso()
        {
            TblObraEstimacions = new HashSet<TblObraEstimacion>();
        }

        public int Id { get; set; }
        public int IdTblobra { get; set; }
        public int? IdTiporecurso { get; set; }
        public int? IdRamo { get; set; }
        public int? IdRubro { get; set; }
        public int? IdFondo { get; set; }
        public int? IdRecurso { get; set; }
        public int? IdEjercicio { get; set; }
        public int? IdPrograma { get; set; }
        public int? IdSubprograma { get; set; }
        public int? IdClasificacion { get; set; }
        public decimal? Autorizados { get; set; }
        public decimal ImporteContratado { get; set; }
        public decimal ImporteModificado { get; set; }
        public decimal ImporteEjercido { get; set; }
        public decimal ImportePorEjercer { get; set; }
        public bool Activo { get; set; }
        public DateTime Registro { get; set; }
        public string Norma { get; set; }
        public int? IdClasificadorN1 { get; set; }
        public int? IdClasificadorN2 { get; set; }
        public int? IdClasificadorN3 { get; set; }
        public decimal ImporteContratadoMinimo { get; set; }
        public decimal ImporteContratadoMaximo { get; set; }

        public virtual CatClasificacion IdClasificacionNavigation { get; set; }
        public virtual CatClasificador IdClasificadorN1Navigation { get; set; }
        public virtual CatClasificador IdClasificadorN2Navigation { get; set; }
        public virtual CatClasificador IdClasificadorN3Navigation { get; set; }
        public virtual CatEjercicio IdEjercicioNavigation { get; set; }
        public virtual CatFondo IdFondoNavigation { get; set; }
        public virtual CatPrograma IdProgramaNavigation { get; set; }
        public virtual CatRamo IdRamoNavigation { get; set; }
        public virtual CatOrigenrecurso IdRecursoNavigation { get; set; }
        public virtual CatRubro IdRubroNavigation { get; set; }
        public virtual CatSubprograma IdSubprogramaNavigation { get; set; }
        public virtual TblObra IdTblobraNavigation { get; set; }
        public virtual CatTipoRecurso IdTiporecursoNavigation { get; set; }
        public virtual ICollection<TblObraEstimacion> TblObraEstimacions { get; set; }
    }
}
