// Derrick Nguyen
//OutputDataFactory.cs
//helps handle output
public class OutputDataFactory
{
    public static OutputHandler getOutputHandler(string type)
    {
        // helps return either json or sqllite or throws new arg
        return type switch
        {
            "JSON" => new JSONOutput(),
            "SQLite" => new SQLIteOutputHandler(),
            _ => throw new ArgumentException("Invalid output type")
        };
    }
}