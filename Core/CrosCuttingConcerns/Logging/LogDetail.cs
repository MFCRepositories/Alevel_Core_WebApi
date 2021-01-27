using System;
using System.Collections.Generic;

namespace Core.CrosCuttingConcerns.Logging
{
    /// <summary>
    /// Sınıf İçine tanımlanan Propertyler log parametreli oluyor.
    /// Hangi bilgi gerekeli ise burada tanımlanıp LogAspect içinde karışılığı veriliyor.
    /// </summary>
    public class LogDetail
    {
        public string MethodName { get; set; }
        public DateTime RunTime { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
