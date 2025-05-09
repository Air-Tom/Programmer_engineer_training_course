#include <iostream>
#include <vector>
#include <Windows.h>
#include "human.h"
#include "student.h"
#include "teacher.h"

int main() {
    SetConsoleOutputCP(1251);

    // Создаем вектор указателей на объекты базового класса human
    std::vector<human*> people;

    // Создаем объекты классов student и teacher
    student* stud = new student("Петров", "Иван", "Алексеевич", { 5, 4, 5, 3, 4, 5 });
    teacher* tch = new teacher("Сергеев", "Дмитрий", "Сергеевич", 40);

    // Добавляем объекты в вектор
    people.push_back(stud);
    people.push_back(tch);

    // Полиморфный вызов методов
    for (const auto& person : people) {
        person->print_info(); // Вызов переопределенного метода
        std::cout << "-------------------" << std::endl;
    }

    // Освобождаем память
    for (const auto& person : people) {
        delete person;
    }

    return 0;
}