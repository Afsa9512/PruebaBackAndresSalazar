using PruebaDobleV.Entities.DevLabEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.Entities.ViewModels
{
    public class ViewModelFactura
    {
        public EntityFactura? EntityFactura { get; set; }
        public List<EntityDetallesFactura>? DetallesFactura { get; set; }
    }
}
