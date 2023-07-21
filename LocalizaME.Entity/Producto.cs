using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
    [Table("Productos")]
    public class Producto : EntityBase
	{
		public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? UnidadMedida { get; set; }
		public decimal? Precio { get; set; }
		
	}
}

