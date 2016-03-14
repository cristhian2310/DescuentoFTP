using System.ServiceProcess;

namespace FtpDescuentoSocios
{
    static class Program 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //var servicio = new MainService();
            //servicio.Test();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new MainService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
