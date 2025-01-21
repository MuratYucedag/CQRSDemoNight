using MediatR;

namespace CQRSDemoNight.MediatorDesignPattern.Commands
{
    public class RemoveCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        public RemoveCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
