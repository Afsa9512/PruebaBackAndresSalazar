using PruebaDobleV.Entities.DevLabEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.BL.Interfaces
{
    public interface ITipoClienteBL
    {
        public Task<EntityResult<List<EntityCatTipoCliente>>> GetAllTipoClientesAsync();
        public Task<EntityResult<EntityCatTipoCliente>> GetTipoClienteByIdAsync(int idTipoCliente);
        public string CreateTipoCliente(EntityCatTipoCliente dto);
        public string UpdateTipoCliente(EntityCatTipoCliente dto);
    }
}
