using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikTecnologyNew
{
    //Convention for treeview style
    public interface INode
    {      
        void AddNode(INode node);
        void RemoveNode(INode node);
        IList<INode> GrandParents { get; }
        INode Parent { get; }
        IList<INode> Nodes { get; }
    }
    public interface IVersion
    {
        void AddVersion(IVersion node); 
        void RemoveVersion();
        void RemoveVersion(IVersion node);
        IList<IVersion> OldVersions { get; }
        IList<IVersion> NextVersions { get; }
    }
    public interface ITecnologyNodeFactory
    {
        INode MakeAssembly(string name);
    }
    public interface INumberNomenclature
    {
        string Number { get; }
    }
    public interface ICaption
    {
        string Name { get; }
    }
    public interface IRepository
    {      
       ICollection<INode> GetProects();
    }
   
}
