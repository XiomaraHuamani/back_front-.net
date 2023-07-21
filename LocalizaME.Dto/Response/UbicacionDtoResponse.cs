using System;
namespace LocalizaME.Dto.Response
{
	public class UbicacionDtoResponse
	{
        public DateTime FechaHora { get; set; }
        public int RepartidorId { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}

