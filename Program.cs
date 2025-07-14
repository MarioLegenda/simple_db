using System.Net.Sockets;
using database.Server;

TcpListener? listener = null;

try
{
    Server server = new Server(5000);
    server.Start();

    listener = server.GetServer();
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e);
    listener?.Stop();
}
finally
{
    listener?.Stop();
}

