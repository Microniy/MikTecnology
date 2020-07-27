﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikTecnology
{
    //Convention for treeview style
    public interface INode
    {      
        void Add(INode node);
        void Remove(INode node);
    }
    public interface IVersion
    {
        void AddVersion(IVersion node); 
        void RemoveVersion();
        void RemoveVersion(IVersion node);
    }
    public abstract class BaseNode : INode,IVersion
    {
        private IList<INode> _nodes = new List<INode>();
        // List children nodes
        public IList<INode> Nodes => _nodes;
        private IList<IVersion> _versions = new List<IVersion>();
        protected IList<IVersion> Versions => _versions;
        //First version this parameter to be null
        private IVersion _baseVersion;
        private IList<IVersion> _oldVersion = new List<IVersion>();
        private IList<IVersion> _nextVersion = new List<IVersion>();
        public IList<IVersion> OldVersions => _oldVersion;
        public IList<IVersion> NextVersions => _nextVersion;
        public virtual void Add(INode node)
        {
            //Children don't have to self and repeated nodes
            if ((!this.Equals(node))&&(!_nodes.Contains(node)))
                _nodes.Add(node);
        }

        public void AddVersion(IVersion node)
        {
            //Children don't have to self and repeated versions
            if ((!this.Equals(node))&& (!_versions.Contains(node)))
            {
                if (_baseVersion == null)
                {
                    //Write Next version for all old nodes (before added)
                    foreach (BaseNode version in this.Versions)
                    {
                        version.SetNextVersion(node);
                    }
                    //Add to first version
                    _versions.Add(node);
                    (node as BaseNode).SetBaseVersion(this);
                    (node as BaseNode).SetOldVersion(this.Versions);
                    this.SetNextVersion(node);//Write Next version for first  node
                   
                }
                else
                {
                    //Add also to first version
                    _baseVersion.AddVersion(node);
                }               
                
            }
                
        }

        public void Remove(INode node)
        {
            //Remove don't try to deleted no conteined nodes
            if (_nodes.Contains(node))
                _nodes.Remove(node);
        }

        protected void SetBaseVersion(IVersion version)//Next version always receive link to first version
        {
            _baseVersion = version;
        }
        protected void DeleteBaseVersion()//Clean base version
        {
            _baseVersion = null;
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

        protected void SetNextVersion(IVersion version)//Add next version
        {
            _nextVersion.Add(version);
        }
        protected void RemoveNextVersion(IVersion version)//Remove next version
        {
            if(_nextVersion.Contains(version))
            _nextVersion.Remove(version);
        }

        public void RemoveVersion(IVersion node)
        {
            //Remove don't try to deleted no conteined nodes
            if (_baseVersion == null)
            {
                if (_versions.Contains(node))
                {
                    this.RemoveNextVersion(node);
                    foreach(BaseNode version in this.Versions)
                    {
                        version.RemoveNextVersion(node);
                    }
                    foreach (BaseNode version in this.Versions)
                    {
                        version.RemoveOldVersion(node);
                    }
                    _versions.Remove(node);
                    (node as BaseNode).DeleteBaseVersion();//this cleanup prevents other nodes from being removed
                }
                    
            }
            else
            {
                //Remove also to first version
                _baseVersion.RemoveVersion(node);
            }
                
        }

        public void RemoveVersion()
        {
            RemoveVersion(this);
        }
    }
}
