﻿#include <iostream>
#include <windows.h>

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

    int a[] = { 1, 2, 3, 4, 5, 6, 7, 2 };
    int b[] = { 7, 6, 5, 4, 3, 2, 1, 3 };

    int kc = sizeof(a) / sizeof(a[0]);

    int* c;

    c = max_vect(kc, a, b);

    cout << "Результирующий массив: ";
    for (int i = 0; i < kc; i++) {
        cout << c[i] << " ";
    }
    cout << endl;

    delete[] c;

    return 0;
}