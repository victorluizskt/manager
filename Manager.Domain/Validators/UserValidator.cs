using FluentValidation;
using Manager.Domain.Entities;
using Manager.Utils.Constants.Validators;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ValidatorsConstants.ENTITY_IS_NOT_EMPTY)
                .NotNull()
                .WithMessage(ValidatorsConstants.ENTITY_IS_NOT_NULL);

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(ValidatorsConstants.NAME_IS_NOT_EMPTY)
                .NotEmpty()
                .WithMessage(ValidatorsConstants.NAME_IS_NOT_NULL)
                .MinimumLength(3)
                .WithMessage(ValidatorsConstants.NAME_LENGTH_MIN)
                .MaximumLength(80)
                .WithMessage(ValidatorsConstants.NAME_LENGTH_MAX);

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(ValidatorsConstants.EMAIL_IS_NOT_EMPTY)
                .NotEmpty()
                .WithMessage(ValidatorsConstants.EMAIL_IS_NOT_NULL)
                .MinimumLength(10)
                .WithMessage(ValidatorsConstants.EMAIL_LENGTH_MIN)
                .MaximumLength(180)
                .WithMessage(ValidatorsConstants.EMAIL_LENGTH_MAX)
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage(ValidatorsConstants.VALIDATE_REGEX_EMAIL);

            RuleFor(x => x.Password)
               .NotNull()
               .WithMessage(ValidatorsConstants.PASSWORD_IS_NOT_EMPTY)
               .NotEmpty()
               .WithMessage(ValidatorsConstants.PASSWORD_IS_NOT_NULL)
               .MinimumLength(6)
               .WithMessage(ValidatorsConstants.PASSWORD_LENGTH_MIN)
               .MaximumLength(30)
               .WithMessage(ValidatorsConstants.PASSWORD_LENGTH_MAX);
        }
    }
}