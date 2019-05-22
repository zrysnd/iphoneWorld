using System;
using Zenject;
using System.Collections.Generic;


namespace iphoneWorld.iphoneWorld
{
    public class Engineer : UnitTestBase, Tester
    {
        protected override void SetInstallers()
        {
            installers.Add(new IphoneWorldInstaller());

        }

        List<Itestable> _listOfIphone;
        Itestable _IphoneBeingTested;
        int _IphoneBeingTestedIndex;
        int _highestBrokenFloor;
        //why comment out -> uncommented the list.
        int _currentFloor;
        int _numOfFloorsBelowThisSubBuilding;
        bool _lastPhoneBroke;
        ItableAccessable _DPTable;
        IalgoGeneratable _DPalgo;
        Ibuilding _building;

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

            //Console.WriteLine("heightOfThisSubBuilding: " + heightOfThisSubBuilding);

            int nextBestFloorInSubBuilding = _DPTable.accessTable(numOfPhonesLeftNow, heightOfThisSubBuilding);
            _currentFloor = _numOfFloorsBelowThisSubBuilding + nextBestFloorInSubBuilding;
            for (int i = 0; i <= _listOfIphone.Count - 1; i++)
            {
                _listOfIphone[i].updateCurrentFloor();
            }
            Console.WriteLine("Engineer moved to floor " + _currentFloor);

        }

        /* requires _IphoneBeingTestedIndex <=..
         */
        public void testOnePhone()
        {
            //while(_highestBrokenFloor != _numOfFloorsBelowThisSubBuilding + 1)
            //{
                this.moveToNextBestFloor();
                _IphoneBeingTested.getTested();

                if (_IphoneBeingTested.isBroken())
                {   
                    Console.WriteLine("One Iphone broke at floor " + _currentFloor);
                    _lastPhoneBroke = true;
                    _IphoneBeingTestedIndex++;
                    _highestBrokenFloor = _currentFloor;
                    //Console.WriteLine("number of Iphones: " + _listOfIphone.Count);
                    //Console.WriteLine("which is the current phone: " + _IphoneBeingTestedIndex);
                    if (_highestBrokenFloor == _numOfFloorsBelowThisSubBuilding + 1)
                        return;
                //if (_IphoneBeingTestedIndex >= _listOfIphone.Count)
                        //return false;
                    _IphoneBeingTested = _listOfIphone[_IphoneBeingTestedIndex];

                    
                    //return true;
                }
                else
                {
                    _lastPhoneBroke = false;
                    Console.WriteLine("Iphone didn't break at floor " + _currentFloor);
                    /* need to change _numOfFloorsBelowThisSubBuilding*/
                    _numOfFloorsBelowThisSubBuilding = _currentFloor;
                }

                //return true;
                //Console.WriteLine("_numOfFloorsBelowThisSubBuilding: " + _numOfFloorsBelowThisSubBuilding);
                
            //}

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
