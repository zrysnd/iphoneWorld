using System;
using Zenject;
namespace iphoneWorld.iphoneWorld

{
    public class IphoneWorldInstaller: BindingInstaller
    {
        public override void Bind()
        {
            //ContainerBindInterfaceTo<Building, Building>(true);
            Container.Bind<Ibuilding>().FromInstance(new Building(100));
        }
    }
}
