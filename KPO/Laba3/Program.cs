using System.Collections;

namespace Laba1
{
    internal static class Program
    {
        public struct Person
        {
            public string name;
            public string group;
            public string ses;

            public Person()
            {
                this.name = "0";
                this.group = "0";
                this.ses = "0";
            }
        }
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
    }
}