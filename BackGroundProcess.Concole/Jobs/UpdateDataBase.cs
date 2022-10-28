using BackGroundProcess.Application.Data;
using BackGroundProcess.Console.Model;
using BackGroundProcess.Domain.Entities;
using Quartz;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace BackGroundProcess.Concole.Jobs
{
    public class UpdateDataBase : IJob
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductsContext _context;

        public UpdateDataBase(IHttpClientFactory clientFactory, IProductsContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            HttpClient client = new HttpClient();
            /* var httpClient = _clientFactory.CreateClient("GetProducts");

             var response = await httpClient.GetAsync("/Products");

             response.EnsureSuccessStatusCode();

             var Products = await response.Content.ReadAsStringAsync();*/

            var Products = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("http://localhost:12739/Products");

            if(Products != null && Products.Any())
            {

                foreach (ProductModel product in Products)
                {
                   await client.PostAsJsonAsync("http://localhost:12739/Products", product);
                }
              
            }

        }
    }
}
