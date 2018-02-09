using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrepodsTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormPrepods());
        }
        /// <summary>
        /// use course
        /// </summary>
        public static bool useCourseSemester = true;
        public static bool useEvenWeeks = false;
        public static bool useYearOfStudy = false;
        
        
    }
}
