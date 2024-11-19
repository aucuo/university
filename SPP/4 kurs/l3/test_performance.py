import timeit
from algorithms.fibonacci import fibonacci_iter, fibonacci_rec_memo
from algorithms.max_element import max_element_iter, max_element_rec
from algorithms.is_prime import is_prime_iter, is_prime_rec

import sys
sys.setrecursionlimit(2000)

def measure_performance():
    n_fib = 30
    arr = list(range(1000))
    prime_check = 7919

    print("Fibonacci performance:")
    print("Iterative:", timeit.timeit(lambda: fibonacci_iter(n_fib), number=1000))
    print("Recursive:", timeit.timeit(lambda: fibonacci_rec_memo(n_fib), number=1000))

    print("\nMax Element performance:")
    print("Iterative:", timeit.timeit(lambda: max_element_iter(arr), number=1000))
    print("Recursive:", timeit.timeit(lambda: max_element_rec(arr, len(arr)), number=1000))

    print("\nPrime Check performance:")
    print("Iterative:", timeit.timeit(lambda: is_prime_iter(prime_check), number=1000))
    print("Recursive:", timeit.timeit(lambda: is_prime_rec(prime_check), number=1000))

if __name__ == "__main__":
    measure_performance()
