using System;
namespace iphoneWorld.iphoneWorld
{
    public class TestRecords:Irecordable
    {
        private int _highestBrokenFloor;
        private int _numOfFloorsBelowThisSubBuilding;
        private bool _lastPhoneBroke;

        public TestRecords()
        {
            _highestBrokenFloor = 0;
            _lastPhoneBroke = false;
            _numOfFloorsBelowThisSubBuilding = 0;
        }

        public int HighestBrokenFloor 
        {
            get
            {
                return _highestBrokenFloor;
            }
            set
            {
                this._highestBrokenFloor = value;
            }
        }

        public int NumOfFloorsBelowThisSubBuilding
        {
            get
            {
                return this._numOfFloorsBelowThisSubBuilding;
            }
            set
            {
                this._numOfFloorsBelowThisSubBuilding = value;
            }
        }

        public bool LastPhoneBroken
        {
            get
            {
                return this._lastPhoneBroke;
            }
            set
            {
                this._lastPhoneBroke = value;
            }
        }
    }
}
