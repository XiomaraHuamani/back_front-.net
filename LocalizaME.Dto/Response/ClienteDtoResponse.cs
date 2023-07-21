using System;
using System.ComponentModel.DataAnnotations;

namespace LocalizaME.Dto.Response
{
	public class ClienteDtoResponse
	{
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Distrito { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}

