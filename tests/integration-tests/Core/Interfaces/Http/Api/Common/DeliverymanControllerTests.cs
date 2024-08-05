using Microsoft.AspNetCore.Mvc.Testing;
using Motoca.Core.Domain.Utils;

namespace Core.Interfaces.Http.Api.Common;

public class DeliverymanControllerTests : IClassFixture<WebApplicationFactory<CoreApi>>
{
    private readonly CoreApiFactory _coreApiFactory;

    public DeliverymanControllerTests(WebApplicationFactory<CoreApi> coreApiFactory)
    {
        _coreApiFactory = new CoreApiFactory(coreApiFactory);
    }

    [Fact]
    public async Task UploadCnhWithBmpFormat()
    {
        await _coreApiFactory.AuthDeliveryman("00111333000144");
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "7f0f3f433c2c8e0726f1657dd13831d8.bmp";
    
        await _coreApiFactory.DeliverymanUploadCNH(pathToImage, fileName);
    }
    
    [Fact]
    public async Task UploadCnhWithPngFormat()
    {
        await _coreApiFactory.AuthDeliveryman("00111333000144");
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "66218c34e544a02f8b4f93230651ec0a.png";
    
        await _coreApiFactory.DeliverymanUploadCNH(pathToImage, fileName);
    }
    
    [Fact]
    public async Task UploadCnhWithJpgFormat()
    {
        await _coreApiFactory.AuthDeliveryman("00111333000144");
        
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "maxresdefault.jpg";
    
        await Assert.ThrowsAsync<HttpRequestException>(() => _coreApiFactory.DeliverymanUploadCNH(pathToImage, fileName));
    }
}