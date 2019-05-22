using System;
using Zenject;
namespace iphoneWorld.iphoneWorld

{
    public class IphoneWorldInstaller: BindingInstaller
    {
        public override void Bind()
        {
            //Container.Bind<Printer>().To<Printer>().AsSingle();
            //Container.Bind<Printer>().FromInstance(new Printer("pp") );
            //ContainerBindInterfaceTo<Building, Building>(true);
            Container.Bind<Ibuilding>().FromInstance(new Building(100));
        }
    }
}
