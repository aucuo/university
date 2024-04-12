using System.Xml.Linq;

namespace lab2
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public List<Group> groups = new List<Group>();

        public void AddGroup()
        {
            groups.Add(new Group());

            MessageBox.Show(
            "Метод AddGroup() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void EditGroup(string name)
        {
            groups.FirstOrDefault(g => g.Name == name)?.EditGroup();

            MessageBox.Show(
            "Метод EditGroup() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void DeleteGroup(string name)
        {
            groups.RemoveAll(g => g.Name == name);

            MessageBox.Show(
            "Метод DeleteGroup() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void AddGrade(string name)
        {
            groups.FirstOrDefault(g => g.Name == name)?.AddGrade();

            MessageBox.Show(
            "Метод AddGrade() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void EditGrade(string name, string className)
        {
            groups.FirstOrDefault(g => g.Name == name)?.EditGrade(className);

            MessageBox.Show(
            "Метод EditGrade() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void DeleteGrade(string name, string className)
        {
            groups.FirstOrDefault(g => g.Name == name)?.DeleteGrade(className);

            MessageBox.Show(
            "Метод DeleteGrade() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}