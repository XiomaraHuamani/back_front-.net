using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
	[Table("Repartidores")]
	public class Repartidor : EntityBase
	{
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? PlacaVehiculo { get; set; }
    }
}

