using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoweGG
{
    class User
    {
        private bool active;

        private string login;

        private string password;

        private int number = 0;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        private int age = 0;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        private string city;

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        private string country;

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        List<User> Book = new List<User>();
    }
}
