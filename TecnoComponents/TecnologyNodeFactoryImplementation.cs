using System;
using System.Collections.Generic;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class TecnologyNodeFactoryImplementation : ITecnologyNodeFactory
    {
        public INode MakeAssembly(string name)
        {
            return new AssemblyNode(name);
        }
    }
}
