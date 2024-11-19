def sort_numbers(numbers_list, ascending=True):
    return sorted(numbers_list, reverse=not ascending)

numbers_list = [34, 12, 89, 23, 9, 56]
order = input("Введите '1' для сортировки по возрастанию или '2' для сортировки по убыванию: ")

if order == '1':
    sorted_list = sort_numbers(numbers_list, ascending=True)
elif order == '2':
    sorted_list = sort_numbers(numbers_list, ascending=False)
else:
    print("Неверный ввод!")
    sorted_list = numbers_list

print("Отсортированный список:", sorted_list)
