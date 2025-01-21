using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Queries.ProductQueries;
using CQRSDemoNight.CQRSDesignPattern.Results.ProductResults;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly CQRSContext _context;
        public GetProductByIdQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var value = await _context.Products.FindAsync(query.ProductId);
            return new GetProductByIdQueryResult
            {
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductStock = value.ProductStock
            };
        }
    }
}