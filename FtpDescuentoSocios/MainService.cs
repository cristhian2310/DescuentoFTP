using System;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using FtpDescuentoSocios.Services;
using FtpDescuentoSocios.Utilities;

namespace FtpDescuentoSocios
{
    public partial class MainService : ServiceBase
    {
        private static readonly Timer SyncTimer = new Timer();

        readonly SocioService _socioService = new SocioService();

        public MainService()
        {
            InitializeComponent();
        }

        public void Test()
        {
            var socios = _socioService.GetAllSocios();

            var servidorFtp = ConfigurationManager.AppSettings["HostFtp"];

            foreach (var socio in socios.Where(socio => socio.UsuarioFtp != null))
            {
                FileHandler.ProcessFile(socio, servidorFtp, socio.UsuarioFtp, socio.PasswordFtp);
            }

        }
        
        protected override void OnStart(string[] args)
        {

            var interval = TimeSpan.FromHours(Convert.ToDouble(ConfigurationManager.AppSettings["tiempoEjecucionHora"])).TotalMilliseconds;

            EventLog.WriteEntry("My simple service started.");

            SyncTimer.Interval = interval;

            SyncTimer.Elapsed += Iniciar;

            SyncTimer.Start();

        }

        protected override void OnStop()
        {
            SyncTimer.Enabled = false;
        }

        public void Iniciar(object sender, ElapsedEventArgs e)
        {
            var socios = _socioService.GetAllSocios();

            var servidorFtp = ConfigurationManager.AppSettings["HostFtp"];

            foreach (var socio in socios.Where(socio => socio.UsuarioFtp != null))
            {
                FileHandler.ProcessFile(socio, servidorFtp, socio.UsuarioFtp, socio.PasswordFtp);
            }
        }



    }
}
