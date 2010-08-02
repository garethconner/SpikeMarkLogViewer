using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpikeMarkLogViewer
{
    public class LogItem
    {
        private int id;
        private string source;
        private string message;
        private string messageLevel;
        private DateTime timestamp;

        public LogItem(int Id, string Source, string Message, string MessageLevel, DateTime Timestamp)
        {
            id = Id;
            source = Source;
            message = Message;
            messageLevel = MessageLevel;
            timestamp = Timestamp;
        }

        public int Id { get { return id; } }
        public string Source { get { return source; } }
        public string Message { get { return message; } }
        public string MessageLevel { get { return messageLevel; } }
        public DateTime TimeStamp { get { return timestamp; } }

    }
}
