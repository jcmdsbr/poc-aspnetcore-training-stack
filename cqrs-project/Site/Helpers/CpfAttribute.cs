using System.ComponentModel.DataAnnotations;
using Infra.CrossCutting.Shared.Validations;

namespace Site.Helpers
{
    public class CpfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cpf = (string) value;

            return CpfValidator.IsValid(cpf);
        }
    }
}