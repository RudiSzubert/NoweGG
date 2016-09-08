using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

namespace NoweGG
{
    [Serializable]
    class User
    {
        private bool active;
        [DataMember]
        private List<User> Book = new List<User>();

        [DataMember]
        private string login;
        [DataMember]
        private string password;
        public User(string log, string pass, int numb)
        {
            login = log;
            password = pass;
            Number = numb;
        }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}