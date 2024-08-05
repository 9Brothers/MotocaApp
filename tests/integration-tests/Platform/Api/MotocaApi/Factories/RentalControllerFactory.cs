using System.Net.Http.Json;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Platform.Api.MotocaApi.Factories;

public static class RentalControllerFactory
{
    public static async Task<RentalResponse?> Rental(this PlatformApiFactory factory, DateTime start, Guid planGuid)
    {
        var client = factory.GetClient();

        var response = await client.PostAsJsonAsync("rental", new {start, planGuid});
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<RentalResponse>();
    }

    public static async Task<EndRentalResponse?> EndRental(this PlatformApiFactory factory)
    {
        var client = factory.GetClient();

        var response = await client.PostAsJsonAsync("rental/end", new {});
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<EndRentalResponse>();
    }
}