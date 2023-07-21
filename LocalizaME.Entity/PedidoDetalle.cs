using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalizaME.Entity
{
	[Table("PedidosDetalles")]
	public class PedidoDetalle
	{
		public int Id { get; set; }
		public Pedido? Pedido { get; set; }
		public int PedidoId { get; set; }
		public Producto? Producto { get; set; }
		public int ProductoId { get; set; }
		public decimal? Cantidad { get; set; }
		public decimal? Precio { get; set; }
	}
}

