using EasySaveLib.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vues
{
    public interface IHome : IAbstractView<HomeController>
    {

        public void showMenu();
    }
}
