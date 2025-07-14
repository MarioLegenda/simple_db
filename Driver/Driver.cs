namespace database.Database;

public class Driver: IDriverFactory
{
    private readonly string _dsn;
    
    public Driver(string dsn)
    {
        _dsn = dsn;
        FileStream stream = new FileStream(dsn, FileMode.OpenOrCreate);
        stream.Dispose();
        stream.Close();
    }
    
    public IReader GetReader()
    {
        return new Reader(new FileStream(_dsn, FileMode.Open, FileAccess.Read));
    }

    public IWriter GetWriter()
    {
        return new Writer(new FileStream(_dsn, FileMode.Append, FileAccess.Write));
    }
}