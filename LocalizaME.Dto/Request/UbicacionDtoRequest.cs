using System;
namespace LocalizaME.Dto.Request
{
	public class UbicacionDtoRequest
	{
        public DateTime FechaHora { get; set; }
        public int RepartidorId { get; set; }
        public string? Telefono { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}

