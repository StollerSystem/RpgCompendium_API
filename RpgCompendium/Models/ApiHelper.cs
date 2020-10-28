using System;
using System.Threading.Tasks;
using RestSharp;

namespace RpgCompendium.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string endPoint)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"{endPoint}", Method.GET);      
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

    public static async Task Post(string endPoint, string newObject)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"{endPoint}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {EnvironmentVariables.BearerToken}");
      request.AddJsonBody(newObject);
      var response = await client.ExecuteTaskAsync(request);
    }
    // OVERLOADED FOR PARAMS
    public static async Task Post(string endPoint, string newObject, string param, int joinId)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"{endPoint}/?{param}={joinId}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {EnvironmentVariables.BearerToken}");
      request.AddJsonBody(newObject);
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