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
            "Метод AddSubscriber() вызван",
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
            "Метод EditSubscriber() вызван",
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
            "Метод DeleteSubscriber() вызван",
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
            "Метод AddPayment() вызван",
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
            "Метод EditPayment() вызван",
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
            "Метод DeletePayment() вызван",
            "Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}