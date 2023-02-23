using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Models;

namespace EasySaveLib.Services
{
    public class ClientRemoteService : RemoteService
    {
        public TcpClient TcpClient { get; set; }
        private NetworkStream Stream { get; set; }

        public ClientRemoteService(IPAddress? ip = null, int? port = null)
        {
            if (ip != null) IP = ip;
            if (port != null) Port = (int)port;
            TcpClient = new TcpClient(IP.ToString(), Port);
            Stream = TcpClient.GetStream();
        }

        public List<JobModel> GetJobs()
        {
            Send(Stream, "GET_JOBS");
            string res = Receive(Stream);
            return new SerializerService().Deserialize<List<JobModel>>(res);
        }

        public void StartJob(JobModel job)
        {
            Send(Stream, "START " + job.Name);
            Receive(Stream);
        }

        public void PauseJob(JobModel job)
        {
            Send(Stream, "PAUSE " + job.Name);
            Receive(Stream);
        }
    }
}
