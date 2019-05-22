using System;
using Zenject;
using iphoneWorld.iphoneWorld;

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


            Ibuilding b = new Building(10);
            Tester e = new Engineer(2, b, 4);
            e.test();

            Ibuilding b2 = new Building(1000);
            Tester e2 = new Engineer(100, b2, 699);
            e2.test();




        }
    }
}
