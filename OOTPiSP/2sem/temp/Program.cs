using System.Security.Cryptography.X509Certificates;

namespace lab2
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public List<Group> groups = new List<Group>();

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());


            
        }

        private void AddGroup()
        {
            groups.Add(new Group());
        }
    }
}