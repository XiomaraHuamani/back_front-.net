using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaME.Dto.Request
{
    public class PedidoDtoRequest
    {
        public int ClienteId { get; set; }
        public int RepartidorId { get; set; }
        public int ProductoId { get; set; }
        public decimal? Cantidad { get; set; }
    }
}
