using NUnit.Framework;
using System;
using Zenject;
namespace iphoneWorld.iphoneWorld.UnitTests

{
    [TestFixture()]
    public class IphoneWorldTestClass : UnitTestBase
    {   
        protected override void SetInstallers()
        {
            installers.Add(new IphoneWorldInstaller());

        }


        [Inject]
        Ibuilding bInjected;

        [Test()]
        public void LinearTest_TestCase()
        {
            //Building b = new Building(100);
            Engineer e = new Engineer(3, bInjected, 3);
            int breaking = e.linearTest();
            Assert.AreEqual(3, breaking);

        }

        [Test()]
        public void DpALgoTestCase()
        {
            //Building b = new Building(100);
            DPAlgorithmGenerator dpAlgo = new DPAlgorithmGenerator(3, bInjected);
            Assert.AreEqual(100, dpAlgo.getBuildingHeight() );
            Assert.AreEqual(3, dpAlgo.getNumberOfPhones() );

            dpAlgo.generateDPTable();
            Assert.AreEqual(14, dpAlgo.AccessMaxNumberOfTestsNeeded(2, 100));
            Assert.AreEqual(9, dpAlgo.AccessMaxNumberOfTestsNeeded(3, 100));
            Assert.AreEqual(4, dpAlgo.AccessMaxNumberOfTestsNeeded(2, 10));
            Assert.AreEqual(10, dpAlgo.AccessMaxNumberOfTestsNeeded(1, 10));

        }

        [Test]
        public void DpTableTestCase()
        {
            Building b = new Building(10);
            DPAlgorithmGenerator dpAlgo = new DPAlgorithmGenerator(3, b);
            ItableAccessable aDpTable = dpAlgo.generateDPTable();
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

            //Assert.AreEqual(1, aDpTable.accessTable(2, 1));

            Engineer e = new Engineer(2, b, 3);

            e.moveToNextBestFloor();
            Assert.AreEqual(4, e.getCurrentFloor() );
        }


    }
}
