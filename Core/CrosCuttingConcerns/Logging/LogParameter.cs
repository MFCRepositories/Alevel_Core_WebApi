using System;

namespace Core.CrosCuttingConcerns.Logging
{
    /// <summary>
    /// Loglama Yapılcak Methodun hangi özlliklerinin loglanmasını bu sınıfa ekleyip
    /// LogAspect Sınıfında Tanımlıyoruz(Reflection ile)
    /// </summary>
    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}
