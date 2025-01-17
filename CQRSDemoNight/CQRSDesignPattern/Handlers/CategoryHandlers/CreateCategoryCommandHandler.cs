using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Commands.CategoryCommands;
using CQRSDemoNight.Entities;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly CQRSContext _context;
        public CreateCategoryCommandHandler(CQRSContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.CategoryName
            });
            await _context.SaveChangesAsync();
        }
    }
}
