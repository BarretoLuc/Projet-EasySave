using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Services
{
    public class RemoteService
    {
        public int Port { get; set; } = 8950;
        public IPAddress IP { get; set; } = IPAddress.Loopback;
        
        public string Receive(NetworkStream stream)
        {
            Byte[] buffer = new Byte[1];
            String data = String.Empty;
            do
            {
                stream.Read(buffer, 0, buffer.Length);
                if (buffer[0] != 3) data += Encoding.ASCII.GetString(buffer, 0, 1);
            } while (buffer[0] != 3);
            
            return data.ToString();
        }
        
        public void Send(NetworkStream stream, string data)
        {
            Byte[] dataBytes = Encoding.ASCII.GetBytes(data + (char)3);
            stream.Write(dataBytes, 0, dataBytes.Length);
        }

        public string[] ParseRequest(string req)
        {
            return req.Split(" ");
        }
    }
}
