using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.Entities.DevLabEntity
{
    public class EntityCliente
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public int IdTipoCliente { get; set; }
        public string? TipoCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? RFC { get; set; }
    }
}
