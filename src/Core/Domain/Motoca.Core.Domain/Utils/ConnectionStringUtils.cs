namespace Motoca.Core.Domain.Utils;

public class ConnectionStringUtils
{
    public static Dictionary<string, string> GetData(string connectionString)
    {
        var values = connectionString
            .Split(";")
            .Select(p =>
            {
                var items = p.Split("=");

                return new KeyValuePair<string, string>(items[0], items[1]);
            })
            .ToDictionary(p => p.Key);

        var dict = new Dictionary<string, string>();

        foreach (var (key, value) in values)
        {
            dict.Add(key, value.Value);
        }

        return dict;
    }
}