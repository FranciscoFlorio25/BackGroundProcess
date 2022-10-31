using BackGroundProcess.Application.Data;
using BackGroundProcess.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.CreateProduct
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public readonly IProductsContext _context;

        public CreateProductRequestHandler(IProductsContext context)
        {
            _context = context;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Description, request.CreationDate, request.IsActive);

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductResponse(product.Id, product.Name, product.Description, product.CreationDate, product.IsActive);
        }
    }
}
