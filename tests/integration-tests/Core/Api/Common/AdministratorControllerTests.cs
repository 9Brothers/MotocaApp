using Microsoft.AspNetCore.Mvc.Testing;

namespace Core.Api.Common;

public class AdministratorControllerTests(WebApplicationFactory<CoreApi> coreApiFactory) : IClassFixture<WebApplicationFactory<CoreApi>>
{
    private readonly CoreApiFactory _coreApiFactory = new(coreApiFactory);

    [Fact]
    public async Task Auth()
    {
        var email = "heber@email.com";
        
        await _coreApiFactory.CreateAdministrator("Heber", email);
        var token = await _coreApiFactory.AuthAdministrator(email);
        
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }
}