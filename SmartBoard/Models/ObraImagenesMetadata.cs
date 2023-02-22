using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBoard.Models
{
    public partial class ObrasImagenesMetadata
    {

        public int IdObra { get; set; }
        public string Pathimagen { get; set; }
        public string Descripcion { get; set; }

    }

    public partial class DocumentoImagenesMetadata
    {

        public int IdDoc { get; set; }
        public string filename { get; set; }
        public string Pathimagen { get; set; }
        public string Descripcion { get; set; }

    }
}
