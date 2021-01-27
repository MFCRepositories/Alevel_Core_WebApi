using Castle.DynamicProxy;
using Core.Utilities.AspectMessage;
using Core.Utilities.Interceptions;
using Core.CrosCuttingConcerns.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect
        : MethodInterception
    {
        private readonly Type validationType;

        public ValidationAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new System.Exception(ValidationMessage.WrongValidationMessage);
            }
            this.validationType = validationType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = Activator.CreateInstance(validationType) as IValidator;
            var entityType = validationType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                try
                {
                    ValitadionTool.Validation(validator, entity);
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
    }
}
