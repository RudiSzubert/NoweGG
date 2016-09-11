using System;
using System.Collections.Generic;
using System.IO;
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

        private List<Conversation> History = new List<Conversation>();

        private bool IfFirstMessage(Message message)
        {
            foreach (Conversation conv in this.History)
            {
                if (conv.Usr2.Equals(message.To))
                    return false;
            }
            return true;
        }

        public void LoadHistory()
        {
            var dir = @"c:\test\Na repy\gg\NoweGG";
            var filename = "History" + this.login + ".bin";
            var SFile = Path.Combine(dir, filename);
            using (Stream stream = File.Open(SFile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                this.History = (List<Conversation>)bformatter.Deserialize(stream);
            }
        }

        public void HistoryToFile()
        {
            var dir = @"c:\test\Na repy\gg\NoweGG";
            var filename = "History" + this.login + ".bin";
            var SFile = Path.Combine(dir, filename);
            using (Stream stream = File.Open(SFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this.History);
            }
        }

        public void SaveMessage(Message message)
        {
            if (IfFirstMessage(message))
            {
                Conversation conversation = new Conversation(message);
                this.History.Add(conversation);
                this.HistoryToFile();
            }
            else
            {
                foreach (Conversation conv in this.History)
                {
                    if (conv.Usr2.Equals(message.To))
                        conv.Conv.Add(message);
                    this.HistoryToFile();
                }
            }
        }

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