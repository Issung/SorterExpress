using System;
using System.IO;

namespace SorterExpress
{
    class Logs
    {
        public static string LOGS_FILE_PATH { get; } = Program.PROGRAMDATA_PATH + "\\logs.l";
        public const string DATE_FORMAT = "dd/MM/yyyy hh:mm:ss tt";
        public static StreamWriter streamWriter = null;

        private static void InitialiseStreamWriter()
        {
            streamWriter = new StreamWriter(LOGS_FILE_PATH, true);
            streamWriter.AutoFlush = false;
        }

        /// <summary>
        /// Please pass in all logs by starting with a capital letter and ending with a full stop. No newlines neccessary.
        /// Create a log file if doesn't already exist.
        /// Remove all new line characters from given string.
        /// Append "[DateTime.Now] - givenString \n" to log file.
        /// returns false if method failed.
        /// </summary>
        public static void Log(params string[] lines)
        {
            // Timestamp first line of log.
            if (lines.Length > 0)
            {
                lines[0] = $"[{DateTime.Now.ToString(DATE_FORMAT)}] - " + lines[0];

                for (int i = 1; i < lines.Length; i++)
                {
                    lines[i] = '\t' + lines[i];
                }
            }

            foreach (string line in lines)
            { 
                Console.WriteLine(line);
            }

            try
            {
                if (streamWriter == null)
                    InitialiseStreamWriter();

                foreach (string line in lines)
                    streamWriter.WriteLine(line);

                streamWriter.Flush();
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
