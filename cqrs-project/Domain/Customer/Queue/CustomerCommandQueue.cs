using System.Threading.Tasks;
using Application.Bus;
using Application.Domain;
using Domain.Customer.Commands;
using Domain.Entities.Params;

namespace Domain.Customer.Queue
{
    public class CustomerCommandQueue : ICustomerCommandQueue
    {
        private readonly IMediatorHandler Bus;

        public CustomerCommandQueue(IMediatorHandler bus)
        {
            Bus = bus;
        }

        public async Task AddNewCustomerCommand(CustomerParam param)
        {
            await Bus.SendCommand(new NewCustomerCommand(param));
        }
    }
}