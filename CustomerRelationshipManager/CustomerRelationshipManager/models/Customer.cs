using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManager
{
    class Customer
    {
        private int customerID;
        private string forename;
        private string surname;
        private string dateOfBirth;

        public int CustomerID                   { get => customerID;        }
        public string Forename                  { get => forename;          }
        public string Surname                   { get => surname;           }
        public string DateOfBirth               { get => dateOfBirth;       }

        public Customer(int customerID, string forename, string surname, string dateOfBirth)
        {
            this.customerID     = customerID;
            this.forename       = forename;
            this.surname        = surname;
            this.dateOfBirth    = dateOfBirth;
        }

        public void Display()
        {
            Console.WriteLine(customerID + "," + forename + "," + surname + "," + dateOfBirth);
        }
    }
}
