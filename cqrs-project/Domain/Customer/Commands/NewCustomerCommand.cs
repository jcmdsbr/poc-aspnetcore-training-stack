using Domain.Customer.Validations;
using Domain.Entities.Params;

namespace Domain.Customer.Commands
{
    public class NewCustomerCommand : CustomerCommand
    {
        public NewCustomerCommand(CustomerParam param)
        {
            Name = param.Name;
            Email = param.Email;
            BirthDate = param.BirthDate;
            Cpf = param.Cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewCustomerValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}