using System;
using System.Collections.Generic;
using System.Text;
using MikTecnologyNew;


namespace TecnoComponents
{
    public class AssemblyNode : BaseNode,INumberNomenclature,ICaption
    {
        private static int _typeId = 1;
        public override int TypeNode => _typeId;
        private string _name;
        public override string Name => _name;

        public string Number => _name;

        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public AssemblyNode(string name)
        {
            this._name = name;
        }
        public AssemblyNode() : this(string.Empty)
        {

        }
    }
    
}
