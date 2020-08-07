using System;
using System.Collections.Generic;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class TecnologyNodeFactoryImplementation : ITecnologyNodeFactory
    {
        public INode Make(string type, string name, int vers = 0)
        {
            switch (type)
            {
                case "AssemblyNode":
                    return AssemblyNode.CreateNode(name, vers);
                case "DetailNode":
                    return DetailNode.CreateNode(name, vers);
                default:
                    return null;
            }           
        }
    }
}
