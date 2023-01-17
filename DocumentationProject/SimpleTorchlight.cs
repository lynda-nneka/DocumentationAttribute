using System;
namespace DocumentationProject
{
    [Document("A simple torchlight")]
	public class Torchlight
	{
        public IBattery battery;

        [Document("This adds the battery to the torchlight", "IBattery")]

        public Torchlight(IBattery battery)
        {
            this.battery = battery;
        }

        [Document("DisplayBatteryName")]
        public void DisplayBatteryName()
        {
            Console.WriteLine(battery.brandName);
        }
         
        [Document("DisplayBatteryLife")]
        public void DisplayBatteryLife()
        {
            Console.WriteLine(battery.batteryLife);
        }

        [Document("This indicate that we can turn on the torchlight")]
        public bool CanTurnOn
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        [Document("This indicates the brightness of the battery")]
        public enum TorchBrightness
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

    }

    public interface IBattery
    {
        public string brandName { get; }

        public int batteryLife { get; }
    }

    [Document("This is a duracell battery that works with a torchlight")]
    public class Duracell : IBattery
    {
        [Document("This is the brand name of the battery", "", "string")]
        public string brandName
        {
            get
            {
                return "Duracell";
            }
        }

        [Document("This is the life of the battery", "", "int")]
        public int batteryLife
        {
            get
            {
                return 60;
            }
        }
    }

    
    [Document("This is a Tiger battery that works with a torchlight")]

    public class Tiger : IBattery
    {
       
        [Document("This is the brand name of the battery", "", "string")]
        public string brandName
        {
            get
            {
                return "Tiger";
            }
        }

        
        [Document("This is the life of the battery", "", "int")]

        public int batteryLife
        {
            get
            {
                return 35;
            }
        }
    }

}

