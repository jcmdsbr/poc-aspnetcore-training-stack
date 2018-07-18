using System;
using Domain.Customer.Commands;
using FluentValidation;
using Infra.CrossCutting.Shared.Messages;
using Infra.CrossCutting.Shared.Validations;

namespace Domain.Customer.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(SystemMessage.MsEmpty, "Nome"))
                .Length(2, 150).WithMessage(string.Format(SystemMessage.MsRange, "Nome", 2, 150));
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage(SystemMessage.MsMinimumAge);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Description)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf.Value)
                .NotEqual(0)
                .Must(IsValidCpf)
                .WithMessage(SystemMessage.MsCpfInvalid);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        protected static bool IsValidCpf(decimal value)
        {
            return CpfValidator.IsValid(value.ToString());
        }
    }
}