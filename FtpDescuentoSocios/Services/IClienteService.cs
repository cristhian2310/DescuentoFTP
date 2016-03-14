using FtpDescuentoSocios.Model;

namespace FtpDescuentoSocios.Services
{
    interface IClienteService
    {
        Cliente GetClienteByNroTarjeta(string tarjeta);

    }
}
