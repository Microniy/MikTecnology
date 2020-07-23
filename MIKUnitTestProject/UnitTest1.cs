using NUnit.Framework;
using System.Collections.Generic;

namespace MIKUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLinkNodeds()
        {
            class TestNode : INode
        {
            private IList<INode> _nodes;
            public IList<INode> Nodes => _nodes;
            public TestNode()
            {

            }
            public void Add(INode nod)
            {

            }
        }
            Assert.Pass();
        }
    }
}