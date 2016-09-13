using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoweGG
{
    [Serializable]
    class Conversation 
    {
        public Conversation(Message msg)
        {
            Conv.Add(msg);
            Usr1 = msg.From;
            Usr2 = msg.To;
        }

        private User usr1;

        public User Usr1
        {
            get
            {
                return usr1;
            }
            set
            {
                usr1 = value;
            }
        }

        private User usr2;

       public User Usr2
        {
            get
            {
                return usr2;
            }
            set
            {
                usr2 = value;
            }
        }

        public List<Message> Conv = new List<Message>();
    }
    [Serializable]
    class Message
    {
        public Message(string txt, DateTime tim, User FR, User TO)
        {
            Text = txt;
            Time = tim;
            From = FR;
            To = TO;
        }

        private string text;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        private DateTime time;

        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        private User from;

        public User From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        private User to;

        public User To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }
    }
}
