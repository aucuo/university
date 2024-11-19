# Итеративная реализация
def max_element_iter(arr):
    max_elem = arr[0]
    for elem in arr:
        if elem > max_elem:
            max_elem = elem
    return max_elem

# Рекурсивная реализация
def max_element_rec(arr, n):
    if n == 1:
        return arr[0]
    else:
        return max(arr[n-1], max_element_rec(arr, n-1))
