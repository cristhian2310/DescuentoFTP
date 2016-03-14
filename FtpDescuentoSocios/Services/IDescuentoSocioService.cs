using System.Collections.Generic;

namespace FtpDescuentoSocios.Services
{
    interface IDescuentoSocioService
    {
        void AgregarDescuentoSocios(List<Model.DescuentoSocio> descuentoSocio);
    }
}
