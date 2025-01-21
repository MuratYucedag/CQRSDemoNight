using CQRSDemoNight.MediatorDesignPattern.Results;
using MediatR;

namespace CQRSDemoNight.MediatorDesignPattern.Queries
{
    public class GetCustomerQuery : IRequest<List<GetCustomerQueryResult>>
    {
    }
}