using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(string Name,string? Description, DateTime CreationDate,
        bool IsActive) : IRequest<CreateProductResponse>;

}
