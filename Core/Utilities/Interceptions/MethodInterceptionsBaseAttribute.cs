using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptions
{
    /// <summary>
    /// IoC Container altyapısı. AUTOFAC teknolojisi kullanıldı.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptionsBaseAttribute
        : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        /// <summary>
        /// Bu Metot =>  Bu attiribute herhangibir metoda tanımlandığında Tanımlanan MEtodun çalışma anını temsil eden metotdur. 
        /// </summary>
        /// <param name="invocation">Detaylar MethodInterception Classı inice olacak</param>
        public virtual void Intercept(IInvocation invocation) { }
    }
}
