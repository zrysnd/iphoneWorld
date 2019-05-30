using System;
namespace iphoneWorld.iphoneWorld
{
    public class DPTable : IDPTable
    {
        //private int[,] _table;
        private ITwoDIntArray _table;

        //public DPTable(int numberOfIphones, Ibuilding building)
        //{
        //    _table = new int[numberOfIphones+1, building.getHeight()+1];
        //}

        public DPTable(ITwoDIntArray table)
        {
            //int[][] i = new int[2][];
            _table = table;
        }

        public int accessTable(int numberOfPhonesLeft, int buildingHeight) 
        { 
            return _table.AccessElement(numberOfPhonesLeft, buildingHeight); 
        }

        public void writeToTable(int numberOfPhonesLeft, int currentFloor, int bestFloorToTest)
        {
            _table.SetElement(numberOfPhonesLeft, currentFloor, bestFloorToTest);
        }

    }
}
