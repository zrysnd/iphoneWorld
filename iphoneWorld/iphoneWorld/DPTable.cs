using System;
namespace iphoneWorld.iphoneWorld
{
    public class DPTable : IDPTable
    {
        private int[,] _table;

        public DPTable(int numberOfIphones, Ibuilding building)
        {
            _table = new int[numberOfIphones+1, building.getHeight()+1];
        }

        public int accessTable(int numberOfPhonesLeft, int buildingHeight) 
        { 
            return _table[numberOfPhonesLeft, buildingHeight]; 
        }

        public void writeToTable(int numberOfPhonesLeft, int currentFloor, int bestFloorToTest)
        {
            _table[numberOfPhonesLeft, currentFloor] = bestFloorToTest;
        }

    }
}
