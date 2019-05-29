using System;
namespace iphoneWorld.iphoneWorld
{
    public class Iphone : Itestable
    {

        private bool _broken;

        private int _breakingFloor; //why would a phone know the max floor, max of what -> changed name, this floor is where the iphone breaks.
                                    /* I might misunderstood the project, should we decide at which floor the iphone breaks at first,
                                     or when we do tests, the program randomly decide whether the phone breaks, and based on the results
                                     we tell at which floor the iphones break?  */
        private int _currentFloor; //makes sense to be at current floor
        private IfloorTellable _carrier;

        public Iphone(int breakingFloor)
        {
            _broken = false;
            _breakingFloor = breakingFloor;
            _currentFloor = 0;
        }

        public void  carriedBy(IfloorTellable carrier)
        {
            _carrier = carrier;
            _currentFloor = carrier.getCurrentFloor();
        }

        public bool isBroken()
        {
            return _broken;
        }

        public void getTested()
        {
            _broken = (_currentFloor > _breakingFloor);
            //_broken = (_carrier.getCurrentFloor() > _breakingFloor);
        }

        public void updateCurrentFloor()
        {
            _currentFloor = _carrier.getCurrentFloor();
        }

        public  void setBreakingFloor(int floor)
        {
            _breakingFloor = floor;
        }

        public int getBreakingFloor()
        {
            return _breakingFloor;
        }

        
    }
}
