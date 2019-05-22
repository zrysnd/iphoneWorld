﻿using System;
namespace iphoneWorld.iphoneWorld
{
    public class Iphone : testItem
    {
        bool _broken;
        int _breakingFloor; //why would a phone know the max floor, max of what -> changed name, this floor is where the iphone breaks.
                           /* I might misunderstood the project, should we decide at which floor the iphone breaks at first,
                            or when we do tests, the program randomly decide whether the phone breaks, and based on the results
                            we tell at which floor the iphones break?  */
        int _currentFloor; //makes sense to be at current floor
        IfloorTellable _carrier;

        public Iphone(int breakingFloor, IfloorTellable carrier)
        {
            _broken = false;
            _breakingFloor = breakingFloor;
            _carrier = carrier;
            _currentFloor = carrier.getCurrentFloor();
        }

        public void breakNow()
        {
            _broken = true;
        }
        public bool isBroken()
        {
            return _broken;
        }

        public void getTested()
        {
            _broken = (_currentFloor > _breakingFloor);
        }

        public void updateCurrentFloor()
        {
            _currentFloor = _carrier.getCurrentFloor();
        }
    }
}
