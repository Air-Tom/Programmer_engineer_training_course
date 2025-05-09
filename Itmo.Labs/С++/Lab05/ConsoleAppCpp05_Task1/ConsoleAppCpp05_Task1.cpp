#include <iostream>
#include <windows.h>

using namespace std;

// Функция для ввода массива с клавиатуры
void inputArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        cout << "arr[" << i << "] = ";
        cin >> arr[i];
    }
}

// Функция для вычисления суммы всех элементов массива
int sumArray(int arr[], int n) {
    int sum = 0;
    for (int i = 0; i < n; i++) {
        sum += arr[i];
    }
    return sum;
}

// Функция для вычисления среднего значения элементов массива
double averageArray(int arr[], int n) {
    return static_cast<double>(sumArray(arr, n)) / n;
}

// Функция для вычисления суммы отрицательных элементов
int sumNegative(int arr[], int n) {
    int sum = 0;
    for (int i = 0; i < n; i++) {
        if (arr[i] < 0) {
            sum += arr[i];
        }
    }
    return sum;
}

// Функция для вычисления суммы положительных элементов
int sumPositive(int arr[], int n) {
    int sum = 0;
    for (int i = 0; i < n; i++) {
        if (arr[i] > 0) {
            sum += arr[i];
        }
    }
    return sum;
}

// Функция для вычисления суммы элементов с четными индексами
int sumEvenIndex(int arr[], int n) {
    int sum = 0;
    for (int i = 0; i < n; i += 2) {
        sum += arr[i];
    }
    return sum;
}

// Функция для вычисления суммы элементов с нечетными индексами
int sumOddIndex(int arr[], int n) {
    int sum = 0;
    for (int i = 1; i < n; i += 2) {
        sum += arr[i];
    }
    return sum;
}

// Функция для поиска минимального и максимального элементов и их индексов
void findMinMax(int arr[], int n, int& minVal, int& maxVal, int& minIndex, int& maxIndex) {
    minVal = arr[0];
    maxVal = arr[0];
    minIndex = 0;
    maxIndex = 0;

    for (int i = 1; i < n; i++) {
        if (arr[i] < minVal) {
            minVal = arr[i];
            minIndex = i;
        }
        if (arr[i] > maxVal) {
            maxVal = arr[i];
            maxIndex = i;
        }
    }
}

// Функция для вычисления произведения элементов между минимальным и максимальным элементами
int productBetweenMinMax(int arr[], int n, int minIndex, int maxIndex) {
    int product = 1;
    int start = minIndex < maxIndex ? minIndex : maxIndex;
    int end = minIndex > maxIndex ? minIndex : maxIndex;

    for (int i = start + 1; i < end; i++) {
        product *= arr[i];
    }
    return product;
}

// Функция для сортировки массива выбором
void selectionSort(int arr[], int n) {
    int minIndex, buf;

    for (int i = 0; i < n; i++) {
        minIndex = i;

        // Поиск минимального элемента в оставшейся части массива
        for (int j = i + 1; j < n; j++) {
            if (arr[j] < arr[minIndex]) {
                minIndex = j;
            }
        }

        // Обмен местами текущего элемента с минимальным
        if (i != minIndex) {
            buf = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = buf;
        }
    }
}

// Функция для вывода массива
void printArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        cout << arr[i] << '\t';
    }
    cout << endl;
}

int main() {

    SetConsoleOutputCP(1251);

    const int n = 10;
    int arr[n];

    // Ввод массива
    cout << "Введите " << n << " элементов массива:" << endl;
    inputArray(arr, n);

    // Вывод исходного массива
    cout << "\nИсходный массив: ";
    printArray(arr, n);

    // Обработка массива (упражнение 1)
    cout << "\nОбработка массива:" << endl;
    cout << "Сумма всех элементов: " << sumArray(arr, n) << endl;
    cout << "Среднее значение: " << averageArray(arr, n) << endl;
    cout << "Сумма отрицательных элементов: " << sumNegative(arr, n) << endl;
    cout << "Сумма положительных элементов: " << sumPositive(arr, n) << endl;
    cout << "Сумма элементов с четными индексами: " << sumEvenIndex(arr, n) << endl;
    cout << "Сумма элементов с нечетными индексами: " << sumOddIndex(arr, n) << endl;

    int minVal, maxVal, minIndex, maxIndex;
    findMinMax(arr, n, minVal, maxVal, minIndex, maxIndex);
    cout << "Минимальный элемент: " << minVal << " (индекс: " << minIndex << ")" << endl;
    cout << "Максимальный элемент: " << maxVal << " (индекс: " << maxIndex << ")" << endl;
    cout << "Произведение элементов между минимальным и максимальным элементами: "
        << productBetweenMinMax(arr, n, minIndex, maxIndex) << endl;

    // Сортировка массива (упражнение 2)
    cout << "\nСортировка массива:" << endl;
    selectionSort(arr, n);
    cout << "Отсортированный массив: ";
    printArray(arr, n);

    return 0;
}