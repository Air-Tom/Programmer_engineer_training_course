#include <iostream>
#include <stdexcept> 
#include <iomanip>   
#include <Windows.h>

using namespace std;

class TimeException : public exception {
private:
    string message; 
public:
    TimeException(const string& msg) : message(msg) {}

    const char* what() const noexcept override {
        return message.c_str();
    }
};

class Time {
private:
    int hours;
    int minutes;
    int seconds;

    void validateTime(int h, int m, int s) const {
        if (h < 0 || h > 23) throw TimeException("Некорректное значение часов (должно быть 0-23)");
        if (m < 0 || m > 59) throw TimeException("Некорректное значение минут (должно быть 0-59)");
        if (s < 0 || s > 59) throw TimeException("Некорректное значение секунд (должно быть 0-59)");
    }

public:
    
    Time(int h = 0, int m = 0, int s = 0) {
        setTime(h, m, s);
    }

    void setTime(int h, int m, int s) {
        validateTime(h, m, s);
        hours = h;
        minutes = m;
        seconds = s;
    }

    int getHours() const { return hours; }
    int getMinutes() const { return minutes; }
    int getSeconds() const { return seconds; }

    void printTime() const {
        cout << setw(2) << setfill('0') << hours << ":"
            << setw(2) << setfill('0') << minutes << ":"
            << setw(2) << setfill('0') << seconds << endl;
    }

    Time addTime(const Time& other) const {
        int totalSeconds = seconds + other.seconds;
        int totalMinutes = minutes + other.minutes + totalSeconds / 60;
        int totalHours = hours + other.hours + totalMinutes / 60;

        totalSeconds %= 60;
        totalMinutes %= 60;
        totalHours %= 24;

        return Time(totalHours, totalMinutes, totalSeconds);
    }
};

int main() {

    SetConsoleOutputCP(1251);

    try {
       
        Time t1(10, 30, 45); 
        Time t2(15, 75, 10); 

        // Вывод времени
        cout << "Время t1: ";
        t1.printTime();

        cout << "Время t2: ";
        t2.printTime();

        // Сложение времени
        Time t3 = t1.addTime(t2);
        cout << "Сумма t1 и t2: ";
        t3.printTime();
    }
    catch (const TimeException& e) {
        cerr << "Ошибка: " << e.what() << endl;
    }

    return 0;
}