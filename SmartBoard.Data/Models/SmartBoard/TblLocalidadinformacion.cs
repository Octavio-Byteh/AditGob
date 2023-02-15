using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class TblLocalidadinformacion
    {
        public int Id { get; set; }
        public int Idlocalidad { get; set; }
        public double? PobnTt { get; set; }
        public double? Pobn15oMyAanlf { get; set; }
        public double? Pobn15MyCpmraIpta { get; set; }
        public double? PobSinAgua { get; set; }
        public double? PobSinDren { get; set; }
        public double? PobSinElect { get; set; }
        public double? PobPisoTierra { get; set; }
        public double? DefAgua { get; set; }
        public double? DefDren { get; set; }
        public double? DefElec { get; set; }
        public double? PpobPisoTierra { get; set; }
        public string Mrg { get; set; }

        public virtual CatLocalidad IdlocalidadNavigation { get; set; }
    }
}
