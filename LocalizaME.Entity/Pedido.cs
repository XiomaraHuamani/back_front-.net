using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
	[Table("Pedidos")]
	public class Pedido : EntityBase
	{
		public DateTime? FechaHoraPedido { get; set; }
		public Cliente? Cliente { get; set; }
		public int ClienteId { get; set; }
        [StringLength(100)]
        public string? RazonSocial { get; set; }
        [StringLength(250)]
        public string? Direccion { get; set; }
        [StringLength(100)]
        public string? Distrito { get; set; }
        [StringLength(20)]
        public string? Telefono { get; set; }
        [StringLength(15)]
        public string? Latitud { get; set; }
        [StringLength(15)]
        public string? Longitud { get; set; }
        public Repartidor? Repartidor { get; set; }
        public int RepartidorId { get; set; }
        public DateTime? FechaHoraAtencion { get; set; }
        public decimal? Total { get; set; }
		public HashSet<PedidoDetalle>? Detalles { get; set; }
	}
}

