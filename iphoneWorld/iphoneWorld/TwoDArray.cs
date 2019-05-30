using System;
namespace iphoneWorld.iphoneWorld
{
    public class TwoDArray:ITwoDIntArray
    {
        private int[] _array;
        private int _numOfRows;
        private int _numOfCols; 

        public TwoDArray(int[] array, int numOfRows )
        {
            _array = array;
            _numOfRows = numOfRows;
            _numOfCols = array.Length / _numOfRows;
        }

        public int AccessElement(int i, int j)
        {
            return _array[i * _numOfCols + j];
        }

        public void SetElement(int i, int j, int newValue)
        {
            this._array[i * _numOfCols + j] = newValue;
        }

    }
}
