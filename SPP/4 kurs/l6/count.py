def count_words_in_file(filename):
    try:
        with open(filename, 'r') as file:
            content = file.read()
            words = content.split()
            print(f"Общее количество слов в файле: {len(words)}")
    except FileNotFoundError:
        print(f"Файл {filename} не найден.")

filename = "output.txt"
count_words_in_file(filename)
