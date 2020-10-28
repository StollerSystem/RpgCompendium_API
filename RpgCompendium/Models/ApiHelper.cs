using System.Threading.Tasks;
using RestSharp;

namespace RpgCompendium.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string input)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"{input}", Method.GET);      
      request.AddHeader("Authorization", $"Bearer {EnvironmentVariables.BearerToken}");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"animals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}