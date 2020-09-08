using System;
using System.Collections.Generic;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class TechnologyLinkFactoryImplementation : ITechnologyLinkFactory
    {
        private TechnologyInfoFactoryImplementation InfoFactoryImplementation = new TechnologyInfoFactoryImplementation();

        public ILink Make(string link, string info, string name, int vers = 0)
        {
            IInformation information = InfoFactoryImplementation.Make(info, name, vers);
            switch (link)
            {
                case "Link":
                    return Link.CreateLink(information);
                default:
                    return null;
            }
        }
    }
    public class TechnologyInfoFactoryImplementation : ITechnologyInfoFactory
    {
        public IInformation Make(string info, string name, int vers = 0)
        {
            switch (info)
            {
                case "AssemblyNode":
                    return AssemblyNode.CreateNode(name, vers);
                case "DetailNode":
                    return DetailNode.CreateNode(name, vers);
                case "MaterialNode":
                //     return MaterialNode.CreateNode(name, vers);
                default:
                    return null;
            }
        }
    }
}
