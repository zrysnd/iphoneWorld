using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.iphoneWorld
{
    public interface Ibreakable
    {
         void breakNow();
    }

    public interface Icarriable
    {
        void movedToNewFloor();//I'm not sure whether I should inject engineer or carrier to iphone class, or pass new floor by parameter.
        void carriedBy(Object carrier);
    }

    public interface Itestable: Icarriable
    {
        void getTested();
    }

    public interface testItem: Itestable, Ibreakable
    {
        //nothing
    }

    public interface IfloorTellable
    {
        void tellfloor();
    }
    public interface Imovable
    {
        void moveToNextBestFloor();//hopefully can get the floor number from DP table.

    }



    public interface Tester : Imovable, IfloorTellable
    {
        void test();
    }
    

    public interface IalgoGeneratable
    {
        void generateDPAlgo();
    }

    public interface Itable
    {
        void drawTable();
    }

    public interface Ibuilding
    {

    }

    
}
