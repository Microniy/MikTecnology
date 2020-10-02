using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        

        public string Number { get => _name; set => _name = value; }

        public IEnumerable<IInformation> FullItemsCollection => _fullItems.Cast<IInformation>();
       
        public string Description { get => _description; set => _description = value; }        

        public string Name { get => _name; set => _name = value; }

        public override int TypeNode { get => _typeId; set => _typeId = value; }

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
