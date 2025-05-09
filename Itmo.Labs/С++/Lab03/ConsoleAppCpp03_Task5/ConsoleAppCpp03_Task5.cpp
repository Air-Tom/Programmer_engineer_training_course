#include <iostream>
#include <windows.h>

using namespace std;

void decimalToBinary(int num) {

    if (num == 0) {
        return;
    }

    decimalToBinary(num / 2);

    cout << num % 2;
}

int main() {

    SetConsoleOutputCP(1251);

    int num;
    cout << "Введите целое положительное число: ";
    cin >> num;

    if (num < 0) {
        cout << "Ошибка: число должно быть положительным.\n";
    }
    else if (num == 0) {
        cout << "Двоичное представление: 0\n";
    }
    else {
        cout << "Двоичное представление: ";
        decimalToBinary(num);
        cout << endl;
    }

    return 0;
}

