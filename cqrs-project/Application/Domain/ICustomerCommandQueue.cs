using System.Threading.Tasks;
using Domain.Entities.Params;

namespace Application.Domain
{
    public interface ICustomerCommandQueue
    {
        Task AddNewCustomerCommand(CustomerParam param);
    }
}