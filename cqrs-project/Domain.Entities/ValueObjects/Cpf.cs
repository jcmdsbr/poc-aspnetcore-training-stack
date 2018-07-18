using Domain.Entities.Core;

namespace Domain.Entities.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        protected Cpf()
        {
        }

        public Cpf(decimal value)
        {
            Value = value;
        }

        public Cpf(string value)
        {
            if (decimal.TryParse(value, out var valid)) Value = valid;
        }

        public decimal Value { get; private set; }

        public string GetValue => Value.ToString(@"000\.000\.000\-00");

        public override string ToString()
        {
            return Value.ToString(@"000\.000\.000\-00");
        }

        protected override bool EqualsCore(Cpf other)
        {
            return Value == other.Value;
        }


        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}