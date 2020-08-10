using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class DetailNode : BaseNode,ICaption,INumberNomenclature, IFindCollection,IDescription
    {
        private static int _typeId = (int)StringTypeNode.DetailNode;
        private static IList<DetailNode> _fullItems = new List<DetailNode>();
        private string _name;
        private string _description = string.Empty;
        public override int TypeNode => _typeId;

        public IEnumerable<INode> FullItemsCollection => _fullItems.Cast<INode>();

        public string Name => _name;

        public string Number => _name;

        public string Description => _description;

        public string SetDescription { set => _description = value; }

        public static DetailNode CreateNode(string name, int vers = 0)
        {
            DetailNode node0 = FindNode(name, 0);
            DetailNode node = FindNode(name, vers);
            if (node is null)
            {
                node = new DetailNode(name);
                node0?.AddVersion(node);
                _fullItems.Add(node);
            }
            return node as DetailNode;
        }
        private static DetailNode FindNode(string number, int vers = 0)
        {

            var listNode = (from nod in _fullItems
                            where (nod.Number == number) && (nod.Ver == vers)
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
        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public DetailNode(string name)
        {
            this._name = name;

        }
        public DetailNode() : this(string.Empty)
        {

        }
        public override void AddNode(INode node)
        {
            if(!(node is AssemblyNode))
            base.AddNode(node);
        }
    }
}
