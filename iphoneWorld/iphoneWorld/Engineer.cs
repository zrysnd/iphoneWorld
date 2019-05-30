using System;
using Zenject;
using System.Collections.Generic;


namespace iphoneWorld.iphoneWorld
{
    public class Engineer :  Tester, IfloorTellable
    {

        private int _numOfPhonesLeft; //your engineer is doing too much, violation of [s]olid
        private Itestable _IphoneBeingTested;
        private int _currentFloor;
        private ItableAccessable _DPTable;
        private IalgoGeneratable _DPalgo;
        private Ibuilding _building;
        private Irecordable _testRecord;



        public Engineer( IalgoGeneratable DPAlgoG, int numOfPhones, Itestable Phone, Irecordable testRecord)
        {
            _currentFloor = 0;
            _DPalgo = DPAlgoG;
            _DPTable = _DPalgo.generateDPTable();
            Phone.carriedBy(this);
            _IphoneBeingTested = Phone;
            this._numOfPhonesLeft = numOfPhones;
            _testRecord = testRecord;


        }

        public void GoToBuilding(Ibuilding building)
        {
            _building = building;
            this._testRecord.HighestBrokenFloor = building.getHeight()+1;

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
            int heightOfThisSubBuilding;
            if(_testRecord.LastPhoneBroken)
                heightOfThisSubBuilding = _currentFloor - 1 - _testRecord.NumOfFloorsBelowThisSubBuilding;
            else
                heightOfThisSubBuilding = _testRecord.HighestBrokenFloor - 1 - _currentFloor;

            int nextBestFloorInSubBuilding = _DPTable.accessTable(this._numOfPhonesLeft, heightOfThisSubBuilding);
            _currentFloor = _testRecord.NumOfFloorsBelowThisSubBuilding + nextBestFloorInSubBuilding;
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
                    _testRecord.LastPhoneBroken = true;
                    _testRecord.HighestBrokenFloor = _currentFloor;
                    if (_testRecord.HighestBrokenFloor == _testRecord.NumOfFloorsBelowThisSubBuilding + 1)
                        return;
                    this._numOfPhonesLeft--;

                }
                else
                {
                    _testRecord.LastPhoneBroken = false;
                    Console.WriteLine("Iphone didn't break at floor " + _currentFloor);
                    _testRecord.NumOfFloorsBelowThisSubBuilding = _currentFloor;
                }


        }

        public int test()
        {
            while(_testRecord.HighestBrokenFloor != _testRecord. NumOfFloorsBelowThisSubBuilding + 1)
            {
                testOnePhone();
                Console.WriteLine();
            }
            Console.WriteLine("breaking floor is: " + _testRecord.NumOfFloorsBelowThisSubBuilding);
            Console.WriteLine("_______________________________");
            Console.WriteLine();
            return _testRecord.NumOfFloorsBelowThisSubBuilding;
        }



    }
}
