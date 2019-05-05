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
        int maxiFloor;
        int currentFloor;
        IfloorTellable Carrier;
        public void breakNow(){}
        public void getTested() { }
        public void movedToNewFloor() { }
        public void carriedBy(Object carrier) { }
    }

    public class DPAlgorithmGenerator : IalgoGeneratable
    {
        Itable DPTable;//I think the algo need to write data to this table?
        public void generateDPAlgo() { }
    }

    public class Engineer: Tester
    {
        //A list of <ITestable>
        int currentFloor;
        IalgoGeneratable algo;
        public void tellfloor() { }
        public void moveToNextBestFloor() { }
        public void test() { }

    }

    public class buidling : Ibuilding
    {
        // The engineer is in the building, so injection?
        Imovable engineerInThisBuilding;
        int height;
    }
}
