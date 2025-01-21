using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Commands.ProductCommands;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly CQRSContext _context;
        public RemoveProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveProductCommand command)
        {
            var value = await _context.Products.FindAsync(command.ProductId);
            _context.Products.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
