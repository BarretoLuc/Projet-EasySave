using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class AbstractController
    {
        public DataStorageService Storage { get; }
        
        public AbstractController()
        {
            Storage = new DataStorageService();
        }
        
        public AbstractController(DataStorageService StorageService)
        {
            Storage = StorageService;
        }
    }
}
