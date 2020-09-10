using MikTecnologyNew;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TecnoComponents
{
    public static class LoaderTested
    {
      
       

        private static ICollection<ILink> GetProjectsRealization()
        {
            ICollection<ILink> nodes = new Collection<ILink>();
            AssemblyNode n1 = new AssemblyNode();
            ILink link = new Link(n1);
            
            nodes.Add(link);
            return nodes;
        }
    }
    public class MoocDB : IRepository
    {
        TechnologyLinkFactoryImplementation factory = new TechnologyLinkFactoryImplementation();
        public ICollection<ILink> GetProects()
        {
            ICollection<ILink> nodes = new Collection<ILink>();
           
            ILink n1 = factory.Make ("Link","AssemblyNode","СМТШ.123456.001");
            ILink n2 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002");
            ILink n3 = factory.Make("Link", "AssemblyNode", "СМТШ.123456.003");
            ILink n4 = factory.Make("Link", "AssemblyNode", "СМТШ.123456.004");
            ILink n5 = factory.Make("Link", "AssemblyNode", "СМТШ.123456.005");
            ILink n6 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002", -1);
            ILink n7 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002", 2);
            ILink n8 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002", -1);
            ILink n9 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002", -1);
            ILink n10 = factory.Make("Link", "AssemblyNode", "СМТШ.321000.002", -1);
            ILink n11 = factory.Make("Link", "DetailNode", "СМТШ.123456.001");
           
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
