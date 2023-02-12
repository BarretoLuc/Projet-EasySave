using EasySaveLib.Models;
using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySaveLib.Controllers
{
    public class JobUpdateController : AbstractController<IJobUpdate, JobUpdateController>
    {
        public JobService JobService { get; set; }
        public JobUpdateController(IJobUpdate View, DataStorageService StorageService) : base(View, StorageService)
        {
            JobService = new JobService();
        }

        public override void init()
        {
            View.Show();
            View.ShowAll(Storage.JobList);
            int choice = View.AskUpdate(Storage.JobList.Count);
            if (choice == 0)
            {
                View.Exit();
                return;
            }
            Storage.JobList[choice - 1] = View.UpdateJob(Storage.JobList[choice - 1]);
            //Storage.SaveJob();
            View.Exit();
        }
    }
}
