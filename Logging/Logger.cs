using System.Collections.Generic;

namespace CQRSExample.Logging
{
    public class Logger
    { 
        public List<string> Messages { get; } = new List<string>();

        public void Log(string message)
        {
            Messages.Add(message);
        }
    }
}