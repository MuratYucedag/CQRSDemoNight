using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Commands.ProductCommands;
using CQRSDemoNight.Entities;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly CQRSContext _context;
        public CreateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductStock = command.ProductStock
            });
            await _context.SaveChangesAsync();
        }
    }
}
