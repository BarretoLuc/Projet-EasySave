using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Services
{
    public class ServerRemoteService : RemoteService
    {
        public TcpListener TcpListener { get; set; }
        public DataStorageService Storage { get; set; }

        public ServerRemoteService(DataStorageService storage, IPAddress? ip = null, int? port = null)
        {
            if (ip != null) IP = ip;
            if (port != null) Port = (int)port;
            TcpListener = new TcpListener(IP, Port);
            Storage = storage;
        }

        public void StartServer()
        {
            TcpListener.Start();

            while (true)
            {
                TcpClient client = TcpListener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem((a) => { AcceptClient(client); });
            }
        }

        private void AcceptClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            while (true)
            {
                string[] req = ParseRequest(Receive(stream));
                Send(stream, GetResponse(req));
                Console.WriteLine("");
            }
            client.Close();
        }

        private string GetResponse(string[] req)
        {
            String res = String.Empty;
            switch (req[0])
            {
                case "GET_JOBS":
                    res += new SerializerService().Serialize<List<JobModel>>(Storage.JobList);
                    break;

                case "START":
                    foreach (JobModel job in Storage.JobList)
                    {
                        if (job.Name == req[1])
                        {
                            ThreadPool.QueueUserWorkItem((a) => { new JobService().ExecuteJob(job, Storage); });
                            res = "true";
                        }
                        break;
                    }
                    if (res != "true") res = "false";
                    break;

                case "PAUSE":
                    foreach (JobModel job in Storage.JobList)
                    {
                        if (job.Name == req[1])
                        {
                            job.State = JobStatsEnum.Pause;
                            res = "true";
                        }
                        break;
                    }
                    if (res != "true") res = "false";
                    break;

                default:
                    break;
            }
            return res;
        }
    }
}
