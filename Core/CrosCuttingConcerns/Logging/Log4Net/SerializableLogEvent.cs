using log4net.Core;

namespace Core.CrosCuttingConcerns.Logging.Log4Net
{
    //TODO : Sorun Çıkarsa Autofac.Extansinos.DependencyInjection Kur.
    [System.Serializable]
    public class SerializableLogEvent
    {
        private readonly LoggingEvent loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            this.loggingEvent = loggingEvent;
        }
        public object Message => loggingEvent.MessageObject;
    }
}
