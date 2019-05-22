using System;
using Zenject;
namespace iphoneWorld.iphoneWorld

{
    public class IphoneWorldInstaller: BindingInstaller
    {
        public override void Bind()
        {
            Container.Bind<Ibuilding>().FromInstance(new Building(1000));
            ContainerBindInterfaceTo<DPAlgorithmGenerator, DPAlgorithmGenerator>(false);
            ContainerBindInterfaceTo<IDPTable, DPTable>(false);
            Container.Bind<int>().FromInstance(3);
            //Container.Bind<IDPTable>().FromInstance(new DPTable(3,new Building(1000)));
            ContainerBindInterfaceTo<Itestable, Iphone>(false);
            ContainerBindInterfaceTo<Tester, Engineer>(false);
            ContainerBindInterfaceTo<World, World>(true);
        }
    }

}
