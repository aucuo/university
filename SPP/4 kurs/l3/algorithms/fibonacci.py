# Итеративная реализация
def fibonacci_iter(n):
    if n <= 1:
        return n
    a, b = 0, 1
    for _ in range(2, n + 1):
        a, b = b, a + b
    return b

# Рекурсивная реализация с мемоизацией
def fibonacci_rec_memo(n, memo=None):
    if memo is None:
        memo = {}
    if n in memo:
        return memo[n]
    if n <= 1:
        return n
    memo[n] = fibonacci_rec_memo(n - 1, memo) + fibonacci_rec_memo(n - 2, memo)
    return memo[n]
