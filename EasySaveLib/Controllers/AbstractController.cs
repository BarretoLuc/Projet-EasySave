using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public abstract class AbstractController<T, CTRLERCLASS> where CTRLERCLASS : AbstractController<T, CTRLERCLASS> 
    {
        public DataStorageService Storage { get; set; }
        public T View { get; set; }

        public AbstractController(IAbstractView<CTRLERCLASS> view)
        {
            Storage = new DataStorageService();
            View = (T)view;
            view.Controller = (CTRLERCLASS) this;
        }

        public abstract void init();
        
       public string GetTranslation(string key)
        {
            return Storage.GetTranslation(key);
        }
    }
}
