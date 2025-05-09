#include <iostream>

using namespace std;

int transpositionSearch(int arr[], int n, int key) {
    for (int i = 0; i < n; i++) {
        if (arr[i] == key) {
            
            if (i > 0) {
                swap(arr[i], arr[i - 1]);
            }
            return i; 
        }
    }
    return -1; 
}

int main() {

    system("chcp 1251");

    int arr[] = { 24, 6, 37, 461, 4, 7, 2, 99, 63, 8 };
    int n = sizeof(arr) / sizeof(arr[0]); 

    int key;

    cout << "Исходный массив: ";
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    while (true) {
        cout << "Введите ключ для поиска (или -1 для выхода): ";
        cin >> key;

        if (cin.fail()) {
            cin.clear(); 
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); 
            cout << "Ошибка ввода. Пожалуйста, введите целое число." << endl;
            continue; 
        }

        if (key == -1) {
            break; 
        }

        int index = transpositionSearch(arr, n, key);

        if (index != -1) {
            cout << "Элемент " << key << " найден на позиции " << index << endl;
        }
        else {
            cout << "Элемент " << key << " не найден" << endl;
        }

        cout << "Массив после поиска: ";
        for (int i = 0; i < n; i++) {
            cout << arr[i] << " ";
        }
        cout << endl;
    }

    return 0;
}