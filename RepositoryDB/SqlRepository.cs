using MikTecnologyNew;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryDB
{
    public class SqlRepository : RepositoryBase<ApplicationContext>, TecnoComponents.ISqlRepository
    {
        public ICollection<ILink> GetProects()
        {
            return GetList<TecnoComponents.Link>(l => l.Parent == null).ToList<ILink>();
        }
    }
}
