using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MikTecnologyNew;


namespace TecnoComponents
{
    public class AssemblyNode : BaseNode,INumberNomenclature,ICaption, IFindCollection
    {
        private static int _typeId = 1;
        private static IList<AssemblyNode> _fullItems = new List<AssemblyNode>();
        public override int TypeNode => _typeId;
        private string _name;
        public override string Name => _name;

        public string Number => _name;

        public IEnumerable<INode> FullItemsCollection => _fullItems.Cast<INode>();

       

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

        public override void Delete()
        {
            throw new NotImplementedException();
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

        public AssemblyNode(string name)
        {            
            this._name = name;
           
        }
        public AssemblyNode() : this(string.Empty)
        {

        }
    }
    
}
