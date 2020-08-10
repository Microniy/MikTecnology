using MikTecnologyNew;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TecnoComponents
{
    public static class LoaderTested
    {
      
       

        private static ICollection<INode> GetProjectsRealization()
        {
            ICollection<INode> nodes = new Collection<INode>();
            AssemblyNode n1 = new AssemblyNode();
            nodes.Add(n1);
            return nodes;
        }
    }
    public class MoocDB : IRepository
    {
        TecnologyNodeFactoryImplementation factory = new TecnologyNodeFactoryImplementation();
        public ICollection<INode> GetProects()
        {
            ICollection<INode> nodes = new Collection<INode>();
            INode n1 = factory.Make ("AssemblyNode","СМТШ.123456.001");
            INode n2 = factory.Make("AssemblyNode", "СМТШ.321000.002");
            INode n3 = factory.Make("AssemblyNode", "СМТШ.123456.003");
            INode n4 = factory.Make("AssemblyNode", "СМТШ.123456.004");
            INode n5 = factory.Make("AssemblyNode", "СМТШ.123456.005");
            INode n6 = factory.Make("AssemblyNode", "СМТШ.321000.002", -1);
            INode n7 = factory.Make("AssemblyNode", "СМТШ.321000.002", 2);
            INode n8 = factory.Make("AssemblyNode", "СМТШ.321000.002", -1);
            INode n9 = factory.Make("AssemblyNode", "СМТШ.321000.002", -1);
            INode n10 = factory.Make("AssemblyNode", "СМТШ.321000.002", -1);
            INode n11 = factory.Make("DetailNode", "СМТШ.123456.001");
            n1.AddNode(n7);
            n1.AddNode(n3);
            n7.AddNode(n4);
            n7.AddNode(n11);
            n4.AddNode(n5);
            nodes.Add(n1);
            return nodes;
        }
      
    }
}
