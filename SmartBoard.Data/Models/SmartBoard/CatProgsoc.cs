using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatProgsoc
    {
        public CatProgsoc()
        {
            TblObras = new HashSet<TblObra>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Invfed { get; set; }
        public bool Invest { get; set; }
        public bool Invmun { get; set; }
        public bool Invben { get; set; }
        public bool Invorg { get; set; }
        public string Agrupa { get; set; }
        public string Subagrupa { get; set; }
        public string Subagrupa2 { get; set; }
        public string Subagrupa3 { get; set; }
        public string Descripcion2 { get; set; }
        public string Clasifiacion { get; set; }
        public bool? Sumar { get; set; }
        public decimal? Presupuesto { get; set; }
        public DateTime? Fechap { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool Activo { get; set; }
        public int? Clave { get; set; }

        public virtual ICollection<TblObra> TblObras { get; set; }
    }
}
