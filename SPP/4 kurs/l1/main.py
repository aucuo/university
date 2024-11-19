# Задача 1
def average_of_three_numbers():
    a = float(input("Введите первое число: "))
    b = float(input("Введите второе число: "))
    c = float(input("Введите третье число: "))
    average = (a + b + c) / 3
    print(f"Среднее арифметическое: {round(average, 2)}")

# Задача 2
def operations_on_two_numbers():
    x = int(input("Введите первое целое число: "))
    y = int(input("Введите второе целое число: "))
    
    if y == 0:
        quotient = "неопределено"
        integer_division = "неопределено"
        remainder = "неопределено"
    else:
        quotient = round(x / y, 2)
        integer_division = x // y
        remainder = x % y
    
    result = {
        "Сумма": x + y,
        "Разность": x - y,
        "Произведение": x * y,
        "Частное": quotient,
        "Целочисленное деление": integer_division,
        "Остаток от деления": remainder,
        "Возведение в степень": x ** y,
        "Побитовое И": x & y,
        "Побитовое ИЛИ": x | y,
        "Побитовое XOR": x ^ y,
        "Побитовая инверсия X": ~x,
        "Побитовая инверсия Y": ~y
    }
    
    for operation, value in result.items():
        print(f"{operation}: {value}")

# Задача 3
def student_data():
    last_name = input("Введите фамилию: ")
    first_name = input("Введите имя: ")
    patronymic = input("Введите отчество: ")
    birth_year = int(input("Введите год рождения: "))
    return {
        "Фамилия": last_name,
        "Имя": first_name,
        "Отчество": patronymic,
        "Год рождения": birth_year
    }

# Задача 4
def format_student_table():
    student_info = student_data()
    
    column_sep = input("Введите символ для разделителя столбцов: ")
    row_sep = input("Введите символ для разделителя строк: ") + '\n'
    col_width = int(input("Введите количество символов в каждом столбце: "))
    fill_char = input("Введите символ для замены пробелов: ")
    
    header = f"{'Поле'.ljust(col_width, fill_char)}{column_sep}{'Тип'.center(col_width, fill_char)}{column_sep}{'Значение'.rjust(col_width, fill_char)}"
    table = [header]
    
    for key, value in student_info.items():
        row = f"{key.ljust(col_width, fill_char)}{column_sep}{str(type(value).__name__).center(col_width, fill_char)}{column_sep}{str(value).rjust(col_width, fill_char)}"
        table.append(row)
    
    print(row_sep.join(table))

def main():
    while True:
        print("\nВыберите задачу:")
        print("1. среднее арифметическое")
        print("2. операции с числами")
        print("3. ввод данных")
        print("4. таблица")
        print("5. Выйти")
        
        try:
            choice = int(input("введите номер задачи (1-5): "))
        except ValueError:
            print("число от 1 до 5 быть должно")
            continue
        
        if choice == 1:
            average_of_three_numbers()
        elif choice == 2:
            operations_on_two_numbers()
        elif choice == 3:
            student_info = student_data()
            print(student_info)
        elif choice == 4:
            format_student_table()
        elif choice == 5:
            print("Программа завершена.")
            break
        else:
            print("Неверный выбор, попробуйте снова.")

main()
