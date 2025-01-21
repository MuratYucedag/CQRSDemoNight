using CQRSDemoNight.Context;
using CQRSDemoNight.MediatorDesignPattern.Commands;
using MediatR;

namespace CQRSDemoNight.MediatorDesignPattern.Handlers
{
    public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand>
    {
        private readonly CQRSContext _context;
        public UpdateCustomerCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Customers.FindAsync(request.CustomerId);
            value.CustomerSurname= request.CustomerSurname;
            value.CustomerName= request.CustomerName;
            await _context.SaveChangesAsync();
        }
    }
}
