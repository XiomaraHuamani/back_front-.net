using System;
using System.ComponentModel.DataAnnotations;

namespace LocalizaME.Dto.Request
{
	public class ProductoDtoRequest
	{
        [Required(ErrorMessage = "Descripcion obligatoria")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Marca obligatoria")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Unidad de medida obligatoria")]
        public string? UnidadMedida { get; set; }
        [Required(ErrorMessage = "Precio obligatorio")]
        public decimal? Precio { get; set; }
    }
}

