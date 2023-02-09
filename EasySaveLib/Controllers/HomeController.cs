using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class HomeController : AbstractController<IHome, HomeController>
    {
        public new DataStorageService Storage { get; }

        public HomeController(IHome View) : base(View)
        {
            Storage = new DataStorageService();
            new LogService();
        }

        public override void init()
        {
            View.showMenu();
        }
        public void AccessSave(IJobCreate jobCreate)
        {
            JobCreateController jobController = new JobCreateController(jobCreate,Storage);
            jobController.init();
        }

        public void ShowJobRun(IJobRun jobRun)
        {
            JobRunController jobRunController = new JobRunController(jobRun, Storage);
            jobRunController.init();
        }

        public void ShowJobViews(IJobView jobView)
        {
            JobViewController jobViewController = new JobViewController(jobView, Storage);
            jobViewController.init();
        }
    }
}
