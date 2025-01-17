using CQRSDemoNight.Context;
using CQRSDemoNight.CQRSDesignPattern.Queries.CategoryQueries;
using CQRSDemoNight.CQRSDesignPattern.Results.CategoryResults;

namespace CQRSDemoNight.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly CQRSContext _context;
        public GetCategoryByIdQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = values.CategoryId,
                CategoryName = values.CategoryName
            };
        }
    }
}
