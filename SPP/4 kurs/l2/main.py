def f(x):
    if x <= -1:
        return -x + 1
    elif -1 < x <= 2:
        return x**2 - 1
    else:
        return 3

def main():
    while True:
        a_input = input("Введите значение a или введите 'рот закрой' для выхода: ")
        if a_input.lower() == 'рот закрой':
            print("Программа завершена.")
            break

        b_input = input("Введите значение b или введите 'рот закрой' для выхода: ")
        if b_input.lower() == 'рот закрой':
            print("Программа завершена.")
            break

        try:
            a = float(a_input)
            b = float(b_input)

            if a > b:
                print("Значение a должно быть меньше или равно b.")
                continue

            print(f"интервал [{a}, {b}]:")
            x = a
            
            while x <= b:
                print(f"f({x}) = {f(x)}")
                x += 1

        except ValueError:
            print("Ошибка: введите числовые значения для a и b.")

if __name__ == "__main__":
    main()
