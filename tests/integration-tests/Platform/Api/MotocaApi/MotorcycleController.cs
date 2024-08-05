using Core.Api.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Platform.Api.MotocaApi.Factories;

namespace Platform.Api.MotocaApi;

public class MotorcycleTests(
    WebApplicationFactory<CoreApi> coreApiFactory,
    WebApplicationFactory<PlatformApi> platformApiFactory)
    : IClassFixture<WebApplicationFactory<CoreApi>>,
        IClassFixture<WebApplicationFactory<PlatformApi>>
{
    private readonly CoreApiFactory _coreApiFactory = new(coreApiFactory);
    private readonly PlatformApiFactory _platformApiFactory = new(platformApiFactory);
    
    [Fact]
    public async Task MotorcycleFlow()
    {
        var token = await _coreApiFactory.SetupAdministator();
        _platformApiFactory.SetToken(token);

        await _platformApiFactory.AddDefaultMotorcycle();
        var motorcycle = await _platformApiFactory.GetDefaultMotorcycle();
        Assert.NotNull(motorcycle);

        await _platformApiFactory.UpdateMotorcycle("AAA0A00", "AAA0A01");
        motorcycle = await _platformApiFactory.GetMotorcycle("AAA0A01");
        Assert.NotNull(motorcycle);
        Assert.Equal("AAA0A01", motorcycle.LicensePlate);

        await _platformApiFactory.DeleteMotorcycle(motorcycle.Guid);
        motorcycle = await _platformApiFactory.GetMotorcycle("AAA0A01");
        Assert.Null(motorcycle);
    }
}