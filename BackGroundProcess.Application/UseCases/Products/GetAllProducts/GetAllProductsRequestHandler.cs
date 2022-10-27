using BackGroundProcess.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.GetAllProducts
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
    {
        public readonly IProductsContext _context;
        public GetAllProductsRequestHandler(IProductsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

            return products.Select(x => new GetAllProductsResponse(x.Id, x.Name, x.Description, x.CreationDate, x.IsActive));
        }
    }
}
