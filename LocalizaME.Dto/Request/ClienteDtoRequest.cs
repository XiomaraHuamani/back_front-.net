using System;
using System.ComponentModel.DataAnnotations;

namespace LocalizaME.Dto.Request
{
	public class ClienteDtoRequest
	{
        [Required(ErrorMessage = "Razon social obligatoria")]
        public string? RazonSocial { get; set; }
        [Required(ErrorMessage = "Telefono obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Direccion obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Distrito obligatorio")]
        public string? Distrito { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
    }
}

