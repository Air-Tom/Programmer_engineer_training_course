#include <iostream>
#include <cmath>
#include <windows.h>

int Myroot(double a, double b, double c, double& x1, double& x2) {
    double discriminant = b * b - 4 * a * c;

    if (discriminant > 0) {
        x1 = (-b + sqrt(discriminant)) / (2 * a);
        x2 = (-b - sqrt(discriminant)) / (2 * a);
        return 1; 
    }
    else if (discriminant == 0) {
        x1 = x2 = -b / (2 * a);
        return 0; 
    }
    else {
        return -1;
    }
}

int main() {

    SetConsoleOutputCP(1251);

    double a, b, c;
    double x1, x2;

    std::cout << "Введите коэффициенты квадратного уравнения (a, b, c): ";
    std::cin >> a >> b >> c;

    int result = Myroot(a, b, c, x1, x2);

    if (result == 1) {
        std::cout << "Корни уравнения: x1 = " << x1 << ", x2 = " << x2 << std::endl;
    }
    else if (result == 0) {
        std::cout << "Корень уравнения один: x1 = x2 = " << x1 << std::endl;
    }
    else {
        std::cout << "Корней уравнения нет." << std::endl;
    }

    return 0;
}