using System;
namespace iphoneWorld.iphoneWorld
{
    public class Iphones : IgroupOfTestable //having this class to represent each individual iphone may not be most economical , after all you could do it using only 1 int. maybe it's better to represent the collection of phones. 
    {
    
        private int _numOfPhonesLeft;
        private int _breakingFloor; //why would a phone know the max floor, max of what -> changed name, this floor is where the iphone breaks.
                                    /* I might misunderstood the project, should we decide at which floor the iphone breaks at first,
                                     or when we do tests, the program randomly decide whether the phone breaks, and based on the results
                                     we tell at which floor the iphones break?  */
                                     
                                     //the project is not to create something useful, it is for you to practice the new skills you learned. make it suitable. 
                                     
        private int _currentFloor; //makes sense to be at current floor
        private IfloorTellable _carrier;

        public int numOfItemsLeft 
        {
            get
            {
                return _numOfPhonesLeft;
            }
            set
            {
                this._numOfPhonesLeft = value;
            }
        }

        public Iphones(int breakingFloor)//, int numOfPhones)
        {
            //_numOfPhonesLeft = numOfPhones;
            _breakingFloor = breakingFloor;
            _currentFloor = 0;
        }



        public void  carriedBy(IfloorTellable carrier)
        {
            _carrier = carrier;
            _currentFloor = carrier.getCurrentFloor();
        }

        public bool getTested()
        {
            return (_currentFloor > _breakingFloor);
        }

        public void updateCurrentFloor()
        {
            _currentFloor = _carrier.getCurrentFloor();
        }

        public int BreakingFloor
        {
            get
            {
                return this._breakingFloor;
            }
            set
            {
                this._breakingFloor = value;
            }
        }

        
    }
}
