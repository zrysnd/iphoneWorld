using System;
using Zenject;
using System.Collections.Generic;


namespace iphoneWorld.iphoneWorld
{
    public class Engineer :  Tester, IfloorTellable
    {

        /*having a list of phones might not be necessary, just for simulation purpose */
        private int _numOfPhonesLeft; //your engineer is doing too much, violation of [s]olid
        private Itestable _IphoneBeingTested;
        private int _highestBrokenFloor;
        private int _currentFloor;
        private int _numOfFloorsBelowThisSubBuilding;
        private bool _lastPhoneBroke;
        private ItableAccessable _DPTable;
        private IalgoGeneratable _DPalgo;
        private Ibuilding _building;

        public Engineer( IalgoGeneratable DPAlgoG, int numOfPhones, Itestable Phone)
        {
            _currentFloor = 0;
            _numOfFloorsBelowThisSubBuilding = 0;
            _lastPhoneBroke = false;
            _DPalgo = DPAlgoG;
            _DPTable = _DPalgo.generateDPTable();
            Phone.carriedBy(this);
            _IphoneBeingTested = Phone;
            this._numOfPhonesLeft = numOfPhones;

        }

        public void GoToBuilding(Ibuilding building)
        {
            _building = building;
            _highestBrokenFloor = building.getHeight() + 1;
        }

        public void PickUpPhones( int numOfPhones, Itestable Phone)
        {
            Phone.carriedBy(this);
            _IphoneBeingTested = Phone;
            this._numOfPhonesLeft = numOfPhones;
        }

        public int getCurrentFloor() 
        { 
            return _currentFloor; 
        }

        public void moveToNextFloor()
        {
            _currentFloor++;
            this._IphoneBeingTested.updateCurrentFloor();

        }

        public void moveToNextBestFloor()
        {
            //int numOfPhonesLeftNow = _listOfIphone.Count - _IphoneBeingTestedIndex;
            int heightOfThisSubBuilding;
            if (_lastPhoneBroke)
                heightOfThisSubBuilding = _currentFloor - 1 - _numOfFloorsBelowThisSubBuilding;
            else
                heightOfThisSubBuilding = _highestBrokenFloor - 1 - _currentFloor;

            int nextBestFloorInSubBuilding = _DPTable.accessTable(this._numOfPhonesLeft, heightOfThisSubBuilding);
            _currentFloor = _numOfFloorsBelowThisSubBuilding + nextBestFloorInSubBuilding;
            this._IphoneBeingTested.updateCurrentFloor();
            Console.WriteLine("Engineer moved to floor " + _currentFloor);

        }


        public void testOnePhone()
        {

                this.moveToNextBestFloor();
                bool PhoneBroken = _IphoneBeingTested.getTested();

                if (PhoneBroken)
                {   
                    Console.WriteLine("One Iphone broke at floor " + _currentFloor);
                    _lastPhoneBroke = true;
                    _highestBrokenFloor = _currentFloor;
                    if (_highestBrokenFloor == _numOfFloorsBelowThisSubBuilding + 1)
                        return;
                    this._numOfPhonesLeft--;

                }
                else
                {
                    _lastPhoneBroke = false;
                    Console.WriteLine("Iphone didn't break at floor " + _currentFloor);
                    _numOfFloorsBelowThisSubBuilding = _currentFloor;
                }


        }

        public int test()
        {
            while(_highestBrokenFloor != _numOfFloorsBelowThisSubBuilding + 1)
            {
                testOnePhone();
                Console.WriteLine();
            }
            Console.WriteLine("breaking floor is: " + _numOfFloorsBelowThisSubBuilding);
            Console.WriteLine("_______________________________");
            Console.WriteLine();
            return _numOfFloorsBelowThisSubBuilding;
        }



    }
}
