using Core.Api.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Motoca.Core.Domain.Utils;
using Platform.Api.MotocaApi.Factories;

namespace Platform.Api.MotocaApi;

public class DeliverymanControllerTests(
    WebApplicationFactory<CoreApi> coreApiFactory,
    WebApplicationFactory<PlatformApi> platformApiFactory)
    : IClassFixture<WebApplicationFactory<CoreApi>>, 
        IClassFixture<WebApplicationFactory<PlatformApi>>
{
    private readonly CoreApiFactory _coreApiFactory = new(coreApiFactory);
    private readonly PlatformApiFactory _platformApiFactory = new(platformApiFactory);
    
    [Fact]
    public async Task DeliverymanFlow()
    {
        var tokenAdministrator = await _coreApiFactory.SetupAdministator();
        Assert.NotNull(tokenAdministrator);
        Assert.NotEmpty(tokenAdministrator);
        
        _platformApiFactory.SetToken(tokenAdministrator);
        await _platformApiFactory.AddDefaultMotorcycle();
        var motorcycle = await _platformApiFactory.GetDefaultMotorcycle();
        Assert.NotNull(motorcycle);
        
        var tokenDeliveryman = await _platformApiFactory.SetupDeliveryman();
        Assert.NotNull(tokenDeliveryman);
        Assert.NotEmpty(tokenDeliveryman);
        
        await _platformApiFactory.DeliverymanUploadDefaultCNH();
        
        var plans = await _platformApiFactory.GetPlans();
        Assert.NotNull(plans);
        Assert.NotEmpty(plans);
        
        var rental = await _platformApiFactory.Rental(DateTime.Now, plans.First().Guid);
        Assert.NotNull(rental);

        var endRental = await _platformApiFactory.EndRental();
        Assert.NotNull(endRental);
        Assert.True(endRental.Fee > 0);
        
        _platformApiFactory.SetToken(tokenAdministrator);
        await _platformApiFactory.DeleteMotorcycle(motorcycle.Guid);
        motorcycle = await _platformApiFactory.GetMotorcycle("AAA0A01");
        Assert.Null(motorcycle);
    }
    
    [Fact]
    public async Task UploadCnhWithBmpFormat()
    {
        await _platformApiFactory.SetupDeliveryman();
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "7f0f3f433c2c8e0726f1657dd13831d8.bmp";
    
        await _platformApiFactory.DeliverymanUploadCNH(pathToImage, fileName);
    }
    
    [Fact]
    public async Task UploadCnhWithPngFormat()
    {
        await _platformApiFactory.SetupDeliveryman();
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "66218c34e544a02f8b4f93230651ec0a.png";
    
        await _platformApiFactory.DeliverymanUploadCNH(pathToImage, fileName);
    }
    
    [Fact]
    public async Task UploadCnhWithJpgFormat()
    {
        await _platformApiFactory.SetupDeliveryman();
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "maxresdefault.jpg";
    
        await Assert.ThrowsAsync<HttpRequestException>(() => _platformApiFactory.DeliverymanUploadCNH(pathToImage, fileName));
    }
}