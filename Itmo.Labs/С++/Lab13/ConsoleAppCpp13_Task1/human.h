#include <string>
#include <sstream>
#pragma once /* Защита от двойного подключения заголовочного файла */

class human {
public:
    // Конструктор класса human
    human(std::string last_name, std::string name, std::string second_name)
        : last_name(last_name), name(name), second_name(second_name) {}

    // Виртуальный метод для вывода информации
    virtual void print_info() const {
        std::cout << "ФИО: " << get_full_name() << std::endl;
    }

    // Получение ФИО человека
    std::string get_full_name() const {
        std::ostringstream full_name;
        full_name << last_name << " " << name << " " << second_name;
        return full_name.str();
    }

    // Виртуальный деструктор
    virtual ~human() {}

private:
    std::string name;        // имя
    std::string last_name;   // фамилия
    std::string second_name; // отчество
};