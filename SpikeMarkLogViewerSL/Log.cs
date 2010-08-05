using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace SpikeMarkLogViewer
{
    class Log
    {
        private List<LogItem> items;
        private static Log instance;

        private Log()
        {
            items = new List<LogItem>();
        }

        public static Log Instance 
        {
            get
            {
                if (instance == null)
                    instance = new Log();
                return instance;
            }
        }

        public List<LogItem> Items { get { return items; } }

        public void InitializeFromStream(StreamReader stream)
        {
            ClearLogItems();
            ReadFromStream(stream);
        }

        private void ReadFromStream(StreamReader stream)
        {
            int id = 0;
            string nextLine;

            while ((nextLine = stream.ReadLine()) != null)
            {
                string[] records = nextLine.Trim().Split(';');
                if (records.Length == 4)
                {
                    string source = records[0].Trim();
                    string message = records[1].Trim();
                    string messageLevel = records[2].Trim();
                    DateTime timestamp = DateTime.Parse(records[3].Trim());

                    items.Add(new LogItem(id, source, message, messageLevel, timestamp));
                    id++;
                    nextLine = stream.ReadLine();
                }
                else
                {
                    nextLine += stream.ReadLine();
                }
            }
        }

        private void ClearLogItems()
        {
            items.Clear();
        }
    }
}
