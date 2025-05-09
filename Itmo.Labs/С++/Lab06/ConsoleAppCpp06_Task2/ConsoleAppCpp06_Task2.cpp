#include <iostream>
#include <windows.h>
#include <fstream> 

using namespace std;

int* max_vect(int kc, int a[], int b[]) {
    int* result = new int[kc];

    for (int i = 0; i < kc; i++) {
        result[i] = (a[i] > b[i]) ? a[i] : b[i];
    }

    return result;
}

int main() {
    
    SetConsoleOutputCP(1251);

    int a[] = { 1, 2, 3, 4, 5, 6, 7, 5 };
    int b[] = { 7, 6, 5, 4, 3, 2, 1, 1 };

    int kc = sizeof(a) / sizeof(a[0]);

    int* c = max_vect(kc, a, b);

    cout << "Результирующий массив: ";
    for (int i = 0; i < kc; i++) {
        cout << c[i] << " ";
    }
    cout << endl;

    ofstream file("arrays.txt");
    if (!file.is_open()) {
        cerr << "Ошибка: не удалось открыть файл для записи." << endl;
        delete[] c; 
        return 1;
    }

    file << "Исходный массив a: ";
    for (int i = 0; i < kc; i++) {
        file << a[i] << " ";
    }
    file << endl;

    file << "Исходный массив b: ";
    for (int i = 0; i < kc; i++) {
        file << b[i] << " ";
    }
    file << endl;

    file << "Результирующий массив c: ";
    for (int i = 0; i < kc; i++) {
        file << c[i] << " ";
    }
    file << endl;

    file.close();

    cout << "Массивы успешно записаны в файл arrays.txt." << endl;

    delete[] c;

    return 0;
}