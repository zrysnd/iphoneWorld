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

    public interface Icountable
    {
        short numOfItemsLeft { get; set; }
    }

    public interface Icarriable
    {
        void updateCurrentFloor();
        void carriedBy(IfloorTellable carrier);
     
    }
    public interface Itestable: Icarriable
    {
        bool getTested();
    }

    public interface IgroupOfTestable: Itestable, Icountable
    {
    }

    public interface Irecordable
    {
        int HighestBrokenFloor { get; set; }
        int NumOfFloorsBelowThisSubBuilding { get; set; }
        bool LastPhoneBroken { get; set; }

    }


    public interface IfloorTellable
    {
        int CurrentFloor { get; }
    }
    public interface Tester
    {
        int test();
        void PrepareTestRecord(Irecordable record);
        void PrepareDpTable(IalgoGeneratable DPAlgoG);
        void GoToBuilding(Ibuilding building);
        void PickUpPhones( IgroupOfTestable Phones);
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
