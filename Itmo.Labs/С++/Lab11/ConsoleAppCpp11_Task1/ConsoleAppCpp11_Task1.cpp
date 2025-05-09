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

    void normalize() {
        minutes += seconds / 60;
        seconds %= 60;
        hours += minutes / 60;
        minutes %= 60;
        hours %= 24;
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

    Time operator+(const Time& other) const {
        Time result(hours + other.hours, minutes + other.minutes, seconds + other.seconds);
        result.normalize();
        return result;
    }

    Time operator-(const Time& other) const {
        int totalSeconds1 = hours * 3600 + minutes * 60 + seconds;
        int totalSeconds2 = other.hours * 3600 + other.minutes * 60 + other.seconds;
        int diff = totalSeconds1 - totalSeconds2;

        if (diff < 0) diff += 24 * 3600; 

        int h = diff / 3600;
        int m = (diff % 3600) / 60;
        int s = diff % 60;

        return Time(h, m, s);
    }

    Time operator+(double value) const {
        int totalSeconds = hours * 3600 + minutes * 60 + seconds + static_cast<int>(value * 3600);
        totalSeconds %= 24 * 3600; 

        int h = totalSeconds / 3600;
        int m = (totalSeconds % 3600) / 60;
        int s = totalSeconds % 60;

        return Time(h, m, s);
    }

    friend Time operator+(double value, const Time& t) {
        return t + value; 
    }

    bool operator==(const Time& other) const {
        return hours == other.hours && minutes == other.minutes && seconds == other.seconds;
    }

    bool operator!=(const Time& other) const {
        return !(*this == other);
    }

    bool operator<(const Time& other) const {
        if (hours != other.hours) return hours < other.hours;
        if (minutes != other.minutes) return minutes < other.minutes;
        return seconds < other.seconds;
    }

    bool operator>(const Time& other) const {
        return other < *this;
    }

    bool operator<=(const Time& other) const {
        return !(*this > other);
    }

    bool operator>=(const Time& other) const {
        return !(*this < other);
    }
};

int main() {
    SetConsoleOutputCP(1251);

    try {
        Time t1(4, 23, 55);
        Time t2(7, 11, 4);

        cout << "Время t1: ";
        t1.printTime();

        cout << "Время t2: ";
        t2.printTime();

        Time t3 = t1 + t2;
        cout << "Сумма t1 и t2: ";
        t3.printTime();

        Time t4 = t2 - t1;
        cout << "Разница t2 и t1: ";
        t4.printTime();

        Time t5 = t1 + 1.5; 
        cout << "Сумма t1 и 1.5 часа: ";
        t5.printTime();

        Time t6 = 2.25 + t1; 
        cout << "Сумма 2.25 часа и t1: ";
        t6.printTime();

        if (t1 == t2) {
            cout << "t1 и t2 равны" << endl;
        }
        else {
            cout << "t1 и t2 не равны" << endl;
        }

        if (t1 < t2) {
            cout << "t1 меньше t2" << endl;
        }
        else {
            cout << "t1 не меньше t2" << endl;
        }
    }
    catch (const TimeException& e) {
        cerr << "Ошибка: " << e.what() << endl;
    }

    return 0;
}