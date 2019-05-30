using System;
namespace iphoneWorld.iphoneWorld
{
    public class TwoDIntArray
    {
        private int[] _array;
        private int _numOfRows;
        private int _numOfCols; 

        public TwoDIntArray(int[] array )
        {
            _array = array;
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
