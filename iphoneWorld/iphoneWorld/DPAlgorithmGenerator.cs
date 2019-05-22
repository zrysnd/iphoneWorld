using System;
namespace iphoneWorld.iphoneWorld
{
    public class DPAlgorithmGenerator : IalgoGeneratable
    {
        private ItableWritable _wirteonlyDPTable;/*this table contains information which tells the engineer at which floor to start the test*/
        private ItableAccessable _readonlyDPtable;
        private int[,] _maxNumberOfTestsNeeded;
        private readonly int _numOfPhones;
        private readonly int _buildingHeight;

        public DPAlgorithmGenerator(int numberOfIphones, Ibuilding building)
        {
            /*_maxNumberOfTestsNeeded[0][0] stands for when 1 phone left,building has 1 floor */
            _numOfPhones = numberOfIphones;
            _buildingHeight = building.getHeight();
            _maxNumberOfTestsNeeded = new int[_numOfPhones + 1, _buildingHeight + 1];
            DPTable aDpTable = new DPTable(numberOfIphones, building);/*inject? but have parameters*/
            _wirteonlyDPTable = aDpTable;
            _readonlyDPtable = aDpTable;

        }

        public int getNumberOfPhones()
        {
            return _numOfPhones;
        }

        public int getBuildingHeight()
        {
            return _buildingHeight;
        }

        public ItableAccessable generateDPTable()
        {
            /*code generating the table..*/
            for(int i = 1; i<= _numOfPhones; i++)
            {
                _maxNumberOfTestsNeeded[i, 1] = 1;
                _maxNumberOfTestsNeeded[i, 0] = 0;
                _wirteonlyDPTable.writeToTable(i, 1, 1);/**/
            }
            for(int j = 1; j <= _buildingHeight; j++)
            {
                _maxNumberOfTestsNeeded[1,j] = j;
                _wirteonlyDPTable.writeToTable(1, j, 1);/**/
            }

            for(int i = 2; i<=_numOfPhones; i++)
            {
                for(int j = 2; j <= _buildingHeight; j++)
                {
                    _maxNumberOfTestsNeeded[i, j] = int.MaxValue;
                    for(int x = 1; x<= j; x++)
                    {
                        int worstCaseNumOfTestNeededIfLastTestWasAtFloorX = 1 + 
                                            MaxOfTwo(_maxNumberOfTestsNeeded[i-1,x-1],
                                                     _maxNumberOfTestsNeeded[i,j-x] ) ;

                        if(worstCaseNumOfTestNeededIfLastTestWasAtFloorX < 
                            _maxNumberOfTestsNeeded[i,j])
                        {
                            _maxNumberOfTestsNeeded[i, j] = 
                                worstCaseNumOfTestNeededIfLastTestWasAtFloorX;

                            _wirteonlyDPTable.writeToTable(i, j, x);/**/
                        }
                    }
                }
            }


            return _readonlyDPtable;
        } //and where is the algorithm if you don't return it? -> I'm returning a table.

        public int AccessMaxNumberOfTestsNeeded(int i, int j)
        {
            return _maxNumberOfTestsNeeded[i, j];
        }


        private int MaxOfTwo(int x, int y)
        {
            if (x > y)
                return x;
            return y;
        }

    }
}
