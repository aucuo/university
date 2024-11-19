def print_lines_with_keyword(filename, keyword):
    try:
        with open(filename, 'r') as file:
            for line in file:
                if keyword in line:
                    print(line.strip())
    except FileNotFoundError:
        print(f"Файл {filename} не найден.")

filename = "output.txt"
keyword = input("Введите ключевое слово для поиска: ")
print_lines_with_keyword(filename, keyword)
