using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatClasificador
    {
        public CatClasificador()
        {
            TblObraRecursoIdClasificadorN1Navigations = new HashSet<TblObraRecurso>();
            TblObraRecursoIdClasificadorN2Navigations = new HashSet<TblObraRecurso>();
            TblObraRecursoIdClasificadorN3Navigations = new HashSet<TblObraRecurso>();
        }

        public int Id { get; set; }
        public double? Nivel3 { get; set; }
        public double? Nivel2 { get; set; }
        public double? Nivel1 { get; set; }
        public string Final { get; set; }
        public string Mitad { get; set; }
        public string Inicio { get; set; }
        public double? Largo { get; set; }
        public double? Clave { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TblObraRecurso> TblObraRecursoIdClasificadorN1Navigations { get; set; }
        public virtual ICollection<TblObraRecurso> TblObraRecursoIdClasificadorN2Navigations { get; set; }
        public virtual ICollection<TblObraRecurso> TblObraRecursoIdClasificadorN3Navigations { get; set; }
    }
}
