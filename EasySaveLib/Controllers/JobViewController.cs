using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class JobViewController : AbstractController<IJobView, JobViewController>
    {

        public JobViewController(IJobView jobView, DataStorageService StorageService) : base(jobView)
        {
            Storage = StorageService;
        }

        public override void init()
        {
            Storage.LoadJob();
            View.ShowAll(Storage.JobList);
            View.Exit();
        }
    }
}
