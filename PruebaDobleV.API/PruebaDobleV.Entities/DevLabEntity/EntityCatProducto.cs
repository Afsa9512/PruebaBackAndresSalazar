using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace PruebaDobleV.Entities.DevLabEntity
{
    public class EntityCatProducto
    {
        public int Id { get; set; }
        public string? NombreProducto { get; set; }
        public string? ImagenProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? Ext { get; set; }
    }
}
