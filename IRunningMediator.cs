using System.Net.Sockets;

namespace database;

public interface IRunningMediator
{
    public void Notify(string command, NetworkStream stream);
}