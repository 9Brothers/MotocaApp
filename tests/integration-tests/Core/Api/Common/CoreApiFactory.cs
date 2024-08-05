using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Motoca.Core.Domain.Mediator.Commands.Responses;
using Motoca.Core.Domain.Utils;

namespace Core.Api.Common;

public class CoreApiFactory
{
    private readonly HttpClient _client;

    public CoreApiFactory(WebApplicationFactory<CoreApi> coreApiFactory)
    {
        DotEnvUtils.Load();

        _client = coreApiFactory.CreateClient();
    }
    
    public void SetToken(string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    public async Task<string?> AuthAdministrator(string email)
    {
        var response = await _client.PostAsJsonAsync("/auth/administrator", new {email});

        response.EnsureSuccessStatusCode();

        var auth = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
        
        if (auth != null)
            SetToken(auth.Token);

        return auth?.Token;
    }

    public async Task CreateAdministrator(string name, string email)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("/administrator", new {name, email});

            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Administrador já cadastrado");
        }
    }

    public async Task CreateAdministratorHeber()
    {
        await CreateAdministrator("Heber", "heber@email.com");
    }

    public async Task<string?> SetupAdministator()
    {
        await CreateAdministratorHeber();
        return await AuthAdministrator("heber@email.com");
    }
}