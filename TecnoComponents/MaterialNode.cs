using System;
using System.Collections.Generic;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class MaterialNode : BaseNode
    {
        private static int _typeId = (int)StringTypeNode.MaterialNode;
        public override int TypeNode => _typeId;

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
