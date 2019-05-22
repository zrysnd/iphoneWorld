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

        //[Inject] Ibuilding b2;

        public static void Main(string[] args)
        {


            Ibuilding b = new Building(10);
            Tester e = new Engineer(2, b, 4);
            e.test();

            Ibuilding b2 = new Building(100);
            Tester e2 = new Engineer(4, b2, 99);
            e2.test();




        }
    }
}
