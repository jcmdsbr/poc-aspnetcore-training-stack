using System;
using Domain.Entities.Core;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Models
{
    public class Customer : Entity
    {
        public Customer(Guid id, string name, DateTime birthDate, Email email, Cpf cpf)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Cpf = cpf;
        }

        // Empty constructor for EF
        protected Customer()
        {
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
    }
}