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
            public new IList<IVersion> Versions;
            public TestNode()
            {
                this.Versions = base.Versions;
            }
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
        [Test(Description = "IVersion test method AddVersion")]
        public void TestIVersionAddOne()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();          
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
        }
        [Test(Description = "IVersion test method AddVersion")]
        public void TestIVersionAddTwo()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.AddVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 2);
        }
        [Test(Description = "IVersion test across method AddVersion")]
        public void TestIVersionAddTwoAcross()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);            
            Assert.AreEqual(n1.Versions.Count, 1);
            n2.AddVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 2);
        }
        [Test(Description = "IVersion test across method AddVersion")]
        public void TestIVersionAddAcrossOnlyBasedLink()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);           
            n2.AddVersion(n3);
            n2.AddVersion(n4);
            Assert.AreEqual(n2.Versions.Count, 0);
        }
        [Test(Description = "IVersion test across method AddVersion")]
        public void TestIVersionAddTreeAcross()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n2.AddVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 2);
            n2.AddVersion(n4);
            Assert.AreEqual(n1.Versions.Count, 3);
            n4.AddVersion(n5);
            Assert.AreEqual(n1.Versions.Count, 4);
            n2.AddVersion(n5);
            Assert.AreEqual(n1.Versions.Count, 4);
        }
        [Test(Description = "IVersion test Add AddVersion")]
        public void TestIVersionAddSelf()
        {
            TestNode n1 = new TestNode();
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n1);
            Assert.AreEqual(n1.Versions.Count, 0);
            TestNode n2 = new TestNode();
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n2.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n2.AddVersion(n1);
            Assert.AreEqual(n1.Versions.Count, 1);
            Assert.AreEqual(n2.Versions.Count, 0);
        }
        [Test(Description = "IVersion test OldVersion")]
        public void TestIVersionOldOneVersion()
        {
            TestNode n1 = new TestNode();  
            TestNode n2 = new TestNode();
            n1.AddVersion(n2);
            Assert.AreEqual(n1.OldVersions.Count, 0);
            Assert.AreEqual(n2.OldVersions.Count, 1);
        }
        [Test(Description = "IVersion test OldVersion")]
        public void TestIVersionOldTwoVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            Assert.AreEqual(n1.OldVersions.Count, 0);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n3.OldVersions.Count, 2);
        }
        [Test(Description = "IVersion test OldVersion")]
        public void TestIVersionOldManyVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.OldVersions.Count, 0);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n3.OldVersions.Count, 2);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n5.OldVersions.Count, 4);
            Assert.AreEqual(n6.OldVersions.Count, 5);
            Assert.AreEqual(n7.OldVersions.Count, 6);
        }
        [Test(Description = "IVersion test NextVersion")]
        public void TestIVersionNextOneVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();            
            n1.AddVersion(n2);
            Assert.AreEqual(n1.NextVersions.Count, 1);
            Assert.AreEqual(n2.NextVersions.Count, 0);
        }
        [Test(Description = "IVersion test NextVersion")]
        public void TestIVersionNextTwoVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            Assert.AreEqual(n1.NextVersions.Count, 2);
            Assert.AreEqual(n2.NextVersions.Count, 1);
            Assert.AreEqual(n3.NextVersions.Count, 0);
        }
        [Test(Description = "IVersion test NextVersion")]
        public void TestIVersionNextManyVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.NextVersions.Count, 6);
            Assert.AreEqual(n2.NextVersions.Count, 5);
            Assert.AreEqual(n3.NextVersions.Count, 4);
            Assert.AreEqual(n4.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 2);
            Assert.AreEqual(n6.NextVersions.Count, 1);
            Assert.AreEqual(n7.NextVersions.Count, 0);           
        }
        [Test(Description = "IVersion test method RemoveVersion")]
        public void TestIVersionRemoveOne()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode(); 
            n1.AddVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.RemoveVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 0);

        }
        [Test(Description = "IVersion test method RemoveVersion")]
        public void TestIVersionRemoveTwo()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 2);
            n1.RemoveVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.RemoveVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 0);
            n1.AddVersion(n2);
            n2.AddVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 2);
            n2.RemoveVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.RemoveVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 1);
            n1.RemoveVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 0);
        }
        [Test(Description = "IVersion test method RemoveVersion")]
        public void TestIVersionRemoveManyVersion()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.Versions.Count, 6);
            n7.RemoveVersion(n7);
            Assert.AreEqual(n1.Versions.Count, 5);
            n3.RemoveVersion(n3);
            Assert.AreEqual(n1.Versions.Count, 4);
            n7.RemoveVersion(n6);//n7 already deleted n6 not delete
            Assert.AreEqual(n1.Versions.Count, 4);
            n6.RemoveVersion();
            Assert.AreEqual(n1.Versions.Count, 3);
            n4.RemoveVersion(n2);
            Assert.AreEqual(n1.Versions.Count, 2);
        }
        [Test(Description = "IVersion test method RemoveVersion correct NextVersion")]
        public void TestIVersionRemoveVersionNextCount()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.NextVersions.Count, 6);
            Assert.AreEqual(n3.NextVersions.Count, 4);
            Assert.AreEqual(n5.NextVersions.Count, 2);
            n7.RemoveVersion(n7);
            Assert.AreEqual(n1.NextVersions.Count, 5);
            Assert.AreEqual(n3.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            n3.RemoveVersion(n3);
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            n7.RemoveVersion(n6);//n7 already deleted n6 not delete
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            n6.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 3);
            Assert.AreEqual(n2.NextVersions.Count, 2);
            Assert.AreEqual(n5.NextVersions.Count, 0);
            n4.RemoveVersion(n2);
            Assert.AreEqual(n1.NextVersions.Count, 2);
            Assert.AreEqual(n4.NextVersions.Count, 1);
            Assert.AreEqual(n5.NextVersions.Count, 0);
        }
        [Test(Description = "IVersion test method RemoveVersion correct OldVersion")]
        public void TestIVersionRemoveVersionOldCount()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);            
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 6);
            n7.RemoveVersion(n6);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 5);
            n3.RemoveVersion(n3);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n6.RemoveVersion(n7);//n7 already deleted n6 not delete
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n5.RemoveVersion();
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 3);
            n4.RemoveVersion(n2);
            Assert.AreEqual(n4.OldVersions.Count, 1);           
            Assert.AreEqual(n7.OldVersions.Count, 2);
        }
        [Test(Description = "IVersion test methods AddVersion, RemoveVersion correct OldVersion and NextVersion")]
        public void TestIVersionManyTimesAddedRemoved()
        {
            TestNode n1 = new TestNode();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            TestNode n4 = new TestNode();
            TestNode n5 = new TestNode();
            TestNode n6 = new TestNode();
            TestNode n7 = new TestNode();
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.NextVersions.Count, 6);
            Assert.AreEqual(n3.NextVersions.Count, 4);
            Assert.AreEqual(n5.NextVersions.Count, 2);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 6);
            n7.RemoveVersion(n6);
            Assert.AreEqual(n1.NextVersions.Count, 5);
            Assert.AreEqual(n3.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 5);
            n3.RemoveVersion(n3);
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n6.RemoveVersion(n7);//n7 already deleted n6 not delete
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n5.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 3);
            Assert.AreEqual(n2.NextVersions.Count, 2);
            Assert.AreEqual(n7.NextVersions.Count, 0);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 3);
            n4.RemoveVersion(n2);
            Assert.AreEqual(n1.NextVersions.Count, 2);
            Assert.AreEqual(n4.NextVersions.Count, 1);
            Assert.AreEqual(n7.NextVersions.Count, 0);
            Assert.AreEqual(n4.OldVersions.Count, 1);
            Assert.AreEqual(n7.OldVersions.Count, 2);
            n7.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 1);
            Assert.AreEqual(n4.NextVersions.Count, 0);
            Assert.AreEqual(n4.OldVersions.Count, 1);
            n4.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 0);
            Assert.AreEqual(n1.OldVersions.Count, 0);
            n1.AddVersion(n2);
            n1.AddVersion(n3);
            n1.AddVersion(n4);
            n3.AddVersion(n5);
            n5.AddVersion(n6);
            n2.AddVersion(n7);
            Assert.AreEqual(n1.NextVersions.Count, 6);
            Assert.AreEqual(n3.NextVersions.Count, 4);
            Assert.AreEqual(n5.NextVersions.Count, 2);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 6);
            n7.RemoveVersion(n6);
            Assert.AreEqual(n1.NextVersions.Count, 5);
            Assert.AreEqual(n3.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 3);
            Assert.AreEqual(n7.OldVersions.Count, 5);
            n3.RemoveVersion(n3);
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n6.RemoveVersion(n7);//n7 already deleted n6 not delete
            Assert.AreEqual(n1.NextVersions.Count, 4);
            Assert.AreEqual(n2.NextVersions.Count, 3);
            Assert.AreEqual(n5.NextVersions.Count, 1);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 4);
            n5.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 3);
            Assert.AreEqual(n2.NextVersions.Count, 2);
            Assert.AreEqual(n7.NextVersions.Count, 0);
            Assert.AreEqual(n2.OldVersions.Count, 1);
            Assert.AreEqual(n4.OldVersions.Count, 2);
            Assert.AreEqual(n7.OldVersions.Count, 3);
            n4.RemoveVersion(n2);
            Assert.AreEqual(n1.NextVersions.Count, 2);
            Assert.AreEqual(n4.NextVersions.Count, 1);
            Assert.AreEqual(n7.NextVersions.Count, 0);
            Assert.AreEqual(n4.OldVersions.Count, 1);
            Assert.AreEqual(n7.OldVersions.Count, 2);
            n7.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 1);
            Assert.AreEqual(n4.NextVersions.Count, 0);
            Assert.AreEqual(n4.OldVersions.Count, 1);
            n4.RemoveVersion();
            Assert.AreEqual(n1.NextVersions.Count, 0);
            Assert.AreEqual(n1.OldVersions.Count, 0);
        }
    }
}