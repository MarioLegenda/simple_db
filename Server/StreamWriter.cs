using System.Net.Sockets;
using System.Text;

namespace database.Server;

public struct StreamWriter
{
    public static void Write(NetworkStream stream, string value)
    {
        byte[] response = new UTF8Encoding(true).GetBytes(value);
        stream.Write(response, 0, response.Length);
    }
}