using System.Collections;
using System.Net.Http.Json;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Platform.Api.MotocaApi.Factories;

public static class MotorcycleControllerFactory
{
    public static async Task AddMotorcycle(this PlatformApiFactory factory, int year, string model, string licensePlate)
    {
        var client = factory.GetClient();

        var response = await client.PostAsJsonAsync("motorcycle", new {year, model, licensePlate});

        response.EnsureSuccessStatusCode();
    }

    public static async Task AddDefaultMotorcycle(this PlatformApiFactory factory)
    {
        try
        {
            await AddMotorcycle(factory, 2023, "YBR125", "AAA0A00");
        }
        catch (Exception e)
        {
            Console.WriteLine("Motocicleta já cadastrada.");
        }
    }

    public static async Task<MotorcycleResponse?> GetMotorcycle(this PlatformApiFactory factory, string licensePlate)
    {
        var client = factory.GetClient();
        
        var response = await client.GetAsync($"motorcycle?licensePlate={licensePlate}");
        response.EnsureSuccessStatusCode();

        var motorcycles = await response.Content.ReadFromJsonAsync<IEnumerable<MotorcycleResponse>>();

        return motorcycles?.FirstOrDefault();
    }
    
    public static async Task<MotorcycleResponse?> GetDefaultMotorcycle(this PlatformApiFactory factory)
    {
        return await GetMotorcycle(factory, "AAA0A00");
    }

    public static async Task UpdateMotorcycle(this PlatformApiFactory factory, string wrongLicensePlate, string correctLicensePlate)
    {
        var client = factory.GetClient();

        var response = await client.PutAsJsonAsync("motorcycle", new {wrongLicensePlate, correctLicensePlate});
        response.EnsureSuccessStatusCode();
    }
    
    public static async Task DeleteMotorcycle(this PlatformApiFactory factory, Guid motorcycleGuid)
    {
        var client = factory.GetClient();

        var response = await client.DeleteAsync($"motorcycle/{motorcycleGuid}");
        response.EnsureSuccessStatusCode();
    }
    
    
}