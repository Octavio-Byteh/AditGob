using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class StgClasificador
    {
        public double? Nivel3 { get; set; }
        public double? Nivel2 { get; set; }
        public double? Nivel1 { get; set; }
        public string Final { get; set; }
        public string Mitad { get; set; }
        public string Inicio { get; set; }
        public double? Largo { get; set; }
        public double? Clave { get; set; }
        public string Nombre { get; set; }
    }
}
