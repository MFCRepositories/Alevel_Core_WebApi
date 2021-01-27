using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptions
{
    /// <summary>
    /// Bu Class => MethodInterceptionsBaseAttribute classından kalıtılıp Intercept() metodu override ediliyor
    /// Not: Ayrıca bu class Direk kullanımayacak. metotlar boş kalacak. çünkü: 
    /// Bu classı miras alan class 
    /// validasyon için,
    /// exceptin için, 
    /// caching için,
    /// Performanca için,
    /// Trancation için aspect yazabilir.
    /// Hangi aspect imzalanan metodun hangi aşamasında çalışmak isterse
    /// O mmetotları override edip onların içini dolrmaso gerekmektedir.
    /// Abstract class içinede metotların gövderinin boş olarak bıraklımasının sebebi budur.
    /// </summary>
    public abstract class MethodInterception 
        : MethodInterceptionsBaseAttribute
    {
        /// <summary>
        /// İmzalanan Metot çalışmadan önce yapılacak işlemler bu metoda yazılacak
        /// </summary>
        /// <param name="invocation">imzalanan metot temsil ediliyor</param>
        protected virtual void OnBefore(IInvocation invocation) { }
        /// <summary>
        /// İmzalanan Metot çalışıp bittiği anda yapılacak işlemler bu metoda yazılacak
        /// </summary>
        /// <param name="invocation">imzalanan metot temsil ediliyor</param>
        protected virtual void OnAfter(IInvocation invocation) { }
        /// <summary>
        /// Metot çalışması sırasında hata alırsa çalışacak metot(Hata yöntimi yapılır)
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        /// <summary>
        /// Metot çalışığ Success Alırsa bu metot çalışcak
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation) { }
        /// <summary>
        /// BU Metod => imzlanan metodun çalışma anını temsil eden metot
        /// OnBefore()--OnAfter()--OnSuccess()--Onexception() Metotlarını  yaşam dönüleri nerede ve nezaman çalışcakları burada tanımanır
        /// </summary>
        /// <param name="invocation">invocation.Proceed() = > metot çalıştığı an...</param>
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
            base.Intercept(invocation);
        }
    }
}
