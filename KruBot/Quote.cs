using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruBot
{
    class Quote
    {
        public string command;
        public string quoteText;

        public Quote()
        {
            command = "";
            quoteText = "";
        }

        public Quote(string passedCommand, string passedText)
        {
            command = passedCommand;
            quoteText = passedText;
        }
    }
}
