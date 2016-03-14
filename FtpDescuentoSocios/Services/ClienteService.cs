using System.Linq;
using FtpDescuentoSocios.Model;

namespace FtpDescuentoSocios.Services
{
    public class ClienteService : Service<Cliente>, IClienteService
    {
        public Cliente GetClienteByNroTarjeta(string tarjeta)
        {
            var cliente = GetBy(x => x.NroTarjeta == tarjeta).FirstOrDefault();
            
            return cliente;
        }
    }
}
