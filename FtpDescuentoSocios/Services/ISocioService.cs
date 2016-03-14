using System.Collections.Generic;
using FtpDescuentoSocios.Model;

namespace FtpDescuentoSocios.Services
{
    interface ISocioService
    {
        IEnumerable<Socio> GetAllSocios();
    }
}
