using NUnit.Framework;
using System.Collections.Generic;
using MikTecnologyNew;
using System;
using System.Linq;
using TecnoComponents;

namespace MIKUnitTestProject
{
    public class Tests
    {
        TechnologyLinkFactoryImplementation factoryLink;
        TechnologyInfoFactoryImplementation factoryInfo;
        [SetUp]
        public void Setup()
        {
           
        }
        public class TestNode : BaseInfoObject
        {
            private static int _idType = 0;
            private string _name;
            public new IList<IVersion> Versions;
            public TestNode()
            {
                this.Versions = base.Versions;
                _name = string.Empty;
            }
            public override int TypeNode => _idType;
            
         
        }
        [Test(Description ="ILink test method Add")]
        public void ILink_AddNode_One()
        {
            ILink n1 = new Link();
            IInformation n2 = new TestNode();           
            Assert.AreEqual(n1.Children.Count, 0);
            n1.AddNode(n2);
            Assert.AreEqual(n1.Children.Count, 1);            
            Assert.AreEqual(n1.Children[0]?.Info, n2);
        }
       
        [Test(Description = "ILink test method Add")]
        public void ILink_AddNode_Two()
        {
            ILink n1 = new Link();
            TestNode n2 = new TestNode();
            Assert.AreEqual(n1.Children.Count, 0);
            n1.AddNode(n2);
            Assert.AreEqual(n1.Children.Count, 1);
            Assert.AreEqual(n1.Children[0]?.Info, n2);
            n1.AddNode(n2);
            Assert.AreEqual(n1.Children.Count, 1);
            TestNode n3 = new TestNode();
            n1.AddNode(n3);
            Assert.AreEqual(n1.Children.Count, 2);
            Assert.AreEqual(n1.Children[0]?.Info, n2);
            Assert.AreEqual(n1.Children[1]?.Info, n3);
        }
       
       [TestCase(100, Description = "ILink test method many Add")]
       public void ILink_AddNode_Many(int value)
       {
            ILink n1 = new Link();       

           for(int i = 0; i < value; i++)
           {
               TestNode n2 = new TestNode();
               Assert.AreEqual(n1.Children.Count, i);
               n1.AddNode(n2);
               Assert.AreEqual(n1.Children[i]?.Info, n2);
            }

           Assert.AreEqual(n1.Children.Count, value);
       }
       
      [Test(Description = "ILink test Add oneself")]
      public void ILink_AddNode_Self_NotAdded()
      {
            IInformation n2 = new TestNode();
            ILink n1 = new Link(n2);                   
            Assert.AreEqual(n1.Children.Count, 0);
            n1.AddNode(n2);
            Assert.AreEqual(n1.Children.Count, 0);
      }
       
     [Test(Description = "ILink test method Remove")]
     public void ILink_Remove_One()
     {
            ILink n1 = new Link();
            TestNode n2 = new TestNode();
            Assert.AreEqual(n1.Children.Count, 0);
            n1.AddNode(n2);               
            Assert.AreEqual(n1.Children.Count, 1);
            n1.RemoveNode(n2);
            Assert.AreEqual(n1.Children.Count, 0);
     }
        
    [Test(Description = "ILink test method Remove")]
    public void ILink_Remove_Two()
    {
            ILink n1 = new Link();
            TestNode n2 = new TestNode();
            TestNode n3 = new TestNode();
            Assert.AreEqual(n1.Children.Count, 0);
            n1.AddNode(n2);
            n1.AddNode(n3);
            Assert.AreEqual(n1.Children.Count, 2);
            Assert.AreEqual(n1.Children[0]?.Info, n2);
            Assert.AreEqual(n1.Children[1]?.Info, n3);
            n1.RemoveNode(n2);
            Assert.AreEqual(n1.Children.Count, 1);
            Assert.AreEqual(n1.Children[0]?.Info, n3);
            n1.RemoveNode(n2);
            Assert.AreEqual(n1.Children.Count, 1);
            Assert.AreEqual(n1.Children[0]?.Info, n3);
            n1.RemoveNode(n3);
            Assert.AreEqual(n1.Children.Count, 0);
    }
        /*
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
        Assert.IsTrue(n2.OldVersions.Contains(n1));
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
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n3.OldVersions.Count, 2);
        Assert.IsTrue(n3.OldVersions.Contains(n1));
        Assert.IsTrue(n3.OldVersions.Contains(n2));
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
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n3.OldVersions.Count, 2);
        Assert.IsTrue(n3.OldVersions.Contains(n1));
        Assert.IsTrue(n3.OldVersions.Contains(n2));
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n5.OldVersions.Count, 4);
        Assert.IsTrue(n5.OldVersions.Contains(n1));
        Assert.IsTrue(n5.OldVersions.Contains(n2));
        Assert.IsTrue(n5.OldVersions.Contains(n3));
        Assert.IsTrue(n5.OldVersions.Contains(n4));
        Assert.AreEqual(n6.OldVersions.Count, 5);
        Assert.IsTrue(n6.OldVersions.Contains(n1));
        Assert.IsTrue(n6.OldVersions.Contains(n2));
        Assert.IsTrue(n6.OldVersions.Contains(n3));
        Assert.IsTrue(n6.OldVersions.Contains(n4));
        Assert.IsTrue(n6.OldVersions.Contains(n5));
        Assert.AreEqual(n7.OldVersions.Count, 6);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsTrue(n7.OldVersions.Contains(n6));
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
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 6);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsTrue(n7.OldVersions.Contains(n6));
        n7.RemoveVersion(n6);
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 5);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        n3.RemoveVersion(n3);
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 4);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        n6.RemoveVersion(n7);//n7 already deleted n6 not delete
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.AreEqual(n7.OldVersions.Count, 4);
        n5.RemoveVersion();
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 3);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsFalse(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        n4.RemoveVersion(n2);
        Assert.AreEqual(n4.OldVersions.Count, 1);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsFalse(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 2);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsFalse(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsFalse(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
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
        Assert.IsTrue(n1.NextVersions.Contains(n2));
        Assert.IsTrue(n1.NextVersions.Contains(n3));
        Assert.IsTrue(n1.NextVersions.Contains(n4));
        Assert.IsTrue(n1.NextVersions.Contains(n5));
        Assert.IsTrue(n1.NextVersions.Contains(n6));
        Assert.IsTrue(n1.NextVersions.Contains(n7));
        Assert.AreEqual(n3.NextVersions.Count, 4);
        Assert.IsTrue(n3.NextVersions.Contains(n4));
        Assert.IsTrue(n3.NextVersions.Contains(n5));
        Assert.IsTrue(n3.NextVersions.Contains(n6));
        Assert.IsTrue(n3.NextVersions.Contains(n7));
        Assert.AreEqual(n5.NextVersions.Count, 2);
        Assert.IsTrue(n5.NextVersions.Contains(n6));
        Assert.IsTrue(n5.NextVersions.Contains(n7));
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 6);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsTrue(n7.OldVersions.Contains(n6));
        n7.RemoveVersion(n6);
        Assert.AreEqual(n1.NextVersions.Count, 5);
        Assert.IsTrue(n1.NextVersions.Contains(n2));
        Assert.IsTrue(n1.NextVersions.Contains(n3));
        Assert.IsTrue(n1.NextVersions.Contains(n4));
        Assert.IsTrue(n1.NextVersions.Contains(n5));
        Assert.IsFalse(n1.NextVersions.Contains(n6));
        Assert.IsTrue(n1.NextVersions.Contains(n7));
        Assert.AreEqual(n3.NextVersions.Count, 3);
        Assert.IsTrue(n3.NextVersions.Contains(n4));
        Assert.IsTrue(n3.NextVersions.Contains(n5));
        Assert.IsFalse(n3.NextVersions.Contains(n6));
        Assert.IsTrue(n3.NextVersions.Contains(n7));
        Assert.AreEqual(n5.NextVersions.Count, 1);
        Assert.IsFalse(n5.NextVersions.Contains(n6));
        Assert.IsTrue(n5.NextVersions.Contains(n7));
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 5);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        n3.RemoveVersion(n3);
        Assert.AreEqual(n1.NextVersions.Count, 4);
        Assert.IsTrue(n1.NextVersions.Contains(n2));
        Assert.IsFalse(n1.NextVersions.Contains(n3));
        Assert.IsTrue(n1.NextVersions.Contains(n4));
        Assert.IsTrue(n1.NextVersions.Contains(n5));
        Assert.IsFalse(n1.NextVersions.Contains(n6));
        Assert.IsTrue(n1.NextVersions.Contains(n7));
        Assert.AreEqual(n2.NextVersions.Count, 3);
        Assert.IsFalse(n2.NextVersions.Contains(n3));
        Assert.IsTrue(n2.NextVersions.Contains(n4));
        Assert.IsTrue(n2.NextVersions.Contains(n5));
        Assert.IsFalse(n2.NextVersions.Contains(n6));
        Assert.IsTrue(n2.NextVersions.Contains(n7));
        Assert.AreEqual(n5.NextVersions.Count, 1);
        Assert.IsFalse(n5.NextVersions.Contains(n6));
        Assert.IsTrue(n5.NextVersions.Contains(n7));
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 4);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        n6.RemoveVersion(n7);//n7 already deleted n6 not delete
        Assert.AreEqual(n1.NextVersions.Count, 4);
        Assert.AreEqual(n2.NextVersions.Count, 3);
        Assert.AreEqual(n5.NextVersions.Count, 1);
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.AreEqual(n7.OldVersions.Count, 4);
        n5.RemoveVersion();
        Assert.AreEqual(n1.NextVersions.Count, 3);
        Assert.IsTrue(n1.NextVersions.Contains(n2));
        Assert.IsFalse(n1.NextVersions.Contains(n3));
        Assert.IsTrue(n1.NextVersions.Contains(n4));
        Assert.IsFalse(n1.NextVersions.Contains(n5));
        Assert.IsFalse(n1.NextVersions.Contains(n6));
        Assert.IsTrue(n1.NextVersions.Contains(n7));
        Assert.AreEqual(n2.NextVersions.Count, 2);
        Assert.IsFalse(n2.NextVersions.Contains(n3));
        Assert.IsTrue(n2.NextVersions.Contains(n4));
        Assert.IsFalse(n2.NextVersions.Contains(n5));
        Assert.IsFalse(n2.NextVersions.Contains(n6));
        Assert.IsTrue(n2.NextVersions.Contains(n7));
        Assert.AreEqual(n7.NextVersions.Count, 0);
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n7.OldVersions.Count, 3);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsFalse(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
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
    [Test(Description = "ILink test property Parent")]
    public void TestINodeParentAddRemove()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        Assert.AreEqual(n2.Parent, null);
        n1.AddNode(n2);
        Assert.AreEqual(n2.Parent, n1);
        Assert.AreEqual(n1.Parent, null);
        n1.RemoveNode(n2);
        Assert.AreEqual(n2.Parent, null);
    }
    [Test(Description = "ILink test property DirectParents")]
    public void TestINodeGrandParentsAddRemove()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        TestNode n3 = new TestNode();
        TestNode n4 = new TestNode();
        n1.AddNode(n2);
        Assert.AreEqual(n2.DirectParents.Count, 1);
        Assert.IsTrue(n2.DirectParents.Contains(n1));
        n2.AddNode(n3);
        Assert.AreEqual(n3.DirectParents.Count, 2);
        Assert.IsTrue(n3.DirectParents.Contains(n1));
        Assert.IsTrue(n3.DirectParents.Contains(n2));
        n3.AddNode(n4);
        Assert.AreEqual(n4.DirectParents.Count, 3);
        Assert.IsTrue(n4.DirectParents.Contains(n1));
        Assert.IsTrue(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
        n1.RemoveNode(n2);
        Assert.AreEqual(n2.DirectParents.Count, 0);
        Assert.IsFalse(n2.DirectParents.Contains(n1));
        Assert.AreEqual(n3.DirectParents.Count, 1);
        Assert.IsFalse(n3.DirectParents.Contains(n1));
        Assert.IsTrue(n3.DirectParents.Contains(n2));
        Assert.AreEqual(n4.DirectParents.Count, 2);
        Assert.IsFalse(n4.DirectParents.Contains(n1));
        Assert.IsTrue(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
        n2.RemoveNode(n3);
        Assert.AreEqual(n3.DirectParents.Count, 0);
        Assert.IsFalse(n3.DirectParents.Contains(n1));
        Assert.IsFalse(n3.DirectParents.Contains(n2));
        Assert.AreEqual(n4.DirectParents.Count, 1);
        Assert.IsFalse(n4.DirectParents.Contains(n1));
        Assert.IsFalse(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
        n1.AddNode(n2);
        n2.AddNode(n3);
        Assert.AreEqual(n2.DirectParents.Count, 1);
        Assert.IsTrue(n2.DirectParents.Contains(n1));
        Assert.AreEqual(n3.DirectParents.Count, 2);
        Assert.IsTrue(n3.DirectParents.Contains(n1));
        Assert.IsTrue(n3.DirectParents.Contains(n2));
        Assert.AreEqual(n4.DirectParents.Count, 3);
        Assert.IsTrue(n4.DirectParents.Contains(n1));
        Assert.IsTrue(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
        n2.RemoveNode(n3);
        Assert.AreEqual(n2.DirectParents.Count, 1);
        Assert.IsTrue(n2.DirectParents.Contains(n1));
        Assert.AreEqual(n3.DirectParents.Count, 0);
        Assert.IsFalse(n3.DirectParents.Contains(n1));
        Assert.IsFalse(n3.DirectParents.Contains(n2));
        Assert.AreEqual(n4.DirectParents.Count, 1);
        Assert.IsFalse(n4.DirectParents.Contains(n1));
        Assert.IsFalse(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
        n2.AddNode(n3);
        Assert.AreEqual(n2.DirectParents.Count, 1);
        Assert.IsTrue(n2.DirectParents.Contains(n1));
        Assert.AreEqual(n3.DirectParents.Count, 2);
        Assert.IsTrue(n3.DirectParents.Contains(n1));
        Assert.IsTrue(n3.DirectParents.Contains(n2));
        Assert.AreEqual(n4.DirectParents.Count, 3);
        Assert.IsTrue(n4.DirectParents.Contains(n1));
        Assert.IsTrue(n4.DirectParents.Contains(n2));
        Assert.IsTrue(n4.DirectParents.Contains(n3));
    }
    [Test(Description = "ILink test cyclic links")]
    public void TestINodeCyclicLinks()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        Assert.AreEqual(n1.Children.Count, 0);
        n1.AddNode(n2);
        Assert.AreEqual(n1.Children.Count, 1);
        n2.AddNode(n1);
        Assert.AreEqual(n2.Children.Count, 0);
        TestNode n3 = new TestNode();
        TestNode n4 = new TestNode();
        TestNode n5 = new TestNode();
        TestNode n6 = new TestNode();
        n3.AddNode(n4);
        Assert.AreEqual(n3.Children.Count, 1);
        n4.AddNode(n5);
        Assert.AreEqual(n4.Children.Count, 1);
        n4.AddNode(n6);
        Assert.AreEqual(n4.Children.Count, 2);
        n4.AddNode(n1);
        Assert.AreEqual(n4.Children.Count, 3);
        n2.AddNode(n3);
        Assert.AreEqual(n2.Children.Count, 0);
    }
    [Test(Description = "test property TypeID ")]
    public void TestBaseNodeTypeIdRealization()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        Assert.IsNotNull(n1.TypeNode);
        Assert.AreEqual(n1.TypeNode, n2.TypeNode);
    }       
    [Test(Description = "Test AssemblyNode int TypeNode not null")]
    public void AseemblyNode_TypeNode_NotNull()
    {
        AssemblyNode n1 = new AssemblyNode();
        Assert.IsNotNull(n1.TypeNode);
    }
    [Test(Description = "Test ITecnologyNodeFactory create object AssemblyNode all type realization")]
    public void ITecnologyNodeFactory_AseemblyNode_Created()
    {
        ILink n1 = factory.Make("AssemblyNode", "test");
        Assert.IsTrue(n1 is AssemblyNode);
        Assert.IsTrue(n1 is BaseInfoObject);
        Assert.IsTrue(n1 is ILink);
        Assert.IsTrue(n1 is IVersion);
        Assert.IsTrue(n1 is INumberNomenclature);
        Assert.IsTrue(n1 is ICaption);
    }
    [Test(Description = "Test AssemblyNode string INumberNomenclature correct")]
    public void AseemblyNode_INumberNomenclature_NumberCorrect()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");
        Assert.IsNotNull((n1 as INumberNomenclature).Number);
        Assert.AreEqual((n1 as INumberNomenclature).Number, "number_1");
    }
    [Test(Description = "Test AssemblyNode string ICaption correct")]
    public void AseemblyNode_ICaption_NameCorrect()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");
        Assert.IsNotNull((n1 as ICaption).Name);
        Assert.AreEqual((n1 as ICaption).Name, "number_1");
    }
    [Test(Description = "Test AssemblyNode Number equal Name")]
    public void AseemblyNode_Number_Name()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");           
        Assert.AreEqual((n1 as INumberNomenclature).Number, (n1 as ICaption).Name);
    }
    [Test(Description = "IVersion test property Ver")]
    public void IVersion_Ver_New()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");
        Assert.IsNotNull((n1 as IVersion).Ver);
        Assert.AreEqual((n1 as IVersion).Ver, 0);
    }
    [Test(Description = "IVersion test property Ver new versions and test IFindCollection count")]
    public void AseemblyNode_MakeAsembly_GenerateNewVersions()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");
        ILink n2 = factory.Make("AssemblyNode", "number_1");
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 1);
        Assert.AreEqual((n2 as IFindCollection).FullItemsCollection.Count(), 1);
        Assert.AreEqual(n1,n2);
        ILink n3 = factory.Make("AssemblyNode", "number_1",1);
        Assert.AreNotEqual(n1, n3);
        Assert.AreEqual((n1 as IVersion).Ver, 0);
        Assert.AreEqual((n2 as IVersion).Ver, 0);
        Assert.AreEqual((n3 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 2);
        Assert.AreEqual((n3 as IFindCollection).FullItemsCollection.Count(), 2);
        ILink n4 = factory.Make("AssemblyNode", "number_1", 1);
        Assert.AreEqual(n3, n4);
        Assert.AreEqual((n4 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 2);
        Assert.AreEqual((n4 as IFindCollection).FullItemsCollection.Count(), 2);
        ILink n5 = factory.Make("AssemblyNode", "number_1", 2000);
        Assert.AreEqual((n5 as IVersion).Ver, 2);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 3);
        Assert.AreEqual((n5 as IFindCollection).FullItemsCollection.Count(), 3);
        ILink n6 = factory.Make("AssemblyNode", "number_1", -1);
        Assert.AreEqual((n6 as IVersion).Ver, 3);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 4);
        Assert.AreEqual((n6 as IFindCollection).FullItemsCollection.Count(), 4);
        ILink n7 = factory.Make("AssemblyNode", "number_2", -1);
        Assert.AreEqual((n7 as IVersion).Ver, 0);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), 5);
        Assert.AreEqual((n7 as IFindCollection).FullItemsCollection.Count(), 5);
    }
    [Test(Description = "IDescription test property Description")]
    public void IDescription_AseemblyNode_DescriptionCreate()
    {
        ILink n1 = factory.Make("AssemblyNode", "number_1");          
        Assert.IsNotNull((n1 as IDescription).Description);
        ILink n2 = factory.Make("AssemblyNode", "number_2");
        Assert.IsNotNull((n2 as IDescription).Description);
        (n1 as IDescription).SetDescription = "test1";
        Assert.AreEqual((n1 as IDescription).Description, "test1");            
        Assert.AreEqual((n2 as IDescription).Description, "");
        (n2 as IDescription).SetDescription = "test2";
        Assert.AreEqual((n2 as IDescription).Description, "test2");
        (n1 as IDescription).SetDescription = "test3";
        Assert.AreEqual((n1 as IDescription).Description, "test3");
    }
    [Test(Description = "IVersion test methods AddVersion, RemoveVersion correct OldVersion1 and OldVersion2")]
    public void IVersionOldVersion1_2_Tested()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        TestNode n3 = new TestNode();
        TestNode n4 = new TestNode();
        TestNode n5 = new TestNode();
        TestNode n6 = new TestNode();
        TestNode n7 = new TestNode();
        Assert.IsNull(n2.OldVersion1);
        Assert.IsNull(n2.OldVersion2);
        n1.AddVersion(n2);
        n1.AddVersion(n3);
        n1.AddVersion(n4);
        n3.AddVersion(n5);
        n5.AddVersion(n6);
        n2.AddVersion(n7);
        Assert.AreEqual(n2.OldVersions.Count,1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n2.OldVersion1, n1);
        Assert.IsNull(n2.OldVersion2);

        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n4.OldVersion1, n3);
        Assert.AreEqual(n4.OldVersion2, n2);

        Assert.AreEqual(n7.OldVersions.Count, 6);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsTrue(n7.OldVersions.Contains(n6));
        Assert.AreEqual(n7.OldVersion1, n6);
        Assert.AreEqual(n7.OldVersion2, n5);
        n7.RemoveVersion(n6);

        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n2.OldVersion1, n1);
        Assert.IsNull(n2.OldVersion2);
        Assert.AreEqual(n4.OldVersions.Count, 3);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsTrue(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n4.OldVersion1, n3);
        Assert.AreEqual(n4.OldVersion2, n2);
        Assert.AreEqual(n7.OldVersions.Count, 5);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsTrue(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        Assert.AreEqual(n7.OldVersion1, n5);
        Assert.AreEqual(n7.OldVersion2, n4);
        n3.RemoveVersion(n3);

        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n2.OldVersion1, n1);
        Assert.IsNull(n2.OldVersion2);
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n4.OldVersion1, n2);
        Assert.AreEqual(n4.OldVersion2, n1);
        Assert.AreEqual(n7.OldVersions.Count, 4);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsTrue(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        Assert.AreEqual(n7.OldVersion1, n5);
        Assert.AreEqual(n7.OldVersion2, n4);
        n6.RemoveVersion(n7);//n7 already deleted n6 not delete           
        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.AreEqual(n7.OldVersions.Count, 4);
        n5.RemoveVersion();

        Assert.AreEqual(n2.OldVersions.Count, 1);
        Assert.IsTrue(n2.OldVersions.Contains(n1));
        Assert.AreEqual(n2.OldVersion1, n1);
        Assert.IsNull(n2.OldVersion2);
        Assert.AreEqual(n4.OldVersions.Count, 2);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsTrue(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n4.OldVersion1, n2);
        Assert.AreEqual(n4.OldVersion2, n1);
        Assert.AreEqual(n7.OldVersions.Count, 3);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsTrue(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsFalse(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        Assert.AreEqual(n7.OldVersion1, n4);
        Assert.AreEqual(n7.OldVersion2, n2);
        n4.RemoveVersion(n2);

        Assert.AreEqual(n4.OldVersions.Count, 1);
        Assert.IsTrue(n4.OldVersions.Contains(n1));
        Assert.IsFalse(n4.OldVersions.Contains(n2));
        Assert.IsFalse(n4.OldVersions.Contains(n3));
        Assert.AreEqual(n4.OldVersion1, n1);
        Assert.IsNull(n4.OldVersion2);
        Assert.AreEqual(n7.OldVersions.Count, 2);
        Assert.IsTrue(n7.OldVersions.Contains(n1));
        Assert.IsFalse(n7.OldVersions.Contains(n2));
        Assert.IsFalse(n7.OldVersions.Contains(n3));
        Assert.IsTrue(n7.OldVersions.Contains(n4));
        Assert.IsFalse(n7.OldVersions.Contains(n5));
        Assert.IsFalse(n7.OldVersions.Contains(n6));
        Assert.AreEqual(n7.OldVersion1, n4);
        Assert.AreEqual(n7.OldVersion2, n1);           
    }
    [Test(Description = "IVersion test methods AddVersion, RemoveVersion correct NextVersion1 and NextVersion2")]
    public void IVersionNextVersion1_2_Tested()
    {
        TestNode n1 = new TestNode();
        TestNode n2 = new TestNode();
        TestNode n3 = new TestNode();
        TestNode n4 = new TestNode();
        TestNode n5 = new TestNode();
        TestNode n6 = new TestNode();
        TestNode n7 = new TestNode();
        Assert.IsNull(n1.NextVersion1);
        Assert.IsNull(n1.NextVersion2);

        n1.AddVersion(n2);
        Assert.AreEqual(n1.NextVersion1,n2);
        Assert.IsNull(n1.NextVersion2);

        n1.AddVersion(n3);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.IsNull(n2.NextVersion2);
        Assert.IsNull(n3.NextVersion1);
        Assert.IsNull(n3.NextVersion2);

        n1.AddVersion(n4);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.AreEqual(n2.NextVersion2, n4);
        Assert.AreEqual(n3.NextVersion1, n4);
        Assert.IsNull(n3.NextVersion2);
        Assert.IsNull(n4.NextVersion1);
        Assert.IsNull(n4.NextVersion2);

        n3.AddVersion(n5);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.AreEqual(n2.NextVersion2, n4);
        Assert.AreEqual(n3.NextVersion1, n4);
        Assert.AreEqual(n3.NextVersion2, n5);
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.IsNull(n4.NextVersion2);
        Assert.IsNull(n5.NextVersion1);
        Assert.IsNull(n5.NextVersion2);

        n5.AddVersion(n6);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.AreEqual(n2.NextVersion2, n4);
        Assert.AreEqual(n3.NextVersion1, n4);
        Assert.AreEqual(n3.NextVersion2, n5);
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.AreEqual(n4.NextVersion2, n6);
        Assert.AreEqual(n5.NextVersion1, n6);
        Assert.IsNull(n5.NextVersion2);
        Assert.IsNull(n6.NextVersion1);
        Assert.IsNull(n6.NextVersion2);

        n2.AddVersion(n7);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.AreEqual(n2.NextVersion2, n4);
        Assert.AreEqual(n3.NextVersion1, n4);
        Assert.AreEqual(n3.NextVersion2, n5);
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.AreEqual(n4.NextVersion2, n6);
        Assert.AreEqual(n5.NextVersion1, n6);
        Assert.AreEqual(n5.NextVersion2, n7);
        Assert.AreEqual(n6.NextVersion1, n7);
        Assert.IsNull(n6.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

        n7.RemoveVersion(n6);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n3);
        Assert.AreEqual(n2.NextVersion1, n3);
        Assert.AreEqual(n2.NextVersion2, n4);
        Assert.AreEqual(n3.NextVersion1, n4);
        Assert.AreEqual(n3.NextVersion2, n5);
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.AreEqual(n4.NextVersion2, n7);
        Assert.AreEqual(n5.NextVersion1, n7);
        Assert.IsNull(n5.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

        n3.RemoveVersion(n3);
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n4);
        Assert.AreEqual(n2.NextVersion1, n4);
        Assert.AreEqual(n2.NextVersion2, n5);           
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.AreEqual(n4.NextVersion2, n7);
        Assert.AreEqual(n5.NextVersion1, n7);
        Assert.IsNull(n5.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

        n6.RemoveVersion(n7);//n7 already deleted n6 not delete           
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n4);
        Assert.AreEqual(n2.NextVersion1, n4);
        Assert.AreEqual(n2.NextVersion2, n5);
        Assert.AreEqual(n4.NextVersion1, n5);
        Assert.AreEqual(n4.NextVersion2, n7);
        Assert.AreEqual(n5.NextVersion1, n7);
        Assert.IsNull(n5.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

        n5.RemoveVersion();
        Assert.AreEqual(n1.NextVersion1, n2);
        Assert.AreEqual(n1.NextVersion2, n4);
        Assert.AreEqual(n2.NextVersion1, n4);
        Assert.AreEqual(n2.NextVersion2, n7);
        Assert.AreEqual(n4.NextVersion1, n7);
        Assert.IsNull(n4.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

        n4.RemoveVersion(n2);
        Assert.AreEqual(n1.NextVersion1, n4);
        Assert.AreEqual(n1.NextVersion2, n7);           
        Assert.AreEqual(n4.NextVersion1, n7);
        Assert.IsNull(n4.NextVersion2);
        Assert.IsNull(n7.NextVersion1);
        Assert.IsNull(n7.NextVersion2);

    }
    [Test(Description = "IVersion test methods AddVersion, RemoveVersion correct NextVersion1 and NextVersion2")]
    public void INodes_AddNode_andVersionTest()
    {
        ILink n1 = factory.Make("AssemblyNode", "����.123321.001-001");
        Assert.IsTrue(n1 is AssemblyNode);
        Assert.AreEqual((n1 as IVersion).Ver, 0);
        Assert.AreEqual((n1 as ICaption).Name, "����.123321.001-001");
        Assert.IsNull((n1 as IVersion).NextVersion1);
        ILink n2 = factory.Make("AssemblyNode", "����.123321.001-001",-1);
        Assert.IsTrue(n2 is AssemblyNode);
        Assert.AreEqual((n2 as IVersion).Ver, 1);
        Assert.AreEqual((n2 as ICaption).Name, "����.123321.001-001");
        Assert.AreEqual((n1 as IVersion).NextVersion1,n2);
        Assert.AreEqual((n2 as IVersion).OldVersion1, n1);
        ILink n3 = factory.Make("AssemblyNode", "����.123321.002");
        Assert.IsTrue(n3 is AssemblyNode);
        Assert.AreEqual((n3 as IVersion).Ver, 0);
        Assert.AreEqual((n3 as ICaption).Name, "����.123321.002");
        Assert.IsNull((n3 as IVersion).NextVersion1);
        ILink n4 = factory.Make("AssemblyNode", "����.123321.002", -1);
        Assert.IsTrue(n4 is AssemblyNode);
        Assert.AreEqual((n4 as IVersion).Ver, 1);
        Assert.AreEqual((n4 as ICaption).Name, "����.123321.002");
        Assert.AreEqual((n3 as IVersion).NextVersion1, n4);
        Assert.AreEqual((n4 as IVersion).OldVersion1, n3);
        n1.AddNode(n4);
        Assert.AreEqual(n1.Children.Count,1);
        Assert.IsTrue(n1.Children.Contains(n4));
    }
    [Test(Description = "AssemblyNode test SourceIntTypConvertor. Converter create element for TypeNode")]
    public void AssemblyNode_TypeNode_SourceIntTypConvertor_value()
    {
        SourceIntTypConvertor intTypConvertor = new SourceIntTypConvertor();
        ILink n1 = factory.Make("AssemblyNode", "����.123321.001-001");
        Assert.IsNotNull(intTypConvertor.Convert((n1 as BaseInfoObject).TypeNode, typeof(string), null, null));
    }
    [Test(Description = "AssemblyNode test StringTypeNode make node")]
    public void AssemblyNode_TypeNode_enum_StringTypeNode()
    {           
        ILink n1 = factory.Make(StringTypeNode.AssemblyNode.ToString(), "����.123321.001-001");
        Assert.AreEqual((int)StringTypeNode.AssemblyNode, (n1 as BaseInfoObject).TypeNode);
    }
    [Test(Description = "Test DetailNode int TypeNode not null")]
    public void DetailNode_TypeNode_NotNull()
    {
        DetailNode n1 = new DetailNode();
        Assert.IsNotNull(n1.TypeNode);
    }
    [Test(Description = "Test ITecnologyNodeFactory create object DetailNode all type realization")]
    public void ITecnologyNodeFactory_DetailNode_Created()
    {
        ILink n1 = factory.Make("DetailNode", "test");
        Assert.IsTrue(n1 is DetailNode);
        Assert.IsTrue(n1 is BaseInfoObject);
        Assert.IsTrue(n1 is ILink);
        Assert.IsTrue(n1 is IVersion);
        Assert.IsTrue(n1 is INumberNomenclature);
        Assert.IsTrue(n1 is ICaption);
    }
    [Test(Description = "Test DetailNode string INumberNomenclature correct")]
    public void DetailNode_INumberNomenclature_NumberCorrect()
    {
        ILink n1 = factory.Make("DetailNode", "number_1");
        Assert.IsNotNull((n1 as INumberNomenclature).Number);
        Assert.AreEqual((n1 as INumberNomenclature).Number, "number_1");
    }
    [Test(Description = "Test DetailNode string ICaption correct")]
    public void DetailNode_ICaption_NameCorrect()
    {
        ILink n1 = factory.Make("DetailNode", "number_1");
        Assert.IsNotNull((n1 as ICaption).Name);
        Assert.AreEqual((n1 as ICaption).Name, "number_1");
    }
    [Test(Description = "Test DetailNode Number equal Name")]
    public void DetailNode_Number_Name()
    {
        ILink n1 = factory.Make("DetailNode", "number_1");
        Assert.AreEqual((n1 as INumberNomenclature).Number, (n1 as ICaption).Name);
    }
    [Test(Description = "IVersion test property Ver new versions and test IFindCollection count to DetailNode")]
    public void DetailNode_MakeAsembly_GenerateNewVersions()
    {

        ILink n1 = factory.Make("DetailNode", "number_1");
        int countPerTest = (n1 as IFindCollection).FullItemsCollection.Count();
        ILink n2 = factory.Make("DetailNode", "number_1");
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest);
        Assert.AreEqual((n2 as IFindCollection).FullItemsCollection.Count(), countPerTest);
        Assert.AreEqual(n1, n2);
        ILink n3 = factory.Make("DetailNode", "number_1", 1);
        Assert.AreNotEqual(n1, n3);
        Assert.AreEqual((n1 as IVersion).Ver, 0);
        Assert.AreEqual((n2 as IVersion).Ver, 0);
        Assert.AreEqual((n3 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest+1);
        Assert.AreEqual((n3 as IFindCollection).FullItemsCollection.Count(), countPerTest+1);
        ILink n4 = factory.Make("DetailNode", "number_1", 1);
        Assert.AreEqual(n3, n4);
        Assert.AreEqual((n4 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        Assert.AreEqual((n4 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        ILink n5 = factory.Make("DetailNode", "number_1", 2000);
        Assert.AreEqual((n5 as IVersion).Ver, 2);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 2);
        Assert.AreEqual((n5 as IFindCollection).FullItemsCollection.Count(), countPerTest + 2);
        ILink n6 = factory.Make("DetailNode", "number_1", -1);
        Assert.AreEqual((n6 as IVersion).Ver, 3);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 3);
        Assert.AreEqual((n6 as IFindCollection).FullItemsCollection.Count(), countPerTest + 3);
        ILink n7 = factory.Make("DetailNode", "number_2", -1);
        Assert.AreEqual((n7 as IVersion).Ver, 0);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 4);
        Assert.AreEqual((n7 as IFindCollection).FullItemsCollection.Count(), countPerTest + 4);
    }
    [Test(Description = "IDescription test property Description to DetailNode")]
    public void IDescription_DetailNode_DescriptionCreate()
    {
        ILink n1 = factory.Make("DetailNode", "number_1");
        Assert.IsNotNull((n1 as IDescription).Description);
        ILink n2 = factory.Make("DetailNode", "number_2");
        Assert.IsNotNull((n2 as IDescription).Description);
        (n1 as IDescription).SetDescription = "test1";
        Assert.AreEqual((n1 as IDescription).Description, "test1");
        Assert.AreEqual((n2 as IDescription).Description, "");
        (n2 as IDescription).SetDescription = "test2";
        Assert.AreEqual((n2 as IDescription).Description, "test2");
        (n1 as IDescription).SetDescription = "test3";
        Assert.AreEqual((n1 as IDescription).Description, "test3");
    }
    [Test(Description = "DetailNode test SourceIntTypConvertor. Converter create element for TypeNode")]
    public void DetailNode_TypeNode_SourceIntTypConvertor_value()
    {
        SourceIntTypConvertor intTypConvertor = new SourceIntTypConvertor();
        ILink n1 = factory.Make("DetailNode", "����.123321.001-001");
        Assert.IsNotNull(intTypConvertor.Convert((n1 as BaseInfoObject).TypeNode, typeof(string), null, null));
    }
    [Test(Description = "DetailNode test StringTypeNode make node")]
    public void DetailNode_TypeNode_enum_StringTypeNode()
    {
        ILink n1 = factory.Make(StringTypeNode.DetailNode.ToString(), "����.123321.001-001");
        Assert.AreEqual((int)StringTypeNode.DetailNode, (n1 as BaseInfoObject).TypeNode);
    }
    [Test(Description = "DetailNode test method AddNode link detail-assembly wrong")]
    public void DetailNode_AddNode_NotAdded_Assembly()
    {
        ILink n1 = factory.Make(StringTypeNode.DetailNode.ToString(), "����.123321.100");
        ILink n2 = factory.Make(StringTypeNode.AssemblyNode.ToString(), "����.123321.101");
        n1.AddNode(n2);
        Assert.AreEqual(n1.Children.Count, 0);
        Assert.IsFalse(n1.Children.Contains(n2));            
        n2.AddNode(n1);
        Assert.AreEqual(n2.Children.Count, 1);
        Assert.IsTrue(n2.Children.Contains(n1));
    }
    [Test(Description = "Test MaterialNode int TypeNode not null")]
    public void MaterialNode_TypeNode_NotNull()
    {
        MaterialNode n1 = new MaterialNode();
        Assert.IsNotNull(n1.TypeNode);
    }
    [Test(Description = "Test ITecnologyNodeFactory create object MaterialNode all type realization")]
    public void ITecnologyNodeFactory_MaterialNode_Created()
    {
        ILink n1 = factory.Make("MaterialNode", "test");
        Assert.IsTrue(n1 is MaterialNode);
        Assert.IsTrue(n1 is BaseInfoObject);
        Assert.IsTrue(n1 is ILink);
        Assert.IsTrue(n1 is IVersion);
        Assert.IsTrue(n1 is INumberNomenclature);
        Assert.IsTrue(n1 is ICaption);
    }
    [Test(Description = "Test MaterialNode string INumberNomenclature correct")]
    public void MaterialNode_INumberNomenclature_NumberCorrect()
    {
        ILink n1 = factory.Make("MaterialNode", "number_1");
        Assert.IsNotNull((n1 as INumberNomenclature).Number);
        Assert.AreEqual((n1 as INumberNomenclature).Number, "number_1");
    }
    [Test(Description = "Test MaterialNode string ICaption correct")]
    public void MaterialNode_ICaption_NameCorrect()
    {
        ILink n1 = factory.Make("MaterialNode", "number_1");
        Assert.IsNotNull((n1 as ICaption).Name);
        Assert.AreEqual((n1 as ICaption).Name, "  ");
        (n1 as IMaterial).SetAssortment("�����");
        Assert.AreEqual((n1 as ICaption).Name, "�����  ");
        Assert.AreEqual((n1 as IMaterial).Assortment, "�����");
        (n1 as IMaterial).SetSize("20x30");
        Assert.AreEqual((n1 as ICaption).Name, "����� 20x30 ");
        Assert.AreEqual((n1 as IMaterial).Size, "20x30");
        (n1 as IMaterial).SetStandard("����.12345-99");
        Assert.AreEqual((n1 as ICaption).Name, "����� 20x30 ����.12345-99");
        Assert.AreEqual((n1 as IMaterial).Standard, "����.12345-99");
    }
    [Test(Description = "IVersion test property Ver new versions and test IFindCollection count to MaterialNode")]
    public void MaterialNode_MakeAsembly_GenerateNewVersions()
    {

        ILink n1 = factory.Make("MaterialNode", "number_1");
        int countPerTest = (n1 as IFindCollection).FullItemsCollection.Count();
        ILink n2 = factory.Make("MaterialNode", "number_1");
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest);
        Assert.AreEqual((n2 as IFindCollection).FullItemsCollection.Count(), countPerTest);
        Assert.AreEqual(n1, n2);
        ILink n3 = factory.Make("MaterialNode", "number_1", 1);
        Assert.AreNotEqual(n1, n3);
        Assert.AreEqual((n1 as IVersion).Ver, 0);
        Assert.AreEqual((n2 as IVersion).Ver, 0);
        Assert.AreEqual((n3 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        Assert.AreEqual((n3 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        ILink n4 = factory.Make("MaterialNode", "number_1", 1);
        Assert.AreEqual(n3, n4);
        Assert.AreEqual((n4 as IVersion).Ver, 1);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        Assert.AreEqual((n4 as IFindCollection).FullItemsCollection.Count(), countPerTest + 1);
        ILink n5 = factory.Make("MaterialNode", "number_1", 2000);
        Assert.AreEqual((n5 as IVersion).Ver, 2);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 2);
        Assert.AreEqual((n5 as IFindCollection).FullItemsCollection.Count(), countPerTest + 2);
        ILink n6 = factory.Make("MaterialNode", "number_1", -1);
        Assert.AreEqual((n6 as IVersion).Ver, 3);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 3);
        Assert.AreEqual((n6 as IFindCollection).FullItemsCollection.Count(), countPerTest + 3);
        ILink n7 = factory.Make("MaterialNode", "number_2", -1);
        Assert.AreEqual((n7 as IVersion).Ver, 0);
        Assert.AreEqual((n1 as IFindCollection).FullItemsCollection.Count(), countPerTest + 4);
        Assert.AreEqual((n7 as IFindCollection).FullItemsCollection.Count(), countPerTest + 4);
    }
    [Test(Description = "MaterialNode test SourceIntTypConvertor. Converter create element for TypeNode")]
    public void MaterialNode_TypeNode_SourceIntTypConvertor_value()
    {
        SourceIntTypConvertor intTypConvertor = new SourceIntTypConvertor();
        ILink n1 = factory.Make("MaterialNode", "����.123321.001-001");
        Assert.IsNotNull(intTypConvertor.Convert((n1 as BaseInfoObject).TypeNode, typeof(string), null, null));
    }
    [Test(Description = "MaterialNode test StringTypeNode make node")]
    public void MaterialNode_TypeNode_enum_StringTypeNode()
    {
        ILink n1 = factory.Make(StringTypeNode.MaterialNode.ToString(), "����.123321.001-001");
        Assert.AreEqual((int)StringTypeNode.MaterialNode, (n1 as BaseInfoObject).TypeNode);
    }
    [Test(Description = "MaterialNode test method AddNode link detail-assembly wrong")]
    public void MaterialNode_AddNode_NotAdded_Assembly()
    {
        ILink n1 = factory.Make(StringTypeNode.DetailNode.ToString(), "����.123321.100");
        ILink n2 = factory.Make(StringTypeNode.MaterialNode.ToString(), "����.123321.101");
        n1.AddNode(n2);
        Assert.AreEqual(n1.Children.Count, 0);
        Assert.IsFalse(n1.Children.Contains(n2));
        n2.AddNode(n1);
        Assert.AreEqual(n2.Children.Count, 0);
        Assert.IsFalse(n2.Children.Contains(n1));
    }
    [Test(Description = "DatailNode test IMaterial property")]
    public void DatailNode_AddNode_Material()
    {
        ILink n1 = factory.Make(StringTypeNode.DetailNode.ToString(), "����.123321.100");
        Assert.IsNull((n1 as IMaterial).Assortment);
        Assert.IsNull((n1 as IMaterial).Size);
        Assert.IsNull((n1 as IMaterial).Standard);
        ILink n2 = factory.Make(StringTypeNode.MaterialNode.ToString(), "123");
        n1.AddNode(n2);
        Assert.IsNull((n1 as IMaterial).Assortment);
        Assert.IsNull((n1 as IMaterial).Size);
        Assert.IsNull((n1 as IMaterial).Standard);
        (n2 as IMaterial).SetAssortment("����");
        Assert.AreEqual((n2 as IMaterial).Assortment, "����");
        Assert.AreEqual((n1 as IMaterial).Assortment, "����");
        (n2 as IMaterial).SetSize("100");
        Assert.AreEqual((n2 as IMaterial).Size, "100");
        Assert.AreEqual((n1 as IMaterial).Size, "100");
        (n2 as IMaterial).SetStandard("����");
        Assert.AreEqual((n2 as IMaterial).Standard, "����");
        Assert.AreEqual((n1 as IMaterial).Standard, "����");
        (n1 as IMaterial).SetAssortment("�����");
        Assert.AreEqual((n2 as IMaterial).Assortment, "�����");
        Assert.AreEqual((n1 as IMaterial).Assortment, "�����");
        (n1 as IMaterial).SetSize("60");
        Assert.AreEqual((n2 as IMaterial).Size, "60");
        Assert.AreEqual((n1 as IMaterial).Size, "60");
        (n1 as IMaterial).SetStandard("DIN");
        Assert.AreEqual((n2 as IMaterial).Standard, "DIN");
        Assert.AreEqual((n1 as IMaterial).Standard, "DIN");
    }
    */
    }
}