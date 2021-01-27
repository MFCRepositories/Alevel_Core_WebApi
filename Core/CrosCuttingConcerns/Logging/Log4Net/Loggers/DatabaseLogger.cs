namespace Core.CrosCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger
        : LoggerServiceBase
    {
        /// <summary>
        /// log4net.config dosyasından appender name "DatabaseLogger" yazılıyor
        /// </summary>
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
