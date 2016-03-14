using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FtpDescuentoSocios.Services;
using FtpDescuentoSocios.Utilities;

namespace FtpDescuentoSocios
{

    class Iniciadora
    {
        readonly SocioService _socioService = new SocioService();

        public void Iniciar(object sender, ElapsedEventArgs e)
        {
            var socios = _socioService.GetAllSocios();

            var servidorFtp = ConfigurationManager.AppSettings["HostFtp"];

            foreach (var socio in socios)
            {
                FileHandler.ProcessFile(socio, servidorFtp, socio.UsuarioFtp, socio.PasswordFtp);
            }
        }
    }
}
