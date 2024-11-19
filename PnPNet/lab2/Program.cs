namespace lab2
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Создание объекта PassengerShip
                List<string> cabins = new List<string> { "Эконом", "Бизнес", "Люкс" };
                PassengerShip ship = new PassengerShip("Титаник", 52310, "Пассажирский", cabins);
                PassengerShip ship2 = new PassengerShip();

                // Вызов методов и свойств
                ship.DisplayInfo();
                ship.UpdateDisplacement(55000);

                ship2.DisplayInfo();

                // Работа с индексатором
                Console.WriteLine("Категория каюты с индексом 1: " + ship[1]);
                ship[1] = "Премиум";
                Console.WriteLine("Обновленная категория каюты с индексом 1: " + ship[1]);

                // Вызов методов интерфейсов
                ship.PerformRepairs();
                ship.AssignCrew("Команда А");

                // Исключение
                ship[5] = "Ошибка";  // Ошибка индекса
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка индекса: " + ex.Message);
            }
            catch (CabinCategoryException ex)
            {
                Console.WriteLine(ex.Message);  // Йо-хохо! сообщение об ошибке
            }
            catch (ShipException ex)
            {
                Console.WriteLine(ex.Message);  // Йо-хохо! сообщение об ошибке
            }
            catch (Exception ex)
            {
                Console.WriteLine("Общая ошибка: " + ex.Message);
            }
        }
    }
}