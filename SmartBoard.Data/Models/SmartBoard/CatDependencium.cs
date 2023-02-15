﻿using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatDependencium
    {
        public CatDependencium()
        {
            TblObras = new HashSet<TblObra>();
            TblPoadetalles = new HashSet<TblPoadetalle>();
            TblPoas = new HashSet<TblPoa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Titular { get; set; }

        public virtual ICollection<TblObra> TblObras { get; set; }
        public virtual ICollection<TblPoadetalle> TblPoadetalles { get; set; }
        public virtual ICollection<TblPoa> TblPoas { get; set; }
    }
}
