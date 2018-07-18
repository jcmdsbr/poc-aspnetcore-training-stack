using Domain.Customer.Commands;

namespace Domain.Customer.Validations
{
    public class NewCustomerValidation : CustomerValidation<NewCustomerCommand>
    {
        public NewCustomerValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidateCpf();
        }
    }
}