using System;
using Zenject;
using System.Collections.Generic;


namespace iphoneWorld.iphoneWorld
{
    public class Engineer :  Tester, IfloorTellable
    {
    
        //your engineer is doing too much, violation of [s]olid

        private IgroupOfTestable _IphonesBeingTested;
        private int _currentFloor; //usually we put dependencies together , then var together. 
        private ItableAccessable _DPTable; //does the "Accessable" have meaning ? do/will you have nonAccessable?
        private IalgoGeneratable _DPalgo; 
        private Irecordable _testRecord;
        // much more [S]




        public Engineer( IalgoGeneratable DPAlgoG, Irecordable testRecord)
        {
            _currentFloor = 0;
            _DPalgo = DPAlgoG;
            _DPTable = _DPalgo.generateDPTable(); 

            _testRecord = testRecord;

        }

        public void GoToBuilding(Ibuilding building)
        {
            this._testRecord.HighestBrokenFloor = building.getHeight()+1;

        }


        public void PickUpPhones(IgroupOfTestable Phones)
        {
            Phones.carriedBy(this);//will it be picked up by not this?
            _IphonesBeingTested = Phones; //this looks like an Inject
        }


        public int getCurrentFloor() //convert to property
        { 
            return _currentFloor; 
        }

        public void moveToNextFloor()
        {
            _currentFloor++;
            this._IphonesBeingTested.updateCurrentFloor();

        }

        public void moveToNextBestFloor()
        {
            int heightOfThisSubBuilding;
            if(_testRecord.LastPhoneBroken)
                heightOfThisSubBuilding = _currentFloor - 1 - _testRecord.NumOfFloorsBelowThisSubBuilding;
            else
                heightOfThisSubBuilding = _testRecord.HighestBrokenFloor - 1 - _currentFloor;

            int nextBestFloorInSubBuilding = _DPTable.accessTable(_IphonesBeingTested.numOfItemsLeft, heightOfThisSubBuilding);
            _currentFloor = _testRecord.NumOfFloorsBelowThisSubBuilding + nextBestFloorInSubBuilding;
            this._IphonesBeingTested.updateCurrentFloor();
            Console.WriteLine("Engineer moved to floor " + _currentFloor);

        }


        public void testOnePhone()
        {

                this.moveToNextBestFloor();
                bool PhoneBroken = _IphonesBeingTested.getTested();

                if (PhoneBroken)
                {   
                    Console.WriteLine("One Iphone broke at floor " + _currentFloor);
                    _testRecord.LastPhoneBroken = true;
                    _testRecord.HighestBrokenFloor = _currentFloor;
                    if (_testRecord.HighestBrokenFloor == _testRecord.NumOfFloorsBelowThisSubBuilding + 1)
                        return;
                    this._IphonesBeingTested.numOfItemsLeft--;

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
