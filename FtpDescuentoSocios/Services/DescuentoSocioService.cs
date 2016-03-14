using System.Collections.Generic;

namespace FtpDescuentoSocios.Services
{
    public class DescuentoSocioService : Service<Model.DescuentoSocio>, IDescuentoSocioService
    {
        public void AgregarDescuentoSocios(List<Model.DescuentoSocio> descuentoSocios)
        {
            foreach (var descuentoSocio in descuentoSocios)
            {
                Insert(descuentoSocio);
            }
            Commit();
        }
    }
}
