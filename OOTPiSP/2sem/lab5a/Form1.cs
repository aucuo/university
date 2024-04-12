using System.Xml.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Program pr = new Program();

        private void updateSubscribers()
        {
            subscribersBox.Items.Clear();

            foreach (var sub in pr.subscribers)
            {
                if (!subscribersBox.Items.Contains(sub.Name))
                {
                    subscribersBox.Items.Add(sub.Name);
                }
            }
        }
        private void updatePayments()
        {
            if (subscribersBox.SelectedItem == null) return;
            string name = subscribersBox.SelectedItem.ToString();

            paymentsBox.Items.Clear();

            var subscriber = pr.subscribers.FirstOrDefault(g => g.Name == name);
            if (subscriber == null) return;

            foreach (var payment in subscriber.Payments)
            {
                var properties = payment.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                StringBuilder text = new StringBuilder();
                text.Append($"[{payment.className}] ");

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(payment);
                        text.Append($"{property.Name}: {value}, ");
                    }
                }

                if (text.Length > 0)
                    text.Length -= 2;

                paymentsBox.Items.Add(text.ToString());
            }
        }


        private void addSubscriber_Click(object sender, EventArgs e)
        {
            pr.AddSubscriber();
            updateSubscribers();
        }

        private void editSubscriber_Click(object sender, EventArgs e)
        {
            if (subscribersBox.SelectedItem == null) return;
            pr.EditSubscriber(subscribersBox.SelectedItem.ToString());
            updateSubscribers();
        }

        private void deleteSubscriber_Click(object sender, EventArgs e)
        {
            if (subscribersBox.SelectedItem == null) return;
            pr.DeleteSubscriber(subscribersBox.SelectedItem.ToString());
            updateSubscribers();
        }

        private void groupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePayments();
        }

        private void addGrade_Click(object sender, EventArgs e)
        {
            if (subscribersBox.SelectedItem == null) return;

            pr.AddPayment(subscribersBox.SelectedItem.ToString());

            updatePayments();
        }

        private void editPayment_Click(object sender, EventArgs e)
        {
            if (subscribersBox.SelectedItem == null) return;
            if (paymentsBox.SelectedItem == null) return;

            string input = paymentsBox.SelectedItem.ToString();
            string pattern = @"\[(.*?)\]";

            string className = "";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                className += match.Groups[1].Value;
            }

            pr.EditPayment(subscribersBox.SelectedItem.ToString(), className);
            updatePayments();
        }

        private void deletePayment_Click(object sender, EventArgs e)
        {
            if (subscribersBox.SelectedItem == null) return;
            if (paymentsBox.SelectedItem == null) return;


            string input = paymentsBox.SelectedItem.ToString();
            string pattern = @"\[(.*?)\]";

            string className = "";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                className += match.Groups[1].Value;
            }

            pr.DeletePayment(subscribersBox.SelectedItem.ToString(), className);
            updatePayments();
        }

        private void formatText_Click(object sender, EventArgs e)
        {
            var formatStrategy = new TextFormatStrategy();
            if (subscribersBox.SelectedItem == null) return;

            var payments = pr.subscribers.FirstOrDefault(p => p.Name == subscribersBox.SelectedItem.ToString()).Payments;
            formatStrategy.Format(payments);
            updatePayments();
        }

        private void formatHTML_Click(object sender, EventArgs e)
        {
            var formatStrategy = new HtmlFormatStrategy();
            if (subscribersBox.SelectedItem == null) return;

            var payments = pr.subscribers.FirstOrDefault(p => p.Name == subscribersBox.SelectedItem.ToString()).Payments;
            formatStrategy.Format(payments);
            updatePayments();
        }
        private void onNotifications_Click(object sender, EventArgs e)
        {
            var formatStrategy = new HtmlFormatStrategy();
            if (subscribersBox.SelectedItem == null) return;

            foreach (var sub in pr.subscribers)
            {
                Payment.Attach(sub);
            }

            MessageBox.Show(
            "Уведомления включены",
            "",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
        private void offNotifications_Click(object sender, EventArgs e)
        {
            foreach (var sub in pr.subscribers)
            {
                Payment.Detach(sub);
            }

            MessageBox.Show(
            "Уведомления выключены",
            "",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}