using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MikTecnologyNew;

namespace TecnoComponents
{
    public class MaterialNode //: BaseInfoObject, IFindCollection, ICaption, INumberNomenclature,IMaterial
    {
        private static int _typeId = (int)StringTypeNode.MaterialNode;
       
        private static IList<MaterialNode> _fullItems = new List<MaterialNode>();        
        private string _number;
        private string _assortment;
        public string Assortment => _assortment;
        private string _size;
        public string Size => _size;
        private string _standard;
        public string Standard => _standard;

        public IEnumerable<ILink> FullItemsCollection => _fullItems.Cast<ILink>();

        public string Name => _assortment+" "+_size+" "+_standard;

        public string Number => _number;

       
        public static MaterialNode CreateNode(string number, int vers = 0)
        {
            MaterialNode node0 = FindNode(number, 0);
            MaterialNode node = FindNode(number, vers);
            if (node is null)
            {
                node = new MaterialNode(number);
               // node0?.AddVersion(node);
                _fullItems.Add(node);
            }
            return node as MaterialNode;
        }
        private static MaterialNode FindNode(string number, int vers = 0)
        {

            var listNode = (from nod in _fullItems
                            where (nod.Number == number) //&& (nod.Ver == vers)
                            select nod);

            if (listNode.Count() == 0)
            {
                return null;
            }
            else
            {
                return listNode.First();
            }
        }
        public MaterialNode(string number)
        {
            this._number = number;

        }
        public MaterialNode() : this(string.Empty)
        {

        }
        public void SetAssortment(string value)
        {
            this._assortment = value;
        }
        public void SetSize(string value)
        {
            this._size = value;
        }
        public void SetStandard(string value)
        {
            this._standard = value;
        }
     

        public void RemoveMaterial()
        {
            throw new NotImplementedException();
        }
    }
}
