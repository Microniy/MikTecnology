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
        void AddNode(IInformation node);
        void RemoveNode(IInformation node);  
        IList<INode> AllParents { get; }
        INode Parent { get; }
        IInformation Info { get; }
        IList<INode> Nodes { get; }

    }
    public interface IInformation
    {
        IList<IInformation> GrandParents { get; }
       
    }
    public interface IVersion
    {
        void AddVersion(IVersion node); 
        void RemoveVersion();
        void RemoveVersion(IVersion node);
        IVersion OldVersion2 { get; }
        IVersion OldVersion1 { get; }
        IList<IVersion> OldVersions { get; }
        IList<IVersion> NextVersions { get; }
        IVersion NextVersion2 { get; }
        IVersion NextVersion1 { get; }
        int Ver { get; }
        void SetVersion();
    }
    public interface ITecnologyNodeFactory
    {
        INode Make(string type,string name,int vers =0);
    }
    public interface INumberNomenclature
    {
        string Number { get; }
    }
    public interface ICaption
    {
        string Name { get; }
    }
    public interface IDescription
    {
        string Description { get; }
        string SetDescription { set; }
    }
    public interface IMaterial
    {
        string Assortment { get; }
        string Size { get; }
        string Standard { get; }
        public void SetAssortment(string value);
        public void SetSize(string value);
        public void SetStandard(string value);
        public void RemoveMaterial();
       
    }
    public interface IFindCollection
    {
        IEnumerable<INode> FullItemsCollection { get; }       
    }
    public interface IRepository
    {      
       ICollection<INode> GetProects();
    }
   
}
