namespace Motoca.Core.Domain.Utils;

public class EnvironmentUtils
{
    public static string TryGetEnvironmentVariable(string variableName)
    {
        var environmentVariable = Environment.GetEnvironmentVariable(variableName);

        if (string.IsNullOrEmpty(environmentVariable))
        {
            var mensagem = $"Informe a variável {variableName}";

            Console.Error.WriteLine(mensagem);
            throw new Exception(mensagem);
        }

        return environmentVariable;
    }
}