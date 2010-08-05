using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpikeMarkLogViewer
{
    public class LogItem
    {
        public LogItem(int Id, string Source, string Message, string MessageLevel, DateTime Timestamp)
        {
            this.Id = Id;
            this.Source = Source;
            this.Message = Message;
            this.MessageLevel = MessageLevel;
            this.TimeStamp = Timestamp;
        }

        public int Id { get; private set; }
        public string Source { get; private set; }
        public string Message { get; private set; }
        public string MessageLevel { get; private set; }
        public DateTime TimeStamp { get; private set; }

    }
}
