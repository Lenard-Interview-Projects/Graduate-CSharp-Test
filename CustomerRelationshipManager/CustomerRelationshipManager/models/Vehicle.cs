using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManager
{
    enum VehicleType
    {
        Car,
        Motorcycle,
        Unknown,
    }

    class Vehicle
    {
        private VehicleType vehicleType;

        private int ownerID;
        private int vehicleID;

        private string registrationNumber;
        private string manufacturer;
        private string model;
        private string registrationDate;
        private string interiorColor;

        private int engineSize;
        private bool hasHelmet;

        internal VehicleType VehicleType    { get => vehicleType;           }

        public int VehicleID                { get => vehicleID;             }
        public string RegistrationNumber    { get => registrationNumber;    }
        public string Manufacturer          { get => manufacturer;          }
        public string Model                 { get => model;                 }

        public string RegistrationDate      { get => registrationDate;      }
        public string InteriorColor         { get => interiorColor;         }
        public int EngineSize               { get => engineSize;            }
        public bool HasHelmet               { get => hasHelmet;             }
        public int OwnerID                  { get => ownerID;               }

        public Vehicle(VehicleType vehicleType, int ownerID, int vehicleID, string registrationNumber, string manufacturer, string model, string registrationDate, string interiorColor, int engineSize, string hasHelmet)
        {
            this.vehicleType            = vehicleType;
            this.ownerID                = ownerID;
            this.vehicleID              = vehicleID;
            this.registrationNumber     = registrationNumber;
            this.manufacturer           = manufacturer;
            this.model                  = model;
            this.registrationDate       = registrationDate;
            this.interiorColor          = interiorColor;
            this.engineSize             = engineSize;
            this.hasHelmet              = GetHasHelmetStorage(hasHelmet);
        }

        /// <summary>
        /// </summary>
        /// <param name="input">The value that we put in to get whether we wear a helmet or not</param>
        /// <returns></returns>
        private bool GetHasHelmetStorage(string input)
        {
            switch (input)
            {
                case "Yes": return true;
                case "No": return false;
                default: return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="input">The value that we put in to get the right VehicleType</param>      
        public static VehicleType GetVehicleType(string input)
        {
            switch (input)
            {
                case "Car":         return VehicleType.Car;
                case "Motorcycle":  return VehicleType.Motorcycle;
                case "Unknown":     return VehicleType.Unknown;
                default:            return VehicleType.Unknown;
            }
        }

        public void Display()
        {
            Console.WriteLine(ownerID + "," + vehicleID + "," + registrationNumber + "," + manufacturer + "," + model + "," + engineSize + "," + registrationDate + "," + interiorColor + "," + hasHelmet + "," + vehicleType);
        }
    }
}
