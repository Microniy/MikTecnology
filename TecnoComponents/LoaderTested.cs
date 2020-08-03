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
        
        public ICollection<INode> GetProects()
        {
            ICollection<INode> nodes = new Collection<INode>();
            AssemblyNode n1 = new AssemblyNode("СМТШ.123456.001");
            AssemblyNode n2 = new AssemblyNode("СМТШ.123456.002");
            AssemblyNode n3 = new AssemblyNode("СМТШ.123456.003");
            AssemblyNode n4 = new AssemblyNode("СМТШ.123456.004");
            AssemblyNode n5 = new AssemblyNode("СМТШ.123456.005");
            n1.AddNode(n2);
            n1.AddNode(n3);
            n2.AddNode(n4);
            n4.AddNode(n5);
            nodes.Add(n1);
            return nodes;
        }
      
    }
}
