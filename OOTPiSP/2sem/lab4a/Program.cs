using System.Xml.Linq;

namespace lab2
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public List<Subscriber> subscribers = new List<Subscriber>();

        public void AddSubscriber()
        {
            subscribers.Add(new Subscriber());

            MessageBox.Show(
            "����� AddSubscriber() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void EditSubscriber(string name)
        {
            subscribers.FirstOrDefault(g => g.Name == name)?.EditSubscriber();

            MessageBox.Show(
            "����� EditSubscriber() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        public void DeleteSubscriber(string name)
        {
            subscribers.RemoveAll(g => g.Name == name);

            MessageBox.Show(
            "����� DeleteSubscriber() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void AddPayment(string name)
        {
            subscribers.FirstOrDefault(g => g.Name == name)?.AddPayment();

            MessageBox.Show(
            "����� AddPayment() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void EditPayment(string name, string className)
        {
            subscribers.FirstOrDefault(g => g.Name == name)?.EditPayment(className);

            MessageBox.Show(
            "����� EditPayment() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public void DeletePayment(string name, string className)
        {
            subscribers.FirstOrDefault(g => g.Name == name)?.DeletePayment(className);

            MessageBox.Show(
            "����� DeletePayment() ������",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}