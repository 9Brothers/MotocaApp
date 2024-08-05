using Motoca.Core.Domain.Utils;

namespace Platform.Api.MotocaApi.Factories;

public static class DeliverymanControllerFactory
{
    public static async Task DeliverymanUploadCNH(this PlatformApiFactory factory, string pathToImage, string filename)
    {
        var client = factory.GetClient();
        
        using var image = File.OpenRead($"{pathToImage}/{filename}");
        
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(image), "file", filename);

        var response = await client.PutAsync("/deliveryman/upload/cnh", content);

        response.EnsureSuccessStatusCode();
    }

    public static async Task DeliverymanUploadDefaultCNH(this PlatformApiFactory factory)
    {
        var pathToImage = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH_TESTS");
        var fileName = "7f0f3f433c2c8e0726f1657dd13831d8.bmp";

        await DeliverymanUploadCNH(factory, pathToImage, fileName);
    }
}