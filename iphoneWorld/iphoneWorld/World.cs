using System;
using System.Collections.Generic;
//using Zenject;
namespace iphoneWorld.iphoneWorld
{
    /*responsibility of class World is to create all instances of objects in this world,
    and try to apply DI, but DI didn't work*/
    public class World //: UnitTestBase
    {
        //protected override void SetInstallers()
        //{
        //    installers.Add(new IphoneWorldInstaller());

        //}
        //[Inject]
        int _numOfPhones;
        //[Inject]
        Ibuilding _building;
        //[Inject]
        IalgoGeneratable _algoG;
        IDPTable _dpTable;
        //[Inject]
        Itestable _iphone;

        Tester _engineer;
        int _breakingFloor;


        public World()
        {
            _breakingFloor = 500;
            _numOfPhones = 100;
            List<Itestable> phoneList = new List<Itestable>();
            for (int i = 0; i <= _numOfPhones - 1; i++)
            {   
                _iphone = new Iphone(_breakingFloor);
                phoneList.Add(_iphone);
            }
            _building = new Building(1000);
            _dpTable = new DPTable(_numOfPhones, _building);
            _algoG = new DPAlgorithmGenerator(_numOfPhones, _building, _dpTable);
            _engineer = new Engineer(_building, phoneList, _algoG);
        }
        public int MakeEngineerTest()
        {
            return _engineer.test();
        }
    }
}
