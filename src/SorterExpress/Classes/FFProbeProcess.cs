using System;
using System.Diagnostics;
using System.Drawing;

namespace SorterExpress
{
    class FFProbeProcess : Process
    {
        public Action<Size> callback;
        public string input;
    }
}
