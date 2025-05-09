#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

bool isValidSNILS(const string& input) {
    string snils;
    for (char c : input) {
        if (c != ' ' && c != '-') {
            snils += c;
        }
    }

    if (snils.length() != 11) {
        return false;
    }

    for (char c : snils) {
        if (!isdigit(c)) {
            return false;
        }
    }

    for (size_t i = 0; i < 8; i++) {
        if (snils[i] == snils[i + 1] && snils[i] == snils[i + 2]) {
            return false;
        }
    }

    int sum = 0;
    for (int i = 0; i < 9; i++) {
        int digit = snils[i] - '0';
        int position = 9 - i;
        sum += digit * position;
    }

    int controlNumber;
    if (sum < 100) {
        controlNumber = sum;
    }
    else if (sum == 100 || sum == 101) {
        controlNumber = 0;
    }
    else {
        controlNumber = sum % 101;
        if (controlNumber == 100) {
            controlNumber = 0;
        }
    }

    int inputControlNumber = stoi(snils.substr(9, 2));

    return controlNumber == inputControlNumber;
}

int main() {
    system("chcp 1251");
    string snils;
    cout << "Введите номер СНИЛС: ";
    getline(cin, snils);

    if (isValidSNILS(snils)) {
        cout << "Номер СНИЛС валидный." << endl;
    }
    else {
        cout << "Номер СНИЛС невалидный." << endl;
    }

    return 0;
}