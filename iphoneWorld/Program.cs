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

            World w = new World();
            w.MakeEngineerTest();


        }
    }
}
