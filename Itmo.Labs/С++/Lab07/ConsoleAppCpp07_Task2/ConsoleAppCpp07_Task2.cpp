#include <iostream>
#include <cmath> 
#include <limits> 
#include <windows.h>

using namespace std;

struct QuadraticSolution {
    double x1;
    double x2;

    QuadraticSolution(double root1, double root2) : x1(root1), x2(root2) {}
};

QuadraticSolution solveQuadratic(double a, double b, double c) {
    double discriminant = b * b - 4 * a * c;

    if (discriminant < 0) {
        
        return { numeric_limits<double>::quiet_NaN(), numeric_limits<double>::quiet_NaN() };
    }
    else if (discriminant == 0) {
        
        double x = -b / (2 * a);
        return { x, x };
    }
    else {
        
        double x1 = (-b + sqrt(discriminant)) / (2 * a);
        double x2 = (-b - sqrt(discriminant)) / (2 * a);
        return { x1, x2 };
    }
}

int main() {

    SetConsoleOutputCP(1251);

    double a, b, c;

    cout << "Введите коэффициенты квадратного уравнения (a, b, c):" << endl;
    cout << "a: ";
    cin >> a;
    cout << "b: ";
    cin >> b;
    cout << "c: ";
    cin >> c;

    QuadraticSolution solution = solveQuadratic(a, b, c);

    if (isnan(solution.x1)) {
        cout << "Уравнение не имеет действительных корней." << endl;
    }
    else if (solution.x1 == solution.x2) {
        cout << "Уравнение имеет один корень: x = " << solution.x1 << endl;
    }
    else {
        cout << "Уравнение имеет два корня: x1 = " << solution.x1 << ", x2 = " << solution.x2 << endl;
    }

    return 0;
}