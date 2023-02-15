using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoadetalleinversion
    {
        public int Id { get; set; }
        public int Idpoadetalle { get; set; }
        public int Idorigenrecurso { get; set; }
        public decimal Monto { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }

        public virtual CatOrigenrecurso IdorigenrecursoNavigation { get; set; }
        public virtual TblPoadetalle IdpoadetalleNavigation { get; set; }
    }
}
