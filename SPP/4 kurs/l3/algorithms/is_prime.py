# Итеративная реализация
def is_prime_iter(n):
    if n <= 1:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

# Рекурсивная реализация
def is_prime_rec(n, i=2):
    if n <= 1:
        return False
    if i > int(n**0.5):
        return True
    if n % i == 0:
        return False
    return is_prime_rec(n, i + 1)
