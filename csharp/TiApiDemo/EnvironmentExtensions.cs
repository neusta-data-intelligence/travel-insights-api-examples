namespace TiApiDemo;

public static class EnvironmentExtensions
{
    public static string GetVariableOrThrow(string name) =>
        Environment.GetEnvironmentVariable(name) ??
        throw new ArgumentException($"{name} must be set");
}