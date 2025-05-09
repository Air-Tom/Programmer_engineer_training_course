#include <iostream>
#include <cmath>
#include <stdexcept>
#include <windows.h>

using namespace std;

double cubicRootPow(double a) {
    if (a < 0) {
        return -pow(-a, 1.0 / 3);
    }
    return pow(a, 1.0 / 3);
}

double cubicRootIterative(double a, double epsilon = 1e-6, int maxIterations = 1000) {
    if (a == 0) return 0;

    double x1 = a; 
    double x2;

    for (int i = 0; i < maxIterations; ++i) {
        x2 = (1.0 / 3) * (a / (x1 * x1) + 2 * x1);

        if (abs(x2 - x1) < epsilon) {
            break;
        }

        x1 = x2;
    }

    return x2;
}

int main() {

    SetConsoleOutputCP(1251);

    double a;
    cout << "Введите число для вычисления кубического корня: ";
    cin >> a;

    try {
        double resultPow = cubicRootPow(a);
        cout << "Кубический корень (pow): " << resultPow << endl;

        double resultIterative = cubicRootIterative(a);
        cout << "Кубический корень (итерационный): " << resultIterative << endl;
    }
    catch (const invalid_argument& e) {
        cerr << "Ошибка: " << e.what() << endl;
    }

    return 0;
}