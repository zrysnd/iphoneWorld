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
        void movedToNewFloor();/* /*I'm not sure whether I should inject engineer or carrier to iphone class, 
        or pass new floor by parameter.*/
        //whichever is natural and SOLID */
        void carriedBy(IfloorTellable carrier);
    }

    public interface Itestable: Icarriable
    {
        void getTested();
    }

    public interface testItem: Itestable, Ibreakable
    {
        /*nothing*/
    }

    public interface IfloorTellable
    {
        int getCurrentFloor(); //tell floor? use proper english -> changed function name to "getCurrentFloor"
        /* this interface's pis used to tell iphone objects their current floor number */
    }
    public interface Imovable
    {
        void moveToNextBestFloor();

    }



    public interface Tester : Imovable, IfloorTellable
    {
        void test();
    }
    

    public interface IalgoGeneratable
    {
        ItableAccessable generateDPTable(int numberOFPhones, int buildingHeight);
    }

    public interface ItableAccessable
    {
        int accessTable(int numberOfPhonesLeft, int buildingHeight); 
    }

    public interface Ibuilding
    {
        //?????????? anything?  //-> added getHeight()
        int getHeight();
    }

    
    //you have scattered interfaces, but they don't tell a story together. 
    
}
