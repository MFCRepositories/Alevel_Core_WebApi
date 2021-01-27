using Core.Utilities.ResultType;
using FluentValidation;

namespace Core.CrosCuttingConcerns.Validation
{
    public static class ValitadionTool
    {
        public static void Validation(IValidator validator,object entity )
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                //return new EntityResult(ResultType.Warning, "Validasyon Hatası " + result.Errors);
                throw new ValidationException(result.Errors);
            }
        }
    }
}
