import math


# Функция приветствия
def greet_user():
    print ('''Yo, бро! 
Салют! 

Как сам? 
Спасёшь утопающего!? 
Или "Спасение утопающих-дело рук самих утопающих?"''')
    print() # Пустая строка </br>

# Функция преобразования строки в число с плавающей точкой
def get_float_input(prompt):
    while True:
        try:
            return float(input(prompt))
        except ValueError:
            print("Пожалуйста, введите корректное число.")

# Ограничение на ввод Theta от 0 до 360 градусов
def get_theta_input(prompt):
    while True:
        try:
            # Запрашиваем ввод у пользователя
            theta = float(input(prompt))

            # Проверяем, находится ли значение в диапазоне от 0 до 360
            if 0 <= theta <= 360:
                return int(round(theta))  # Округляем до ближайшего целого и возвращаем
            else:
                print("Ошибка: значение должно быть в диапазоне от 0 до 360 градусов.")
        except ValueError:
            print("Ошибка: пожалуйста, введите числовое значение.")

# Функция преобразования ярдов в футы
def yards_to_feet(yards):
    return yards * 3

# Функция преобразования миль в час в футы в секунду
def mph_to_fts(mph):
    return mph * 5280 / 3600

# Функция вычисления Х
def calculate_x(d1, theta_radians):
    return  d1 * math.tan(theta_radians)

# Функция вычисления L1
def calculate_L1(x, d1):
    return math.sqrt(x**2 + d1**2)

# Функция вычисления L2
def calculate_L2(h, x, d2):
    return math.sqrt((h - x)**2 + d2**2)

# Функция вычисления t
def calculate_t(L1, L2, vsand, n):
    return (1 / vsand) * (L1 + n * L2)

def main():
    greet_user()

    # Задаём значение d1 (в ярдах) и theta (в градусах)
    d1 = yards_to_feet(get_float_input('Введите значение d1 в ярдах: '))
    theta = get_theta_input('Введите значение 𝜃1 в диапазоне от 0 до 360 градусов: ')
    print(f'Theta = {theta}')
    print(type (theta)) # Проверка типа данных theta
    print()

    # Преобразование угла из градусов в радианы
    theta_radians = math.radians(theta)

    # Вычисляем x
    x = calculate_x(d1, theta_radians)
    print(f'Результат x = {x:.2f}')

    # Вычисляем длину пути L1
    L1 = calculate_L1(x, d1)
    print()

    # Введем с консоли значение бокового смещения между спасателем и утопающим h (в ярдах)
    # и d2 кратчайшее расстояние от утопающего до берега
    h = yards_to_feet(get_float_input('Введите значение h в ярдах: '))
    d2 = get_float_input('Введите значение d2 в футах: ')

    # Вычисляем длину пути L2
    L2 = calculate_L2(h, x, d2)

    # Выводим результат L1 и L2
    print(f'Результат L1 = {(format(L1,'.2f'))}; L2 = {(format(L2,'.2f'))};')
    print()

    # Введем с консоли скорость движения спасателя по песку vsand
    # и n коэффициент замедления спасателя при движении в воде
    vsand = mph_to_fts(get_float_input('Введите значение vsand в милях в час: '))
    print(f'Результат в футах в секунду vsand = {vsand:.2f}')
    n = get_float_input(('Введите значение n: '))
    print()

    # Вычисляем общее время t на достижение утопающего
    t = calculate_t(L1, L2, vsand, n)
    print(f'Результат общего времени до утопающего t = {(format(t,'.1f'))} секунд')
    print(type(t))

if __name__ == '__main__':
    main()