using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaME.Dto.Response
{
    public class PedidoDetalleDtoResponse
    {
        public int Id { get; set; }
        public ProductoDtoResponse? Producto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }
    }
}
