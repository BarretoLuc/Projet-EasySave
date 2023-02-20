using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class AbstractViewImpl<T> : IAbstractView<T>
    {
        public AbstractViewImpl()
        {
        }

        public T Controller { get ; set ; }
    }
}