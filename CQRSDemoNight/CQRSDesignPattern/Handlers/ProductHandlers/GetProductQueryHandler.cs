using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Results.ProductResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly CQRSContext _context;
        public GetProductQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _context.Products.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock
            }).ToListAsync();
            return values;
        }
    }
}
