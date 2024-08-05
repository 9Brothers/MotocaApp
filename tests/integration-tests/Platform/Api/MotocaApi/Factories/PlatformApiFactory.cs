using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Motoca.Core.Domain.Mediator.Commands.Responses;
using Motoca.Core.Domain.Utils;

namespace Platform.Api.MotocaApi.Factories;

public class PlatformApiFactory
{
    private readonly HttpClient _client;

    public PlatformApiFactory(WebApplicationFactory<PlatformApi> coreApiFactory)
    {
        DotEnvUtils.Load();

        _client = coreApiFactory.CreateClient();
    }

    public HttpClient GetClient() => _client;
    
    public void SetToken(string token)
    {
        _client.DefaultRequestHeaders.Remove("Authorization");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    public async Task CreateDeliveryman(string name, string email, DateTime birthdate, string cnh, string cnhType, string cnpj)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("/deliveryman", new
            {
                name,
                email,
                birthdate,
                cnh,
                cnhType,
                cnpj
            });

            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Entregador já cadastrado");
        }   
    }
    
    public async Task CreateDefaultDeliveryman()
    {
        await CreateDeliveryman(
            "Heber", 
            "heber@deliveryman.com", 
            new DateTime(1991, 1, 1),
            "123456789",
            "AB",
            "00111333000144"
        );
    }
    
    public async Task<string?> AuthDeliveryman(string cnpj)
    {
        var response = await _client.PostAsJsonAsync("/auth", new {cnpj});

        response.EnsureSuccessStatusCode();

        var auth = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
        
        if (auth != null)
            SetToken(auth.Token);

        return auth?.Token;
    }

    public async Task<string?> SetupDeliveryman()
    {
        await CreateDefaultDeliveryman();
        return await AuthDeliveryman("00111333000144");
    }
}