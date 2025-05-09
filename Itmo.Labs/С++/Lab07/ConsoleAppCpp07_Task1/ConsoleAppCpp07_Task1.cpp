#include <iostream>
#include <windows.h>

using namespace std;

struct Time {
    int hours;
    int minutes;
    int seconds;

    int toSeconds() const {
        return hours * 3600 + minutes * 60 + seconds;
    }

    void normalize() {
        if (seconds >= 60) {
            minutes += seconds / 60;
            seconds %= 60;
        }
        if (minutes >= 60) {
            hours += minutes / 60;
            minutes %= 60;
        }
    }

    Time add(const Time& other) const {
        Time result;
        result.hours = hours + other.hours;
        result.minutes = minutes + other.minutes;
        result.seconds = seconds + other.seconds;
        result.normalize(); 
        return result;
    }

    Time subtract(const Time& other) const {
        Time result;
        int totalSeconds = toSeconds() - other.toSeconds();
        if (totalSeconds < 0) {
            cout << "Ошибка: результат вычитания отрицательный!" << endl;
            return { 0, 0, 0 };
        }
        result.hours = totalSeconds / 3600;
        result.minutes = (totalSeconds % 3600) / 60;
        result.seconds = totalSeconds % 60;
        return result;
    }
};

int main() {

    SetConsoleOutputCP(1251);

    Time t1, t2;

    cout << "Введите первый интервал времени (часы, минуты, секунды):" << endl;
    cout << "Часы: ";
    cin >> t1.hours;
    cout << "Минуты: ";
    cin >> t1.minutes;
    cout << "Секунды: ";
    cin >> t1.seconds;

    cout << "Введите второй интервал времени (часы, минуты, секунды):" << endl;
    cout << "Часы: ";
    cin >> t2.hours;
    cout << "Минуты: ";
    cin >> t2.minutes;
    cout << "Секунды: ";
    cin >> t2.seconds;

    cout << "Первый интервал в секундах: " << t1.toSeconds() << endl;
    cout << "Второй интервал в секундах: " << t2.toSeconds() << endl;

    Time sum = t1.add(t2);
    cout << "Сумма интервалов: "
        << sum.hours << " час(ов), "
        << sum.minutes << " минут(а), "
        << sum.seconds << " секунд(а)." << endl;

    Time diff = t1.subtract(t2);
    cout << "Разница интервалов: "
        << diff.hours << " час(ов), "
        << diff.minutes << " минут(а), "
        << diff.seconds << " секунд(а)." << endl;

    return 0;
}