namespace Lab4
{
    abstract internal class Worker
    {
        protected string name;
        protected string jobTitle; // должность
        public Worker(string name, string jobTitle) // с параметрами
        {
            Console.WriteLine("Конструктор Worker с параметрами");
            this.name = name;
            this.jobTitle = jobTitle;
        }
        public Worker() // без параметров
        {
            Console.WriteLine("Конструктор Worker без параметров");
            this.name = "Lesson.name";
            this.jobTitle = "Lesson.day";
        }
        public Worker(Worker worker) // копирования
        {
            Console.WriteLine("Конструктор Worker копирования");
            this.name = worker.name;
            this.jobTitle = worker.jobTitle;
        }
        ~Worker() { Console.WriteLine("Деструктор Worker"); } // деструктор
        public abstract void Print(); // абстрактный метод
    }
}
