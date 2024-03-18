using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SorterExpress.Data.DbContext;
using SorterExpress.Forms;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static Tensorflow.ApiDef.Types;

namespace SorterExpress
{
    static class Program
    {
        public static string APPLICATION_INSTALL_DIRECTORY { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string PROGRAMDATA_PATH { get; } = Application.CommonAppDataPath;

        public static string LOG_FILE { get; } = PROGRAMDATA_PATH + "\\logs.l";

        public static string THUMBS_PATH { get; } = PROGRAMDATA_PATH + "\\Thumbs\\";

        /// <summary>
        /// The name of the program.
        /// </summary>
        public static readonly string NAME = "SorterExpress";
        public static readonly string GITHUB_REPOSITORY_OWNER = "Issung";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Unhandled exceptions for our Application Domain
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

            // Unhandled exceptions for the executing UI thread
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Run in background because Vacuum command can be expensive.
            new Thread(SetupSqliteDatabase).Start();

            if (args.Length == 0)
            {
                Application.Run(new WelcomeForm());
            }
            else
            {
                if (args[0] == "sort")
                {
                    Application.Run(new SortForm(new DirectoryInfo(args.Last())));
                }
                else if (args[0] == "view")
                {
                    Application.Run(new ViewForm(new DirectoryInfo(args.Last())));
                }
                else if (args[0] == "duplicates")
                {
                    Application.Run(new DuplicatesForm(new DirectoryInfo(args.Last())));
                }
                else if (args[0] == "masstag")
                {
                    Application.Run(new MassTagForm(new DirectoryInfo(args.Last())));
                }
                else if (args[0] == "renametag")
                {
                    //Application.Run(new RenameTagForm(new DirectoryInfo(args.Last())));
                }
            }
        }

        /// <summary>
        /// Ensure SQLite database is created, migrated, and vacuumed.
        /// </summary>
        private static void SetupSqliteDatabase()
        {
            using (var context = Designer.CreateDbContext())
            {
                context.Database.Migrate();
                context.Database.ExecuteSqlRaw("VACUUM;");
            }
            Console.WriteLine("SQLite database created and migrations applied.");
        }

        /// <summary>
        /// Main thread exception handler
        /// </summary>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Log(true, $"Application_ThreadException - {e.Exception.Message}", e.Exception.StackTrace);
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        /// <summary>
        /// Application domain exception handler
        /// </summary>
        public static void AppDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                Log(true, $"AppDomain_UnhandledException - {ex.Message}", ex.StackTrace);
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        public static void Log(Exception ex)
        {
            Log(true, $"AppDomain_UnhandledException - {ex.Message}", ex.StackTrace);
        }

        public static void Log(bool timestampFirstLine, params string[] lines)
        {
            try
            {
                if (timestampFirstLine)
                    lines[0] = $"[{DateTime.Now.ToString()}] - " + lines[0];
                
                if (File.Exists(LOG_FILE))
                    File.AppendAllLines(LOG_FILE, lines);
                else
                    File.WriteAllLines(LOG_FILE, lines);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
