namespace ClassLibrary1;

public class OutputDataFactory
{
    public static OutputHandler getOutputHandler(string type)
    {
        return type switch
        {
            "JSON" => new JSONOutput(),
            "SQLite" => new SQLIteOutputHandler(),
            _ => throw new ArgumentException("Invalid output type")
        };
    }
}