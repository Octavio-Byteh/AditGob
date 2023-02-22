using System;
using System.Collections.Generic;

namespace SmartBoard.Data.Models.SmartBoard
{
    public partial class CatChecklist
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Idtipochecklist { get; set; }
        public int Idcategoriachecklist { get; set; }
        public bool Activo { get; set; }
        public bool Estitilo { get; set; }
        public string Titulo { get; set; }
        public int? Secuencia { get; set; }
        public string Norma { get; set; }
        public string Nota { get; set; }
        public string Categoria { get; set; }
        public int? Numero { get; set; }
        public bool? ArchivoPermite { get; set; }
        public bool ArchivoMultiple { get; set; }
        public string ArchivoExtensions { get; set; }
        public string HexColor { get; set; }

        public virtual CatCategoriaCheckList IdcategoriachecklistNavigation { get; set; }
        public virtual CatTipoCheckList IdtipochecklistNavigation { get; set; }
    }
}
