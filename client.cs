using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ChatClient
{
    static void Main()
    {
        TcpClient client = new TcpClient();
        client.Connect(IPAddress.Parse("127.0.0.1"), 8888);
        Console.WriteLine("Connected to server");

        NetworkStream stream = client.GetStream();

        while (true)
        {
            Console.Write("Enter message: ");
            string message = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);

            byte[] responseBuffer = new byte[1024];
            int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
            string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
            Console.WriteLine("Server response: " + response);
        }

        client.Close();
    }
}