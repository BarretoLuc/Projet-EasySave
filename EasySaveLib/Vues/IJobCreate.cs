using EasySaveLib.Controllers;
using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vues
{
    public interface IJobCreate : IAbstractView<JobCreateController>
    {
        public void Show();
        public void NewJob();
    }
}
