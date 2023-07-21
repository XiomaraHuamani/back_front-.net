using System;
namespace LocalizaME.Dto.Response
{
	public class ProductoDtoResponse
	{
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? UnidadMedida { get; set; }
        public decimal? Precio { get; set; }
    }
}

