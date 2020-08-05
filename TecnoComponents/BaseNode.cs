using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public abstract class BaseNode : INode, IVersion
    {
        private IList<INode> _nodes = new List<INode>();
        // List children nodes
        public IList<INode> Nodes => _nodes;
        private INode _parent;
        public INode Parent => _parent;
        private IList<INode> _grandparents = new List<INode>();
        // List parent nodes
        public IList<INode> GrandParents => _grandparents;
        private IList<IVersion> _versions = new List<IVersion>();
        protected IList<IVersion> Versions => _versions;
        //First version this parameter to be null
        private IVersion _baseVersion;
        private IList<IVersion> _oldVersion = new List<IVersion>();
        private IList<IVersion> _nextVersion = new List<IVersion>();
        public IList<IVersion> OldVersions => _oldVersion;
        public IList<IVersion> NextVersions => _nextVersion;
        private int _ver;
        
        public abstract int TypeNode
        {
            get;
        }
        public abstract string Name
        {
            get;
        }

        public int Ver => _ver;

       

      

        public abstract void Delete();//this method should clear static collections of inherited classes

        public void AddNode(INode node)
        {
            bool findCyclicLink = false;
            foreach (INode node2 in this.GrandParents) // Find cyclic links parents and children
            {
                if (this.FindCyclicLink(node2))
                {
                    findCyclicLink = true;
                    break;
                }
            }
            //Children don't have to self and repeated nodes, and not nodes in parents
            if ((!this.Equals(node)) && (!findCyclicLink) && (!_nodes.Contains(node)) && (!_grandparents.Contains(node)))
            {
                _nodes.Add(node);
                (node as BaseNode).AddParent(this);
                // AddNode all parents
                foreach (INode node1 in this.GrandParents)
                {
                    (node as BaseNode).AddGrandParent(node1);
                }
                (node as BaseNode).AddGrandParent(this);
            }

        }
        protected void AddParent(INode node)
        {
            this._parent = node;
        }
        protected void AddGrandParent(INode node)
        {
            this._grandparents.Add(node);
            //Added children nodes this grandparent
            foreach (BaseNode baseNode in this.Nodes)
            {
                baseNode.AddGrandParent(node);
            }
        }
        protected void CleanParent()
        {
            this._parent = null;
            this._grandparents.Clear();
        }
        protected void CleanGrandParent(INode node)
        {
            if (this._grandparents.Contains(node))
            {
                foreach (INode node1 in this.Nodes)
                {
                    (node1 as BaseNode).CleanGrandParent(node);
                }
                this._grandparents.Remove(node);
            }
        }
        public void AddVersion(IVersion node)
        {
            //Children don't have to self and repeated versions
            if ((!this.Equals(node)) && (!_versions.Contains(node)))
            {               
                if (_baseVersion == null)
                {                    
                    //Write Next version for all old nodes (before added)
                    foreach (BaseNode version in this.Versions)
                    {
                        version.SetNextVersion(node);                       
                    }
                    //AddNode to first version
                    _versions.Add(node);
                    (node as BaseNode).SetBaseVersion(this);
                    (node as BaseNode).SetOldVersion(this.Versions);
                    this.SetNextVersion(node);//Write Next version for first  node
                    node.SetVersion();//initialization version number
                }
                else
                {
                    //AddNode also to first version
                    _baseVersion.AddVersion(node);
                }

            }

        }

        public void RemoveNode(INode node)
        {
            //RemoveNode don't try to deleted no conteined nodes
            if (_nodes.Contains(node))
            {
                _nodes.Remove(node);
                foreach (BaseNode grparent in this.GrandParents) //RemoveNode for children nodes all grand parent this node
                {
                    (node as BaseNode).CleanGrandParent(grparent);
                }
                (node as BaseNode).CleanGrandParent(this);//RemoveNode for children node this node
                (node as BaseNode).CleanParent();
            }

        }

        protected void SetBaseVersion(IVersion version)//Next version always receive link to first version
        {
            _baseVersion = version;
        }
        protected void CleanVersionState()//Clean base version
        {
            _baseVersion = null;
            _oldVersion.Clear();
            _nextVersion.Clear();
        }

        protected void SetOldVersion(IList<IVersion> versions)//Next version receive all versions before
        {
            foreach (IVersion version in versions)
                _oldVersion.Add(version);
        }
        protected void RemoveOldVersion(IVersion version)//Next version receive all versions before
        {
            if (_oldVersion.Contains(version))
                _oldVersion.Remove(version);
        }

        protected void SetNextVersion(IVersion version)//AddNode next version
        {
            _nextVersion.Add(version);
        }
        protected void RemoveNextVersion(IVersion version)//RemoveNode next version
        {
            if (_nextVersion.Contains(version))
                _nextVersion.Remove(version);
        }

        public void RemoveVersion(IVersion node)
        {
            //RemoveNode don't try to deleted no conteined nodes
            if (_baseVersion == null)
            {
                if (_versions.Contains(node))
                {
                    this.RemoveNextVersion(node);
                    foreach (BaseNode version in this.Versions)
                    {
                        version.RemoveNextVersion(node);
                        version.RemoveOldVersion(node);
                    }
                    _versions.Remove(node);
                    (node as BaseNode).CleanVersionState();//this cleanup prevents other nodes from being removed
                }

            }
            else
            {
                //RemoveNode also to first version
                _baseVersion.RemoveVersion(node);
            }

        }

        public void RemoveVersion()
        {
            RemoveVersion(this);
        }

        protected bool FindCyclicLink(INode node)
        {
            foreach (BaseNode node1 in this.Nodes)
            {
                if (node1.FindCyclicLink(node)) { return true; }//this cicle to be recursive find cyclic link
            }
            return false;
        }

        public void SetVersion()
        {
            int i = this.OldVersions.Max(x => x.Ver);
            this._ver = i + 1;
        }
    }

}
