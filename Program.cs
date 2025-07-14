//
//using database.Database;
//
// string simulatedDsn = "/home/mario/applications/database/output.bin";
//
// Driver driver = new Driver(simulatedDsn);
//     
// IWriter writer = driver.GetWriter();
//
// writer.Write("some value that is shit");

using System.Net.Sockets;
using database.Server;

class Program
{
    static void Main()
    {
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
    }
}

