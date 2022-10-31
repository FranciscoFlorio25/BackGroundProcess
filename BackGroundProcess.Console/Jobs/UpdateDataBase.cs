using BackGroundProcess.Console.Model;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace BackGroundProcess.Concole.Jobs
{
    public class UpdateDataBase : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            HttpClient client = new HttpClient();

            var productsToAdd = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7054/Products");
            var productsInBase = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7097/Products");

            if (productsToAdd != null && productsToAdd.Any())
            {

                foreach (ProductModel product in productsToAdd)
                {

                    if (productsInBase != null && productsInBase.Any())
                    {

                        if (!productsInBase.Contains(product))
                        {
                            await client.PostAsJsonAsync("https://localhost:7097/Products", product);
                        }
                    }
                    else
                    {
                        await client.PostAsJsonAsync("https://localhost:7097/Products", product);
                    }
                }
            }
        }
    }
}
