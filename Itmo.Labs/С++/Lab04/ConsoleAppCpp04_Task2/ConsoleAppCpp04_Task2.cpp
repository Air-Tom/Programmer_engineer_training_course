#include <iostream>

using namespace std;


bool Input(int& a, int& b) {
    cout << "Введите два целых числа (a и b): ";
    if (cin >> a >> b) {
        return true; 
    }
    else {
        cin.clear(); 
        cin.ignore(numeric_limits<streamsize>::max(), '\n'); 
        return false; 
    }
}

int main() {

    system("chcp 1251");

    int a, b;

    if (!Input(a, b)) { 
        cerr << "Ошибка ввода данных!" << endl;
        return 1;
    }

    int s = a + b;
    cout << "Сумма чисел: " << s << endl;

    return 0;
}