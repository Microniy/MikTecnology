using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikTecnologyNew
{
    //Convention for treeview style
    public interface ILink
    {      
        ILink AddNode(IInformation node);
        void AddNode(ILink link);
        void RemoveNode(IInformation node);  
        IList<ILink> AllParents { get; }
        ILink Parent { get; }
        IInformation Info { get; }
        IList<ILink> Children { get; }
        IQuantity Count { get; }
        ILink Clone();
    }
    public interface IQuantity
    {
        double Quantity { get; }
        string UnitQuantity { get; }
    }
    public interface IInformation
    {
        IList<IInformation> DirectParents { get; }
       
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
    public interface ITechnologyLinkFactory
    {
        ILink Make(string link, string info, string name,int vers =0);
    }
    public interface ITechnologyInfoFactory
    {
        IInformation Make(string info, string name, int vers = 0);
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
        IEnumerable<IInformation> FullItemsCollection { get; }       
    }   
   public interface IRepository
    {
        public ICollection<ILink> GetProects();
    }
}
