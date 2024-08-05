using System.Net.Http.Json;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Platform.Api.MotocaApi.Factories;

public static class PlanControllerFactory
{
    public static async Task<IEnumerable<PlanResponse>?> GetPlans(this PlatformApiFactory factory)
    {
        var client = factory.GetClient();

        var response = await client.GetAsync("plan");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<PlanResponse>>();
    }
}