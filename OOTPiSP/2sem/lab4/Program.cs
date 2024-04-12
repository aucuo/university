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
        private IFormatStrategy formatStrategy;

        public void AddGroup()
        {
            groups.Add(new Group());

            MessageBox.Show(
            "����� AddGroup() ������",
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
            "����� EditGroup() ������",
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
            "����� DeleteGroup() ������",
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
            "����� AddGrade() ������",
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
            "����� EditGrade() ������",
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
            "����� DeleteGrade() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void SetFormatStrategy()
        {
            var result = MessageBox.Show(
            "�� - JSON, ��� - HTML",
            "Program - SetFormatStrategy",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                formatStrategy = new JsonFormatStrategy();
            }
            else if (result == DialogResult.No)
            {
                formatStrategy = new HtmlFormatStrategy();
            }
        }
        public void ExportGrade(string name)
        {
            SetFormatStrategy();
            if (formatStrategy == null)
            {
                throw new InvalidOperationException("Format strategy has not been set.");
            }
            var grades = groups.FirstOrDefault(g => g.Name == name).Grades;
            formatStrategy.Format(grades);
        }
    }
}