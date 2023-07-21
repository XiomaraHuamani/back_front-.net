using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
	[Table("Clientes")]
	public class Cliente : EntityBase
	{
		[StringLength(100)]
		public string? RazonSocial { get; set; }
        [StringLength(20)]
        public string? Telefono { get; set; }
        [StringLength(250)]
        public string? Direccion { get; set; }
        [StringLength(100)]
        public string? Distrito { get; set; }
        [StringLength(15)]
        public string? Latitud { get; set; }
        [StringLength(15)]
        public string? Longitud { get; set; }
	}
}

