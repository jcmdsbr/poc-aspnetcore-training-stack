using Domain.Entities.Models;
using Domain.Entities.ValueObjects;

namespace Application.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(Email customerEmail);
    }
}