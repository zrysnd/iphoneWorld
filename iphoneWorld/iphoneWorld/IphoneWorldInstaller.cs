using System;
using System.Collections.Generic;
using Zenject;
namespace iphoneWorld.iphoneWorld

{
    public class UnitTestInstaller: BindingInstaller
    {
        private int _BuildingHeight;
        private int _IPhoneBreakingFloor;
        private int _NumOfPhones;

        public override void Bind()
        {
            ContainerBindInterfaceTo<Ibuilding, Building>(false);
            ContainerBindInterfaceTo<DPAlgorithmGenerator, DPAlgorithmGenerator>(false);
            ContainerBindInterfaceTo<IalgoGeneratable, DPAlgorithmGenerator>(false);
            ContainerBindInterfaceTo<IDPTable, DPTable>(false);
            ContainerBindInterfaceTo<Itestable, Iphone>(false);
            ContainerBindInterfaceTo<Iphone, Iphone>(true);
            ContainerBindInterfaceTo<Tester, Engineer>(false);

            Container.Bind<IList<Itestable>>().To<List<Itestable>>().FromInstance(new List<Itestable>() );

            ContainerBindInterfaceTo<World, World>(true);

            Container.Bind<int>().FromInstance(_IPhoneBreakingFloor).WhenInjectedInto<Iphone>();
            Container.Bind<int>().FromInstance(_BuildingHeight).WhenInjectedInto<Building>();
            Container.Bind<int>().FromInstance(_NumOfPhones);
        }

        public int BuildingHeight
        {
            get
            {
                return _BuildingHeight;
            }
            set
            {
                this._BuildingHeight = value;
            }
        }

        public int IPhoneBreakingFloor
        {
            get
            {
                return this._IPhoneBreakingFloor;
            }
            set
            {
                this._IPhoneBreakingFloor = value;
            }
        }

        public int NumOfPhones
        {
            get
            {
                return this._NumOfPhones;
            }
            set
            {
                this._NumOfPhones = value;
            }
        }


    }


}
