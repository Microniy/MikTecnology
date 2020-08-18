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
            ILink link = (from info in this.Children
                            where info.Info == node
                            select info).FirstOrDefault();
            ILink parent = (from info in this.AllParents
                          where info.Info == node
                          select info).FirstOrDefault();
            if ((_info != node) && (link == null) && (parent == null))
            {
                ILink link1 = new Link(node);
                foreach(ILink tmpLink in this.AllParents)
                {
                    (link1 as Link).AddAllParent(tmpLink);
                }
                (link1 as Link).AddAllParent(this);
                (link1 as Link).SetParent(this);
                _children.Add(link1);
                return link1;
            }
            return null;
        }
        public void AddNode(ILink link)
        {
            if ((_info != link.Info) && (!this.Children.Contains(link))&&(!this.AllParents.Contains(link)))
            {                
                foreach (ILink tmpLink in this.AllParents)
                {
                    (link as Link).AddAllParent(tmpLink);
                }
              (link as Link).AddAllParent(this);
                (link as Link).SetParent(this);
                _children.Add(link);               
            }
        }
        protected void AddAllParent(ILink link)
        {
            this._allParent.Add(link);
            foreach (Link tmpLink in this.Children)
            {
                tmpLink.AddAllParent(link);
            }
        }
        public void RemoveNode(IInformation node)
        {
            ILink link = (from info in this._children
                          where info.Info == node
                          select info).FirstOrDefault();
            if (link != null)
            {
                foreach(ILink tmpLink in this.AllParents)
                {
                    (link as Link).RemoveAllParent(tmpLink);
                }
                (link as Link).RemoveAllParent(this);
                (link as Link).SetParent(null);
                this._children.Remove(link);
            }
        }
        protected void RemoveAllParent(ILink link)
        {
            if(this.AllParents.Contains(link))
            {
                this._allParent.Remove(link);
                foreach(Link tmpLink in this.Children)
                {
                    tmpLink.RemoveAllParent(link);
                }
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

        public ILink Clone()
        {
            ILink link = new Link(this.Info);
            return link;
        }
    }
}
