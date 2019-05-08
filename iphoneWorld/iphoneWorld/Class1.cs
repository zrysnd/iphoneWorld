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
        int breakingFloor; //why would a phone know the max floor, max of what -> changed name, this floor is where the iphone breaks.
        /* I might misunderstood the project, should we decide at which floor the iphone breaks at first,
         or when we do tests, the program randomly decide whether the phone breaks, and based on the results
         we tell at which floor the iphones break?  */  
        int currentFloor; //makes sense to be at current floor
        IfloorTellable Carrier;
        public void breakNow(){}
        public void getTested() { }
        public void movedToNewFloor() { } 
        public void carriedBy(IfloorTellable carrier) { }
    }

    public class DPAlgorithmGenerator : IalgoGeneratable
    {
        ItableAccessable DPTable;/*this table contains information which tells the engineer at which floor to start the test*/
        public ItableAccessable generateDPTable(int numberOFPhones, int buildingHeight) 
        { 
            //code generating the table..
            return DPTable; 
        } //and where is the algorithm if you don't return it?
    }

    public class Engineer: Tester
    {
        List<Itestable> listOfIphone; 
        //why comment out -> uncommeted.
        int currentFloor;
        ItableAccessable DPTable;
        public int getCurrentFloor() { return currentFloor; }
        public void moveToNextBestFloor() { }
        public void test() { }

    }

    public class buidling : Ibuilding
    {
        int height;
        public int getHeight() { return height; }
    }

    public class DPTable : ItableAccessable
    {
        int[,] table;
        public int accessTable(int numberOfPhonesLeft, int buildingHeight) { return table[numberOfPhonesLeft, buildingHeight]; }
    }
}
