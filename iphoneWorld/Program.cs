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


            //Ibuilding b = new Building(10);
            //Tester e = new Engineer(2, b, 4);
            //e.test();
            int breakingFloor = 699;
            int buildingHeight = 1000;
            int numberOFPhones = 100;

            Ibuilding building = new Building(buildingHeight);
            IalgoGeneratable algoG = new DPAlgorithmGenerator(numberOFPhones, building);

            List<Itestable> phoneList = new List<Itestable>();
            for (int i = 0; i <= numberOFPhones - 1; i++)
            {
                Iphone thisIphone = new Iphone(breakingFloor);
                phoneList.Add(thisIphone);
            }

            Tester e2 = new Engineer(building, breakingFloor, phoneList,algoG);
            e2.test();




        }
    }
}
