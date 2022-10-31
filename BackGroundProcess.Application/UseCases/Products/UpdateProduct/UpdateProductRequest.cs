using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundProcess.Application.UseCases.Products.UpdateProduct
{
    public record UpdateProductRequest(int Id, string Name,
        string? Description,
        bool IsActive) : IRequest;

}
