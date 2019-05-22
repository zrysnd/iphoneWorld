using System;
using Zenject;
using iphoneWorld.iphoneWorld;
using System.Collections.Generic;

namespace iphoneWorld


{
    class MainClass : UnitTestBase
    {
        protected override void SetInstallers()
        {
            installers.Add(new IphoneWorldInstaller());

        }

        /*it seems that it's hard use inject for main function, main function is static*/
        public static void Main(string[] args)
        {


            //int breakingFloor = 500;
            //int buildingHeight = 1000;
            //int numberOFPhones = 100;

            //Ibuilding building = new Building(buildingHeight);
            //IalgoGeneratable algoG = new DPAlgorithmGenerator(numberOFPhones, building);

            //List<Itestable> phoneList = new List<Itestable>();
            //for (int i = 0; i <= numberOFPhones - 1; i++)
            //{
            //    Iphone thisIphone = new Iphone(breakingFloor);
            //    phoneList.Add(thisIphone);
            //}

            //Tester e2 = new Engineer(building, phoneList,algoG);
            //e2.test();

            World w = new World();
            w.MakeEngineerTest();


        }
    }
}
