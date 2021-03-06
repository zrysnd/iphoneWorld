﻿using System;
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
            ContainerBindInterfaceTo<IgroupOfTestable, Iphones>(false);
            ContainerBindInterfaceTo<Iphones, Iphones>(true);
            ContainerBindInterfaceTo<Tester, Engineer>(false);
            ContainerBindInterfaceTo<Irecordable, TestRecords>(false);

            ContainerBindInterfaceTo<ITwoDIntArray, TwoDArray>(false);
            Container.Bind<int[]>().To<int[]>().AsTransient().WhenInjectedInto<TwoDArray>();
            Container.Bind<int>().FromInstance((_NumOfPhones + 1)).WhenInjectedInto<TwoDArray>();
            Container.Bind<int>().FromInstance((_NumOfPhones + 1) * (_BuildingHeight + 1)).WhenInjectedInto<int[]>();



            Container.Bind<short>().FromInstance((short)_NumOfPhones).WhenInjectedInto<IgroupOfTestable>();
            Container.Bind<int>().FromInstance(_IPhoneBreakingFloor).WhenInjectedInto<Iphones>();
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
