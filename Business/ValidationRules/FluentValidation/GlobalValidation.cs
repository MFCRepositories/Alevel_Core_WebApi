using Core.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public static class GlobalValidation
    {
        public static void Val(IValidator validations, IEntity entity)
        {
            var result = validations.Validate(entity);
            if (! result.IsValid)
            {
                
            }
        }
    }
}
