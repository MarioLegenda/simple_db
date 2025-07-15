using database.Database;

namespace database.Server;

using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private readonly TcpListener _server;
    private readonly IMediator _mediator;

    public Server(int port, IMediator mediator)
    {
        _mediator = mediator;
        _server = new TcpListener(IPAddress.Any, port);
    }

    public void Start()
    {
        _server.Start();
        Console.WriteLine("Server started");

        while (true)
        {
            TcpClient client = _server.AcceptTcpClient();
            Console.WriteLine("A connection has been made to the database");

            NetworkStream stream = client.GetStream();
                
            StreamWriter.Write(stream, "You are connected to the database" + Environment.NewLine);

            byte[] buffer = new byte[1024 * 1024 * 10];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string command = new UTF8Encoding().GetString(buffer, 0, bytesRead);

                _mediator.Notify(command, stream);
            }

            client.Close();
        }
    }

    public TcpListener CurrentServer
    {
        get { return _server; }
    }
}