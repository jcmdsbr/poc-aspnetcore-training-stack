﻿using Domain.Entities.Core;

namespace Domain.Entities.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        protected Email()
        {
        }

        public Email(string value)
        {
            Description = value;
        }

        public string Description { get; private set; }

        protected override bool EqualsCore(Email other)
        {
            return Description == other.Description;
        }

        protected override int GetHashCodeCore()
        {
            return Description.GetHashCode();
        }
    }
}