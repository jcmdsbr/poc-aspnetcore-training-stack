using System.Linq;
using Application.Repository;
using Domain.Entities.Models;
using Domain.Entities.ValueObjects;
using Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext db) : base(db)
        {
        }

        public Customer GetByEmail(Email email)
        {
            return DbSet.Include(x => x.Email).FirstOrDefault(c => c.Email.Equals(email));
        }
    }
}