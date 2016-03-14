using System.Diagnostics;

namespace FtpDescuentoSocios.Utilities
{
    public static class LogHandler
    {
            public static void Log(string message, EventLogEntryType eventLogType)
            {
                const int eventId = 101;

                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(message, eventLogType, eventId);
                }
            }
    }
}
