using System.Net.Sockets;

namespace database;

public interface IMediator
{
    public void Notify(string command, NetworkStream stream);
}