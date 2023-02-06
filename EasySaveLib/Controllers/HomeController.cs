using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class HomeController
    {
        public DataStorageService DataStorageService { get; }
        
        public HomeController()
        {
            DataStorageService = new DataStorageService();
        }
    }
}
