#include <iostream>
#include <Windows.h>

// Шаблонная функция для вычисления среднего арифметического
template <typename T>
double calculateAverage(const T* array, int size) {
    double sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += static_cast<double>(array[i]); 
    }
    return sum / size; 
}

int main() {

    SetConsoleOutputCP(1251);

    int intArray[] = { 1, 2, 3, 4, 5 };
    int intSize = sizeof(intArray) / sizeof(intArray[0]);
    std::cout << "Среднее арифметическое (int): " << calculateAverage(intArray, intSize) << std::endl;

    long longArray[] = { 10L, 20L, 30L, 40L, 50L };
    int longSize = sizeof(longArray) / sizeof(longArray[0]);
    std::cout << "Среднее арифметическое (long): " << calculateAverage(longArray, longSize) << std::endl;

    double doubleArray[] = { 1.5, 2.5, 3.5, 4.5, 5.5 };
    int doubleSize = sizeof(doubleArray) / sizeof(doubleArray[0]);
    std::cout << "Среднее арифметическое (double): " << calculateAverage(doubleArray, doubleSize) << std::endl;

    char charArray[] = { 'a', 'b', 'c', 'd', 'e' };
    int charSize = sizeof(charArray) / sizeof(charArray[0]);
    std::cout << "Среднее арифметическое (char): " << calculateAverage(charArray, charSize) << std::endl;

    return 0;
}