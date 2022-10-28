using BackGroundProcess.Application.UseCases.Products.CreateProduct;
using BackGroundProcess.Application.UseCases.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackGroundProcess.Api.Routes
{
    public static class ProductsRoutes
    {
        public static IEndpointRouteBuilder MapProducts (this IEndpointRouteBuilder builder)
        {
            builder.MapGet(pattern: "/Products", async ([FromServices] IMediator mediator)
                => Results.Ok(await mediator.Send(request: new GetAllProductsRequest())))
                .WithName(endpointName: "GetProducts")
                .Produces<IEnumerable<GetAllProductsResponse>>(StatusCodes.Status200OK, contentType: "application/json");

            builder.MapPost(pattern: "/Products", async ([FromServices] IMediator mediator, [FromBody] CreateProductRequest request)
                 => Results.Ok(await mediator.Send(request)))
                .WithName(endpointName: "CreateProducts")
                .Produces<CreateProductRequest>(StatusCodes.Status200OK, contentType: "application/json");

            return builder;
        }

    }
}
