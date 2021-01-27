namespace Core.CrosCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger
        : LoggerServiceBase
    {
        /// <summary>
        /// log4net.config dosyasından appender name "JsonFileLogger" yazılıyor
        /// </summary>
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
