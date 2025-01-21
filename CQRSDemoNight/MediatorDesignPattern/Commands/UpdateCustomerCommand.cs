using MediatR;

namespace CQRSDemoNight.MediatorDesignPattern.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}