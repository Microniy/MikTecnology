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

        public ILink AddNode(IInformation node)
        {
            ILink link = (from info in this._children
                            where info.Info == node
                            select info).FirstOrDefault();
            if ((_info != node) && (link == null))
            {
                ILink link1 = new Link(node);
                (link1 as Link).SetParent(this);
                _children.Add(link1);
                return link1;
            }
            return null;
        }

        public void RemoveNode(IInformation node)
        {
            ILink link = (from info in this._children
                          where info.Info == node
                          select info).FirstOrDefault();
            if (link != null)
            {
                (link as Link).SetParent(null);
                this._children.Remove(link);
            }
        }
        protected void SetParent(ILink link)
        {
            this._parent = link;
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
