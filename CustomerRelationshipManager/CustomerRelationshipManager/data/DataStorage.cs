using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace CustomerRelationshipManager
{
    class DataStorage
    {
        private static IList<Customer> customers = new List<Customer>();
        private static IList<Vehicle> vehicles = new List<Vehicle>();
        public IList<string[]> dataCollected = new List<string[]>();

        public static IList<Customer> GetCustomers { get => customers; }
        public static IList<Vehicle> GetVehicles   { get => vehicles;  }

        public void Initialize()
        {
            // Store all the data into readFile and get splitData ready so we
            // store it into dataCollected
            string[] readFile = File.ReadAllLines("../../resources/CustomerInformation.csv");
            string[] splitData = null;

            // We are spliting the file data and storing it into
            // dataCollected row by row
            for (int i = 1; i < readFile.Length; i++)
            {
                splitData = readFile[i].Split(',');
                dataCollected.Add(splitData);
            }

            // Storing the vehicles into their own list
            for (int i = 0; i < dataCollected.Count; i++)
            {
                // Checking if we have a vehicle ID and if we 
                // don't don't include the vehicle
                if (dataCollected[i][4] != "")
                {
                    // Add Vehicles to the list
                    vehicles.Add(new Vehicle(Vehicle.GetVehicleType(dataCollected[i][12]),  // Vehicle Type
                                             int.Parse(dataCollected[i][0]),                // Customer ID
                                             int.Parse(dataCollected[i][4]),                // Vehicle ID
                                             dataCollected[i][5],                           // Registration Number
                                             dataCollected[i][6],                           // Manufacturer
                                             dataCollected[i][7],                           // Model 
                                             dataCollected[i][9],                           // Registration Date
                                             dataCollected[i][10],                          // Interior Color
                                             int.Parse(dataCollected[i][8]),                // Engine Size
                                             dataCollected[i][11]                           // Has Helmet
                    ));
                }
            }

            // Remove any duplicated customers
            for (int i = 1; i < dataCollected.Count; i++)
            {
                if (dataCollected[i][0] == dataCollected[i - 1][0])
                    dataCollected.Remove(dataCollected[i]);
            }

            // Storing the customers into their own list
            for (int i = 0; i < dataCollected.Count; i++)
            {
                // Add Customers to the list
                customers.Add(new Customer(int.Parse(dataCollected[i][0]),    // Customer ID
                                           dataCollected[i][1],               // Forename
                                           dataCollected[i][2],               // Surname
                                           dataCollected[i][3]                // Date of birth
                ));
            }

            /* 
             * For Debugging Purposes
             * 
                for (int i = 0; i < customers.Count; i++)
                {
                    customers[i].Display();
                }

                Console.WriteLine("");

                for (int i = 0; i < vehicles.Count; i++)
                {
                    vehicles[i].Display();
                }
            */
        }
    }
}
