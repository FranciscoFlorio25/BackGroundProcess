using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.GetAllProducts
{
    public record GetAllProductsResponse(
        int Id,
        string Name,
        string? Description,
        DateTime CreationDate,
        bool IsActive
        );
}