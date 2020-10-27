using System.Collections.Generic;
using System.Windows.Forms;

namespace SorterExpress.Classes
{
    struct Shortcut
    {
        public bool CTRL, ALT;
        public System.Windows.Forms.Keys Key;

        public Shortcut(bool ctrl = false, bool alt = false, Keys key = Keys.None)
        {
            this.CTRL = ctrl;
            this.ALT = alt;
            this.Key = key;
        }

        public static bool operator == (Shortcut l, Shortcut r)
        {
            if (l.CTRL != r.CTRL)
                return false;

            if (l.ALT != r.ALT)
                return false;

            if (l.Key != r.Key)
                return false;

            return true;
        }

        public static bool operator != (Shortcut l, Shortcut r)
        {
            return !(l == r);
        }

        public override string ToString()
        {
            List<string> keys = new List<string>();

            if (CTRL)
                keys.Add("CTRL");
            if (ALT)
                keys.Add("ALT");

            keys.Add(Key.ToString());

            return $"(Shortcut: {string.Join(" + ", keys)})";
        }
    }
}
