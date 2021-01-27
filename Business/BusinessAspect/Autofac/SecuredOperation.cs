using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperation
        : MethodInterception
    {
        private string[] Roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            Roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimsRoles();
            foreach (var role in Roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
                throw new Exception("Yetkiniz Yok");
            }
        }
    }
}
