using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaME.Dto.Response
{
    public class PedidoDtoResponse
    {
        public int Id { get; set; }
        public DateTime? FechaHoraPedido { get; set; }
        public string? Cliente { get; set; }
        public string? Direccion { get; set; }
        public string? Distrito { get; set; }
        public string? Telefono { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public string? Repartidor { get; set; }
        public DateTime? FechaHoraAtencion { get; set; }
        public decimal? Total { get; set; }
    }
}
