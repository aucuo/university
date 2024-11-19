import os

# Создаем директорию "project"
os.makedirs('project', exist_ok=True)

# Переходим в директорию "project"
os.chdir('project')

# Проверяем, что мы находимся в правильной директории
print(os.getcwd())


# Создаем и записываем текст в файл "data.txt"
with open('data.txt', 'w') as f:
    f.write('fst line\n')
    f.write('scnd line\n')
    f.write('thrd line\n')


# Читаем содержимое файла и выводим его
with open('data.txt', 'r') as f:
    content = f.read()
    print(content)


# Создаем копию файла
import shutil
shutil.copy('data.txt', 'data_backup.txt')


# Удаляем файл "data.txt"
os.remove('data.txt')

# Переименовываем файл "data_backup.txt" обратно в "data.txt"
os.rename('data_backup.txt', 'data.txt')

# Загружаем файл
from google.colab import files
uploaded = files.upload()  # Выберите файл на вашем компьютере


# Получаем содержимое папки /content/
content_dir = os.listdir('/content/')

# Записываем содержимое папки в файл "data.txt"
with open('data.txt', 'a') as f:
    f.write('\nСодержимое папки /content/:\n')
    for item in content_dir:
        f.write(f"{item}\n")


# Скачиваем файл "data.txt" на компьютер
files.download('data.txt')
