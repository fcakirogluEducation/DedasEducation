namespace DedasApp.API.Consts;

public class RepositoryConst
{
    public const string InMemory = "in-memory";
    public const string SqlServer = "sqlserver";
}

public enum KeyedRepositoryName
{
    InMemory,
    SqlServer,
    Oracle
}