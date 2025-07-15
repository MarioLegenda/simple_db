using System.Net.Sockets;
using database;
using database.Database;
using database.Server;

TcpListener? listener = null;
Driver driver = new Driver("/home/mario/applications/database/output.bin");

try
{
    Server server = new Server(5001, new DatabaseMediator(driver));
    server.Start();

    listener = server.CurrentServer;
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e);
}
finally
{
    listener?.Stop();
}

