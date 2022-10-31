using BackGroundProcess.Application.Data;
using BackGroundProcess.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductRequestHandler : AsyncRequestHandler<UpdateProductRequest>
    {
        public readonly IProductsContext _context;
        public UpdateProductRequestHandler(IProductsContext context)
        {
            _context = context;

        }

        protected override async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == request.Id, cancellationToken);

            Product updateProduct = new Product(
                request.Name,
                request.Description,
                DateTime.Now,
                true
            );

            product.Name = request.Name;
            product.Description = request.Description;
            product.IsActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
