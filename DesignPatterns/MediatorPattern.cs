using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(string from, string to, string message);
    }

    public class ChatRoom : AbstractChatroom
    {
        Dictionary<string, Participant> _particpiants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {

            if (!_particpiants.ContainsValue(participant))
            {
                _particpiants[participant.Name] = participant;
            }
            participant.ChatRoom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = _particpiants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    public class Participant
    {
        private ChatRoom _chatroom;
        private string _name;

        public Participant(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public ChatRoom ChatRoom
        {
            get { return _chatroom; }
            set { this._chatroom = value; }
        }

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
        //public string 
    }

    class Beatle : Participant
    {
        // Constructor
        public Beatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }



    class MediatorPattern
    {
        public void MediatorControl()
        {
            ChatRoom chatroom = new ChatRoom();

            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

        }
    }
}
