using FluentValidation;
using System;

namespace WebCRUD.Domain.Fluentvalidation
{
    public static class PasswordValidator
    {
        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(password =>
                {
                    bool isTruePassword = password.Contains("123456");
                    return isTruePassword;
                })
                .WithMessage("{PropertyName} Bir kun orag`ida ma`lumot kiritish lozim");
        }
    }
}
