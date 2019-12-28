using System;
using System.Diagnostics;

namespace SorterExpress
{
    class FFMPEGProcess : Process
    {
        public Action<string> callback;
        public string input;
        public string output;
    }
}