using MediatR;

namespace CQRSDemoNight.MediatorDesignPattern.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
