#include <iostream>
#include <map>
#include <string>
#include <Windows.h>

int main() {
    
    SetConsoleOutputCP(1251);

    std::map<std::string, char> studentGrades;

    studentGrades["Жаров"] = '5';
    studentGrades["Соколов"] = '4';
    studentGrades["Фирсов"] = '3';

    std::cout << "Текущие оценки студентов:" << std::endl;
    for (const auto& entry : studentGrades) {
        std::cout << entry.first << ": " << entry.second << std::endl;
    }

    std::string studentName = "Жаров";
    studentGrades[studentName] = '5'; 

    studentGrades["Куликов"] = '4';

    std::cout << "\nОбновленные оценки студентов:" << std::endl;
    for (const auto& entry : studentGrades) {
        std::cout << entry.first << ": " << entry.second << std::endl;
    }

    std::string searchName = "Фирсов";
    auto it = studentGrades.find(searchName);
    if (it != studentGrades.end()) {
        std::cout << "\nОценка студента " << searchName << ": " << it->second << std::endl;
    }
    else {
        std::cout << "\nСтудент " << searchName << " не найден." << std::endl;
    }

    return 0;
}