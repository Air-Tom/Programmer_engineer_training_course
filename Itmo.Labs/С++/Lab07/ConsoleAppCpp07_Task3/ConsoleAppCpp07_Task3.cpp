#include <iostream>
#include <tuple>
#include <cmath> 
#include <limits> 
#include <Windows.h>

using namespace std;

tuple<double, double, bool> solveQuadratic(double a, double b, double c) {
    double discriminant = b * b - 4 * a * c;

    if (discriminant < 0) {
     
        return make_tuple(0.0, 0.0, false); 
    }
    else if (discriminant == 0) {
     
        double x = -b / (2 * a);
        return make_tuple(x, x, true); 
    }
    else {
       
        double x1 = (-b + sqrt(discriminant)) / (2 * a);
        double x2 = (-b - sqrt(discriminant)) / (2 * a);
        return make_tuple(x1, x2, true); 
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

    auto result = solveQuadratic(a, b, c); 
    double x1 = get<0>(result); 
    double x2 = get<1>(result); 
    bool hasRoots = get<2>(result); 

    if (!hasRoots) {
        cout << "Уравнение не имеет действительных корней." << endl;
    }
    else if (x1 == x2) {
        cout << "Уравнение имеет один корень: x = " << x1 << endl;
    }
    else {
        cout << "Уравнение имеет два корня: x1 = " << x1 << ", x2 = " << x2 << endl;
    }

    return 0;
}