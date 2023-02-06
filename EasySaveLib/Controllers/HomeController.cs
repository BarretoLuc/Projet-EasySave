using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class HomeController : AbstractController
    {
        public new DataStorageService Storage { get; }

        public HomeController()
        {
            Storage = new DataStorageService();
        }
        
    }
}
