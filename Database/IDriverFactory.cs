namespace database.Database;

public interface IDriverFactory
{
    public IWriter GetWriter();
    public IReader GetReader();
}