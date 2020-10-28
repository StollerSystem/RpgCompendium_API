using System.Threading.Tasks;
using RestSharp;

namespace RpgCompendium.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"monsters", Method.GET);      
      request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE2MDM4MjMwNzQsImV4cCI6MTYwNDQyNzg3NCwiaWF0IjoxNjAzODIzMDc0fQ.dqpV2HYa0vTbbw4gGqIa3P4g_dt_ueO8skKawogeB_M");
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