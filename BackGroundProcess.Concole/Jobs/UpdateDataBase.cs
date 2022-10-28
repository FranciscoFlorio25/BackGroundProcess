using BackGroundProcess.Application.Data;
using BackGroundProcess.Console.Model;
using BackGroundProcess.Domain.Entities;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace BackGroundProcess.Concole.Jobs
{
    public class UpdateDataBase : IJob
    {
        private readonly ILogger<UpdateDataBase> _logger;

        public UpdateDataBase(ILogger<UpdateDataBase> logger)
        {

            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            HttpClient client = new HttpClient();
            /* var httpClient = _clientFactory.CreateClient("GetProducts");

             var response = await httpClient.GetAsync("/Products");

             response.EnsureSuccessStatusCode();

             var Products = await response.Content.ReadAsStringAsync();*/

            _logger.LogInformation("Accesing Request");
            var Products = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("http://localhost:12739/Products");

            _logger.LogInformation("Request Succesfull");
            if (Products != null && Products.Any())
            {

                foreach (ProductModel product in Products)
                {
                    await client.PostAsJsonAsync("http://localhost:12739/Products", product);
                    _logger.LogInformation("Product with id {0} was added", product.Id);
                }
                _logger.LogInformation("Request Succesfull, data load completed");
            }
            else
            {
                _logger.LogInformation("No data to add");
            }

        }
    }
}
