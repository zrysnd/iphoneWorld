using System;
using Zenject;
using System.Collections.Generic;


namespace iphoneWorld.iphoneWorld
{
    public class Engineer : UnitTestBase, Tester, IfloorTellable
    {
        protected override void SetInstallers()
        {
            installers.Add(new IphoneWorldInstaller());

        }

        /*having a list of phones might not be necessary, just for simulation purpose */
        private List<Itestable> _listOfIphone;
        private Itestable _IphoneBeingTested;
        private int _IphoneBeingTestedIndex;
        private int _highestBrokenFloor;
        private int _currentFloor;
        private int _numOfFloorsBelowThisSubBuilding;
        private bool _lastPhoneBroke;
        private ItableAccessable _DPTable;
        private IalgoGeneratable _DPalgo;
        private Ibuilding _building;

        public Engineer(int numberOFPhones, Ibuilding building, int breakingFloor)
        {
            _currentFloor = 0;
            _numOfFloorsBelowThisSubBuilding = 0;
            _highestBrokenFloor = building.getHeight() + 1;
            _lastPhoneBroke = false;


            _listOfIphone = new List<Itestable>();
            for (int i = 0; i <= numberOFPhones - 1; i++)
            {
                Iphone thisIphone = new Iphone(breakingFloor, this);
                _listOfIphone.Add(thisIphone);
            }
            _IphoneBeingTestedIndex = 0;
            _IphoneBeingTested = _listOfIphone[_IphoneBeingTestedIndex];

            _building = building;
            _DPalgo = new DPAlgorithmGenerator(numberOFPhones, building);
            _DPTable = _DPalgo.generateDPTable();

        }

        public int getCurrentFloor() 
        { 
            return _currentFloor; 
        }

        public void moveToNextFloor()
        {
            _currentFloor++;
            for (int i = 0; i <= _listOfIphone.Count - 1; i++)
            {
                _listOfIphone[i].updateCurrentFloor();
            }

        }

        public void moveToNextBestFloor()
        {
            int numOfPhonesLeftNow = _listOfIphone.Count - _IphoneBeingTestedIndex;
            int heightOfThisSubBuilding;
            if (_lastPhoneBroke)
                heightOfThisSubBuilding = _currentFloor - 1 - _numOfFloorsBelowThisSubBuilding;
            else
                heightOfThisSubBuilding = _highestBrokenFloor - 1 - _currentFloor;

            int nextBestFloorInSubBuilding = _DPTable.accessTable(numOfPhonesLeftNow, heightOfThisSubBuilding);
            _currentFloor = _numOfFloorsBelowThisSubBuilding + nextBestFloorInSubBuilding;
            for (int i = 0; i <= _listOfIphone.Count - 1; i++)
            {
                _listOfIphone[i].updateCurrentFloor();
            }
            Console.WriteLine("Engineer moved to floor " + _currentFloor);

        }


        public void testOnePhone()
        {

                this.moveToNextBestFloor();
                _IphoneBeingTested.getTested();

                if (_IphoneBeingTested.isBroken())
                {   
                    Console.WriteLine("One Iphone broke at floor " + _currentFloor);
                    _lastPhoneBroke = true;
                    _IphoneBeingTestedIndex++;
                    _highestBrokenFloor = _currentFloor;
                    if (_highestBrokenFloor == _numOfFloorsBelowThisSubBuilding + 1)
                        return;
                    _IphoneBeingTested = _listOfIphone[_IphoneBeingTestedIndex];

                }
                else
                {
                    _lastPhoneBroke = false;
                    Console.WriteLine("Iphone didn't break at floor " + _currentFloor);
                    _numOfFloorsBelowThisSubBuilding = _currentFloor;
                }


        }

        public void test()
        {
            while(_highestBrokenFloor != _numOfFloorsBelowThisSubBuilding + 1)
            {
                testOnePhone();
                Console.WriteLine();
            }
            Console.WriteLine("breaking floor is: " + _numOfFloorsBelowThisSubBuilding);
            Console.WriteLine("_______________________________");
            Console.WriteLine();
        }

        public int linearTest()
        {
            int lastFloor = 0;
            while (!_listOfIphone[0].isBroken())
            {
                lastFloor = this._currentFloor;
                this.moveToNextFloor();
                _IphoneBeingTested.getTested();

            }
            return lastFloor;
        }


    }
}
