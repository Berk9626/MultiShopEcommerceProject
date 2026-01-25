using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    //merkezi sistem var kaotik bağımlılık ortadan kalkıyor. Her bir handleri private readonly gibi tanımlayarak oluşturmak yerine mediatr benim için
    //yapacak
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
    }
}
