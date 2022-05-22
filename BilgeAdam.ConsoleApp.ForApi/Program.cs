using BilgeAdam.Common.Dtos;
using System.Text.Json;

namespace BilgeAdam.ConsoleApp.ForApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7273");
                var response = client.GetAsync("api/supplier/list?count=10&page=1").Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    var result = JsonSerializer.Deserialize<PagedList<List<SupplierListDto>>>(jsonResult);

                    foreach (var item in result.Data)
                    {
                        Console.WriteLine($"{item.ContactName}-{item.CompanyName}");
                        Console.WriteLine();
                    }
                }
            }
            Console.Read();
        }
    }
}