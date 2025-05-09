#include <iostream>
#include <iomanip> 
#include <Windows.h>

using namespace std;

class Time {
private:
    int hours;
    int minutes;
    int seconds;

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

public:

    Time() : hours(0), minutes(0), seconds(0) {}

    Time(int h, int m, int s) : hours(h), minutes(m), seconds(s) {
        normalize(); 
    }

    void print() const {
        cout << setw(2) << setfill('0') << hours << ":"
            << setw(2) << setfill('0') << minutes << ":"
            << setw(2) << setfill('0') << seconds << endl;
    }

    Time add(const Time& other) const {
        Time result;
        result.hours = hours + other.hours;
        result.minutes = minutes + other.minutes;
        result.seconds = seconds + other.seconds;
        result.normalize(); 
        return result;
    }
};

int main() {

    SetConsoleOutputCP(1251);

    const Time t1(9, 99, 63); 
    const Time t2(1, 21, 48);

    Time t3;

    t3 = t1.add(t2);

    cout << "Время t1: ";
    t1.print();
    cout << "Время t2: ";
    t2.print();
    cout << "Сумма t1 и t2: ";
    t3.print();

    return 0;
}