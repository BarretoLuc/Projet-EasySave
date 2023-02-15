using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveWPF
{
    internal class AbstractViewImpl<T> : IAbstractView<T>
    {
        public AbstractViewImpl()
        {
        }

        public T Controller { get; set; }
    }
}