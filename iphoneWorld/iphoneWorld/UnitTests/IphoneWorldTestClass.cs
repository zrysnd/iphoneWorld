﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Zenject;
namespace iphoneWorld.iphoneWorld.UnitTests

{
    [TestFixture()]
    public class IphoneWorldTestClass : UnitTestBase
    {
        private int _BuildingHeightDefault = 1000;
        private int _IPhoneBreakingFloorDefault = 500;
        private int _NumOfPhonesDefault = 100;

        protected override void SetInstallers()
        {
            UnitTestInstaller HaveToCallConstructorHere = new UnitTestInstaller();

            HaveToCallConstructorHere.BuildingHeight = _BuildingHeightDefault;
            HaveToCallConstructorHere.IPhoneBreakingFloor = _IPhoneBreakingFloorDefault;
            HaveToCallConstructorHere.NumOfPhones = _NumOfPhonesDefault;

            installers.Add( HaveToCallConstructorHere );

        }
        [Inject]
        Tester _engineer;
        [Inject]
        Iphone aIphone;
        [Inject]
        Itestable iPhoneToBeTested;
        [Inject]
        Ibuilding bInjected;
        [Inject]
        IDPTable _table;
        [Inject]
        DPAlgorithmGenerator _dpAlgo;
        [Inject]
        IalgoGeneratable _AlgoToBeInjectedToEngineer;
        [Inject]
        IList<Itestable> _listOfPhones;
        [Inject]
        World world;
        int numOfPhone = 3;
  

        [Test()]
        public void BuildingTestCase()
        {
            Assert.AreEqual(bInjected.getHeight(), _BuildingHeightDefault);
        }

        [Test()]
        public void IphoneTestCase()
        {
            Assert.AreEqual(aIphone.getBreakingFloor(), _IPhoneBreakingFloorDefault);
            aIphone.setBreakingFloor(10000);
            Assert.AreEqual(aIphone.getBreakingFloor(), 10000);

        }


        [Test()]
        public void DpALgoTestCase()
        {   
            Assert.AreEqual(_BuildingHeightDefault, _dpAlgo.getBuildingHeight() );
            Assert.AreEqual(_NumOfPhonesDefault, _dpAlgo.getNumberOfPhones() );

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

        [Test]
        public void EngineerTestCase()
        {

            //List<Itestable> listOfPhones = new List<Itestable>();
            numOfPhone = 100;
            for (int i = 0; i <= numOfPhone - 1; i++)
            {
                _listOfPhones.Add(iPhoneToBeTested);
            }
            _engineer.GoToBuilding(bInjected);
            _engineer.PickUpPhones(_listOfPhones);
            Assert.AreEqual(_IPhoneBreakingFloorDefault, _engineer.test());

        }


        [Test]
        public void WorldTestCase()
        {
            //world = new World();
            int breaking = world.MakeEngineerTest();
            Assert.AreEqual(world.getBreakingFloor(), breaking);/**/
        }



    }
}
