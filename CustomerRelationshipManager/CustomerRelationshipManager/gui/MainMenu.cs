using System;

namespace CustomerRelationshipManager
{
    class MainMenu
    {
        public static void ShowMenu()
        {
            int answer = -1;
            int customerView = -1;

            Introduction();

            /*
             * We've put the code below in a while loop so we can check each answer without having to
             * exit or have another option like 'Retry' or 'Check something else?'
            */
            while (answer != -99)
            {
                if (customerView == -99)
                {
                    Console.Clear();
                    Introduction();

                    customerView = -1;
                }

                Console.Write("Enter your question number (-99 Quit): ");
                answer = int.Parse(Console.ReadLine());

                // We are simply checking the answer and running the
                // appropriate method
                switch (answer)
                {
                    case 0:
                        Console.Clear();
                        DisplayAllCustomers();

                        while(customerView != -99)
                        {
                            Console.Write("Select the customer who's vehicles you want to see (-99 Quit): ");
                            customerView = int.Parse(Console.ReadLine());

                            Console.WriteLine("");
                            GetVehicleInfoByOwnerID(customerView);
                        }

                        answer = -1;
                        break;
                    case 1:
                        Console.Clear();
                        Introduction();
                        CustomerAndVehicle();

                        answer = -1;
                        break;
                    case 2:
                        Console.Clear();
                        Introduction();
                        CustomerAgeGroup();

                        answer = -1;
                        break;
                    case 3:
                        Console.Clear();
                        Introduction();
                        VehicleAgeGroup();

                        answer = -1;
                        break;
                    case 4:
                        Console.Clear();
                        Introduction();
                        VehicleEngineSize();

                        answer = -1;
                        break;
                }

                Console.WriteLine("");
            }
        }

        private static void DisplayAllCustomers()
        {
            for (int i = 0; i < DataStorage.GetCustomers.Count; i++)
            {
                var customer = DataStorage.GetCustomers[i];

                Console.WriteLine(customer.CustomerID + " - " + customer.Forename + " " + customer.Surname);
            }

            // New Line
            Console.WriteLine("");
        }

        /// <summary>
        /// All the options the user has are listed below.
        /// </summary>
        private static void Introduction()
        {
            Console.WriteLine("Hello Customer, I hope you are having a wonderful time!!");
            Console.WriteLine("");
            Console.WriteLine("Please select on of the following options:");
            Console.WriteLine("0: Display all customers");
            Console.WriteLine("1: Display the customers and the vehicles they own.");
            Console.WriteLine("2: Display customers between the age of 20 and 30");
            Console.WriteLine("3: Display vehicles before 1st of January 2010");
            Console.WriteLine("4: Display vehicles with the engine size over 1100cc");
            Console.WriteLine("");
        }

        /// <summary>
        /// Here we check which car belons to which customer and we
        /// display the vehicle of the customer
        /// </summary>
        private static void CustomerAndVehicle()
        {
            for (int j = 0; j < DataStorage.GetVehicles.Count; j++)
            {
                var vehicle = DataStorage.GetVehicles[j];

                for (int i = 0; i < DataStorage.GetCustomers.Count; i++)
                {
                    var customer = DataStorage.GetCustomers[i];

                    if (vehicle.OwnerID == customer.CustomerID)
                    {
                        Console.WriteLine(customer.Forename + " " + customer.Surname + " - " + vehicle.Manufacturer + " " + vehicle.Model + " - CuID: " + customer.CustomerID + " - OwID: " + vehicle.OwnerID);
                        break;
                    }
                }
            }

            // New Line
            Console.WriteLine("");
        }

        /// <summary>
        /// Compares the age of each customer and it only displays
        /// customers that are older than 20 but younger than 30
        /// </summary>
        private static void CustomerAgeGroup()
        {
            var today = DateTime.UtcNow;

            for (int i = 0; i < DataStorage.GetCustomers.Count; i++)
            {
                var customer = DataStorage.GetCustomers[i];
                var age = today.Year - DateTime.Parse(DataStorage.GetCustomers[i].DateOfBirth).Year;

                if(age > 20 && age < 30)
                    Console.WriteLine(customer.Forename + " " + customer.Surname + " - " + customer.DateOfBirth + " - " + age);
            }

            // New Line
            Console.WriteLine("");
        }

        /// <summary>
        /// Compares the vehicle age and if it was built before 1st Jan 2010
        /// it displays it on the screen
        /// </summary>
        private static void VehicleAgeGroup()
        {
            for (int i = 0; i < DataStorage.GetVehicles.Count; i++)
            {
                var vehicle = DataStorage.GetVehicles[i];

                if (DateTime.Parse(vehicle.RegistrationDate) < DateTime.Parse("01/01/2010"))
                    Console.WriteLine(vehicle.Manufacturer + " " + vehicle.Model + " - " + vehicle.RegistrationDate);
            }

            // New Line
            Console.WriteLine("");
        }

        /// <summary>
        /// Compares engine sizes and only display the vehicle
        /// that has an engine size bigger than 1100cc
        /// </summary>
        private static void VehicleEngineSize()
        {
            for (int i = 0; i < DataStorage.GetVehicles.Count; i++)
            {
                var vehicle = DataStorage.GetVehicles[i];

                if (vehicle.EngineSize > 1100)
                    Console.WriteLine(vehicle.Manufacturer + " - " + vehicle.Model + " - " + vehicle.EngineSize);
            }

            // New Line
            Console.WriteLine("");
        }

        /// <summary>
        /// The function compares the id provided with the id of the vehicle and if there
        /// is a match it displays the vehicle
        /// </summary>
        private static void GetVehicleInfoByOwnerID(int id)
        {
            for (int i = 0; i < DataStorage.GetVehicles.Count; i++)
            {
                var vehicle = DataStorage.GetVehicles[i];

                if (vehicle.OwnerID == id)
                    Console.WriteLine(vehicle.OwnerID + " - " + vehicle.Manufacturer + " - " + vehicle.Model + " - " + vehicle.EngineSize);
            }

            // New Line
            Console.WriteLine("");
        }
    }
}
