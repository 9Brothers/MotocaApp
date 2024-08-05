using dotenv.net;

namespace Motoca.Core.Domain.Utils;

public class DotEnvUtils
{
    public static void Load(string path = ".env")
    {
        var prod = Environment.GetEnvironmentVariable("PRODUCTION");
        
        if (string.IsNullOrEmpty(prod))
            DotEnv.Load(new DotEnvOptions(envFilePaths: new[] {path}));
    }
}