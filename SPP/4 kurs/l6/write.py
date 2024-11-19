def write_to_file(filename):
    with open(filename, 'w') as file:
        while True:
            data = input("Введите текст (или 'exit' для завершения): ")
            if data.lower() == 'exit':
                break
            file.write(data + '\n')
    print(f"Данные успешно сохранены в файл {filename}")

filename = "output.txt"
write_to_file(filename)
