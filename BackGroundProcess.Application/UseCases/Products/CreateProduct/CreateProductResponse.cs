using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.CreateProduct
{
    public record CreateProductResponse(int Id,
        string Name,
        string? Description,
        DateTime CreationDate,
        bool IsActive);
}