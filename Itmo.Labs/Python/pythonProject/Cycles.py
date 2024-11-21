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

# Let's GO!
if __name__ == '__main__':
    greet_user()

# Задаём значение d1 (в ярдах) и theta (в градусах)
d1 = yards_to_feet(get_float_input('Введите значение d1 в ярдах: '))

# Введем с консоли значение бокового смещения между спасателем и утопающим h (в ярдах)
# и d2 кратчайшее расстояние от утопающего до берега
h = yards_to_feet(get_float_input('Введите значение h в ярдах: '))
d2 = get_float_input('Введите значение d2 в футах: ')

# Введем с консоли скорость движения спасателя по песку vsand
# и n коэффициент замедления спасателя при движении в воде
vsand = mph_to_fts(get_float_input('Введите значение vsand в милях в час: '))
print(f'Результат в футах в секунду vsand = {vsand:.2f}')
n = get_float_input(('Введите значение n: '))
print()

# Перебор углов от 0 до 360 градусов
min_time = float('inf')
optimal_theta = 0

for theta in range(91):  # от 0 до 90 включительно
    theta_radians = math.radians(theta)
    x = calculate_x(d1, theta_radians)
    L1 = calculate_L1(x, d1)
    L2 = calculate_L2(h, x, d2)

    t = calculate_t(L1, L2, vsand, n)

    if t < min_time:
        min_time = t
        optimal_theta = theta

print(f'Оптимальный угол θ = {optimal_theta} градусов')
print(f'Минимальное время t = {min_time:.1f} секунд')