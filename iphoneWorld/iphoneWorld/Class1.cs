using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.iphoneWorld
{
    public class Iphone : testItem
    {
        bool broken;
        int maxiFloor; //why would a phone know the max floor, max of what
        int currentFloor; //makes sense to be at current floor
        IfloorTellable Carrier;
        public void breakNow(){}
        public void getTested() { }
        public void movedToNewFloor() { } 
        public void carriedBy(Object carrier) { }
    }

    public class DPAlgorithmGenerator : IalgoGeneratable
    {
        Itable DPTable;//I think the algo need to write data to this table?
        public void generateDPAlgo() { } //and where is the algorithm if you don't return it?
    }

    public class Engineer: Tester
    {
        //A list of <ITestable>  
        //why comment out
        int currentFloor;
        IalgoGeneratable algo;
        public void tellfloor() { }
        public void moveToNextBestFloor() { }
        public void test() { }

    }

    public class buidling : Ibuilding
    {
        // The engineer is in the building, so injection?
        //sure
        Imovable engineerInThisBuilding;
        int height;
    }
}
