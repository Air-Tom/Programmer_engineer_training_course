//#include <iostream>
//#include <cmath>
//#include <stdexcept> 
//#include <Windows.h>
//
//class Triangle {
//
//private:
//    double side1, side2, side3;
//
//    void validateSides() const {
//        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1) {
//            throw std::invalid_argument("Невозможно построить треугольник с такими сторонами.");
//        }
//    }
//
//public:
//
//    Triangle(double s1, double s2, double s3) : side1(s1), side2(s2), side3(s3) {
//        validateSides();
//    }
//
//    double calculateArea() const {
//        double semiperimeter = (side1 + side2 + side3) / 2.0;
//        return std::sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));
//    }
//};
//
//int main() {
//
//    SetConsoleOutputCP(1251);
//
//    double s1, s2, s3;
//
//    std::cout << "Введите длины сторон треугольника: \n";
//    std::cout << "Сторона 1: ";
//    std::cin >> s1;
//    std::cout << "Сторона 2: ";
//    std::cin >> s2;
//    std::cout << "Сторона 3: ";
//    std::cin >> s3;
//
//    try {
//        
//        Triangle triangle(s1, s2, s3);
//
//        double area = triangle.calculateArea();
//        std::cout << "Площадь треугольника: " << area << std::endl;
//    }
//    catch (const std::invalid_argument& e) {
//        
//        std::cerr << "Ошибка: " << e.what() << std::endl;
//    }
//
//    return 0;
//}

#include <iostream>
using namespace std;

class A {
private:
    int* arr;    // Указатель на динамический массив
    int size_;   // Размер массива

public:
    // Конструктор по умолчанию
    A() : arr(nullptr), size_(0) {}

    // Конструктор с параметром (размер массива)
    A(int size) : size_(size) {
        arr = new int[size_]; // Выделяем память под массив
        for (int i = 0; i < size_; i++) {
            arr[i] = 0; // Инициализируем массив нулями
        }
    }

    // Конструктор копирования
    A(const A& other) : size_(other.size_) {
        arr = new int[size_]; // Выделяем память под новый массив
        for (int i = 0; i < size_; i++) {
            arr[i] = other.arr[i]; // Копируем элементы
        }
    }

    // Оператор присваивания
    A& operator=(const A& other) {
        if (this != &other) { // Проверка на самоприсваивание
            delete[] arr; // Освобождаем старую память
            size_ = other.size_;
            arr = new int[size_]; // Выделяем новую память
            for (int i = 0; i < size_; i++) {
                arr[i] = other.arr[i]; // Копируем элементы
            }
        }
        return *this;
    }

    // Деструктор
    ~A() {
        delete[] arr; // Освобождаем память
    }

    // Метод для получения размера массива
    int size() const {
        return size_;
    }

    // Оператор [] для неконстантных объектов
    int& operator[](int index) {
        if (index < 0 || index >= size_) {
            throw out_of_range("Индекс выходит за пределы массива");
        }
        return arr[index];
    }

    // Оператор [] для константных объектов
    const int& operator[](int index) const {
        if (index < 0 || index >= size_) {
            throw out_of_range("Индекс выходит за пределы массива");
        }
        return arr[index];
    }
};

int main() {
    A a1;          // Конструктор по умолчанию
    A a2(10);      // Конструктор с параметром (размер массива 10)
    A a3 = a2;     // Конструктор копирования
    a1 = a3;       // Оператор присваивания
    a2 = A(20);    // Создание временного объекта и присваивание

    const A a4(5); // Константный объект
    for (int i = 0; i < a2.size(); i++) { // Используем размер a4
        cout << a4[i] << " "; // Доступ к элементам константного объекта
    }

    return 0;
}