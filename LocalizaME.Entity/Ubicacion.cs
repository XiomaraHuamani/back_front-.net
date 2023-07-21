using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
    [Table("Ubicaciones")]
    public class Ubicacion : EntityBase
	{
        public DateTime FechaHora { get; set; }
        public Repartidor? Repartidor { get; set; }
        public int RepartidorId { get; set; }
        public string? Telefono { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}

