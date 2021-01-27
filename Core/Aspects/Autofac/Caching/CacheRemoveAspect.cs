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
    public class CacheRemoveAspect
        : MethodInterception
    {
        private readonly string pattern;
        private ICacheManager cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            this.pattern = pattern;
            this.cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            cacheManager.RemoveByPattern(pattern);
        }
    }
}
