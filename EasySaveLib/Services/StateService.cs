using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Services
{
    public class StateService
    {
        private SerializerService Serializer;

        public StateService()
        {
            Serializer = new SerializerService();
        }
        
        public List<JobModel> LoadJob()
        {
            if (!File.Exists(Settings.Settings.Default.dataStorageFolder + "job.json"))
            {
                return new List<JobModel>();
            }
            var json = File.ReadAllText(Settings.Settings.Default.dataStorageFolder + "job.json");
            return Serializer.Deserialize<List<JobModel>>(json);
        }
        
        public void SaveJob(List<JobModel> jobList)
        {

            //Semaphore? semaphorefileLargeTransfert;
            //if (!Semaphore.TryOpenExisting("saveJson", out semaphorefileLargeTransfert))
            //{
            //    semaphorefileLargeTransfert = new Semaphore(1, 1, "saveJson");
            //}

            //semaphorefileLargeTransfert.WaitOne();

            string path = Settings.Settings.Default.dataStorageFolder + "job.json";

            var json = Serializer.Serialize(jobList);

            if (!Directory.Exists(Settings.Settings.Default.dataStorageFolder))
                Directory.CreateDirectory(Settings.Settings.Default.dataStorageFolder);


            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

        }
    }
}
