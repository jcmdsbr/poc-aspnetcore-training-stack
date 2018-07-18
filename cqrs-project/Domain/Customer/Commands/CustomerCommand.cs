using System;
using Domain.Core.Commands;
using Domain.Entities.ValueObjects;

namespace Domain.Customer.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Email Email { get; protected set; }
        public Cpf Cpf { get; protected set; }
    }
}