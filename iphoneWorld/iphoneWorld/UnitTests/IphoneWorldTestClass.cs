using NUnit.Framework;
using System;
using System.Collections.Generic;
using Zenject;
namespace iphoneWorld.iphoneWorld.UnitTests

{
    [TestFixture()]
    public class IphoneWorldTestClass : UnitTestBase
    {   
        protected override void SetInstallers()
        {
            installers.Add(new UnitTestInstaller());

        }


        [Inject]
        Ibuilding bInjected;
        [Inject]
        IDPTable _table;
        [Inject]
        DPAlgorithmGenerator _dpAlgo;
        [Inject]
        World world;
  

        [Test()]
        public void DpALgoTestCase()
        {   
            //_table = new DPTable(3, bInjected);
            //DPAlgorithmGenerator dpAlgo = new DPAlgorithmGenerator(3, bInjected, _table);
            Assert.AreEqual(1000, _dpAlgo.getBuildingHeight() );
            Assert.AreEqual(3, _dpAlgo.getNumberOfPhones() );

            _dpAlgo.generateDPTable();
            Assert.AreEqual(14, _dpAlgo.AccessMaxNumberOfTestsNeeded(2, 100));
            Assert.AreEqual(9, _dpAlgo.AccessMaxNumberOfTestsNeeded(3, 100));
            Assert.AreEqual(4, _dpAlgo.AccessMaxNumberOfTestsNeeded(2, 10));
            Assert.AreEqual(10, _dpAlgo.AccessMaxNumberOfTestsNeeded(1, 10));

        }

        [Test]
        public void DpTableTestCase()
        {
       
            ItableAccessable aDpTable = _dpAlgo.generateDPTable();

            Assert.AreEqual(1, aDpTable.accessTable(1, 10));

            //this is onw possible worst case, 4 tests, breaking at 10 or higher than 10.
            Assert.AreEqual(4, aDpTable.accessTable(2, 10));
            //didn't break at floor 4-> go to floor 7
            Assert.AreEqual(3, aDpTable.accessTable(2, 6));
            //didn't break at floor 4, didn't break at floor 7-> go to floor 9
            Assert.AreEqual(2, aDpTable.accessTable(2, 3));
            //didn't break at floor 4, didn't break at floor 7, didn't break at floor9, go to floor 10
            Assert.AreEqual(1, aDpTable.accessTable(2, 1));


            //broke at floor 4 -> go to floor 1
            Assert.AreEqual(1, aDpTable.accessTable(1, 3));

            Assert.AreEqual(1, aDpTable.accessTable(2, 1));

        }



        //[Test]
        //public void WorldTestCase()
        //{
        //    //world = new World();
        //    int breaking = world.MakeEngineerTest();
        //    Assert.AreEqual(world.getBreakingFloor(), breaking);/**/
        //}



    }
}
