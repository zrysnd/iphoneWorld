using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iphoneWorld.iphoneWorld
{


   

   

    public class Building : Ibuilding
    {
        int _height;
        //public Building()
        //{
        //    _height = 100;
        //}

        public Building(int height)
        {
            _height = height;
        }

        public int getHeight() { return _height; }
    }





}
