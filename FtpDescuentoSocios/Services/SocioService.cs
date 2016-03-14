using System.Collections.Generic;
using FtpDescuentoSocios.Model;

namespace FtpDescuentoSocios.Services
{
    class SocioService : Service<Socio>, ISocioService
    {
        public IEnumerable<Socio> GetAllSocios()
        {
            return GetAll();
        }
    }
}
