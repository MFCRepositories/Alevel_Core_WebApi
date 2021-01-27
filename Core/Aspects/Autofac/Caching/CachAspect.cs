using Castle.DynamicProxy;
using Core.CrosCuttingConcerns.Caching;
using Core.Utilities.Interceptions;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CachAspect
        : MethodInterception
    {
        private int duration;
        private ICacheManager cacheManager;
        public CachAspect(int duration = 60)
        {
            this.duration = duration;
            cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.ReflectedType.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            cacheManager.Add(key,invocation.ReturnValue, duration);
        }
    }
}
