#include <iostream>
#include <windows.h>

using namespace std;

int sumSeries(int n) {
    
    if (n == 1) {
        return 5;
    }
    
    return 5 * n + sumSeries(n - 1);
}

int main() {

    SetConsoleOutputCP(1251);

    int n;
    cout << "Введите значение n (n > 0): ";
    cin >> n;

    if (n <= 0) {
        cout << "Ошибка: n должно быть больше 0.\n";
    }
    else {
        int result = sumSeries(n);
        cout << "Сумма ряда " << n << " = " << result << endl;
    }

    return 0;
}
