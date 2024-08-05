using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Motoca.Core.Domain.Mediator.Commands.Responses;
using Motoca.Core.Domain.Utils;

namespace Core.Interfaces.Http.Api.Common;

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

    public async Task<string?> AuthDeliveryman(string cnpj)
    {
        var response = await _client.PostAsJsonAsync("/auth/deliveryman", new {cnpj});

        response.EnsureSuccessStatusCode();

        var auth = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
        
        if (auth != null)
            SetToken(auth.Token);

        return auth?.Token;
    }

    public async Task DeliverymanUploadCNH(string pathToImage, string filename)
    {
        using var image = File.OpenRead($"{pathToImage}/{filename}");
        
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(image), "file", filename);

        var response = await _client.PutAsync("/deliveryman/upload/cnh", content);

        response.EnsureSuccessStatusCode();
    }
}