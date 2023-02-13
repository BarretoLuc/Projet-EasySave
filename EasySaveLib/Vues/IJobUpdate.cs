using EasySaveLib.Controllers;
using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vues
{
    public interface IJobUpdate : IAbstractView<JobUpdateController>
    {
        public void Show();
        public void ShowAll(List<JobModel> listjob);
        public void Exit();
        public int AskUpdate(int listJobLength);
        public JobModel UpdateJob(JobModel job);
    }
}
