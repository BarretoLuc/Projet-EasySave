using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySaveLib.Vues
{
    public interface IJobView : IAbstractView<JobViewController>
    {
        public void Show(JobModel job)
        {
        }
        public void ShowAll(List<JobModel> listJob)
        {
        }
        public void Exit()
        { 
        }
    }
}
