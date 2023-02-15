using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblPoadetalleArea
    {
        public int Id { get; set; }
        public int Idpoadetalle { get; set; }
        public int Idarea { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Comentarios { get; set; }

        public virtual CatArea IdareaNavigation { get; set; }
        public virtual TblPoadetalle IdpoadetalleNavigation { get; set; }
    }
}
