using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MikTecnologyNew;


namespace TecnoComponents
{
    public class AssemblyNode : BaseInfoObject,INumberNomenclature,ICaption,IDescription, IFindCollection
    {
        private static int _typeId = (int)StringTypeNode.AssemblyNode;
        private static IList<AssemblyNode> _fullItems = new List<AssemblyNode>();
        
        private string _name;
        private string _description=string.Empty;
        

        public string Number => _name;

        public IEnumerable<IInformation> FullItemsCollection => _fullItems.Cast<IInformation>();

        public string Description =>_description;

        public string SetDescription { set => _description=value; }

        public string Name => _name;

        public override int TypeNode => _typeId;

        public static AssemblyNode CreateNode(string name,int vers = 0)
        {
            AssemblyNode node0 = FindNode(name,0);
            AssemblyNode node = FindNode(name,vers);
            if (node is null)
            {
                node = new AssemblyNode(name);
                node0?.AddVersion(node);
                _fullItems.Add(node);
            }
            return node as AssemblyNode;
        }

        private static AssemblyNode FindNode(string number, int vers = 0)
        {
            
            var listNode = (from nod in _fullItems
                            where (nod .Number == number) && (nod.Ver == vers)
                            select nod);
          
            if (listNode.Count() == 0)
            {
                return null;
            }
            else
            {
               return listNode.First();
            }               
        }

        public static void ClearItemsCollections()
        {
            _fullItems.Clear();
        }

        public AssemblyNode(string name)
        {            
            this._name = name;
           
        }
        public AssemblyNode() : this(string.Empty)
        {

        }
    }
    
}
