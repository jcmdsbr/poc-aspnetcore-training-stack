using System;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Params
{
    public class CustomerParam
    {
        public CustomerParam(Guid id, string name, DateTime birthDate, string email, string cpf)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
    }
}