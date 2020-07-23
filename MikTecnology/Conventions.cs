using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikTecnology
{
    public interface INode
    {      
        void Add(INode node);
        void Remove(INode node);
    }
    public abstract class BaseNode : INode
    {
        private IList<INode> _nodes = new List<INode>();
        public IList<INode> Nodes => _nodes;       
        public virtual void Add(INode node)
        {
            if ((!this.Equals(node))&&(!_nodes.Contains(node)))
                _nodes.Add(node);
        }
        public void Remove(INode node)
        {
            if (_nodes.Contains(node))
                _nodes.Remove(node);
        }
    }
}
