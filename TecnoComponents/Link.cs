using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class Link : ILink
    {
        private IList<ILink> _allParent = new List<ILink>();
        private ILink _parent;
        private IInformation _info;
        private IList<ILink> _children = new List<ILink>();
        public IList<ILink> AllParents => _allParent;

        public ILink Parent => _parent;

        public IInformation Info => _info;

        public IList<ILink> Children => _children;

        public IQuantity Count => throw new NotImplementedException();

        public void AddNode(IInformation node)
        {
            ILink link = (from info in this._children
                            where info.Info == node
                            select info).FirstOrDefault();
            if ((_info != node) && (link == null))
            {
                _children.Add(new Link(node));
            }
        }

        public void RemoveNode(IInformation node)
        {
            throw new NotImplementedException();
        }
        public Link(IInformation information)
        {
            _info = information;
        }
        public Link() : this(null)
        {

        }
        public static Link CreateLink(IInformation info)
        {
            Link link = new Link(info);
               
            return link;
        }
    }
}
