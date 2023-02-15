using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblObraDocProcHistorium
    {
        public int Id { get; set; }
        public int IdObraDocumentoProceso { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Categoria { get; set; }

        public virtual TblObradocumentoproceso IdObraDocumentoProcesoNavigation { get; set; }
    }
}
