using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using FtpDescuentoSocios.Model;
using FtpDescuentoSocios.Services;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace FtpDescuentoSocios.Utilities
{
    public static class FileHandler
    {
        public static void MoveFile(string sourceFileName, string destFileName)
        {
            try
            {
                File.Move(sourceFileName, destFileName);

                var message = string.Format("El archivo {0} se ha movido exitosamente", sourceFileName);
                
                LogHandler.Log(message, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                var message = string.Format("Error: {0} Detalle: {1}", ex.Message, ex.InnerException);
                
                LogHandler.Log(message, EventLogEntryType.Warning);
            }
        }

        public static List<String> GetFileName(string usuario ,string servidorFtp, string usuarioFtp, string password)
        {
            var dominio = ConfigurationManager.AppSettings["dominioFtp"];

            //var usuarioSocio = string.Concat(suarioFtp);


            var request = (FtpWebRequest)WebRequest.Create(servidorFtp);


            request.Method = WebRequestMethods.Ftp.ListDirectory;


            request.Credentials = new NetworkCredential(usuarioFtp, password);

            var response = (FtpWebResponse)request.GetResponse();

            var responseStream = response.GetResponseStream();

            var reader = new StreamReader(responseStream);

            var names = reader.ReadToEnd();

            reader.Close();

            response.Close();

            var user = usuarioFtp.First().ToString().ToUpper() + usuarioFtp.Substring(1);

            var filesNames =
                names.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).
                Where(x => x.Contains(user)).ToList();
                

            
            return filesNames;
        }
        
        public static void ProcessFile(Socio socio, string servidorFtp, string usuarioFtp, string password)
        {
            try
            {
                var descuentoSocios = new List<DescuentoSocio>();

                var clienteService = new ClienteService();

                var descuentoSociosService = new DescuentoSocioService();
       
                var fileName = GetFileName(socio.Usuario,servidorFtp, usuarioFtp, password);

                if (fileName == null) return;

                foreach (var name in fileName)
                {
                    var ff = ConfigurationManager.AppSettings["LocalizacionTemporal"] + name;
          
                    using (var ftpClient = new WebClient())
                    {
                        ftpClient.Credentials = new NetworkCredential(usuarioFtp, password);

                        ftpClient.DownloadFile(servidorFtp + name, ff);
                    }

                    using (var parser = new TextFieldParser(ff))
                    {
                        parser.TextFieldType = FieldType.Delimited;

                        parser.SetDelimiters(",");

                        while (!parser.EndOfData)
                        {
                            //Processing row
                            var fields = parser.ReadFields();
                            if (fields == null) continue;
                            
                            var clienteId = clienteService.GetClienteByNroTarjeta(fields[0]) != null
                                ? clienteService.GetClienteByNroTarjeta(fields[0]).IDCliente
                                : 0;

                            
                            var usrCreacionId = clienteService.GetClienteByNroTarjeta(fields[0]) != null
                                ? clienteService.GetClienteByNroTarjeta(fields[0]).IDCliente
                                : 0;

                            if (clienteId == 0 || usrCreacionId == 0) continue;
                            var descuentoSocio = new DescuentoSocio
                            {
                                IdSocio = socio.IdSocio,
                                IdCliente = clienteId,
                                IdUsrCreacion = usrCreacionId,
                                Monto = Convert.ToDecimal(fields[1]),
                                FechaTransaccion =
                                    new DateTime(Convert.ToInt32(fields[2].Substring(0, 4)),
                                        Convert.ToInt32(fields[2].Substring(4, 2)),
                                        Convert.ToInt32(fields[2].Substring(6, 2))),
                                FechaCreacion = DateTime.Now
                            };
                            descuentoSocios.Add(descuentoSocio);
                        }
                        

                        var carpetaRecibida = ConfigurationManager.AppSettings["CarpetaRecibida"];

                        var client = new Ftp(servidorFtp, usuarioFtp, password);
                        client.Rename(name, carpetaRecibida + name); 
                } 
                }
                descuentoSociosService.AgregarDescuentoSocios(descuentoSocios);

               
            }
            catch(Exception ex)
            {
                var message = string.Format("Error: {0} Detalle: {1}", ex.Message, ex.InnerException);

                LogHandler.Log(message, EventLogEntryType.Warning); 
            }
        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                var message = string.Format("Error: {0} Detalle: {1}", ex.Message, ex.InnerException);

                LogHandler.Log(message, EventLogEntryType.Warning);
            }
        }
    }
}
