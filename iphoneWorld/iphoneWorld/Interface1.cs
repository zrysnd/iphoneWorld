using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iphoneWorld.iphoneWorld
{
    public interface ITwoDIntArray
    {
        int AccessElement(int i, int j);
        void SetElement(int i, int j, int newValue);
    }

    public interface Icarriable
    {
        void updateCurrentFloor();
        void carriedBy(IfloorTellable carrier);
     
    }
    public interface Itestable: Icarriable
    {
        void setBreakingFloor(int floor);
        bool getTested();
        //bool isBroken();
    }

    public interface IgroupOfTestable
    {
        void TestOneOfThePhones();
    }


    public interface IfloorTellable
    {
        int getCurrentFloor(); //tell floor? use proper english -> changed function name to "getCurrentFloor"
        /* this interface's pis used to tell iphone objects their current floor number */
    }
    public interface Tester
    {
        int test();
        void GoToBuilding(Ibuilding building);
        void PickUpPhones(int numOfPhones, Itestable Phone);
    }
    


    public interface IalgoGeneratable
    {
        ItableAccessable generateDPTable();
    }



    public interface ItableAccessable
    {
        int accessTable(int numberOfPhonesLeft, int buildingHeight); 
    }
    public interface ItableWritable
    {
        void writeToTable(int numberOfPhonesLeft, int currentFloor, int bestFloorToTest);
    }
    public interface IDPTable: ItableWritable, ItableAccessable
    {

    }


    public interface Ibuilding
    {
        //?????????? anything?  //-> added getHeight()
        int getHeight();
    }

    
    //you have scattered interfaces, but they don't tell a story together. 
    
}
