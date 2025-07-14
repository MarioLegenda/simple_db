using System.Xml;

namespace database.Database;

public interface IWriter
{
    public int Write(string value);
}