#include "human.h"
#include <string>

class teacher : public human {
public:
    // Конструктор класса teacher
    teacher(std::string last_name, std::string name, std::string second_name,
        unsigned int work_time) : human(last_name, name, second_name) {
        this->work_time = work_time;
    }

    // Получение количества учебных часов
    unsigned int get_work_time() const {
        return this->work_time;
    }

    // Переопределение метода print_info
    void print_info() const override {
        std::cout << "Преподаватель: " << get_full_name() << std::endl;
        std::cout << "Количество учебных часов: " << get_work_time() << std::endl;
    }

private:
    unsigned int work_time; // Учебные часы
};