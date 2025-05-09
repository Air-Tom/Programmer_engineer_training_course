#include <iostream>
#include <cstring> 
#include <cstdlib> 
#include <windows.h>

using namespace std;

void performOperation(const string& flag, int num1, int num2) {
    if (flag == "-a") {
        cout << "Результат сложения: " << num1 + num2 << endl;
    }
    else if (flag == "-m") {
        cout << "Результат умножения: " << num1 * num2 << endl;
    }
    else {
        cout << "Ошибка: неверный флаг. Используйте -a для сложения или -m для умножения." << endl;
    }
}

int main() {

    SetConsoleOutputCP(1251);

    string flag;
    int num1, num2;

    cout << "Введите флаг (-a для сложения, -m для умножения): ";
    cin >> flag;

    if (flag != "-a" && flag != "-m") {
        cout << "Ошибка: неверный флаг. Используйте -a для сложения или -m для умножения." << endl;
        return 1; 
    }

    cout << "Введите первое число: ";
    cin >> num1;

    if (cin.fail()) {
        cout << "Ошибка: первое число введено некорректно." << endl;
        return 1; 
    }

    cout << "Введите второе число: ";
    cin >> num2;

    if (cin.fail()) {
        cout << "Ошибка: второе число введено некорректно." << endl;
        return 1; 
    }

    performOperation(flag, num1, num2);

    return 0;
}