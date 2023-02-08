using EasySaveLib.Services;

namespace EasySaveLib.Controllers
{
    public class HomeController : AbstractController
    {
        public new DataStorageService Storage { get; }

        public HomeController()
        {
            Storage = new DataStorageService();
            new LogService();
        }
        
    }
}
