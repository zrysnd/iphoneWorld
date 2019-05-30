using System;
namespace iphoneWorld.iphoneWorld
{
    public class DPTable : IDPTable
    {
        private ITwoDIntArray _table;

        public DPTable(ITwoDIntArray table)
        {
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
