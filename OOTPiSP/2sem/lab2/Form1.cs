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

        private void updateGroups()
        {
            groupsBox.Items.Clear();

            // Добавляем новые элементы из groups в groupsBox
            foreach (var group in pr.groups)
            {
                if (!groupsBox.Items.Contains(group.Name))
                {
                    groupsBox.Items.Add(group.Name);
                }
            }
        }
        private void updateGrades()
        {
            // Проверяем, выбран ли элемент
            if (groupsBox.SelectedItem == null) return;
            string name = groupsBox.SelectedItem.ToString();

            gradesBox.Items.Clear();

            // Получаем группу и ее оценки
            var group = pr.groups.FirstOrDefault(g => g.Name == name);
            if (group == null) return;

            foreach (var grade in group.Grades)
            {
                // Рефлексия для вызова всех геттеров текущего типа grade
                var properties = grade.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                StringBuilder text = new StringBuilder();
                text.Append($"[{grade.className}] ");

                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var value = property.GetValue(grade);
                        text.Append($"{property.Name}: {value}, ");
                    }
                }

                // Убираем последнюю запятую и пробел
                if (text.Length > 0)
                    text.Length -= 2;

                gradesBox.Items.Add(text.ToString());
            }
        }


        private void addGroup_Click(object sender, EventArgs e)
        {
            pr.AddGroup();
            updateGroups();
        }

        private void editGroup_Click(object sender, EventArgs e)
        {
            if (groupsBox.SelectedItem == null) return;
            pr.EditGroup(groupsBox.SelectedItem.ToString());
            updateGroups();
        }

        private void deleteGroup_Click(object sender, EventArgs e)
        {
            if (groupsBox.SelectedItem == null) return;
            pr.DeleteGroup(groupsBox.SelectedItem.ToString());
            updateGroups();
        }

        private void groupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGrades();
        }

        private void addGrade_Click(object sender, EventArgs e)
        {
            if (groupsBox.SelectedItem == null) return;

            pr.AddGrade(groupsBox.SelectedItem.ToString());

            updateGrades();
        }

        private void editGrade_Click(object sender, EventArgs e)
        {
            if (groupsBox.SelectedItem == null) return;
            if (gradesBox.SelectedItem == null) return;

            string input = gradesBox.SelectedItem.ToString();
            string pattern = @"\[(.*?)\]";

            string className = "";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                className += match.Groups[1].Value;
            }

            pr.EditGrade(groupsBox.SelectedItem.ToString(), className);
            updateGrades();
        }

        private void deleteGrade_Click(object sender, EventArgs e)
        {
            if (groupsBox.SelectedItem == null) return;
            if (gradesBox.SelectedItem == null) return;


            string input = gradesBox.SelectedItem.ToString();
            string pattern = @"\[(.*?)\]";

            string className = "";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                className += match.Groups[1].Value;
            }

            pr.DeleteGrade(groupsBox.SelectedItem.ToString(), className);
            updateGrades();
        }
    }
}