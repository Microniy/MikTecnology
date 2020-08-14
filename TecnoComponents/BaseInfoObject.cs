using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public abstract class BaseInfoObject : IInformation, IVersion
    {

        private IList<IInformation> _directParents;


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

        public int Ver => _ver;

        public IVersion OldVersion2 => _oldVersion.OrderByDescending(x => x.Ver).Skip(1).Take(1).FirstOrDefault();

        public IVersion OldVersion1 => _oldVersion.LastOrDefault();

        public IVersion NextVersion2 => _nextVersion.Skip(1).Take(1).FirstOrDefault();

        public IVersion NextVersion1 => _nextVersion.FirstOrDefault();

        public IList<IInformation> DirectParents => _directParents;       

       
        public void AddVersion(IVersion node)
        {
            //Children don't have to self and repeated versions
            if ((!this.Equals(node)) && (!_versions.Contains(node)))
            {               
                if (_baseVersion == null)
                {                    
                    //Write Next version for all old nodes (before added)
                    foreach (BaseInfoObject version in this.Versions)
                    {
                        version.SetNextVersion(node);                       
                    }
                    //AddNode to first version
                    (node as BaseInfoObject)._oldVersion.Add(this);
                    (node as BaseInfoObject).SetOldVersion(this.Versions);
                    _versions.Add(node);
                    (node as BaseInfoObject).SetBaseVersion(this);                    
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
                    foreach (BaseInfoObject version in this.Versions)
                    {
                        version.RemoveNextVersion(node);
                        version.RemoveOldVersion(node);
                    }
                    _versions.Remove(node);
                    (node as BaseInfoObject).CleanVersionState();//this cleanup prevents other nodes from being removed
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
               

        public void SetVersion()
        {
            int i = this.OldVersions.Max(x => x.Ver);
            this._ver = i + 1;
        }
    }

}
