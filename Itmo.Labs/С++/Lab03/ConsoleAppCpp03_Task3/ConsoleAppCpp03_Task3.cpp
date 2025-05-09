#include <iostream>
#include <cmath>
#include <windows.h> 

using namespace std;

double calculateArea(double side) {
    return (sqrt(3) / 4) * side * side;
}

double calculateArea(double side1, double side2, double side3) {
    double p = (side1 + side2 + side3) / 2; 
    return sqrt(p * (p - side1) * (p - side2) * (p - side3));
}

int main() {

    SetConsoleOutputCP(1251);

    int choice;
    cout << "Выберите тип треугольника:\n";
    cout << "1. Равносторонний\n";
    cout << "2. Разносторонний\n";
    cout << "Введите номер: ";
    cin >> choice;

    if (choice == 1) {
        double side;
        cout << "Введите длину стороны равностороннего треугольника: ";
        cin >> side;

        if (side <= 0) {
            cout << "Ошибка: длина стороны должна быть положительной.\n";
        }
        else {
            double area = calculateArea(side);
            cout << "Площадь равностороннего треугольника: " << area << endl;
        }
    }
    else if (choice == 2) {
        double side1, side2, side3;
        cout << "Введите длины трех сторон разностороннего треугольника:\n";
        cout << "Сторона 1: ";
        cin >> side1;
        cout << "Сторона 2: ";
        cin >> side2;
        cout << "Сторона 3: ";
        cin >> side3;

        if (side1 <= 0 || side2 <= 0 || side3 <= 0) {
            cout << "Ошибка: длины сторон должны быть положительными.\n";
        }
        else if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1) {
            cout << "Ошибка: такие стороны не могут образовать треугольник.\n";
        }
        else {
            double area = calculateArea(side1, side2, side3);
            cout << "Площадь разностороннего треугольника: " << area << endl;
        }
    }
    else {
        cout << "Ошибка: неверный выбор.\n";
    }

    return 0;
}