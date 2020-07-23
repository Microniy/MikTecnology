using NUnit.Framework;
using System.Collections.Generic;
using MikTecnology;

namespace MIKUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        class TestNode : BaseNode
        {          
        }
        [Test(Description ="INode test method Add")]
        public void TestINodeAddOne()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();           
            Assert.AreEqual(n1.Nodes.Count, 0);
            n1.Add(n2);
            Assert.AreEqual(n1.Nodes.Count, 1);           
        }
        [Test(Description = "INode test method Add")]
        public void TestINodeAddTwo()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            Assert.AreEqual(n1.Nodes.Count, 0);
            n1.Add(n2);
            n1.Add(n2);
            Assert.AreEqual(n1.Nodes.Count, 1);
            TestNode n3 = new TestNode();
            n1.Add(n3);
            Assert.AreEqual(n1.Nodes.Count, 2);
        }
        [TestCase(100, Description = "INode test method many Add")]
        public void TestINodeAddMany(int value)
        {
            TestNode n1 = new TestNode();       
            
            for(int i = 0; i < value; i++)
            {
                TestNode n2 = new TestNode();
                Assert.AreEqual(n1.Nodes.Count, i);
                n1.Add(n2);
            }
                     
            Assert.AreEqual(n1.Nodes.Count, 100);
        }
        [Test(Description = "INode test Add oneself")]
        public void TestINodeAddSelf()
        {
            TestNode n1 = new TestNode();          
            Assert.AreEqual(n1.Nodes.Count, 0);
            n1.Add(n1);
            Assert.AreEqual(n1.Nodes.Count, 0);
        }
        [Test(Description = "INode test method Remove")]
        public void TestINodeRemoveOne()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            Assert.AreEqual(n1.Nodes.Count, 0);
            n1.Add(n2);               
            Assert.AreEqual(n1.Nodes.Count, 1);
            n1.Remove(n2);
            Assert.AreEqual(n1.Nodes.Count, 0);
        }
        [Test(Description = "INode test method Remove")]
        public void TestINodeRemoveTwo()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            Assert.AreEqual(n1.Nodes.Count, 0);
            n1.Add(n2);
            n1.Add(n3);
            Assert.AreEqual(n1.Nodes.Count, 2);
            n1.Remove(n2);
            Assert.AreEqual(n1.Nodes.Count, 1);
            n1.Remove(n2);
            Assert.AreEqual(n1.Nodes.Count, 1);
            n1.Remove(n3);
            Assert.AreEqual(n1.Nodes.Count, 0);
        }

    }
}